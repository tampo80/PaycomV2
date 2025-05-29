using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Notifications.Update.v1;
public record UpdateNotificationCommand(
    Guid? Id,
    string Type,
    DateTime DateEnvoi,
    string Contenu) : IRequest<UpdateNotificationResponse>;
