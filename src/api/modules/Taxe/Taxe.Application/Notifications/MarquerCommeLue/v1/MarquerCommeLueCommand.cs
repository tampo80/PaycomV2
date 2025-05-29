using MediatR;

namespace PayCom.WebApi.Taxe.Application.Notifications.MarquerCommeLue.v1;

public class MarquerCommeLueCommand : IRequest<MarquerCommeLueResponse>
{
    public Guid NotificationId { get; set; }
}

public class MarquerCommeLueResponse
{
    public Guid Id { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
} 
