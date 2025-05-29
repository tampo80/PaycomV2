using Ardalis.Specification;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Specifications;
using PayCom.WebApi.Taxe.Application.AgentFiscals.Get.v1;

using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain;
namespace PayCom.WebApi.Taxe.Application.AgentFiscals.Search.v1;
public class SearchAgentFiscalSpecs : EntitiesByPaginationFilterSpec<AgentFiscal, AgentFiscalResponse>
{
    public SearchAgentFiscalSpecs(SearchAgenFiscalsCommand command)
        : base(command) =>
        Query
            .OrderBy(a => a.Nom, !command.HasOrderBy())
            .Where(a => a.Nom.Contains(command.Keyword), !string.IsNullOrEmpty(command.Keyword));
}
