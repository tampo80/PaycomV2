using FSH.Framework.Core.Caching;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Prefectures.Get.v1;
public sealed class GetPrefectureHandler(
    [FromKeyedServices("taxe:prefectures")] IReadRepository<Prefecture> repository,
    ICacheService cache) : IRequestHandler<GetPrefectureRequest, PrefectureResponse>
{
    public async Task<PrefectureResponse> Handle(GetPrefectureRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"Prefecture {request.Id}", async () =>
            {
                var prefectureItem = await repository.GetByIdAsync(request.Id);
                if (prefectureItem == null) throw new PrefectureNotFoundException(request.Id);
                return new PrefectureResponse(prefectureItem.Id, prefectureItem.Nom, prefectureItem.Code);
            }, cancellationToken: cancellationToken);
        return item!;
    }
}
