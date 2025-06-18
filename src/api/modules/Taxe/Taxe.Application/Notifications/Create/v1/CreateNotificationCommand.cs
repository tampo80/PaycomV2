using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.Notifications.Create.v1;
public record CreateNotificationCommand(
    [property: DefaultValue("Type de notification")] string Type,
    DateTime DateEnvoi,
    [property: DefaultValue("Contenu")] string Contenu,
    [property: DefaultValue(TypeDestinataire.ContribuableSpecifique)] TypeDestinataire TypeDestinataire,
    Guid? ContribuableId = null,
    Guid? AgentFiscalId = null,
    [property: DefaultValue("Titre de la notification")] string Titre = "",
    [property: DefaultValue(1)] int Priorite = 1,
    DateTime? DateExpiration = null) : IRequest<CreateNotificationResponse>;
