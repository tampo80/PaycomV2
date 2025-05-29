using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PayCom.WebApi.Taxe.Application.Penalites.Create.v1;
using PayCom.WebApi.Taxe.Application.Penalites.Delete.v1;
using PayCom.WebApi.Taxe.Application.Penalites.Get.v1;
using PayCom.WebApi.Taxe.Application.Penalites.Search.v1;
using PayCom.WebApi.Taxe.Application.Penalites.Update.v1;

namespace PayCom.WebApi.Taxe.Infrastructure.EndPoints.v1;

public static class CreatePenaliteEndPoints
{
    internal static RouteHandlerBuilder MapPenaliteCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreatePenaliteCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreatePenaliteEndPoints))
            .WithSummary("Créer une pénalité")
            .WithDescription("Crée une nouvelle pénalité")
            .Produces<CreatePenaliteResponse>()
            .RequirePermission("Permissions.Penalites.Create")
            .MapToApiVersion(1);
    }
}

public static class UpdatePenaliteEndPoints
{
    internal static RouteHandlerBuilder MapPenaliteUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdatePenaliteCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdatePenaliteEndPoints))
            .WithSummary("Mettre à jour une pénalité")
            .WithDescription("Met à jour les informations d'une pénalité existante")
            .Produces<UpdatePenaliteResponse>()
            .RequirePermission("Permissions.Penalites.Update")
            .MapToApiVersion(1);
    }
}

public static class DeletePenaliteEndPoints
{
    internal static RouteHandlerBuilder MapPenaliteDeleteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                await mediator.Send(new DeletePenaliteCommand(id));
                return Results.NoContent();
            })
            .WithName(nameof(DeletePenaliteEndPoints))
            .WithSummary("Supprimer une pénalité")
            .WithDescription("Supprime une pénalité du système")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.Penalites.Delete")
            .MapToApiVersion(1);
    }
}

public static class GetPenaliteEndPoints
{
    internal static RouteHandlerBuilder MapPenaliteGetEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetPenaliteRequest(id));
                return Results.Ok(response);
            })
            .WithName(nameof(GetPenaliteEndPoints))
            .WithSummary("Obtenir une pénalité")
            .WithDescription("Récupère les détails d'une pénalité spécifique")
            .Produces<PenaliteResponse>()
            .RequirePermission("Permissions.Penalites.Get")
            .MapToApiVersion(1);
    }
}

public static class SearchPenaliteEndPoints
{
    internal static RouteHandlerBuilder MapPenaliteSearchEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async ([FromBody] SearchPenalitesCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(SearchPenaliteEndPoints))
            .WithSummary("Rechercher des pénalités")
            .WithDescription("Recherche et liste les pénalités selon les critères spécifiés")
            .Produces<PagedList<PenaliteResponse>>()
            .RequirePermission("Permissions.Penalites.Search")
            .MapToApiVersion(1);
    }
} 
