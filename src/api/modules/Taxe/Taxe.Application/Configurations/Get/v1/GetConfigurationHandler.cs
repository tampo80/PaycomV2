using FSH.Framework.Core.Caching;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Configurations.Get.v1;
public sealed class GetConfigurationHandler(
    [FromKeyedServices("taxe:configurations")]
    IReadRepository<Configuration> repository,
    ICacheService cache) : IRequestHandler<GetConfigurationRequest, ConfigurationResponse>
{
    public async Task<ConfigurationResponse> Handle(GetConfigurationRequest request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"configuration: {request.Id}", async () =>
            {
                var configurationItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (configurationItem == null) throw new ConfigurationNotFoundException(request.Id);
                return new ConfigurationResponse(configurationItem.Id, configurationItem.Cle, configurationItem.Valeur,
                    configurationItem.Description);
            }, cancellationToken: cancellationToken);
        return item!;
    }
}
