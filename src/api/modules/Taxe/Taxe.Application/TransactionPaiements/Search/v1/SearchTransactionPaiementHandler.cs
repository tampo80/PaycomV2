using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Application.TransactionPaiements.Get.v1;

namespace PayCom.WebApi.Taxe.Application.TransactionPaiements.Search.v1;
public class SearchTransactionPaiementHandler(
    [FromKeyedServices("taxe:transaction-paiements")] IReadRepository<TransactionPaiement> repository)
: IRequestHandler<SearchTransactionPaiementCommand, PagedList<TransactionPaiementResponse>>
{
    public async Task<PagedList<TransactionPaiementResponse>> Handle(SearchTransactionPaiementCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var spec = new SearchTransactionPaiementSpecs(request);
        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);
        return new PagedList<TransactionPaiementResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
}
