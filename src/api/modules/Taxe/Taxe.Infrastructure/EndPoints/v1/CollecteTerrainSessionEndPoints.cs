using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PayCom.WebApi.Taxe.Application.CollecteTerrainSessions.Create.v1;
using PayCom.WebApi.Taxe.Application.CollecteTerrainSessions.Delete.v1;
using PayCom.WebApi.Taxe.Application.CollecteTerrainSessions.Get.v1;
using PayCom.WebApi.Taxe.Application.CollecteTerrainSessions.Search.v1;
using PayCom.WebApi.Taxe.Application.CollecteTerrainSessions.Update.v1;
using PayCom.WebApi.Taxe.Application.CollecteTerrainSessions.Demarrer.v1;
using PayCom.WebApi.Taxe.Application.CollecteTerrainSessions.Cloturer.v1;
using PayCom.WebApi.Taxe.Application.CollecteTerrainSessions.Stop.v1;
using PayCom.WebApi.Taxe.Application.CollecteTerrainSessions.GenerateReport.v1;
using PayCom.WebApi.Taxe.Application.CollecteTerrainSessions.GetTransactions.v1;

namespace PayCom.WebApi.Taxe.Infrastructure.EndPoints.v1;

public static class CreateCollecteTerrainSessionEndPoints
{
    internal static RouteHandlerBuilder MapCollecteTerrainSessionCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreateCollecteTerrainSessionCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreateCollecteTerrainSessionEndPoints))
            .WithSummary("Créer une session de collecte terrain")
            .WithDescription("Crée une nouvelle session de collecte terrain dans le système")
            .Produces<CreateCollecteTerrainSessionResponse>()
            .RequirePermission("Permissions.CollecteTerrainSessions.Create")
            .MapToApiVersion(1);
    }
}

public static class UpdateCollecteTerrainSessionEndPoints
{
    internal static RouteHandlerBuilder MapCollecteTerrainSessionUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdateCollecteTerrainSessionCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdateCollecteTerrainSessionEndPoints))
            .WithSummary("Mettre à jour une session de collecte terrain")
            .WithDescription("Met à jour les informations d'une session de collecte terrain existante")
            .Produces<UpdateCollecteTerrainSessionResponse>()
            .RequirePermission("Permissions.CollecteTerrainSessions.Update")
            .MapToApiVersion(1);
    }
}

public static class DeleteCollecteTerrainSessionEndPoints
{
    internal static RouteHandlerBuilder MapCollecteTerrainSessionDeleteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                await mediator.Send(new DeleteCollecteTerrainSessionCommand(id));
                return Results.NoContent();
            })
            .WithName(nameof(DeleteCollecteTerrainSessionEndPoints))
            .WithSummary("Supprimer une session de collecte terrain")
            .WithDescription("Supprime une session de collecte terrain du système")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.CollecteTerrainSessions.Delete")
            .MapToApiVersion(1);
    }
}

public static class GetCollecteTerrainSessionEndPoints
{
    internal static RouteHandlerBuilder MapCollecteTerrainSessionGetEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetCollecteTerrainSessionRequest(id));
                return Results.Ok(response);
            })
            .WithName(nameof(GetCollecteTerrainSessionEndPoints))
            .WithSummary("Obtenir une session de collecte terrain")
            .WithDescription("Récupère les détails d'une session de collecte terrain spécifique")
            .Produces<CollecteTerrainSessionResponse>()
            .RequirePermission("Permissions.CollecteTerrainSessions.Get")
            .MapToApiVersion(1);
    }
}

public static class SearchCollecteTerrainSessionEndPoints
{
    internal static RouteHandlerBuilder MapCollecteTerrainSessionSearchEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async ([FromBody] SearchCollecteTerrainSessionsCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(SearchCollecteTerrainSessionEndPoints))
            .WithSummary("Rechercher des sessions de collecte terrain")
            .WithDescription("Recherche et liste les sessions de collecte terrain selon les critères spécifiés")
            .Produces<PagedList<CollecteTerrainSessionResponse>>()
            .RequirePermission("Permissions.CollecteTerrainSessions.Search")
            .MapToApiVersion(1);
    }
}

public static class DemarrerSessionEndPoints
{
    internal static RouteHandlerBuilder MapDemarrerSessionEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/{id:guid}/demarrer", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new DemarrerSessionCommand(id));
                return Results.Ok(response);
            })
            .WithName(nameof(DemarrerSessionEndPoints))
            .WithSummary("Démarrer une session de collecte")
            .WithDescription("Démarre une session de collecte terrain")
            .Produces<DemarrerSessionResponse>()
            .RequirePermission("Permissions.CollecteTerrainSessions.Demarrer")
            .MapToApiVersion(1);
    }
}

public static class CloturerSessionEndPoints
{
    internal static RouteHandlerBuilder MapCloturerSessionEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/{id:guid}/cloturer", async (Guid id, ISender mediator) =>
            {
                var command = new CloturerSessionCommand { SessionId = id };
                var response = await mediator.Send(command);
                return Results.Ok(response);
            })
            .WithName(nameof(CloturerSessionEndPoints))
            .WithSummary("Clôturer une session de collecte")
            .WithDescription("Clôture une session de collecte terrain")
            .Produces<CloturerSessionResponse>()
            .RequirePermission("Permissions.CollecteTerrainSessions.Cloturer")
            .MapToApiVersion(1);
    }
}

public static class StopCollecteTerrainSessionEndPoints
{
    internal static RouteHandlerBuilder MapStopCollecteTerrainSessionEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/{id:guid}/stop", async (Guid id, [FromBody] StopCollecteTerrainSessionCommand command, ISender mediator) =>
            {
                command.SessionId = id;
                var response = await mediator.Send(command);
                return Results.Ok(response);
            })
            .WithName(nameof(StopCollecteTerrainSessionEndPoints))
            .WithSummary("Arrêter une session de collecte")
            .WithDescription("Arrête une session de collecte terrain en cours")
            .Produces<StopCollecteTerrainSessionResponse>()
            .RequirePermission("Permissions.CollecteTerrainSessions.Stop")
            .MapToApiVersion(1);
    }
}

public static class GenerateCollecteReportEndPoints
{
    internal static RouteHandlerBuilder MapGenerateCollecteReportEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/rapports", async ([FromBody] GenerateCollecteReportCommand command, ISender mediator) =>
            {
                var response = await mediator.Send(command);
                return Results.File(
                    response.Content,
                    response.ContentType,
                    response.FileName
                );
            })
            .WithName(nameof(GenerateCollecteReportEndPoints))
            .WithSummary("Générer un rapport de collecte")
            .WithDescription("Génère un rapport détaillé des collectes pour une période donnée")
            .Produces<byte[]>()
            .RequirePermission("Permissions.CollecteTerrainSessions.GenerateReport")
            .MapToApiVersion(1);
    }
}

public static class GetCollecteTerrainSessionTransactionsEndPoints
{
    public static void MapGetCollecteTerrainSessionTransactionsEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/v1/collecte-terrain-sessions/{id}/transactions", async (
            Guid id,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var command = new GetCollecteTerrainSessionTransactionsCommand { SessionId = id };
            var result = await sender.Send(command, cancellationToken);
            return Results.Ok(result);
        })
        .WithName("GetCollecteTerrainSessionTransactions")
        .WithTags("CollecteTerrainSessions")
        .WithSummary("Récupère les transactions d'une session de collecte")
        .WithDescription("Récupère la liste des transactions associées à une session de collecte")
        .Produces<GetCollecteTerrainSessionTransactionsResponse>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .RequireAuthorization("CollecteTerrainSessions.Read")
        .MapToApiVersion(1);
    }
} 
