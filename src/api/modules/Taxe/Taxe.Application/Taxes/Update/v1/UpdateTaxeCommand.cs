using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Taxes.Update.v1;
public record UpdateTaxeCommand(
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
    DateTime DateDerniereModification) : IRequest<UpdateTaxeResponse>;
