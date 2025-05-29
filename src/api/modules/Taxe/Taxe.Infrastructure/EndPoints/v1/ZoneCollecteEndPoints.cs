using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PayCom.WebApi.Taxe.Application.ZoneCollectes.Create.v1;
using PayCom.WebApi.Taxe.Application.ZoneCollectes.Delete.v1;
using PayCom.WebApi.Taxe.Application.ZoneCollectes.Get.v1;
using PayCom.WebApi.Taxe.Application.ZoneCollectes.Search.v1;
using PayCom.WebApi.Taxe.Application.ZoneCollectes.Update.v1;
using PayCom.WebApi.Taxe.Application.ZoneCollectes.AssignerAgent.v1;
using PayCom.WebApi.Taxe.Application.ZoneCollectes.DesassignerAgent.v1;

namespace PayCom.WebApi.Taxe.Infrastructure.EndPoints.v1;

public static class CreateZoneCollecteEndPoints
{
    internal static RouteHandlerBuilder MapZoneCollecteCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreateZoneCollecteCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreateZoneCollecteEndPoints))
            .WithSummary("Créer une zone de collecte")
            .WithDescription("Crée une nouvelle zone de collecte dans le système")
            .Produces<CreateZoneCollecteResponse>()
            .RequirePermission("Permissions.ZonesCollecte.Create")
            .MapToApiVersion(1);
    }
}

public static class UpdateZoneCollecteEndPoints
{
    internal static RouteHandlerBuilder MapZoneCollecteUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdateZoneCollecteCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdateZoneCollecteEndPoints))
            .WithSummary("Mettre à jour une zone de collecte")
            .WithDescription("Met à jour les informations d'une zone de collecte existante")
            .Produces<UpdateZoneCollecteResponse>()
            .RequirePermission("Permissions.ZonesCollecte.Update")
            .MapToApiVersion(1);
    }
}

public static class DeleteZoneCollecteEndPoints
{
    internal static RouteHandlerBuilder MapZoneCollecteDeleteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                await mediator.Send(new DeleteZoneCollecteCommand(id));
                return Results.NoContent();
            })
            .WithName(nameof(DeleteZoneCollecteEndPoints))
            .WithSummary("Supprimer une zone de collecte")
            .WithDescription("Supprime une zone de collecte du système")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.ZonesCollecte.Delete")
            .MapToApiVersion(1);
    }
}

public static class GetZoneCollecteEndPoints
{
    internal static RouteHandlerBuilder MapZoneCollecteGetEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetZoneCollecteRequest(id));
                return Results.Ok(response);
            })
            .WithName(nameof(GetZoneCollecteEndPoints))
            .WithSummary("Obtenir une zone de collecte")
            .WithDescription("Récupère les détails d'une zone de collecte spécifique")
            .Produces<ZoneCollecteResponse>()
            .RequirePermission("Permissions.ZonesCollecte.Get")
            .MapToApiVersion(1);
    }
}

public static class SearchZoneCollecteEndPoints
{
    internal static RouteHandlerBuilder MapZoneCollecteSearchEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async ([FromBody] SearchZoneCollectesCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(SearchZoneCollecteEndPoints))
            .WithSummary("Rechercher des zones de collecte")
            .WithDescription("Recherche et liste les zones de collecte selon les critères spécifiés")
            .Produces<PagedList<ZoneCollecteResponse>>()
            .RequirePermission("Permissions.ZonesCollecte.Search")
            .MapToApiVersion(1);
    }
}

public static class AssignerAgentZoneEndPoints
{
    internal static RouteHandlerBuilder MapAssignerAgentZoneEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/{zoneId:guid}/agents/{agentId:guid}", async (Guid zoneId, Guid agentId, ISender mediator) =>
            {
                var response = await mediator.Send(new AssignerAgentZoneCommand(zoneId, agentId));
                return Results.Ok(response);
            })
            .WithName(nameof(AssignerAgentZoneEndPoints))
            .WithSummary("Assigner un agent à une zone")
            .WithDescription("Assigne un agent fiscal à une zone de collecte spécifique")
            .Produces<AssignerAgentZoneResponse>()
            .RequirePermission("Permissions.ZonesCollecte.GererAgents")
            .MapToApiVersion(1);
    }
}

public static class DesassignerAgentZoneEndPoints
{
    internal static RouteHandlerBuilder MapDesassignerAgentZoneEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{zoneId:guid}/agents/{agentId:guid}", async (Guid zoneId, Guid agentId, ISender mediator) =>
            {
                await mediator.Send(new DesassignerAgentZoneCommand(zoneId, agentId));
                return Results.NoContent();
            })
            .WithName(nameof(DesassignerAgentZoneEndPoints))
            .WithSummary("Désassigner un agent d'une zone")
            .WithDescription("Retire un agent fiscal d'une zone de collecte spécifique")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.ZonesCollecte.GererAgents")
            .MapToApiVersion(1);
    }
} 
