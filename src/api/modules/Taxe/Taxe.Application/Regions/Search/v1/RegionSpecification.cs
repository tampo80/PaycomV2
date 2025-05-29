using Ardalis.Specification;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Application.Regions.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Regions.Search.v1;
public class SearchRegionSpecs : EntitiesByPaginationFilterSpec<Region, RegionResponse>
{
    public SearchRegionSpecs(SearchRegionsCommand command)
        : base(command) =>
        Query
            .OrderBy(r => r.Nom, !command.HasOrderBy())
            .Where(r => r.Nom.Contains(command.Nom), !string.IsNullOrEmpty(command.Nom))
            .Where(r => r.Code.Contains(command.Code), !string.IsNullOrEmpty(command.Code));
}
