using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PayCom.WebApi.Taxe.Application.TransactionCollectes.Create.v1;
using PayCom.WebApi.Taxe.Application.TransactionCollectes.Delete.v1;
using PayCom.WebApi.Taxe.Application.TransactionCollectes.Get.v1;
using PayCom.WebApi.Taxe.Application.TransactionCollectes.Search.v1;
using PayCom.WebApi.Taxe.Application.TransactionCollectes.Update.v1;
using PayCom.WebApi.Taxe.Application.TransactionCollectes.Synchroniser.v1;

namespace PayCom.WebApi.Taxe.Infrastructure.EndPoints.v1;

public static class CreateTransactionCollecteEndPoints
{
    internal static RouteHandlerBuilder MapTransactionCollecteCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreateTransactionCollecteCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreateTransactionCollecteEndPoints))
            .WithSummary("Créer une transaction de collecte")
            .WithDescription("Crée une nouvelle transaction de collecte de taxe")
            .Produces<CreateTransactionCollecteResponse>()
            .RequirePermission("Permissions.TransactionsCollecte.Create")
            .MapToApiVersion(1);
    }
}

public static class UpdateTransactionCollecteEndPoints
{
    internal static RouteHandlerBuilder MapTransactionCollecteUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdateTransactionCollecteCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdateTransactionCollecteEndPoints))
            .WithSummary("Mettre à jour une transaction de collecte")
            .WithDescription("Met à jour les informations d'une transaction de collecte existante")
            .Produces<UpdateTransactionCollecteResponse>()
            .RequirePermission("Permissions.TransactionsCollecte.Update")
            .MapToApiVersion(1);
    }
}

public static class DeleteTransactionCollecteEndPoints
{
    internal static RouteHandlerBuilder MapTransactionCollecteDeleteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                await mediator.Send(new DeleteTransactionCollecteCommand(id));
                return Results.NoContent();
            })
            .WithName(nameof(DeleteTransactionCollecteEndPoints))
            .WithSummary("Supprimer une transaction de collecte")
            .WithDescription("Supprime une transaction de collecte du système")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.TransactionsCollecte.Delete")
            .MapToApiVersion(1);
    }
}

public static class GetTransactionCollecteEndPoints
{
    internal static RouteHandlerBuilder MapTransactionCollecteGetEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetTransactionCollecteRequest(id));
                return Results.Ok(response);
            })
            .WithName(nameof(GetTransactionCollecteEndPoints))
            .WithSummary("Obtenir une transaction de collecte")
            .WithDescription("Récupère les détails d'une transaction de collecte spécifique")
            .Produces<TransactionCollecteResponse>()
            .RequirePermission("Permissions.TransactionsCollecte.Get")
            .MapToApiVersion(1);
    }
}

public static class SearchTransactionCollecteEndPoints
{
    internal static RouteHandlerBuilder MapTransactionCollecteSearchEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async ([FromBody] SearchTransactionCollectesCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(SearchTransactionCollecteEndPoints))
            .WithSummary("Rechercher des transactions de collecte")
            .WithDescription("Recherche et liste les transactions de collecte selon les critères spécifiés")
            .Produces<PagedList<TransactionCollecteResponse>>()
            .RequirePermission("Permissions.TransactionsCollecte.Search")
            .MapToApiVersion(1);
    }
}

public static class SynchroniserTransactionEndPoints
{
    internal static RouteHandlerBuilder MapSynchroniserTransactionEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPatch("/{id:guid}/synchroniser", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new SynchroniserTransactionCommand(id));
                return Results.Ok(response);
            })
            .WithName(nameof(SynchroniserTransactionEndPoints))
            .WithSummary("Synchroniser une transaction")
            .WithDescription("Synchronise une transaction de collecte avec le système central")
            .Produces<SynchroniserTransactionResponse>()
            .RequirePermission("Permissions.TransactionsCollecte.Synchroniser")
            .MapToApiVersion(1);
    }
} 
