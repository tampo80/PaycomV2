using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;

namespace PayCom.WebApi.Taxe.Application.Penalites.Get.v1;
public record PenaliteResponse(
    Guid Id,
    DateTime DateApplication,
    double Montant,
    string Type,
    string Description,
    Domain.Taxe TaxeConcernee);
