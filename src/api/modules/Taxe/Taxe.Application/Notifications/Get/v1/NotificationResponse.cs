using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
namespace PayCom.WebApi.Taxe.Application.Notifications.Get.v1;

public record NotificationResponse(
    Guid? Id,
    string Type,
    DateTime DateEnvoi,
    string Contenu
);
