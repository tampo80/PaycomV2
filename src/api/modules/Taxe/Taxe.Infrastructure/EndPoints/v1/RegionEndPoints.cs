using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PayCom.WebApi.Taxe.Application.Regions.Create.v1;
using PayCom.WebApi.Taxe.Application.Regions.Delete.v1;
using PayCom.WebApi.Taxe.Application.Regions.Get.v1;
using PayCom.WebApi.Taxe.Application.Regions.Search.v1;
using PayCom.WebApi.Taxe.Application.Regions.Update.v1;
using RegionResponse = PayCom.WebApi.Taxe.Application.Regions.Get.v1.RegionResponse;


namespace PayCom.WebApi.Taxe.Infrastructure.EndPoints.v1;

public static class CreateRegionEndPoints
{
    internal static RouteHandlerBuilder MapRegionCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreateRegionCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreateRegionEndPoints))
            .WithSummary("Créer une région")
            .WithDescription("Crée une nouvelle région administrative")
            .Produces<CreateRegionResponse>()
            .RequirePermission("Permissions.Regions.Create")
            .MapToApiVersion(1);
    }
}

public static class UpdateRegionEndPoints
{
    internal static RouteHandlerBuilder MapRegionUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdateRegionCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdateRegionEndPoints))
            .WithSummary("Mettre à jour une région")
            .WithDescription("Met à jour les informations d'une région existante")
            .Produces<UpdateRegionResponse>()
            .RequirePermission("Permissions.Regions.Update")
            .MapToApiVersion(1);
    }
}

public static class DeleteRegionEndPoints
{
    internal static RouteHandlerBuilder MapRegionDeleteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                await mediator.Send(new DeleteRegionCommand(id));
                return Results.NoContent();
            })
            .WithName(nameof(DeleteRegionEndPoints))
            .WithSummary("Supprimer une région")
            .WithDescription("Supprime une région du système")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.Regions.Delete")
            .MapToApiVersion(1);
    }
}

public static class GetRegionEndPoints
{
    internal static RouteHandlerBuilder MapRegionGetEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetRegionRequest(id));
                return Results.Ok(response);
            })
            .WithName(nameof(GetRegionEndPoints))
            .WithSummary("Obtenir une région")
            .WithDescription("Récupère les détails d'une région spécifique")
            .Produces<RegionResponse>()
            .RequirePermission("Permissions.Regions.Get")
            .MapToApiVersion(1);
    }
}

public static class SearchRegionEndPoints
{
    internal static RouteHandlerBuilder MapRegionSearchEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async ([FromBody] SearchRegionsCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(SearchRegionEndPoints))
            .WithSummary("Rechercher des régions")
            .WithDescription("Recherche et liste des régions selon les critères spécifiés")
            .Produces<PagedList<RegionResponse>>()
            .RequirePermission("Permissions.Regions.Search")
            .MapToApiVersion(1);
    }
} 
