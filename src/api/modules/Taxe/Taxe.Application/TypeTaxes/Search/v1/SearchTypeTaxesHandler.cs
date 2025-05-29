using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Application.TypeTaxes.Get.v1;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.TypeTaxes.Search.v1;

public class SearchTypeTaxesHandler(
    [FromKeyedServices("taxe:types-taxe")] IReadRepository<TypeTaxe> repository)
    : IRequestHandler<SearchTypeTaxesCommand, PagedList<TypeTaxeResponse>>
{
    public async Task<PagedList<TypeTaxeResponse>> Handle(SearchTypeTaxesCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var spec = new SearchTypeTaxeSpecs(request);
        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);
        return new PagedList<TypeTaxeResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
} 
