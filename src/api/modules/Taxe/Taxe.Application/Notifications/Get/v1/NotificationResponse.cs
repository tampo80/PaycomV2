using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.Notifications.Get.v1;

public record NotificationResponse(
    Guid? Id,
    string Type,
    DateTime DateEnvoi,
    string Contenu,
    bool EstLue,
    DateTime? DateLecture,
    StatutNotification Statut,
    TypeDestinataire TypeDestinataire,
    Guid? ContribuableId,
    Guid? AgentFiscalId,
    string Titre,
    int Priorite,
    DateTime? DateExpiration,
    bool EstArchivee
);
