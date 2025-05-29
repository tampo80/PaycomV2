using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PayCom.WebApi.Taxe.Application.Configurations.Create.v1;
using PayCom.WebApi.Taxe.Application.Configurations.Delete.v1;
using PayCom.WebApi.Taxe.Application.Configurations.Get.v1;
using PayCom.WebApi.Taxe.Application.Configurations.Search.v1;
using PayCom.WebApi.Taxe.Application.Configurations.Update.v1;

namespace PayCom.WebApi.Taxe.Infrastructure.EndPoints.v1;

public static class CreateConfigurationEndPoints
{
    internal static RouteHandlerBuilder MapConfigurationCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreateConfigurationCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreateConfigurationEndPoints))
            .WithSummary("Créer une configuration")
            .WithDescription("Crée une nouvelle configuration dans le système")
            .Produces<CreateConfigurationResponse>()
            .RequirePermission("Permissions.Configurations.Create")
            .MapToApiVersion(1);
    }
}

public static class UpdateConfigurationEndPoints
{
    internal static RouteHandlerBuilder MapConfigurationUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdateConfigurationCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdateConfigurationEndPoints))
            .WithSummary("Mettre à jour une configuration")
            .WithDescription("Met à jour les informations d'une configuration existante")
            .Produces<UpdateConfigurationResponse>()
            .RequirePermission("Permissions.Configurations.Update")
            .MapToApiVersion(1);
    }
}

public static class DeleteConfigurationEndPoints
{
    internal static RouteHandlerBuilder MapConfigurationDeleteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                await mediator.Send(new DeleteConfigurationCommand(id));
                return Results.NoContent();
            })
            .WithName(nameof(DeleteConfigurationEndPoints))
            .WithSummary("Supprimer une configuration")
            .WithDescription("Supprime une configuration du système")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.Configurations.Delete")
            .MapToApiVersion(1);
    }
}

public static class GetConfigurationEndPoints
{
    internal static RouteHandlerBuilder MapConfigurationGetEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetConfigurationRequest { Id = id });
                return Results.Ok(response);
            })
            .WithName(nameof(GetConfigurationEndPoints))
            .WithSummary("Obtenir une configuration")
            .WithDescription("Récupère les détails d'une configuration spécifique")
            .Produces<ConfigurationResponse>()
            .RequirePermission("Permissions.Configurations.Get")
            .MapToApiVersion(1);
    }
}

public static class SearchConfigurationEndPoints
{
    internal static RouteHandlerBuilder MapConfigurationSearchEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async ([FromBody] SearchConfigurationCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(SearchConfigurationEndPoints))
            .WithSummary("Rechercher des configurations")
            .WithDescription("Recherche et liste les configurations selon les critères spécifiés")
            .Produces<PagedList<ConfigurationResponse>>()
            .RequirePermission("Permissions.Configurations.Search")
            .MapToApiVersion(1);
    }
} 