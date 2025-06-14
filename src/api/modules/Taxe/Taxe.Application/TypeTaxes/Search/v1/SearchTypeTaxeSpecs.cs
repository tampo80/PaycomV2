using Ardalis.Specification;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Application.TypeTaxes.Get.v1;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.TypeTaxes.Search.v1;

public class SearchTypeTaxeSpecs : EntitiesByPaginationFilterSpec<TypeTaxe, TypeTaxeResponse>
{
    public SearchTypeTaxeSpecs(SearchTypeTaxeCommand command)
        : base(command) =>
        Query
            .OrderBy(c => c.Nom, !command.HasOrderBy())
            .Where(c => c.Nom.Contains(command.Keyword), !string.IsNullOrEmpty(command.Keyword));
}

