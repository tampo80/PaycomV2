using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
namespace PayCom.WebApi.Taxe.Application.Echeances.Get.v1;

public record EcheanceResponse(
    Guid Id,
    Guid ObligationFiscaleId,
    DateTime DateEcheance,
    decimal MontantDu,
    decimal MontantPaye,
    decimal MontantRestant,
    string Statut); 
