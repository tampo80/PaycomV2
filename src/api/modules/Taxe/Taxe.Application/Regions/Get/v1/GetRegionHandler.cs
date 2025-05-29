using FSH.Framework.Core.Caching;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Regions.Get.v1;
public sealed class GetRegionHandler(
    [FromKeyedServices("taxe:regions")] IReadRepository<Region> repository,
    ICacheService cache,
    ILogger<GetRegionHandler> logger)
    : IRequestHandler<GetRegionRequest, RegionResponse>
{
    public async Task<RegionResponse> Handle(GetRegionRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"region:{request.Id}",
            async () =>
            {
                var region = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (region == null) 
                {
                    logger.LogWarning("Region {RegionId} not found", request.Id);
                    throw new RegionNotFoundException(request.Id);
                }
                logger.LogInformation("Retrieved region {RegionId} from database", request.Id);
                return new RegionResponse(region.Id, region.Nom, region.Code);
            },
            cancellationToken: cancellationToken);
        return item!;
    }
}
