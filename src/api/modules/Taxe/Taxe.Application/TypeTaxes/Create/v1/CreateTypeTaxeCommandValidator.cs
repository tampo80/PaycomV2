using FluentValidation;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.TypeTaxes.Create.v1;

public class CreateTypeTaxeCommandValidator : AbstractValidator<CreateTypeTaxeCommand>
{
    public CreateTypeTaxeCommandValidator()
    {
        RuleFor(p => p.Nom)
            .NotEmpty().WithMessage("Le nom du type de taxe est obligatoire")
            .MaximumLength(100).WithMessage("Le nom ne peut pas dépasser 100 caractères");
            
        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("La description du type de taxe est obligatoire")
            .MaximumLength(500).WithMessage("La description ne peut pas dépasser 500 caractères");
            
        RuleFor(p => p.MontantBase)
            .NotEmpty().WithMessage("Le montant de base est obligatoire")
            .GreaterThanOrEqualTo(0).WithMessage("Le montant de base doit être positif ou nul");
            
       
    }
    
    private bool BeValidFrequencePaiement(string frequencePaiement)
    {
        return Enum.TryParse<FrequencePaiement>(frequencePaiement, out _);
    }
} 
