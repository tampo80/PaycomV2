using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
namespace PayCom.WebApi.Taxe.Application.Taxes.Get.v1;

public record TaxeResponse(
    Guid Id,
    int AnneeImposition,
    double Taux,
    DateTime DateEcheance,
    double MontantDu,
    double MontantPaye,
    double SoldeRestant,
    double PrixUnitaire,
    string UniteMesure,
    string Caracteristiques,
    DateTime DateCreation,
    DateTime DateDerniereModification);
