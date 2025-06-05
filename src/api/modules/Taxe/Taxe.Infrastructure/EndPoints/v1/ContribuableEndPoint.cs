using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PayCom.WebApi.Taxe.Application.Contribuables.Create.v1;
using PayCom.WebApi.Taxe.Application.Contribuables.Delete.v1;
using PayCom.WebApi.Taxe.Application.Contribuables.Get.v1;
using PayCom.WebApi.Taxe.Application.Contribuables.Search.v1;
using PayCom.WebApi.Taxe.Application.Contribuables.Update.v1;
using PayCom.WebApi.Taxe.Application.Contribuables.AssocierUtilisateur.v1;
using PayCom.WebApi.Taxe.Application.Contribuables.AssocierAgentFiscal.v1;
using PayCom.WebApi.Taxe.Application.Contribuables.GetByUserId.v1;
using PayCom.WebApi.Taxe.Application.Contribuables.DissocierUtilisateur.v1;

namespace PayCom.WebApi.Taxe.Infrastructure.EndPoints.v1;

public static class CreateContribuableEndPoints
{
    internal static RouteHandlerBuilder MapContribuableCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreateContribuableCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreateContribuableEndPoints))
            .WithSummary("creates a Contribuable")
            .WithDescription("creates a Contribuable")
            .Produces<CreateContribuableResponse>()
            .RequirePermission("Permissions.Contribuables.Create")
            .MapToApiVersion(1);
    }
}

public static class UpdateContribuableEndPoints
{
    internal static RouteHandlerBuilder MapContribuableUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdateContribuableCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdateContribuableEndPoints))
            .WithSummary("updates a Contribuable")
            .WithDescription("updates a Contribuable")
            .Produces<UpdateContribuableResponse>()
            .RequirePermission("Permissions.Contribuables.Update")
            .MapToApiVersion(1);
    }
}

public static class DeleteContribuableEndPoints
{
    internal static RouteHandlerBuilder MapContribuableDeleteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                await mediator.Send(new DeleteContribuableCommand( id ));
                return Results.NoContent();
            })
            .WithName(nameof(DeleteContribuableEndPoints))
            .WithSummary("deletes a Contribuable")
            .WithDescription("deletes a Contribuable")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.Contribuables.Delete")
            .MapToApiVersion(1);
    }
}

public static class GetContribuableEndPoints
{
    internal static RouteHandlerBuilder MapContribuableGetEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetContribuableRequest(id));
                return Results.Ok(response);
            })
            .WithName(nameof(GetContribuableEndPoints))
            .WithSummary("gets a Contribuable")
            .WithDescription("gets a Contribuable")
            .Produces<ContribuableResponse>()
            .RequirePermission("Permissions.Contribuables.Read")
            .MapToApiVersion(1);
    }
}

public static class SearchContribuableEndPoints
{
    internal static RouteHandlerBuilder MapContribuableSearchEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async ( [FromBody] SearchContribuableCommand command, ISender mediator) =>
            {
                var response = await mediator.Send(command);
                return Results.Ok(response);
            })
            .WithName(nameof(SearchContribuableEndPoints))
            .WithSummary("searches for Contribuables")
            .WithDescription("searches for Contribuables")
            .Produces<PagedList<ContribuableResponse>>()
            .RequirePermission("Permissions.Contribuables.Read")
            .MapToApiVersion(1);
    }
}

public static class AssocierUtilisateurContribuableEndPoints
{
    internal static RouteHandlerBuilder MapAssocierUtilisateurContribuableEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/{contribuableId:guid}/utilisateurs/{utilisateurId:guid}", async (Guid contribuableId, Guid utilisateurId, ISender mediator) =>
            {
                var response = await mediator.Send(new AssocierUtilisateurContribuableCommand(contribuableId, utilisateurId));
                return Results.Ok(response);
            })
            .WithName(nameof(AssocierUtilisateurContribuableEndPoints))
            .WithSummary("Associer un utilisateur à un contribuable")
            .WithDescription("Associe un compte utilisateur à un contribuable pour permettre la connexion")
            .Produces<AssocierUtilisateurContribuableResponse>()
            .RequirePermission("Permissions.Contribuables.Manage")
            .MapToApiVersion(1);
    }
}

public static class AssocierAgentFiscalContribuableEndPoints
{
    internal static RouteHandlerBuilder MapAssocierAgentFiscalContribuableEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/{contribuableId:guid}/agents/{agentFiscalId:guid}", async (Guid contribuableId, Guid agentFiscalId, ISender mediator) =>
            {
                var response = await mediator.Send(new AssocierAgentFiscalContribuableCommand(contribuableId, agentFiscalId));
                return Results.Ok(response);
            })
            .WithName(nameof(AssocierAgentFiscalContribuableEndPoints))
            .WithSummary("Associer un agent fiscal à un contribuable")
            .WithDescription("Associe un agent fiscal à un contribuable pour la gestion fiscale")
            .Produces<AssocierAgentFiscalContribuableResponse>()
            .RequirePermission("Permissions.Contribuables.Manage")
            .MapToApiVersion(1);
    }
}

public static class GetContribuableByUserIdEndPoints
{
    internal static RouteHandlerBuilder MapContribuableGetByUserIdEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/utilisateur/{userId:guid}", async (Guid userId, ISender mediator) =>
            {
                var response = await mediator.Send(new GetContribuableByUserIdRequest(userId));
                return Results.Ok(response);
            })
            .WithName(nameof(GetContribuableByUserIdEndPoints))
            .WithSummary("Récupère un contribuable par son ID utilisateur")
            .WithDescription("Recherche et retourne un contribuable associé à l'ID utilisateur spécifié")
            .Produces<ContribuableResponse>()
            .RequirePermission("Permissions.Contribuables.Read")
            .MapToApiVersion(1);
    }
}

public static class DissocierUtilisateurContribuableEndPoints
{
    internal static RouteHandlerBuilder MapDissocierUtilisateurContribuableEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/{id:guid}/dissocier-utilisateur", async (Guid id, ISender mediator) =>
            {
                var command = new DissocierUtilisateurContribuableCommand(id);
                var result = await mediator.Send(command);

                if (!result.Succeeded)
                {
                    return Results.BadRequest(new { detail = result.Message });
                }

                return Results.Ok(result);
            })
            .WithName(nameof(DissocierUtilisateurContribuableEndPoints))
            .WithSummary("Dissocier un utilisateur d'un contribuable")
            .WithDescription("Permet de dissocier un compte utilisateur d'un contribuable")
            .Produces<DissocierUtilisateurContribuableResponse>()
            .RequirePermission("Permissions.Contribuables.Manage")
            .MapToApiVersion(1);
    }
}
