﻿using PayCom.Blazor.Infrastructure.Preferences;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace PayCom.Blazor.Client.Layout;

public partial class MainLayout
{
    [Parameter]
    public RenderFragment ChildContent { get; set; } = default!;
    [Parameter]
    public EventCallback<bool> OnDarkModeToggle { get; set; }
    [Parameter]
    public EventCallback<bool> OnRightToLeftToggle { get; set; }

    private bool _drawerOpen;
    private bool _isDarkMode;

    protected override async Task OnInitializedAsync()
    {
        if (await ClientPreferences.GetPreference() is ClientPreference preferences)
        {
            _drawerOpen = preferences.IsDrawerOpen;
            _isDarkMode = preferences.IsDarkMode;
        }
    }

    public async Task ToggleDarkMode()
    {
        _isDarkMode = !_isDarkMode;
        await OnDarkModeToggle.InvokeAsync(_isDarkMode);
    }

    private async Task DrawerToggle()
    {
        _drawerOpen = await ClientPreferences.ToggleDrawerAsync();
    }
    private void Logout()
    {
        var parameters = new DialogParameters
        {
                { nameof(Components.Dialogs.Logout.ContentText), "Vous êtes sûr de vouloir vous déconnecter ?"},
                { nameof(Components.Dialogs.Logout.ButtonText), "Déconnexion"},
                { nameof(Components.Dialogs.Logout.Color), Color.Error}
            };

        var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true };
        DialogService.Show<Components.Dialogs.Logout>("Déconnexion", parameters, options);
    }

    private void Profile()
    {
        Navigation.NavigateTo("/identity/account");
    }
}
