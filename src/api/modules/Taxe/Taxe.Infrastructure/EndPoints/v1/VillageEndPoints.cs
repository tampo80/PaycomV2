using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PayCom.WebApi.Taxe.Application.Villages.Create.v1;
using PayCom.WebApi.Taxe.Application.Villages.Delete.v1;
using PayCom.WebApi.Taxe.Application.Villages.Get.v1;
using PayCom.WebApi.Taxe.Application.Villages.Search.v1;
using PayCom.WebApi.Taxe.Application.Villages.Update.v1;

namespace PayCom.WebApi.Taxe.Infrastructure.EndPoints.v1;

public static class CreateVillageEndPoints
{
    internal static RouteHandlerBuilder MapVillageCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreateVillageCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreateVillageEndPoints))
            .WithSummary("Créer un village")
            .WithDescription("Crée un nouveau village")
            .Produces<CreateVillageResponse>()
            .RequirePermission("Permissions.Villages.Create")
            .MapToApiVersion(1);
    }
}

public static class UpdateVillageEndPoints
{
    internal static RouteHandlerBuilder MapVillageUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdateVillageCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdateVillageEndPoints))
            .WithSummary("Mettre à jour un village")
            .WithDescription("Met à jour les informations d'un village existant")
            .Produces<UpdateVillageResponse>()
            .RequirePermission("Permissions.Villages.Update")
            .MapToApiVersion(1);
    }
}

public static class DeleteVillageEndPoints
{
    internal static RouteHandlerBuilder MapVillageDeleteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                await mediator.Send(new DeleteVillageCommand(id));
                return Results.NoContent();
            })
            .WithName(nameof(DeleteVillageEndPoints))
            .WithSummary("Supprimer un village")
            .WithDescription("Supprime un village du système")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.Villages.Delete")
            .MapToApiVersion(1);
    }
}

public static class GetVillageEndPoints
{
    internal static RouteHandlerBuilder MapVillageGetEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetVillageRequest(id));
                return Results.Ok(response);
            })
            .WithName(nameof(GetVillageEndPoints))
            .WithSummary("Obtenir un village")
            .WithDescription("Récupère les détails d'un village spécifique")
            .Produces<VillageResponse>()
            .RequirePermission("Permissions.Villages.Get")
            .MapToApiVersion(1);
    }
}

public static class SearchVillageEndPoints
{
    internal static RouteHandlerBuilder MapVillageSearchEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async ([FromBody] SearchVillagesCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(SearchVillageEndPoints))
            .WithSummary("Rechercher des villages")
            .WithDescription("Recherche et liste des villages selon les critères spécifiés")
            .Produces<PagedList<VillageResponse>>()
            .RequirePermission("Permissions.Villages.Search")
            .MapToApiVersion(1);
    }
} 
