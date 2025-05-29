using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.AgentFiscals.Create.v1;
public sealed class CreateAgentFiscalHandler(
    ILogger<CreateAgentFiscalHandler> logger,
    [FromKeyedServices("taxe:agentfiscals")] IRepository<AgentFiscal> repository)
    : IRequestHandler<CreateAgentFiscalCommand, CreateAgentFiscalResponse>
{
    public async Task<CreateAgentFiscalResponse> Handle(CreateAgentFiscalCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        var agentFiscal = AgentFiscal.Create(
            request.Nom, 
            request.Prenom, 
            request.Identifiant, 
            request.LocalisationGPS,
            request.DateEmbauche, 
            request.DateFinFonction, 
            request.Statut,
            request.UtilisateurId,
            request.Email,
            request.Telephone,
            request.EstCollecteurTerrain,
            request.SoldePortefeuille);
            
        await repository.AddAsync(agentFiscal, cancellationToken);
        logger.LogInformation("AgentFiscal créé avec l'ID {AgentFiscalId}", agentFiscal.Id);
        return new CreateAgentFiscalResponse(agentFiscal.Id);
    }
}
