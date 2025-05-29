using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Application.Villages.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Villages.Search.v1;
public class SearchVillageHandler(
    [FromKeyedServices("taxe:villages")] IReadRepository<Village> repository)
: IRequestHandler<SearchVillageCommand, PagedList<VillageResponse>>
{
    public async Task<PagedList<VillageResponse>> Handle(SearchVillageCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var spec = new SearchVillageSpecs(request);
        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);
        return new PagedList<VillageResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
}
