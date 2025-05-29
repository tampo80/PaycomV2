using Ardalis.Specification;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Application.TransactionPaiements.Get.v1;

namespace PayCom.WebApi.Taxe.Application.TransactionPaiements.Search.v1;
public class SearchTransactionPaiementSpecs : EntitiesByPaginationFilterSpec<TransactionPaiement, TransactionPaiementResponse>
{
    public SearchTransactionPaiementSpecs(SearchTransactionPaiementCommand command) : base(command)
        => Query.OrderBy(t => t.CodeTransaction, !command.HasOrderBy())
            .Where(t => t.CodeTransaction.Contains(command.Keyword), !string.IsNullOrEmpty(command.Keyword));
}
