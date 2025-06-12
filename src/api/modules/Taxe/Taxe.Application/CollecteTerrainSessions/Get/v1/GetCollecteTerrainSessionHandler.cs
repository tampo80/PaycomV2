using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using Microsoft.EntityFrameworkCore;

namespace PayCom.WebApi.Taxe.Application.CollecteTerrainSessions.Get.v1;
public sealed class GetCollecteTerrainSessionHandler(
    ILogger<GetCollecteTerrainSessionHandler> logger,
    [FromKeyedServices("taxe:collecte-sessions")] IReadRepository<CollecteTerrainSession> repository) : IRequestHandler<GetCollecteTerrainSessionRequest, CollecteTerrainSessionResponse>
{
    public async Task<CollecteTerrainSessionResponse> Handle(GetCollecteTerrainSessionRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        // Utiliser une spécification ou une requête qui inclut les entités associées
        var specification = new GetCollecteTerrainSessionSpec(request.Id);
        var session = await repository.FirstOrDefaultAsync(specification, cancellationToken);
        
        if (session is null)
        {
            logger.LogWarning("Session de collecte terrain non trouvée {sessionId}", request.Id);
            throw new KeyNotFoundException($"Session de collecte terrain non trouvée avec ID {request.Id}");
        }
        
        logger.LogInformation("Session de collecte terrain récupérée {sessionId}", session.Id);
        
        return new CollecteTerrainSessionResponse(
            session.Id,
            session.DateDebut,
            session.DateFin,
            session.Notes,
            session.Statut.ToString(),
            session.AgentFiscalId,
            session.ZoneCollecteId,
            session.ZoneCollecte?.Nom,
            session.ZoneCollecte?.Code,
            session.ZoneCollecte?.CommuneId,
            session.ZoneCollecte?.Commune?.Nom
        );
    }
} 
