using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Contribuables.AssocierAgentFiscal.v1;

public class AssocierAgentFiscalContribuableHandler(
    ILogger<AssocierAgentFiscalContribuableHandler> logger,
    [FromKeyedServices("taxe:contribuables")] IRepository<Contribuable> contribuableRepository,
    [FromKeyedServices("taxe:agentfiscals")] IRepository<AgentFiscal> agentFiscalRepository) 
    : IRequestHandler<AssocierAgentFiscalContribuableCommand, AssocierAgentFiscalContribuableResponse>
{
    public async Task<AssocierAgentFiscalContribuableResponse> Handle(AssocierAgentFiscalContribuableCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        var contribuable = await contribuableRepository.GetByIdAsync(request.ContribuableId, cancellationToken);
        _ = contribuable ?? throw new ContribuableNotFoundException(request.ContribuableId);
        
        var agentFiscal = await agentFiscalRepository.GetByIdAsync(request.AgentFiscalId, cancellationToken);
        _ = agentFiscal ?? throw new AgentFiscalNotFoundException(request.AgentFiscalId);
        
        contribuable.AssocierAgentFiscal(request.AgentFiscalId);
        
        await contribuableRepository.UpdateAsync(contribuable, cancellationToken);
        
        logger.LogInformation("Contribuable {ContribuableId} associé à l'agent fiscal {AgentFiscalId}", request.ContribuableId, request.AgentFiscalId);
        
        return new AssocierAgentFiscalContribuableResponse(contribuable.Id, agentFiscal.Id);
    }
} 
