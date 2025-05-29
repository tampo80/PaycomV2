using Ardalis.Specification;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Application.Echeanciers.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Echeanciers.Search.v1;
public class SearchEcheancierSpecs : EntitiesByPaginationFilterSpec<Echeancier, EcheancierResponse>
{
    public SearchEcheancierSpecs(SearchEcheancierCommand command) : base(command)
        => Query.OrderBy(c => c.DateEcheance, !command.HasOrderBy())
            .Where(c => command.Keyword == null || c.DateEcheance.ToString().Contains(command.Keyword));
}
