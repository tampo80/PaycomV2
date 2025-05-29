using Ardalis.Specification;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using PayCom.WebApi.Taxe.Application.Taxes.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Taxes.Search.v1;
public class SearchTaxeSpecs : EntitiesByPaginationFilterSpec<Taxe.Domain.Taxe, TaxeResponse>
{
    public SearchTaxeSpecs(SearchTaxeCommand command) : base(command)
        => Query.OrderBy(t => t.UniteMesure, !command.HasOrderBy())
            .Where(t => t.UniteMesure.Contains(command.Keyword), !string.IsNullOrEmpty(command.Keyword));
}
