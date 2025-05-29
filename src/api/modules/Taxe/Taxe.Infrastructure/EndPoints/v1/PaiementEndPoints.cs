using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PayCom.WebApi.Taxe.Application.Paiements.Create.v1;
using PayCom.WebApi.Taxe.Application.Paiements.Delete.v1;
using PayCom.WebApi.Taxe.Application.Paiements.Get.v1;
using PayCom.WebApi.Taxe.Application.Paiements.Search.v1;
using PayCom.WebApi.Taxe.Application.Paiements.Update.v1;

namespace PayCom.WebApi.Taxe.Infrastructure.EndPoints.v1;

public static class CreatePaiementEndPoints
{
    internal static RouteHandlerBuilder MapPaiementCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreatePaiementCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreatePaiementEndPoints))
            .WithSummary("Créer un paiement")
            .WithDescription("Crée un nouveau paiement dans le système")
            .Produces<CreatePaiementResponse>()
            .RequirePermission("Permissions.Paiements.Create")
            .MapToApiVersion(1);
    }
}

public static class UpdatePaiementEndPoints
{
    internal static RouteHandlerBuilder MapPaiementUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdatePaiementCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdatePaiementEndPoints))
            .WithSummary("Mettre à jour un paiement")
            .WithDescription("Met à jour les informations d'un paiement existant")
            .Produces<UpdatePaiementResponse>()
            .RequirePermission("Permissions.Paiements.Update")
            .MapToApiVersion(1);
    }
}

public static class DeletePaiementEndPoints
{
    internal static RouteHandlerBuilder MapPaiementDeleteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                await mediator.Send(new DeletePaiementCommand(id));
                return Results.NoContent();
            })
            .WithName(nameof(DeletePaiementEndPoints))
            .WithSummary("Supprimer un paiement")
            .WithDescription("Supprime un paiement du système")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.Paiements.Delete")
            .MapToApiVersion(1);
    }
}

public static class GetPaiementEndPoints
{
    internal static RouteHandlerBuilder MapPaiementGetEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetPaiementRequest(id));
                return Results.Ok(response);
            })
            .WithName(nameof(GetPaiementEndPoints))
            .WithSummary("Obtenir un paiement")
            .WithDescription("Récupère les détails d'un paiement spécifique")
            .Produces<PaiementResponse>()
            .RequirePermission("Permissions.Paiements.Get")
            .MapToApiVersion(1);
    }
}

public static class SearchPaiementEndPoints
{
    internal static RouteHandlerBuilder MapPaiementSearchEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async ([FromBody] SearchPaiementsCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(SearchPaiementEndPoints))
            .WithSummary("Rechercher des paiements")
            .WithDescription("Recherche et liste les paiements selon les critères spécifiés")
            .Produces<PagedList<PaiementResponse>>()
            .RequirePermission("Permissions.Paiements.Search")
            .MapToApiVersion(1);
    }
} 
