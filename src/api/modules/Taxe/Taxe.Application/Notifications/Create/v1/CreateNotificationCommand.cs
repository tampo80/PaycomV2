using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.Notifications.Create.v1;
public record CreateNotificationCommand(
    [property: DefaultValue("Type de notification")] string Type,
    DateTime DateEnvoi,
    [property: DefaultValue("Contenu")] string Contenu) : IRequest<CreateNotificationResponse>;
