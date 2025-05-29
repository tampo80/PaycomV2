using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PayCom.WebApi.Taxe.Application.Villes.Create.v1;
using PayCom.WebApi.Taxe.Application.Villes.Delete.v1;
using PayCom.WebApi.Taxe.Application.Villes.Get.v1;
using PayCom.WebApi.Taxe.Application.Villes.Search.v1;
using PayCom.WebApi.Taxe.Application.Villes.Update.v1;
using VilleResponse = PayCom.WebApi.Taxe.Application.Villes.Get.v1.VilleResponse;

namespace PayCom.WebApi.Taxe.Infrastructure.EndPoints.v1;

public static class CreateVilleEndPoints
{
    internal static RouteHandlerBuilder MapVilleCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreateVilleCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreateVilleEndPoints))
            .WithSummary("Créer une ville")
            .WithDescription("Crée une nouvelle ville")
            .Produces<CreateVilleResponse>()
            .RequirePermission("Permissions.Villes.Create")
            .MapToApiVersion(1);
    }
}

public static class UpdateVilleEndPoints
{
    internal static RouteHandlerBuilder MapVilleUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdateVilleCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdateVilleEndPoints))
            .WithSummary("Mettre à jour une ville")
            .WithDescription("Met à jour les informations d'une ville existante")
            .Produces<UpdateVilleResponse>()
            .RequirePermission("Permissions.Villes.Update")
            .MapToApiVersion(1);
    }
}

public static class DeleteVilleEndPoints
{
    internal static RouteHandlerBuilder MapVilleDeleteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                await mediator.Send(new DeleteVilleCommand(id));
                return Results.NoContent();
            })
            .WithName(nameof(DeleteVilleEndPoints))
            .WithSummary("Supprimer une ville")
            .WithDescription("Supprime une ville du système")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.Villes.Delete")
            .MapToApiVersion(1);
    }
}

public static class GetVilleEndPoints
{
    internal static RouteHandlerBuilder MapVilleGetEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetVilleRequest(id));
                return Results.Ok(response);
            })
            .WithName(nameof(GetVilleEndPoints))
            .WithSummary("Obtenir une ville")
            .WithDescription("Récupère les détails d'une ville spécifique")
            .Produces<VilleResponse>()
            .RequirePermission("Permissions.Villes.Get")
            .MapToApiVersion(1);
    }
}

public static class SearchVilleEndPoints
{
    internal static RouteHandlerBuilder MapVilleSearchEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async ([FromBody] SearchVillesCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(SearchVilleEndPoints))
            .WithSummary("Rechercher des villes")
            .WithDescription("Recherche et liste des villes selon les critères spécifiés")
            .Produces<PagedList<VilleResponse>>()
            .RequirePermission("Permissions.Villes.Search")
            .MapToApiVersion(1);
    }
} 
