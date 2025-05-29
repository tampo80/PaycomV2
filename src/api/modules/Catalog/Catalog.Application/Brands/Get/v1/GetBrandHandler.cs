using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Catalog.Domain.Exceptions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Caching;
using PayCom.WebApi.Catalog.Domain;
using MediatR;

namespace PayCom.WebApi.Catalog.Application.Brands.Get.v1;
public sealed class GetBrandHandler(
    [FromKeyedServices("catalog:brands")] IReadRepository<Brand> repository,
    ICacheService cache)
    : IRequestHandler<GetBrandRequest, BrandResponse>
{
    public async Task<BrandResponse> Handle(GetBrandRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"brand:{request.Id}",
            async () =>
            {
                var brandItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (brandItem == null) throw new BrandNotFoundException(request.Id);
                return new BrandResponse(brandItem.Id, brandItem.Name, brandItem.Description);
            },
            cancellationToken: cancellationToken);
        return item!;
    }
}
