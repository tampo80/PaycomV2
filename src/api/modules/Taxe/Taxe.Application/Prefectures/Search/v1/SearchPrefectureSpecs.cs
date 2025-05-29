using Ardalis.Specification;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Application.Prefectures.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Prefectures.Search.v1;
public class SearchPrefectureSpecs : EntitiesByPaginationFilterSpec<Prefecture, PrefectureResponse>
{
    public SearchPrefectureSpecs(SearchPrefectureCommand command) : base(command)
        => Query.OrderBy(p => p.Nom, !command.HasOrderBy())
            .Where(p => p.Nom.Contains(command.Keyword), !string.IsNullOrEmpty(command.Keyword));
}
