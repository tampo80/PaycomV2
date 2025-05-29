using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Application.Penalites.Search.v1;
using PayCom.WebApi.Taxe.Application.Prefectures.Get.v1;
using PayCom.WebApi.Taxe.Application.Prefectures.Search.v1;

namespace PayCom.WebApi.Taxe.Application.Prefectures.Search.v1;
public class SearchPrefectureHandler(
    [FromKeyedServices("taxe:prefectures")] IReadRepository<Prefecture> repository)
: IRequestHandler<SearchPrefectureCommand, PagedList<PrefectureResponse>>
{
    public async Task<PagedList<PrefectureResponse>> Handle(SearchPrefectureCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var spec = new SearchPrefectureSpecs(request);
        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);
        return new PagedList<PrefectureResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
}
