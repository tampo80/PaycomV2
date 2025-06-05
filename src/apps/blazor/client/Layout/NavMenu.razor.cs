using PayCom.Blazor.Infrastructure.Auth;
using PayCom.Shared.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Security.Claims;

namespace PayCom.Blazor.Client.Layout;

public partial class NavMenu
{
    [CascadingParameter]
    protected Task<AuthenticationState> AuthState { get; set; } = default!;
    [Inject]
    protected IAuthorizationService AuthService { get; set; } = default!;
    [Inject]
    protected IJSRuntime JSRuntime { get; set; } = default!;

    // Permissions générales
    private bool _canViewHangfire;
    private bool _canViewDashboard;
    private bool _canViewRoles;
    private bool _canViewUsers;
    private bool _canViewProducts;
    private bool _canViewBrands;
    private bool _canViewTodos;
    private bool _canViewTenants;
    private bool _canViewAuditTrails;
    private bool _isRootTenant;
    private bool _showCatalogueModule=false;
    
    // Permissions spécifiques au module Taxe
    private bool _canViewContribuables;
    private bool _canViewAgentFiscals;
    private bool _canViewTaxes;
    private bool _canViewObligationsFiscales;
    private bool _canViewRegions;
    private bool _canViewCommunes;
    
    // Rôles spécifiques
    private bool _isAdmin;
    private bool _isAgentFiscal;
    private bool _isContribuable;
    private bool _isAdministrateurFiscal;
    
    // Hiérarchie des rôles
    private bool HasRoleContribuable => _isContribuable || _isAdmin;
    private bool HasRoleAgentFiscal => _isAgentFiscal || _isAdmin;
    private bool HasRoleAdminFiscal => _isAdministrateurFiscal || _isAdmin;
    
    // Groupes de permissions avec hiérarchie
    private bool CanViewAdministrationGroup => _canViewUsers || _canViewRoles || _canViewTenants || _isAdmin;
    private bool CanViewEspaceContribuableGroup => HasRoleContribuable;
    private bool CanViewEspaceAgentFiscalGroup => HasRoleAgentFiscal;
    private bool CanViewAdministrationFiscaleGroup => HasRoleAdminFiscal;
    private bool CanViewParametresSystemeGroup => _canViewCommunes || _canViewRegions || _isAdmin;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await FixChromeBrowserIssues();
    }

    protected override async Task OnParametersSetAsync()
    {
        var user = (await AuthState).User;
        
        // Vérification des rôles de l'utilisateur
        _isAdmin = user.IsInRole(FshRoles.Admin);
        _isAgentFiscal = user.IsInRole(FshRoles.AgentFiscal);
        _isContribuable = user.IsInRole(FshRoles.Contribuable);
        _isAdministrateurFiscal = user.IsInRole(FshRoles.AdministrateurFiscal);

        Console.WriteLine($"Rôles utilisateur - Admin: {_isAdmin}, AgentFiscal: {_isAgentFiscal}, Contribuable: {_isContribuable}, AdministrateurFiscal: {_isAdministrateurFiscal}");
        Console.WriteLine($"HasRoleAgentFiscal: {HasRoleAgentFiscal}, HasRoleContribuable: {HasRoleContribuable}, HasRoleAdminFiscal: {HasRoleAdminFiscal}");
        
        // Permissions générales
        _canViewHangfire = await AuthService.HasPermissionAsync(user, FshActions.View, FshResources.Hangfire);
        _canViewDashboard = await AuthService.HasPermissionAsync(user, FshActions.View, FshResources.Dashboard);
        _canViewRoles = await AuthService.HasPermissionAsync(user, FshActions.View, FshResources.Roles);
        _canViewUsers = await AuthService.HasPermissionAsync(user, FshActions.View, FshResources.Users);
        _canViewProducts = await AuthService.HasPermissionAsync(user, FshActions.View, FshResources.Products);
        _canViewBrands = await AuthService.HasPermissionAsync(user, FshActions.View, FshResources.Brands);
        _canViewTodos = await AuthService.HasPermissionAsync(user, FshActions.View, FshResources.Todos);
        _canViewTenants = await AuthService.HasPermissionAsync(user, FshActions.View, FshResources.Tenants);
        _canViewAuditTrails = await AuthService.HasPermissionAsync(user, FshActions.View, FshResources.AuditTrails);
        
        // Permissions spécifiques au module Taxe avec hiérarchie des rôles
        _canViewContribuables = await AuthService.HasPermissionAsync(user, FshActions.Read, FshResources.Contribuables) || HasRoleAgentFiscal;
        _canViewAgentFiscals = await AuthService.HasPermissionAsync(user, FshActions.View, FshResources.AgentFiscals) || _isAdmin;
        _canViewTaxes = await AuthService.HasPermissionAsync(user, FshActions.Read, FshResources.Taxes) || HasRoleAgentFiscal;
        _canViewObligationsFiscales = await AuthService.HasPermissionAsync(user, FshActions.Read, FshResources.ObligationsFiscales) || HasRoleAgentFiscal || HasRoleContribuable;
        _canViewRegions = await AuthService.HasPermissionAsync(user, FshActions.View, FshResources.Regions) || _isAdmin;
        _canViewCommunes = await AuthService.HasPermissionAsync(user, FshActions.View, FshResources.Communes) || _isAdmin;
        
        // Vérifier si l'utilisateur appartient au tenant racine (administration centrale)
        var tenantClaim = user.FindFirst("tenant");
        _isRootTenant = tenantClaim != null && tenantClaim.Value == "root";
        
        // Déterminer si le module Catalogue doit être affiché
        _showCatalogueModule = false;
    }

    private async Task FixChromeBrowserIssues()
    {
        // Petit délai pour s'assurer que les éléments DOM sont bien chargés
        await Task.Delay(100);
        
        // Injecter un petit script pour corriger les problèmes de clic dans Chrome
        await JSRuntime.InvokeVoidAsync("eval", @"
            setTimeout(function() {
                var navGroups = document.querySelectorAll('.mud-nav-group');
                navGroups.forEach(function(group) {
                    group.addEventListener('click', function(e) {
                        if (e.target.classList.contains('mud-nav-group-title') || 
                            e.target.parentElement.classList.contains('mud-nav-group-title')) {
                            e.stopPropagation();
                            var header = e.currentTarget.querySelector('.mud-nav-group-header');
                            if (header) {
                                header.click();
                            }
                        }
                    });
                });
            }, 500);
        ");
    }
}
