using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PayCom.WebApi.Taxe.Application.Taxes.Create.v1;
using PayCom.WebApi.Taxe.Application.Taxes.Delete.v1;
using PayCom.WebApi.Taxe.Application.Taxes.Get.v1;
using PayCom.WebApi.Taxe.Application.Taxes.Search.v1;
using PayCom.WebApi.Taxe.Application.Taxes.Update.v1;

namespace PayCom.WebApi.Taxe.Infrastructure.EndPoints.v1;

public static class CreateTaxeEndPoints
{
    internal static RouteHandlerBuilder MapTaxeCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreateTaxeCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreateTaxeEndPoints))
            .WithSummary("Créer une taxe")
            .WithDescription("Crée une nouvelle taxe dans le système")
            .Produces<CreateTaxeResponse>()
            .RequirePermission("Permissions.Taxes.Create")
            .MapToApiVersion(1);
    }
}

public static class UpdateTaxeEndPoints
{
    internal static RouteHandlerBuilder MapTaxeUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdateTaxeCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdateTaxeEndPoints))
            .WithSummary("Mettre à jour une taxe")
            .WithDescription("Met à jour les informations d'une taxe existante")
            .Produces<UpdateTaxeResponse>()
            .RequirePermission("Permissions.Taxes.Update")
            .MapToApiVersion(1);
    }
}

public static class DeleteTaxeEndPoints
{
    internal static RouteHandlerBuilder MapTaxeDeleteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                await mediator.Send(new DeleteTaxeCommand(id));
                return Results.NoContent();
            })
            .WithName(nameof(DeleteTaxeEndPoints))
            .WithSummary("Supprimer une taxe")
            .WithDescription("Supprime une taxe du système")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.Taxes.Delete")
            .MapToApiVersion(1);
    }
}

public static class GetTaxeEndPoints
{
    internal static RouteHandlerBuilder MapTaxeGetEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetTaxeRequest { Id = id });
                return Results.Ok(response);
            })
            .WithName(nameof(GetTaxeEndPoints))
            .WithSummary("Obtenir une taxe")
            .WithDescription("Récupère les détails d'une taxe spécifique")
            .Produces<TaxeResponse>()
            .RequirePermission("Permissions.Taxes.View")
            .MapToApiVersion(1);
    }
}

public static class SearchTaxeEndPoints
{
    internal static RouteHandlerBuilder MapTaxeSearchEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async ([FromBody] SearchTaxeCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(SearchTaxeEndPoints))
            .WithSummary("Rechercher des taxes")
            .WithDescription("Recherche et liste les taxes selon les critères spécifiés")
            .Produces<PagedList<TaxeResponse>>()
            .RequirePermission("Permissions.Taxes.Search")
            .MapToApiVersion(1);
    }
} 
