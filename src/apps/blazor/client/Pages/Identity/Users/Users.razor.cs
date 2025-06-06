﻿using PayCom.Blazor.Client.Components.EntityTable;
using PayCom.Blazor.Infrastructure.Api;
using PayCom.Blazor.Infrastructure.Auth;
using PayCom.Shared.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

namespace PayCom.Blazor.Client.Pages.Identity.Users;

public partial class Users
{
    [CascadingParameter]
    protected Task<AuthenticationState> AuthState { get; set; } = default!;
    [Inject]
    protected IAuthorizationService AuthService { get; set; } = default!;

    [Inject]
    protected IApiClient UsersClient { get; set; } = default!;

    protected EntityClientTableContext<UserDetail, Guid, RegisterUserCommand> Context { get; set; } = default!;

    private bool _canExportUsers;
    private bool _canViewAuditTrails;
    private bool _canViewRoles;

    // Fields for editform
    protected string Password { get; set; } = string.Empty;
    protected string ConfirmPassword { get; set; } = string.Empty;

    private bool _passwordVisibility;
    private InputType _passwordInput = InputType.Password;
    private string _passwordInputIcon = Icons.Material.Filled.VisibilityOff;

    protected override async Task OnInitializedAsync()
    {
        var user = (await AuthState).User;
        _canExportUsers = await AuthService.HasPermissionAsync(user, FshActions.Export, FshResources.Users);
        _canViewRoles = await AuthService.HasPermissionAsync(user, FshActions.View, FshResources.UserRoles);
        _canViewAuditTrails = await AuthService.HasPermissionAsync(user, FshActions.View, FshResources.AuditTrails);

        Context = new(
            entityName: "User",
            entityNamePlural: "Users",
            entityResource: FshResources.Users,
            searchAction: FshActions.View,
            updateAction: string.Empty,
            deleteAction: string.Empty,
            fields: new()
            {
                new(user => user.FirstName,"Nom"),
                new(user => user.LastName, "Prénom(s)"),
                new(user => user.UserName, "UserName"),
                new(user => user.Email, "Email"),
                new(user => user.PhoneNumber, "N° Téléphone"),
                new(user => user.EmailConfirmed, "Email Confirmation", Type: typeof(bool)),
                new(user => user.IsActive, "Activé", Type: typeof(bool))
            },
            idFunc: user => user.Id,
            loadDataFunc: async () => (await UsersClient.GetUsersListEndpointAsync()).ToList(),
            searchFunc: (searchString, user) =>
                string.IsNullOrWhiteSpace(searchString)
                    || user.FirstName?.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true
                    || user.LastName?.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true
                    || user.Email?.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true
                    || user.PhoneNumber?.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true
                    || user.UserName?.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true,
            createFunc: user => UsersClient.RegisterUserEndpointAsync(user),
            hasExtraActionsFunc: () => true,
            exportAction: string.Empty);
    }

    private void ViewProfile(in Guid userId) =>
        Navigation.NavigateTo($"/identity/users/{userId}/profile");

    private void ManageRoles(in Guid userId) =>
        Navigation.NavigateTo($"/identity/users/{userId}/roles");
    private void ViewAuditTrails(in Guid userId) =>
        Navigation.NavigateTo($"/identity/users/{userId}/audit-trail");

    private void TogglePasswordVisibility()
    {
        if (_passwordVisibility)
        {
            _passwordVisibility = false;
            _passwordInputIcon = Icons.Material.Filled.VisibilityOff;
            _passwordInput = InputType.Password;
        }
        else
        {
            _passwordVisibility = true;
            _passwordInputIcon = Icons.Material.Filled.Visibility;
            _passwordInput = InputType.Text;
        }

        Context.AddEditModal.ForceRender();
    }
}
