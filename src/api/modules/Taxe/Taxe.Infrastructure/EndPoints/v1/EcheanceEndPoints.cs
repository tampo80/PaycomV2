using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PayCom.WebApi.Taxe.Application.Echeances.Create.v1;
using PayCom.WebApi.Taxe.Application.Echeances.Delete.v1;
using PayCom.WebApi.Taxe.Application.Echeances.Get.v1;
using PayCom.WebApi.Taxe.Application.Echeances.Search.v1;
using PayCom.WebApi.Taxe.Application.Echeances.Update.v1;
using PayCom.WebApi.Taxe.Application.Echeances.CalculerMontant.v1;
using PayCom.WebApi.Taxe.Application.Echeances.AppliquerPenalite.v1;

namespace PayCom.WebApi.Taxe.Infrastructure.EndPoints.v1;

public static class CreateEcheanceEndPoints
{
    internal static RouteHandlerBuilder MapEcheanceCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreateEcheanceCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreateEcheanceEndPoints))
            .WithSummary("Créer une échéance")
            .WithDescription("Crée une nouvelle échéance de paiement pour une obligation fiscale")
            .Produces<CreateEcheanceResponse>()
            .RequirePermission("Permissions.Echeances.Create")
            .MapToApiVersion(1);
    }
}

public static class UpdateEcheanceEndPoints
{
    internal static RouteHandlerBuilder MapEcheanceUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdateEcheanceCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdateEcheanceEndPoints))
            .WithSummary("Mettre à jour une échéance")
            .WithDescription("Met à jour les informations d'une échéance existante")
            .Produces<UpdateEcheanceResponse>()
            .RequirePermission("Permissions.Echeances.Update")
            .MapToApiVersion(1);
    }
}

public static class DeleteEcheanceEndPoints
{
    internal static RouteHandlerBuilder MapEcheanceDeleteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                await mediator.Send(new DeleteEcheanceCommand(id));
                return Results.NoContent();
            })
            .WithName(nameof(DeleteEcheanceEndPoints))
            .WithSummary("Supprimer une échéance")
            .WithDescription("Supprime une échéance du système")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.Echeances.Delete")
            .MapToApiVersion(1);
    }
}

public static class GetEcheanceEndPoints
{
    internal static RouteHandlerBuilder MapEcheanceGetEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetEcheanceRequest(id));
                return Results.Ok(response);
            })
            .WithName(nameof(GetEcheanceEndPoints))
            .WithSummary("Obtenir une échéance")
            .WithDescription("Récupère les détails d'une échéance spécifique")
            .Produces<EcheanceResponse>()
            .RequirePermission("Permissions.Echeances.Get")
            .MapToApiVersion(1);
    }
}

public static class SearchEcheanceEndPoints
{
    internal static RouteHandlerBuilder MapEcheanceSearchEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async ([FromBody] SearchEcheancesCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(SearchEcheanceEndPoints))
            .WithSummary("Rechercher des échéances")
            .WithDescription("Recherche et liste les échéances selon les critères spécifiés")
            .Produces<PagedList<EcheanceResponse>>()
            .RequirePermission("Permissions.Echeances.Search")
            .MapToApiVersion(1);
    }
}

public static class CalculerMontantEcheanceEndPoints
{
    internal static RouteHandlerBuilder MapCalculerMontantEcheanceEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPatch("/{id:guid}/calculer-montant", async (Guid id, [FromBody] CalculerMontantEcheanceCommand request, ISender mediator) =>
            {
                if (id != request.EcheanceId) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CalculerMontantEcheanceEndPoints))
            .WithSummary("Calculer le montant d'une échéance")
            .WithDescription("Calcule le montant dû pour une échéance spécifique")
            .Produces<CalculerMontantEcheanceResponse>()
            .RequirePermission("Permissions.Echeances.Gerer")
            .MapToApiVersion(1);
    }
}

public static class AppliquerPenaliteEndPoints
{
    internal static RouteHandlerBuilder MapAppliquerPenaliteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPatch("/{id:guid}/appliquer-penalite", async (Guid id, [FromBody] AppliquerPenaliteCommand request, ISender mediator) =>
            {
                if (id != request.EcheanceId) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(AppliquerPenaliteEndPoints))
            .WithSummary("Appliquer une pénalité à une échéance")
            .WithDescription("Applique une pénalité au montant d'une échéance spécifique")
            .Produces<AppliquerPenaliteResponse>()
            .RequirePermission("Permissions.Echeances.AppliquerPenalites")
            .MapToApiVersion(1);
    }
} 
