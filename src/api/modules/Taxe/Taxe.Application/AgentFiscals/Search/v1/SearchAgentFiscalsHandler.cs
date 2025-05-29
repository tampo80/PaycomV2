using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Application.AgentFiscals.Get.v1;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.AgentFiscals.Search.v1;
public sealed class SearchAgentFiscalsHandler(
    [FromKeyedServices("taxe:agentfiscals")] IReadRepository<AgentFiscal> repository) : IRequestHandler<SearchAgenFiscalsCommand, PagedList<AgentFiscalResponse>>
{
    public async Task<PagedList<AgentFiscalResponse>> Handle(SearchAgenFiscalsCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var spec = new SearchAgentFiscalSpecs(request);
        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);
        return new PagedList<AgentFiscalResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
    
}
