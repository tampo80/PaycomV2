using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PayCom.WebApi.Taxe.Application.ObligationFiscales.Create.v1;
using PayCom.WebApi.Taxe.Application.ObligationFiscales.Delete.v1;
using PayCom.WebApi.Taxe.Application.ObligationFiscales.Get.v1;
using PayCom.WebApi.Taxe.Application.ObligationFiscales.Search.v1;
using PayCom.WebApi.Taxe.Application.ObligationFiscales.Update.v1;
using PayCom.WebApi.Taxe.Application.ObligationFiscales.Desactiver.v1;
using PayCom.WebApi.Taxe.Application.ObligationFiscales.Reactiver.v1;
using PayCom.WebApi.Taxe.Application.ObligationFiscales.GenererEcheances.v1;
using PayCom.WebApi.Taxe.Application.ObligationFiscales.GetByContribuable.v1;

namespace PayCom.WebApi.Taxe.Infrastructure.EndPoints.v1;

public static class CreateObligationFiscaleEndPoints
{
    internal static RouteHandlerBuilder MapObligationFiscaleCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreateObligationFiscaleCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreateObligationFiscaleEndPoints))
            .WithSummary("Créer une obligation fiscale")
            .WithDescription("Crée une nouvelle obligation fiscale pour un contribuable")
            .Produces<CreateObligationFiscaleResponse>()
            .RequirePermission("Permissions.ObligationsFiscales.Create")
            .MapToApiVersion(1);
    }
}

public static class UpdateObligationFiscaleEndPoints
{
    internal static RouteHandlerBuilder MapObligationFiscaleUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdateObligationFiscaleCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdateObligationFiscaleEndPoints))
            .WithSummary("Mettre à jour une obligation fiscale")
            .WithDescription("Met à jour les informations d'une obligation fiscale existante")
            .Produces<UpdateObligationFiscaleResponse>()
            .RequirePermission("Permissions.ObligationsFiscales.Update")
            .MapToApiVersion(1);
    }
}

public static class DeleteObligationFiscaleEndPoints
{
    internal static RouteHandlerBuilder MapObligationFiscaleDeleteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                await mediator.Send(new DeleteObligationFiscaleCommand(id));
                return Results.NoContent();
            })
            .WithName(nameof(DeleteObligationFiscaleEndPoints))
            .WithSummary("Supprimer une obligation fiscale")
            .WithDescription("Supprime une obligation fiscale du système")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.ObligationsFiscales.Delete")
            .MapToApiVersion(1);
    }
}

public static class GetObligationFiscaleEndPoints
{
    internal static RouteHandlerBuilder MapObligationFiscaleGetEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetObligationFiscaleRequest(id));
                return Results.Ok(response);
            })
            .WithName(nameof(GetObligationFiscaleEndPoints))
            .WithSummary("Obtenir une obligation fiscale")
            .WithDescription("Récupère les détails d'une obligation fiscale spécifique")
            .Produces<ObligationFiscaleResponse>()
            .RequirePermission("Permissions.ObligationsFiscales.Get")
            .MapToApiVersion(1);
    }
}

public static class SearchObligationFiscaleEndPoints
{
    internal static RouteHandlerBuilder MapObligationFiscaleSearchEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async ([FromBody] SearchObligationFiscalesCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(SearchObligationFiscaleEndPoints))
            .WithSummary("Rechercher des obligations fiscales")
            .WithDescription("Recherche et liste les obligations fiscales selon les critères spécifiés")
            .Produces<PagedList<ObligationFiscaleResponse>>()
            .RequirePermission("Permissions.ObligationsFiscales.Search")
            .MapToApiVersion(1);
    }
}

public static class DesactiverObligationFiscaleEndPoints
{
    internal static RouteHandlerBuilder MapDesactiverObligationFiscaleEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPatch("/{id:guid}/desactiver", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new DesactiverObligationFiscaleCommand(id));
                return Results.Ok(response);
            })
            .WithName(nameof(DesactiverObligationFiscaleEndPoints))
            .WithSummary("Désactiver une obligation fiscale")
            .WithDescription("Désactive une obligation fiscale existante")
            .Produces<DesactiverObligationFiscaleResponse>()
            .RequirePermission("Permissions.ObligationsFiscales.Gerer")
            .MapToApiVersion(1);
    }
}

public static class ReactiverObligationFiscaleEndPoints
{
    internal static RouteHandlerBuilder MapReactiverObligationFiscaleEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPatch("/{id:guid}/reactiver", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new ReactiverObligationFiscaleCommand(id));
                return Results.Ok(response);
            })
            .WithName(nameof(ReactiverObligationFiscaleEndPoints))
            .WithSummary("Réactiver une obligation fiscale")
            .WithDescription("Réactive une obligation fiscale précédemment désactivée")
            .Produces<ReactiverObligationFiscaleResponse>()
            .RequirePermission("Permissions.ObligationsFiscales.Gerer")
            .MapToApiVersion(1);
    }
}

public static class GenererEcheancesEndPoints
{
    internal static RouteHandlerBuilder MapGenererEcheancesEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/{id:guid}/generer-echeances", async (Guid id, GenererEcheancesCommand request, ISender mediator) =>
            {
                if (id != request.ObligationFiscaleId) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(GenererEcheancesEndPoints))
            .WithSummary("Générer les échéances d'une obligation fiscale")
            .WithDescription("Génère automatiquement les échéances pour une obligation fiscale périodique")
            .Produces<GenererEcheancesResponse>()
            .RequirePermission("Permissions.ObligationsFiscales.Gerer")
            .MapToApiVersion(1);
    }
}

public static class GetObligationsByContribuableEndPoints
{
    internal static RouteHandlerBuilder MapGetObligationsByContribuableEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/contribuable/{contribuableId:guid}", async (Guid contribuableId, ISender mediator) =>
            {
                var response = await mediator.Send(new GetObligationsByContribuableIdCommand(contribuableId));
                return Results.Ok(response);
            })
            .WithName(nameof(GetObligationsByContribuableEndPoints))
            .WithSummary("Obtenir les obligations fiscales d'un contribuable")
            .WithDescription("Récupère toutes les obligations fiscales d'un contribuable spécifique - Sécurisé par vérification de propriété")
            .Produces<List<ObligationFiscaleResponse>>()
            .RequireAuthorization()
            .MapToApiVersion(1);
    }
} 
