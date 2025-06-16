using FluentValidation;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.TypeTaxes.Create.v1;

public sealed class CreateTypeTaxeCommandValidator : AbstractValidator<CreateTypeTaxeCommand>
{
    public CreateTypeTaxeCommandValidator()
    {
        RuleFor(p => p.Nom)
            .NotEmpty().WithMessage("Le nom du type de taxe est obligatoire")
            .MaximumLength(100).WithMessage("Le nom ne peut pas dépasser 100 caractères");
            
        RuleFor(p => p.Description)
            .MaximumLength(500).WithMessage("La description ne peut pas dépasser 500 caractères");
            
        RuleFor(p => p.MontantBase)
            .GreaterThanOrEqualTo(0).WithMessage("Le montant de base doit être positif ou nul");
            
        RuleFor(p => p.FrequencePaiement)
            .IsInEnum().WithMessage("La fréquence de paiement doit être valide");
            
        RuleFor(p => p.UniteMesure)
            .IsInEnum().WithMessage("L'unité de mesure doit être valide");
    }
} 
