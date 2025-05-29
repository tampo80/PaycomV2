using FluentValidation;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Taxes.Create.v1;
public class CreateTaxeCommandValidator : AbstractValidator<CreateTaxeCommand>
{
    public CreateTaxeCommandValidator()
    {
        RuleFor(p => p.AnneeImposition).NotEmpty();
        RuleFor(p => p.Taux).NotEmpty();
        RuleFor(p => p.DateEcheance).NotEmpty();
        RuleFor(p => p.MontantDu).NotEmpty();
        RuleFor(p => p.MontantPaye).NotEmpty();
        RuleFor(p => p.SoldeRestant).NotEmpty();
        RuleFor(p => p.PrixUnitaire).NotEmpty();
        RuleFor(p => p.UniteMesure).NotEmpty();
        RuleFor(p => p.Caracteristiques)
            .NotEmpty();
        RuleFor(p => p.DateCreation).NotEmpty();
        RuleFor(p => p.DateDerniereModification).NotEmpty();
    }
}
