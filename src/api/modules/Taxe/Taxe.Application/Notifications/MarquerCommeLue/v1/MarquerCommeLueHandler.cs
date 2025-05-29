using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Notifications.MarquerCommeLue.v1;

public class MarquerCommeLueHandler : IRequestHandler<MarquerCommeLueCommand, MarquerCommeLueResponse>
{
    private readonly IRepository<Notification> _repository;
    private readonly ILogger<MarquerCommeLueHandler> _logger;

    public MarquerCommeLueHandler(
        [FromKeyedServices("taxe:notifications")] IRepository<Notification> repository,
        ILogger<MarquerCommeLueHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<MarquerCommeLueResponse> Handle(MarquerCommeLueCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var notification = await _repository.GetByIdAsync(request.NotificationId, cancellationToken);
            
            if (notification == null)
            {
                return new MarquerCommeLueResponse
                {
                    Success = false,
                    Message = "Notification non trouvée"
                };
            }

            notification.MarquerCommeLue();
            
            await _repository.UpdateAsync(notification, cancellationToken);
            
            return new MarquerCommeLueResponse
            {
                Id = notification.Id,
                Success = true,
                Message = "Notification marquée comme lue avec succès"
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur lors du marquage de la notification {NotificationId} comme lue", request.NotificationId);
            
            return new MarquerCommeLueResponse
            {
                Success = false,
                Message = $"Erreur lors du marquage de la notification comme lue: {ex.Message}"
            };
        }
    }
} 
