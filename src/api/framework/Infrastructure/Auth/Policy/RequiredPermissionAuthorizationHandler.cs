﻿using FSH.Framework.Core.Identity.Users.Abstractions;
using PayCom.Shared.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace FSH.Framework.Infrastructure.Auth.Policy;
public sealed class RequiredPermissionAuthorizationHandler(IUserService userService) : AuthorizationHandler<PermissionAuthorizationRequirement>
{
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionAuthorizationRequirement requirement)
    {
        var endpoint = context.Resource switch
        {
            HttpContext httpContext => httpContext.GetEndpoint(),
            Endpoint ep => ep,
            _ => null,
        };

        var requiredPermissions = endpoint?.Metadata.GetMetadata<IRequiredPermissionMetadata>()?.RequiredPermissions;
        if (requiredPermissions == null || !requiredPermissions.Any())
        {
            // there are no permission requirements set by the endpoint
            // hence, authorize requests
            context.Succeed(requirement);
            return;
        }
        
        if (context.User?.GetUserId() is { } userId)
        {
            // Vérifier si l'utilisateur a au moins une des permissions requises (OR logique)
            foreach (var permission in requiredPermissions)
            {
                if (await userService.HasPermissionAsync(userId, permission))
                {
                    context.Succeed(requirement);
                    return; // Sortir dès qu'une permission est validée
                }
            }
        }
    }
}
