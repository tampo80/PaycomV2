﻿using PayCom.Blazor.Client.Components;
using PayCom.Blazor.Infrastructure.Api;
using PayCom.Blazor.Infrastructure.Auth;
using PayCom.Shared.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace PayCom.Blazor.Client.Pages.Identity.Users;

public partial class UserRoles
{
    [Parameter]
    public string? Id { get; set; }
    [CascadingParameter]
    protected Task<AuthenticationState> AuthState { get; set; } = default!;
    [Inject]
    protected IAuthorizationService AuthService { get; set; } = default!;
    [Inject]
    protected IApiClient UsersClient { get; set; } = default!;

    private List<UserRoleDetail> _userRolesList = default!;

    private string _title = string.Empty;
    private string _description = string.Empty;

    private string _searchString = string.Empty;

    private bool _canEditUsers;
    private bool _canSearchRoles;
    private bool _loaded;

    protected override async Task OnInitializedAsync()
    {
        var state = await AuthState;

        _canEditUsers = await AuthService.HasPermissionAsync(state.User, FshActions.Update, FshResources.Users);
        _canSearchRoles = await AuthService.HasPermissionAsync(state.User, FshActions.View, FshResources.UserRoles);

        if (await ApiHelper.ExecuteCallGuardedAsync(
                () => UsersClient.GetUserEndpointAsync(Id!), Toast, Navigation)
            is UserDetail user)
        {
            _title = $"{user.FirstName} {user.LastName}'s Roles";
            _description = string.Format("Gérer {0} less Roles", user.FirstName, user.LastName);

            if (await ApiHelper.ExecuteCallGuardedAsync(
                    () => UsersClient.GetUserRolesEndpointAsync(user.Id.ToString()), Toast, Navigation)
                is ICollection<UserRoleDetail> response)
            {
                _userRolesList = response.ToList();
            }
        }

        _loaded = true;
    }

    private async Task SaveAsync()
    {
        var request = new AssignUserRoleCommand()
        {
            UserRoles = _userRolesList
        };

        Console.WriteLine($"roles : {request.UserRoles.Count}");

        await ApiHelper.ExecuteCallGuardedAsync(
                () => UsersClient.AssignRolesToUserEndpointAsync(Id, request),
                Toast,
                successMessage: "Le rôle de l'utilisateur a été mis à jour avec succès");

        Navigation.NavigateTo("/identity/users");
    }

    private bool Search(UserRoleDetail userRole) =>
        string.IsNullOrWhiteSpace(_searchString)
            || userRole.RoleName?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) is true;
}
