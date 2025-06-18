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
using PayCom.WebApi.Taxe.Application.Paiements.CreateByAgent.v1;
using PayCom.WebApi.Taxe.Application.Paiements.SearchByContribuable.v1;
using PayCom.WebApi.Taxe.Application.Paiements.SearchByAgentFiscal.v1;
using PayCom.WebApi.Taxe.Application.TransactionPaiements.Get.v1;
using PayCom.WebApi.Taxe.Application.TransactionPaiements.SearchByAgent.v1;


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

public static class CreatePaiementByAgentEndPoints
{
    internal static RouteHandlerBuilder MapPaiementByAgentCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/by-agent", async (CreatePaiementByAgentCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreatePaiementByAgentEndPoints))
            .WithSummary("Enregistrer un paiement par agent")
            .WithDescription("Permet à un agent fiscal d'enregistrer un paiement de taxe")
            .Produces<CreatePaiementResponse>()
            .RequirePermission("Permissions.Paiements.CreateByAgent")
            .MapToApiVersion(1);
    }
}

public static class SearchTransactionsByAgentEndPoints
{
    internal static RouteHandlerBuilder MapTransactionsByAgentSearchEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/transactions/search-by-agent", async ([FromBody] SearchTransactionsByAgentCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(SearchTransactionsByAgentEndPoints))
            .WithSummary("Rechercher les transactions par agent")
            .WithDescription("Recherche les transactions de paiement traitées par un agent fiscal")
            .Produces<PagedList<TransactionPaiementResponse>>()
            .RequirePermission("Permissions.TransactionsPaiements.SearchByAgent")
            .MapToApiVersion(1);
    }
}

public static class SearchPaiementsByContribuableEndPoints
{
    internal static RouteHandlerBuilder MapPaiementSearchByContribuableEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search-by-contribuable", async ([FromBody] SearchPaiementsByContribuableCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(SearchPaiementsByContribuableEndPoints))
            .WithSummary("Rechercher des paiements par contribuable")
            .WithDescription("Recherche et liste les paiements d'un contribuable spécifique selon les critères")
            .Produces<PagedList<PaiementResponse>>()
            .RequirePermission("Permissions.Paiements.Search")
            .MapToApiVersion(1);
    }
}

public static class SearchPaiementsByAgentFiscalEndPoints
{
    internal static RouteHandlerBuilder MapPaiementSearchByAgentFiscalEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search-by-agent", async ([FromBody] SearchPaiementsByAgentFiscalCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(SearchPaiementsByAgentFiscalEndPoints))
            .WithSummary("Rechercher des paiements par agent fiscal")
            .WithDescription("Recherche et liste les paiements traités par un agent fiscal spécifique selon les critères")
            .Produces<PagedList<PaiementResponse>>()
            .RequirePermission("Permissions.Paiements.Search")
            .MapToApiVersion(1);
    }
} 
