using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PayCom.WebApi.Taxe.Application.Prefectures.Create.v1;
using PayCom.WebApi.Taxe.Application.Prefectures.Delete.v1;
using PayCom.WebApi.Taxe.Application.Prefectures.Get.v1;
using PayCom.WebApi.Taxe.Application.Prefectures.Search.v1;
using PayCom.WebApi.Taxe.Application.Prefectures.Update.v1;

namespace PayCom.WebApi.Taxe.Infrastructure.EndPoints.v1;

public static class CreatePrefectureEndPoints
{
    internal static RouteHandlerBuilder MapPrefectureCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreatePrefectureCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreatePrefectureEndPoints))
            .WithSummary("Créer une préfecture")
            .WithDescription("Crée une nouvelle préfecture administrative")
            .Produces<CreatePrefectureResponse>()
            .RequirePermission("Permissions.Prefectures.Create")
            .MapToApiVersion(1);
    }
}

public static class UpdatePrefectureEndPoints
{
    internal static RouteHandlerBuilder MapPrefectureUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdatePrefectureCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdatePrefectureEndPoints))
            .WithSummary("Mettre à jour une préfecture")
            .WithDescription("Met à jour les informations d'une préfecture existante")
            .Produces<UpdatePrefectureResponse>()
            .RequirePermission("Permissions.Prefectures.Update")
            .MapToApiVersion(1);
    }
}

public static class DeletePrefectureEndPoints
{
    internal static RouteHandlerBuilder MapPrefectureDeleteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                await mediator.Send(new DeletePrefectureCommand(id));
                return Results.NoContent();
            })
            .WithName(nameof(DeletePrefectureEndPoints))
            .WithSummary("Supprimer une préfecture")
            .WithDescription("Supprime une préfecture du système")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.Prefectures.Delete")
            .MapToApiVersion(1);
    }
}

public static class GetPrefectureEndPoints
{
    internal static RouteHandlerBuilder MapPrefectureGetEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetPrefectureRequest(id));
                return Results.Ok(response);
            })
            .WithName(nameof(GetPrefectureEndPoints))
            .WithSummary("Obtenir une préfecture")
            .WithDescription("Récupère les détails d'une préfecture spécifique")
            .Produces<PrefectureResponse>()
            .RequirePermission("Permissions.Prefectures.Get")
            .MapToApiVersion(1);
    }
}

public static class SearchPrefectureEndPoints
{
    internal static RouteHandlerBuilder MapPrefectureSearchEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async ([FromBody] SearchPrefecturesCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(SearchPrefectureEndPoints))
            .WithSummary("Rechercher des préfectures")
            .WithDescription("Recherche et liste des préfectures selon les critères spécifiés")
            .Produces<PagedList<PrefectureResponse>>()
            .RequirePermission("Permissions.Prefectures.Search")
            .MapToApiVersion(1);
    }
} 
