using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PayCom.WebApi.Taxe.Application.Notifications.Create.v1;
using PayCom.WebApi.Taxe.Application.Notifications.Delete.v1;
using PayCom.WebApi.Taxe.Application.Notifications.Get.v1;
using PayCom.WebApi.Taxe.Application.Notifications.Search.v1;
using PayCom.WebApi.Taxe.Application.Notifications.Update.v1;
using PayCom.WebApi.Taxe.Application.Notifications.MarquerCommeLue.v1;

namespace PayCom.WebApi.Taxe.Infrastructure.EndPoints.v1;

public static class CreateNotificationEndPoints
{
    internal static RouteHandlerBuilder MapNotificationCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreateNotificationCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreateNotificationEndPoints))
            .WithSummary("Créer une notification")
            .WithDescription("Crée une nouvelle notification dans le système")
            .Produces<CreateNotificationResponse>()
            .RequirePermission("Permissions.Notifications.Create")
            .MapToApiVersion(1);
    }
}

public static class UpdateNotificationEndPoints
{
    internal static RouteHandlerBuilder MapNotificationUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdateNotificationCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdateNotificationEndPoints))
            .WithSummary("Mettre à jour une notification")
            .WithDescription("Met à jour les informations d'une notification existante")
            .Produces<UpdateNotificationResponse>()
            .RequirePermission("Permissions.Notifications.Update")
            .MapToApiVersion(1);
    }
}

public static class DeleteNotificationEndPoints
{
    internal static RouteHandlerBuilder MapNotificationDeleteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                await mediator.Send(new DeleteNotificationCommand(id));
                return Results.NoContent();
            })
            .WithName(nameof(DeleteNotificationEndPoints))
            .WithSummary("Supprimer une notification")
            .WithDescription("Supprime une notification du système")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.Notifications.Delete")
            .MapToApiVersion(1);
    }
}

public static class GetNotificationEndPoints
{
    internal static RouteHandlerBuilder MapNotificationGetEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetNotificationRequest(id));
                return Results.Ok(response);
            })
            .WithName(nameof(GetNotificationEndPoints))
            .WithSummary("Obtenir une notification")
            .WithDescription("Récupère les détails d'une notification spécifique")
            .Produces<NotificationResponse>()
            .RequirePermission("Permissions.Notifications.Get")
            .MapToApiVersion(1);
    }
}

public static class SearchNotificationEndPoints
{
    internal static RouteHandlerBuilder MapNotificationSearchEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async ([FromBody] SearchNotificationCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(SearchNotificationEndPoints))
            .WithSummary("Rechercher des notifications")
            .WithDescription("Recherche et liste les notifications selon les critères spécifiés")
            .Produces<PagedList<NotificationResponse>>()
            .RequirePermission("Permissions.Notifications.Search")
            .MapToApiVersion(1);
    }
}

public static class MarquerCommeLueEndPoints
{
    internal static RouteHandlerBuilder MapMarquerCommeLueEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/{id:guid}/marquer-comme-lue", async (Guid id, ISender mediator) =>
            {
                var command = new MarquerCommeLueCommand { NotificationId = id };
                var response = await mediator.Send(command);
                return Results.Ok(response);
            })
            .WithName(nameof(MarquerCommeLueEndPoints))
            .WithSummary("Marquer une notification comme lue")
            .WithDescription("Marque une notification comme ayant été lue par l'utilisateur")
            .Produces<MarquerCommeLueResponse>()
            .RequirePermission("Permissions.Notifications.Update")
            .MapToApiVersion(1);
    }
} 
