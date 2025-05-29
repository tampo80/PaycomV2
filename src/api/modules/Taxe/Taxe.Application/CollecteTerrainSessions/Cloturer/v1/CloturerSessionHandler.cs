using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.CollecteTerrainSessions.Cloturer.v1;

public class CloturerSessionHandler : IRequestHandler<CloturerSessionCommand, CloturerSessionResponse>
{
    private readonly IRepository<CollecteTerrainSession> _repository;
    private readonly ILogger<CloturerSessionHandler> _logger;

    public CloturerSessionHandler(
        [FromKeyedServices("taxe:collecte-sessions")] IRepository<CollecteTerrainSession> repository,
        ILogger<CloturerSessionHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<CloturerSessionResponse> Handle(CloturerSessionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var session = await _repository.GetByIdAsync(request.SessionId, cancellationToken);
            
            if (session == null)
            {
                return new CloturerSessionResponse
                {
                    Success = false,
                    Message = "Session de collecte non trouvée"
                };
            }

         //   session.CloturerSession();
            
            await _repository.UpdateAsync(session, cancellationToken);
            
            return new CloturerSessionResponse
            {
                Id = session.Id,
                Success = true,
                Message = "Session de collecte clôturée avec succès"
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur lors de la clôture de la session de collecte {SessionId}", request.SessionId);
            
            return new CloturerSessionResponse
            {
                Success = false,
                Message = $"Erreur lors de la clôture de la session: {ex.Message}"
            };
        }
    }
} 
