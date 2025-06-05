using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PayCom.WebApi.Taxe.Application.AgentFiscals.Create.v1;
using PayCom.WebApi.Taxe.Application.AgentFiscals.Delete.v1;
using PayCom.WebApi.Taxe.Application.AgentFiscals.Get.v1;
using PayCom.WebApi.Taxe.Application.AgentFiscals.Search.v1;
using PayCom.WebApi.Taxe.Application.AgentFiscals.Update.v1;
using PayCom.WebApi.Taxe.Application.AgentFiscals.AssocierUtilisateur.v1;
using PayCom.WebApi.Taxe.Application.AgentFiscals.GetByUserId.v1;

namespace PayCom.WebApi.Taxe.Infrastructure.EndPoints.v1;

public static class CreateAgentFiscalEndPoints
{
   internal static RouteHandlerBuilder MapAgentFiscalCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreateAgentFiscalCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreateAgentFiscalEndPoints))
            .WithSummary("créer un Agent Fiscal")
            .WithDescription("créer un Agent Fiscal")
            .Produces<CreateAgentFiscalResponse>()
            .RequirePermission("Permissions.AgentFiscals.Create")
            .MapToApiVersion(1);
    }
}

public static class UpdateAgentFiscalEndPoints
{
    internal static RouteHandlerBuilder MapAgentFiscalUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id,UpdateAgentFiscalCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdateAgentFiscalEndPoints))
            .WithSummary("updates a AgentFiscal")
            .WithDescription("updates a AgentFiscal")
            .Produces<UpdateAgentFiscalResponse>()
            .RequirePermission("Permissions.AgentFiscals.Update")
            .MapToApiVersion(1);
    }
}

public static class DeleteAgentFiscalEndPoints
{
    internal static RouteHandlerBuilder MapAgentFiscalDeleteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id,  ISender mediator) =>
            {
                await mediator.Send(new DeleteAgentFiscalCommand(id));
                return Results.NoContent();
            })
            .WithName(nameof(DeleteAgentFiscalEndPoints))
            .WithSummary("supprimer l'AgentFiscal")
            .WithDescription("supprimer l'AgentFiscal")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.AgentFiscals.Delete")
            .MapToApiVersion(1);
    }
}

public static class GetAgentFiscalEndPoints
{
    internal static RouteHandlerBuilder MapAgentFiscalGetEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetAgentFiscalRequest(id));
                return Results.Ok(response);
            })
            .WithName(nameof(GetAgentFiscalEndPoints))
            .WithSummary("gets a AgentFiscal")
            .WithDescription("gets a AgentFiscal")
            .Produces<AgentFiscalResponse>()
            .RequirePermission("Permissions.AgentFiscals.Get")
            .MapToApiVersion(1);
    }
}

public static class SearchAgentFiscalEndPoints
{
    internal static RouteHandlerBuilder MapAgentFiscalSearchEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async ([FromBody] SearchAgenFiscalsCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(SearchAgentFiscalEndPoints))
            .WithSummary("searches a AgentFiscal")
            .WithDescription("searches a AgentFiscal")
            .Produces<PagedList<AgentFiscalResponse>>()
            .RequirePermission("Permissions.AgentFiscals.Search")
            .MapToApiVersion(1);
    }
}

public static class AssocierUtilisateurAgentEndPoints
{
    internal static RouteHandlerBuilder MapAssocierUtilisateurAgentEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/{agentId:guid}/utilisateurs/{utilisateurId:guid}", async (Guid agentId, Guid utilisateurId, ISender mediator) =>
            {
                var response = await mediator.Send(new AssocierUtilisateurAgentCommand(agentId, utilisateurId));
                return Results.Ok(response);
            })
            .WithName(nameof(AssocierUtilisateurAgentEndPoints))
            .WithSummary("Associer un utilisateur à un agent fiscal")
            .WithDescription("Associe un compte utilisateur à un agent fiscal pour permettre la connexion")
            .Produces<AssocierUtilisateurAgentResponse>()
            .RequirePermission("Permissions.AgentFiscals.GererUtilisateurs")
            .MapToApiVersion(1);
    }
}

public static class GetAgentFiscalByUserIdEndPoints
{
    internal static RouteHandlerBuilder MapAgentFiscalGetByUserIdEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/utilisateur/{userId:guid}", async (Guid userId, ISender mediator) =>
            {
                var response = await mediator.Send(new GetAgentFiscalByUserIdRequest(userId));
                return Results.Ok(response);
            })
            .WithName(nameof(GetAgentFiscalByUserIdEndPoints))
            .WithSummary("Récupère un agent fiscal par son ID utilisateur")
            .WithDescription("Recherche et retourne un agent fiscal associé à l'ID utilisateur spécifié")
            .Produces<AgentFiscalResponse>()
            .RequirePermission("Permissions.AgentFiscals.View")
            .MapToApiVersion(1);
    }
}
