using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.AgentFiscals.Update.v1;
public sealed class UpdateAgentFiscalHandler(
    ILogger<UpdateAgentFiscalHandler> logger,
    [FromKeyedServices("taxe:agentfiscals")]
    IRepository<AgentFiscal> repository) : IRequestHandler<UpdateAgentFiscalCommand, UpdateAgentFiscalResponse>
{
    public async Task<UpdateAgentFiscalResponse> Handle(UpdateAgentFiscalCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var agentFiscal = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = agentFiscal  ?? throw new AgentFiscalNotFoundException(request.Id);
        var updateAgentFiscal = agentFiscal.Update(
            request.Nom, 
            request.Prenom, 
            request.Identifiant,
            request.LocalisationGPS, 
            request.DateEmbauche, 
            request.DateFinFonction, 
            request.Statut,
            agentFiscal.UtilisateurId, // Garder les valeurs existantes pour les champs non inclus dans la requête
            agentFiscal.Email,
            agentFiscal.Telephone,
            agentFiscal.EstCollecteurTerrain,
            agentFiscal.SoldePortefeuille);
        await repository.UpdateAsync(updateAgentFiscal, cancellationToken);
        logger.LogInformation("AgentFiscal avec l'id : {AgentFiscalId} mis à jour.", agentFiscal.Id);
        return new UpdateAgentFiscalResponse(agentFiscal.Id);
    }
}
