using Ardalis.Specification;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Application.Villages.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Villages.Search.v1;
public class SearchVillageSpecs : EntitiesByPaginationFilterSpec<Village, VillageResponse>
{
    public SearchVillageSpecs(SearchVillageCommand command) : base(command)
        => Query.OrderBy(v => v.Nom, !command.HasOrderBy())
            .Where(v => v.Nom.Contains(command.Keyword), !string.IsNullOrEmpty(command.Keyword));
}
