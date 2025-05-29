using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain.Events.PrefectureEvents;

namespace PayCom.WebApi.Taxe.Application.Prefectures.EventHandler;
public class PrefectureEventHandler(ILogger<PrefectureEventHandler> logger)
: INotificationHandler<PrefectureCreated>
{
    public async Task Handle(PrefectureCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("gesion de penalité crée..");
        await Task.FromResult(notification);
        logger.LogInformation("gestion de penalité terminéé..");
    }
}
