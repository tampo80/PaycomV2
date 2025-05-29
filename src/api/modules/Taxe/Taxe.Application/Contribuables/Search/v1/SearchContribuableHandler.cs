using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Application.Contribuables.Get.v1;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Contribuables.Search.v1;
public class SearchContribuableHandler(
    [FromKeyedServices("taxe:contribuables")] IReadRepository<Contribuable> repository) : IRequestHandler<SearchContribuableCommand, PagedList<ContribuableResponse>>
{
    public async Task<PagedList<ContribuableResponse>> Handle(SearchContribuableCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var spec = new SearchContribuableSpecs(request);
        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);
        return new PagedList<ContribuableResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
}
