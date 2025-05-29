using Finbuckle.MultiTenant.Abstractions;
using FSH.Framework.Core.Origin;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Infrastructure.Identity.RoleClaims;
using FSH.Framework.Infrastructure.Identity.Roles;
using FSH.Framework.Infrastructure.Identity.Users;
using FSH.Framework.Infrastructure.Tenant;
using PayCom.Shared.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using IdentityConstants = PayCom.Shared.Authorization.IdentityConstants;

namespace FSH.Framework.Infrastructure.Identity.Persistence;
internal sealed class IdentityDbInitializer(
    ILogger<IdentityDbInitializer> logger,
    IdentityDbContext context,
    RoleManager<FshRole> roleManager,
    UserManager<FshUser> userManager,
    TimeProvider timeProvider,
    IMultiTenantContextAccessor<FshTenantInfo> multiTenantContextAccessor,
    IOptions<OriginOptions> originSettings) : IDbInitializer
{
    public async Task MigrateAsync(CancellationToken cancellationToken)
    {
        if ((await context.Database.GetPendingMigrationsAsync(cancellationToken).ConfigureAwait(false)).Any())
        {
            await context.Database.MigrateAsync(cancellationToken).ConfigureAwait(false);
            logger.LogInformation("[{Tenant}] applied database migrations for identity module", context.TenantInfo?.Identifier);
        }
    }

    public async Task SeedAsync(CancellationToken cancellationToken)
    {
        await SeedRolesAsync();
        await SeedAdminUserAsync();
    }

    private async Task SeedRolesAsync()
    {
        // Créer ou récupérer tous les rôles
        var roles = new Dictionary<string, FshRole>();
        
        foreach (string roleName in FshRoles.DefaultRoles)
        {
            if (await roleManager.Roles.SingleOrDefaultAsync(r => r.Name == roleName)
                is not FshRole role)
            {
                // create role
                role = new FshRole(roleName, $"{roleName} Role for {multiTenantContextAccessor.MultiTenantContext.TenantInfo?.Id} Tenant");
                await roleManager.CreateAsync(role);
            }
            
            roles[roleName] = role;
        }

        // Assigner les permissions de base au rôle Basic
        if (roles.TryGetValue(FshRoles.Basic, out var basicRole))
        {
            await AssignPermissionsToRoleAsync(context, FshPermissions.Basic, basicRole);
        }
        
        // Assigner les permissions spécifiques au rôle Contribuable
        if (roles.TryGetValue(FshRoles.Contribuable, out var contribuableRole))
        {
            var contribuablePermissions = FshPermissions.All
                .Where(p => 
                    p.Resource == FshResources.ObligationsFiscales || 
                    p.Resource == FshResources.Contribuables && p.Action == FshActions.View ||
                    p.Resource == FshResources.Dashboard && p.Action == FshActions.View)
                .ToList();
                
            await AssignPermissionsToRoleAsync(context, contribuablePermissions, contribuableRole);
        }
        
        // Assigner les permissions spécifiques au rôle Agent Fiscal
        if (roles.TryGetValue(FshRoles.AgentFiscal, out var agentFiscalRole))
        {
            var agentFiscalPermissions = FshPermissions.All
                .Where(p => 
                    p.Resource == FshResources.Contribuables ||
                    p.Resource == FshResources.ObligationsFiscales ||
                    p.Resource == FshResources.Taxes ||
                    p.Resource == FshResources.Dashboard && p.Action == FshActions.View)
                .ToList();
                
            await AssignPermissionsToRoleAsync(context, agentFiscalPermissions, agentFiscalRole);
        }
        
        // Assigner toutes les permissions au rôle Admin (sauf celles de Root)
        if (roles.TryGetValue(FshRoles.Admin, out var adminRole))
        {
            // L'administrateur hérite toutes les permissions non-root
            await AssignPermissionsToRoleAsync(context, FshPermissions.Admin, adminRole);
            
            // Si c'est le tenant root, ajouter aussi les permissions root
            if (multiTenantContextAccessor.MultiTenantContext.TenantInfo?.Id == TenantConstants.Root.Id)
            {
                await AssignPermissionsToRoleAsync(context, FshPermissions.Root, adminRole);
            }
        }
    }

    private async Task AssignPermissionsToRoleAsync(IdentityDbContext dbContext, IReadOnlyList<FshPermission> permissions, FshRole role)
    {
        var currentClaims = await roleManager.GetClaimsAsync(role);
        var newClaims = permissions
            .Where(permission => !currentClaims.Any(c => c.Type == FshClaims.Permission && c.Value == permission.Name))
            .Select(permission => new FshRoleClaim
            {
                RoleId = role.Id,
                ClaimType = FshClaims.Permission,
                ClaimValue = permission.Name,
                CreatedBy = "application",
                CreatedOn = timeProvider.GetUtcNow()
            })
            .ToList();

        foreach (var claim in newClaims)
        {
            logger.LogInformation("Seeding {Role} Permission '{Permission}' for '{TenantId}' Tenant.", role.Name, claim.ClaimValue, multiTenantContextAccessor.MultiTenantContext.TenantInfo?.Id);
            await dbContext.RoleClaims.AddAsync(claim);
        }

        // Save changes to the database context
        if (newClaims.Count != 0)
        {
            await dbContext.SaveChangesAsync();
        }

    }

    private async Task SeedAdminUserAsync()
    {
        if (string.IsNullOrWhiteSpace(multiTenantContextAccessor.MultiTenantContext.TenantInfo?.Id) || string.IsNullOrWhiteSpace(multiTenantContextAccessor.MultiTenantContext.TenantInfo?.AdminEmail))
        {
            return;
        }

        if (await userManager.Users.FirstOrDefaultAsync(u => u.Email == multiTenantContextAccessor.MultiTenantContext.TenantInfo!.AdminEmail)
            is not FshUser adminUser)
        {
            string adminUserName = $"{multiTenantContextAccessor.MultiTenantContext.TenantInfo?.Id.Trim()}.{FshRoles.Admin}".ToUpperInvariant();
            adminUser = new FshUser
            {
                FirstName = multiTenantContextAccessor.MultiTenantContext.TenantInfo?.Id.Trim().ToUpperInvariant(),
                LastName = FshRoles.Admin,
                Email = multiTenantContextAccessor.MultiTenantContext.TenantInfo?.AdminEmail,
                UserName = adminUserName,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                NormalizedEmail = multiTenantContextAccessor.MultiTenantContext.TenantInfo?.AdminEmail!.ToUpperInvariant(),
                NormalizedUserName = adminUserName.ToUpperInvariant(),
                ImageUrl = new Uri(originSettings.Value.OriginUrl! + TenantConstants.Root.DefaultProfilePicture),
                IsActive = true
            };

            logger.LogInformation("Seeding Default Admin User for '{TenantId}' Tenant.", multiTenantContextAccessor.MultiTenantContext.TenantInfo?.Id);
            var password = new PasswordHasher<FshUser>();
            adminUser.PasswordHash = password.HashPassword(adminUser, TenantConstants.DefaultPassword);
            await userManager.CreateAsync(adminUser);
        }

        // Assigner les rôles à l'utilisateur Admin
        if (!await userManager.IsInRoleAsync(adminUser, FshRoles.Admin))
        {
            logger.LogInformation("Assigning Admin Role to Admin User for '{TenantId}' Tenant.", multiTenantContextAccessor.MultiTenantContext.TenantInfo?.Id);
            await userManager.AddToRoleAsync(adminUser, FshRoles.Admin);
        }
        
        // Assigner également les rôles Contribuable et AgentFiscal à l'utilisateur Admin
        if (!await userManager.IsInRoleAsync(adminUser, FshRoles.Contribuable))
        {
            logger.LogInformation("Assigning Contribuable Role to Admin User for '{TenantId}' Tenant.", multiTenantContextAccessor.MultiTenantContext.TenantInfo?.Id);
            await userManager.AddToRoleAsync(adminUser, FshRoles.Contribuable);
        }
        
        if (!await userManager.IsInRoleAsync(adminUser, FshRoles.AgentFiscal))
        {
            logger.LogInformation("Assigning AgentFiscal Role to Admin User for '{TenantId}' Tenant.", multiTenantContextAccessor.MultiTenantContext.TenantInfo?.Id);
            await userManager.AddToRoleAsync(adminUser, FshRoles.AgentFiscal);
        }
    }
}
