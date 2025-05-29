using Ardalis.Specification;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Application.Operations.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Operations.Search.v1;
public class SearchOperationSpecs : EntitiesByPaginationFilterSpec<Operation, OperationResponse>
{
    public SearchOperationSpecs(SearchOperationCommand command) : base(command)
        => Query.OrderBy(o => o.Description, !command.HasOrderBy())
            .Where(o => o.Description.Contains(command.Keyword), !string.IsNullOrEmpty(command.Keyword));
}
