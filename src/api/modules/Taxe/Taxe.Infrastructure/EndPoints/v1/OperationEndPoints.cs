using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PayCom.WebApi.Taxe.Application.Operations.Create.v1;
using PayCom.WebApi.Taxe.Application.Operations.Delete.v1;
using PayCom.WebApi.Taxe.Application.Operations.Get.v1;
using PayCom.WebApi.Taxe.Application.Operations.Search.v1;
using PayCom.WebApi.Taxe.Application.Operations.Update.v1;

namespace PayCom.WebApi.Taxe.Infrastructure.EndPoints.v1;

public static class CreateOperationEndPoints
{
    internal static RouteHandlerBuilder MapOperationCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreateOperationCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreateOperationEndPoints))
            .WithSummary("Créer une opération")
            .WithDescription("Crée une nouvelle opération dans le système")
            .Produces<CreateOperationResponse>()
            .RequirePermission("Permissions.Operations.Create")
            .MapToApiVersion(1);
    }
}

public static class UpdateOperationEndPoints
{
    internal static RouteHandlerBuilder MapOperationUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdateOperationCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdateOperationEndPoints))
            .WithSummary("Mettre à jour une opération")
            .WithDescription("Met à jour les informations d'une opération existante")
            .Produces<UpdateOperationResponse>()
            .RequirePermission("Permissions.Operations.Update")
            .MapToApiVersion(1);
    }
}

public static class DeleteOperationEndPoints
{
    internal static RouteHandlerBuilder MapOperationDeleteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                await mediator.Send(new DeleteOperationCommand(id));
                return Results.NoContent();
            })
            .WithName(nameof(DeleteOperationEndPoints))
            .WithSummary("Supprimer une opération")
            .WithDescription("Supprime une opération du système")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.Operations.Delete")
            .MapToApiVersion(1);
    }
}

public static class GetOperationEndPoints
{
    internal static RouteHandlerBuilder MapOperationGetEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetOperationRequest(id));
                return Results.Ok(response);
            })
            .WithName(nameof(GetOperationEndPoints))
            .WithSummary("Obtenir une opération")
            .WithDescription("Récupère les détails d'une opération spécifique")
            .Produces<OperationResponse>()
            .RequirePermission("Permissions.Operations.Get")
            .MapToApiVersion(1);
    }
}

public static class SearchOperationEndPoints
{
    internal static RouteHandlerBuilder MapOperationSearchEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async ([FromBody] SearchOperationsCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(SearchOperationEndPoints))
            .WithSummary("Rechercher des opérations")
            .WithDescription("Recherche et liste les opérations selon les critères spécifiés")
            .Produces<PagedList<OperationResponse>>()
            .RequirePermission("Permissions.Operations.Search")
            .MapToApiVersion(1);
    }
} 
