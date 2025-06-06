﻿using PayCom.Blazor.Client.Components;
using PayCom.Blazor.Infrastructure.Api;
using PayCom.Blazor.Infrastructure.Auth;
using PayCom.Shared.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace PayCom.Blazor.Client.Pages.Identity.Users;

public partial class UserProfile
{
    [CascadingParameter]
    protected Task<AuthenticationState> AuthState { get; set; } = default!;
    [Inject]
    protected IAuthorizationService AuthService { get; set; } = default!;
    [Inject]
    protected IApiClient UsersClient { get; set; } = default!;

    [Parameter]
    public string? Id { get; set; }
    [Parameter]
    public string? Title { get; set; }
    [Parameter]
    public string? Description { get; set; }

    private bool _active;
    private bool _emailConfirmed;
    private char _firstLetterOfName;
    private string? _firstName;
    private string? _lastName;
    private string? _phoneNumber;
    private string? _email;
    private Uri? _imageUrl;
    private bool _loaded;
    private bool _canToggleUserStatus;

    private async Task ToggleUserStatus()
    {
        var request = new ToggleUserStatusCommand { ActivateUser = _active, UserId = Id };
        await ApiHelper.ExecuteCallGuardedAsync(() => UsersClient.ToggleUserStatusEndpointAsync(Id!, request), Toast);
        Navigation.NavigateTo("/identity/users");
    }

    [Parameter]
    public string? ImageUrl { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (await ApiHelper.ExecuteCallGuardedAsync(
                () => UsersClient.GetUserEndpointAsync(Id!), Toast, Navigation)
            is UserDetail user)
        {
            _firstName = user.FirstName;
            _lastName = user.LastName;
            _email = user.Email;
            _phoneNumber = user.PhoneNumber;
            _active = user.IsActive;
            _emailConfirmed = user.EmailConfirmed;
            _imageUrl = user.ImageUrl;
            Title = $"{_firstName} {_lastName}'s Profile";
            Description = _email;
            if (_firstName?.Length > 0)
            {
                _firstLetterOfName = _firstName.ToUpperInvariant().FirstOrDefault();
            }
        }

        var state = await AuthState;
        _canToggleUserStatus = await AuthService.HasPermissionAsync(state.User, FshActions.Update, FshResources.Users);
        _loaded = true;
    }
}
