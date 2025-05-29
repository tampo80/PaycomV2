using FSH.Framework.Core.Caching;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Villages.Get.v1;
public class GetVillageHandler(
    [FromKeyedServices("taxe:villages")] IReadRepository<Village> repository,
    ICacheService cache) : IRequestHandler<GetVillageRequest, VillageResponse>
{
    public async Task<VillageResponse> Handle(GetVillageRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"village {request.Id}", async () =>
            {
                var villageItem = await repository.GetByIdAsync(request.Id);
                if (villageItem == null) throw new VillageNotFoundException(request.Id);
                return new VillageResponse(
                    villageItem.Id,
                    villageItem.Nom,
                    villageItem.Code
                );
            }, cancellationToken: cancellationToken);
        return item!;
    }
}
