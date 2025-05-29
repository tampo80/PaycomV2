using Ardalis.Specification;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using PayCom.WebApi.Taxe.Application.Communes.Get.v1;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Communes.Search.v1;
public class SearchCommuneSpecs : EntitiesByPaginationFilterSpec<Commune, CommuneResponse>
{
    public SearchCommuneSpecs(SearchCommuneCommand command)
        : base(command) =>
        Query
            .OrderBy(c => c.Nom, !command.HasOrderBy())
            .Where(c => c.Nom.Contains(command.Keyword), !string.IsNullOrEmpty(command.Keyword));
}
