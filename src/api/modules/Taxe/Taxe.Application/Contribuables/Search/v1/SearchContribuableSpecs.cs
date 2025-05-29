using System.Net.Mime;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using Ardalis.Specification;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using PayCom.WebApi.Taxe.Application.Contribuables.Get.v1;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Contribuables.Search.v1;
public class SearchContribuableSpecs : EntitiesByPaginationFilterSpec<Contribuable, ContribuableResponse>
{
    public SearchContribuableSpecs(SearchContribuableCommand command) : base(command)
        => Query.OrderBy(c => c.Nom, !command.HasOrderBy())
            .Where(c => c.Nom.Contains(command.Keyword), !string.IsNullOrEmpty(command.Keyword));
}
