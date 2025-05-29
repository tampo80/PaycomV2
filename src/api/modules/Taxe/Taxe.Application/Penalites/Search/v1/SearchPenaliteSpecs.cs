using Ardalis.Specification;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Application.Penalites.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Penalites.Search.v1;
public class SearchPenaliteSpecs : EntitiesByPaginationFilterSpec<Penalite, PenaliteResponse>
{
    public SearchPenaliteSpecs(SearchPenaliteCommand command) : base(command)
        => Query.OrderBy(p => p.Type, !command.HasOrderBy())
            .Where(p => p.Type.Contains(command.Keyword),
                !string.IsNullOrEmpty(command.Keyword));
}
