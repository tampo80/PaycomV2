using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PayCom.WebApi.Taxe.Application.Communes.Create.v1;
using PayCom.WebApi.Taxe.Application.Communes.Delete.v1;
using PayCom.WebApi.Taxe.Application.Communes.Get.v1;
using PayCom.WebApi.Taxe.Application.Communes.Search.v1;
using PayCom.WebApi.Taxe.Application.Communes.Update.v1;

namespace PayCom.WebApi.Taxe.Infrastructure.EndPoints.v1;

public static class CommuneEndpoints
{
    internal static RouteHandlerBuilder MapCommuneCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreateCommuneCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName("CreateCommuneEndpoint")
            .WithSummary("creates a commune")
            .WithDescription("creates a commune")
            .Produces<CreateCommuneResponse>()
            .RequirePermission("Permissions.Communes.Create")
            .MapToApiVersion(1);
    }

    internal static RouteHandlerBuilder MapCommuneGetEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetCommuneQuery(id));
                return Results.Ok(response);
            })
            .WithName("GetCommuneEndpoint")
            .WithSummary("Get a commune")
            .WithDescription("Get a commune by ID")
            .Produces<CommuneResponse>()
            .RequirePermission("Permissions.Communes.Get")
            .MapToApiVersion(1);
    }

    internal static RouteHandlerBuilder MapCommuneUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdateCommuneCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName("UpdateCommuneEndpoint")
            .WithSummary("Update a commune")
            .WithDescription("Update an existing commune")
            .Produces<UpdateCommuneResponse>()
            .RequirePermission("Permissions.Communes.Update")
            .MapToApiVersion(1);
    }

    internal static RouteHandlerBuilder MapCommuneDeleteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                await mediator.Send(new DeleteCommuneCommand(id));
                return Results.NoContent();
            })
            .WithName("DeleteCommuneEndpoint")
            .WithSummary("Delete a commune")
            .WithDescription("Delete a commune")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.Communes.Delete")
            .MapToApiVersion(1);
    }

    internal static RouteHandlerBuilder MapCommuneSearchEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async ([FromBody] SearchCommuneCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName("SearchCommuneEndpoint")
            .WithSummary("Search communes")
            .WithDescription("Search and list communes based on the specified criteria")
            .Produces<PagedList<CommuneResponse>>()
            .RequirePermission("Permissions.Communes.Search")
            .MapToApiVersion(1);
    }
} 
