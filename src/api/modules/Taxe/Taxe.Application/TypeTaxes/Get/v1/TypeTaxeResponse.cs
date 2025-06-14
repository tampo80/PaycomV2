using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.TypeTaxes.Get.v1;

public record TypeTaxeResponse(
    Guid Id,
    string Code,
    string Nom,
    string Description,
    bool EstPeriodique,
    FrequencePaiement FrequencePaiement,
    double MontantBase,
    UniteMesure UniteMesure,
    bool NecessiteInspection,
    DateTime DateCreation,
    DateTime DateDerniereModification); 
