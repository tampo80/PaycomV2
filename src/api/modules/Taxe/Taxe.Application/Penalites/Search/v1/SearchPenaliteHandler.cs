using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Application.Penalites.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Penalites.Search.v1;
public class SearchPenaliteHandler(
    [FromKeyedServices("taxe:penalites")] IReadRepository<Penalite> repository)
: IRequestHandler<SearchPenaliteCommand, PagedList<PenaliteResponse>>
{
    public async Task<PagedList<PenaliteResponse>> Handle(SearchPenaliteCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var spec = new SearchPenaliteSpecs(request);
        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);
        return new PagedList<PenaliteResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
    
}
