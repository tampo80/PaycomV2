﻿using PayCom.Blazor.Client.Components.EntityTable;
using PayCom.Blazor.Infrastructure.Api;
using PayCom.Blazor.Infrastructure.Auth;
using PayCom.Shared.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace PayCom.Blazor.Client.Pages.Identity.Roles;

public partial class Roles
{
    [CascadingParameter]
    protected Task<AuthenticationState> AuthState { get; set; } = default!;
    [Inject]
    protected IAuthorizationService AuthService { get; set; } = default!;
    [Inject]
    private IApiClient RolesClient { get; set; } = default!;

    protected EntityClientTableContext<RoleDto, string?, CreateOrUpdateRoleCommand> Context { get; set; } = default!;

    private bool _canViewRoleClaims;

    protected override async Task OnInitializedAsync()
    {
        var state = await AuthState;
        _canViewRoleClaims = await AuthService.HasPermissionAsync(state.User, FshActions.View, FshResources.RoleClaims);

        Context = new(
            entityName: "Role",
            entityNamePlural: "Roles",
            entityResource: FshResources.Roles,
            searchAction: FshActions.View,
            fields: new()
            {
                new(role => role.Id, "Id"),
                new(role => role.Name,"Name"),
                new(role => role.Description, "Description")
            },
            idFunc: role => role.Id,
            loadDataFunc: async () => (await RolesClient.GetRolesEndpointAsync()).ToList(),
            searchFunc: (searchString, role) =>
                string.IsNullOrWhiteSpace(searchString)
                    || role.Name?.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true
                    || role.Description?.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true,
            createFunc: async role => await RolesClient.CreateOrUpdateRoleEndpointAsync(role),
            updateFunc: async (_, role) => await RolesClient.CreateOrUpdateRoleEndpointAsync(role),
            deleteFunc: async id => await RolesClient.DeleteRoleEndpointAsync(id!),
            hasExtraActionsFunc: () => _canViewRoleClaims,
            canUpdateEntityFunc: e => !FshRoles.IsDefault(e.Name!),
            canDeleteEntityFunc: e => !FshRoles.IsDefault(e.Name!),
            exportAction: string.Empty);
    }

    private void ManagePermissions(string? roleId)
    {
        ArgumentNullException.ThrowIfNull(roleId, nameof(roleId));
        Navigation.NavigateTo($"/identity/roles/{roleId}/permissions");
    }
}
