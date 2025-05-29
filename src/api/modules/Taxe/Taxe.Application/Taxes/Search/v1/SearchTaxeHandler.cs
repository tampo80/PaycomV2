using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Application.Taxes.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Taxes.Search.v1;
public class SearchTaxeHandler(
    [FromKeyedServices("taxe:taxes")] IReadRepository<Taxe.Domain.Taxe> repository)
: IRequestHandler<SearchTaxeCommand, PagedList<TaxeResponse>>
{
    public async Task<PagedList<TaxeResponse>> Handle(SearchTaxeCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var spec = new SearchTaxeSpecs(request);
        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);
        return new PagedList<TaxeResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
}
