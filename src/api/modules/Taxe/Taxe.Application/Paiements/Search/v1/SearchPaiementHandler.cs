using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Application.Paiements.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Paiements.Search.v1;
public class SearchPaiementHandler(
    [FromKeyedServices("taxe:paiements")] IReadRepository<Paiement> repository)
: IRequestHandler<SearchPaiementCommand, PagedList<PaiementResponse>>
{
    public async Task<PagedList<PaiementResponse>> Handle(SearchPaiementCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var spec = new SearchPaiementSpecs(request);
        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);
        return new PagedList<PaiementResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
    
}
