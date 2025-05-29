using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.AgentFiscals.AssocierUtilisateur.v1;

public sealed class AssocierUtilisateurAgentHandler(
    ILogger<AssocierUtilisateurAgentHandler> logger,
    [FromKeyedServices("taxe:agentfiscals")]
    IRepository<AgentFiscal> repository) : IRequestHandler<AssocierUtilisateurAgentCommand, AssocierUtilisateurAgentResponse>
{
    public async Task<AssocierUtilisateurAgentResponse> Handle(AssocierUtilisateurAgentCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        var agentFiscal = await repository.GetByIdAsync(request.AgentId, cancellationToken);
        _ = agentFiscal ?? throw new AgentFiscalNotFoundException(request.AgentId);
        
        agentFiscal.AssocierUtilisateur(request.UtilisateurId);
        
        await repository.UpdateAsync(agentFiscal, cancellationToken);
        
        logger.LogInformation("Agent fiscal avec l'id : {AgentId} associé à l'utilisateur : {UtilisateurId}", 
            agentFiscal.Id, request.UtilisateurId);
            
        return new AssocierUtilisateurAgentResponse(agentFiscal.Id, request.UtilisateurId);
    }
} 
