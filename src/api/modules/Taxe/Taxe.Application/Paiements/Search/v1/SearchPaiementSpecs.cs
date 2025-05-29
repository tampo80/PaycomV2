using Ardalis.Specification;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Application.Paiements.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Paiements.Search.v1;
public class SearchPaiementSpecs : EntitiesByPaginationFilterSpec<Paiement, PaiementResponse>
{
    public SearchPaiementSpecs(SearchPaiementCommand command) : base(command)
        => Query.OrderBy(p => p.InformationsSupplementaires, !command.HasOrderBy())
            .Where(p => p.InformationsSupplementaires.Contains(command.Keyword),
                !string.IsNullOrEmpty(command.Keyword));
}
