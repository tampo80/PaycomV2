using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.Notifications.Update.v1;
public record UpdateNotificationCommand(
    Guid? Id,
    string Type,
    DateTime DateEnvoi,
    string Contenu,
    TypeDestinataire? TypeDestinataire = null,
    Guid? ContribuableId = null,
    string Titre = "",
    int? Priorite = null,
    DateTime? DateExpiration = null) : IRequest<UpdateNotificationResponse>;
