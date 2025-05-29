using FSH.Framework.Core.Caching;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.AgentFiscals.Get.v1;
public sealed class GetAgentFiscalHandler(
    [FromKeyedServices("taxe:agentfiscals")]
    IReadRepository<AgentFiscal> repository,
    ICacheService cache) : IRequestHandler<GetAgentFiscalRequest, AgentFiscalResponse>
{
    public async Task<AgentFiscalResponse> Handle(GetAgentFiscalRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"agentFiscal:{request.Id}",
            async () =>
            {
                var agentFiscalItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (agentFiscalItem == null) throw new AgentFiscalNotFoundException(request.Id);
                return new AgentFiscalResponse(
                    agentFiscalItem.Id, 
                    agentFiscalItem.Nom, 
                    agentFiscalItem.Prenom,
                    agentFiscalItem.Identifiant, 
                    agentFiscalItem.LocalisationGPS, 
                    agentFiscalItem.DateEmbauche,
                    agentFiscalItem.DateFinFonction, 
                    agentFiscalItem.Statut,
                    agentFiscalItem.Email,
                    agentFiscalItem.Telephone,
                    agentFiscalItem.EstCollecteurTerrain,
                    agentFiscalItem.SoldePortefeuille,
                    agentFiscalItem.UtilisateurId);
            }, cancellationToken: cancellationToken);
        return item!;
    }
    
}
