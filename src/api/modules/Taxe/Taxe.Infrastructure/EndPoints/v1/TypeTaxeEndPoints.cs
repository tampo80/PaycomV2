using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PayCom.WebApi.Taxe.Application.TypeTaxes.Create.v1;
using PayCom.WebApi.Taxe.Application.TypeTaxes.Delete.v1;
using PayCom.WebApi.Taxe.Application.TypeTaxes.Get.v1;
using PayCom.WebApi.Taxe.Application.TypeTaxes.Search.v1;
using PayCom.WebApi.Taxe.Application.TypeTaxes.Update.v1;

namespace PayCom.WebApi.Taxe.Infrastructure.EndPoints.v1;

public static class CreateTypeTaxeEndPoints
{
    internal static RouteHandlerBuilder MapTypeTaxeCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreateTypeTaxeCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreateTypeTaxeEndPoints))
            .WithSummary("Créer un type de taxe")
            .WithDescription("Crée un nouveau type de taxe dans le système")
            .Produces<CreateTypeTaxeResponse>()
            .RequirePermission("Permissions.TypesTaxe.Create")
            .MapToApiVersion(1);
    }
}

public static class UpdateTypeTaxeEndPoints
{
    internal static RouteHandlerBuilder MapTypeTaxeUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdateTypeTaxeCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdateTypeTaxeEndPoints))
            .WithSummary("Mettre à jour un type de taxe")
            .WithDescription("Met à jour les informations d'un type de taxe existant")
            .Produces<UpdateTypeTaxeResponse>()
            .RequirePermission("Permissions.TypesTaxe.Update")
            .MapToApiVersion(1);
    }
}

public static class DeleteTypeTaxeEndPoints
{
    internal static RouteHandlerBuilder MapTypeTaxeDeleteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                await mediator.Send(new DeleteTypeTaxeCommand(id));
                return Results.NoContent();
            })
            .WithName(nameof(DeleteTypeTaxeEndPoints))
            .WithSummary("Supprimer un type de taxe")
            .WithDescription("Supprime un type de taxe du système")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.TypesTaxe.Delete")
            .MapToApiVersion(1);
    }
}

public static class GetTypeTaxeEndPoints
{
    internal static RouteHandlerBuilder MapTypeTaxeGetEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetTypeTaxeRequest(id));
                return Results.Ok(response);
            })
            .WithName(nameof(GetTypeTaxeEndPoints))
            .WithSummary("Obtenir un type de taxe")
            .WithDescription("Récupère les détails d'un type de taxe spécifique")
            .Produces<TypeTaxeResponse>()
            .RequirePermission("Permissions.TypesTaxe.Get")
            .MapToApiVersion(1);
    }
}

public static class SearchTypeTaxeEndPoints
{
    internal static RouteHandlerBuilder MapTypeTaxeSearchEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async ([FromBody] SearchTypeTaxesCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(SearchTypeTaxeEndPoints))
            .WithSummary("Rechercher des types de taxe")
            .WithDescription("Recherche et liste les types de taxe selon les critères spécifiés")
            .Produces<PagedList<TypeTaxeResponse>>()
            .RequirePermission("Permissions.TypesTaxe.Search")
            .MapToApiVersion(1);
    }
} 
