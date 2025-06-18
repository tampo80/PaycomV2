using FluentValidation;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.BusinessRules;

namespace PayCom.WebApi.Taxe.Application.Paiements.Create.v1;
public class CreatePaiementCommandValidator : AbstractValidator<CreatePaiementCommand>
{
    public CreatePaiementCommandValidator()
    {
        RuleFor(p => p.Date)
            .NotEmpty()
            .WithMessage("La date du paiement est requise.");

        RuleFor(p => p.Montant)
            .NotEmpty()
            .WithMessage("Le montant du paiement est requis.")
            .Must(montant => {
                try 
                {
                    PaiementBusinessRules.ValidateMontant(montant);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            })
            .WithMessage("Le montant du paiement n'est pas valide selon les règles métier.");

        RuleFor(p => p.CodeTransaction)
            .NotEmpty()
            .WithMessage("Le code de transaction est requis.")
            .MaximumLength(100)
            .WithMessage("Le code de transaction ne peut pas dépasser 100 caractères.");

        RuleFor(p => p.ModePaiement)
            .IsInEnum()
            .WithMessage("Le mode de paiement sélectionné n'est pas valide.");

        RuleFor(p => p.Statut)
            .IsInEnum()
            .WithMessage("Le statut du paiement n'est pas valide.");

        RuleFor(p => p.DateTransaction)
            .NotEmpty()
            .WithMessage("La date de transaction est requise.");

        RuleFor(p => p.FraisTransaction)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Les frais de transaction ne peuvent pas être négatifs.");

        RuleFor(p => p.InformationsSupplementaires)
            .MaximumLength(500)
            .WithMessage("Les informations supplémentaires ne peuvent pas dépasser 500 caractères.");

        // EcheanceId peut être null pour les paiements libres - pas de validation requise
        // La relation est optionnelle en base de données
        
        // Validation des nouveaux champs obligatoires
        RuleFor(p => p.ContribuableId)
            .NotEmpty()
            .WithMessage("L'ID du contribuable est requis pour tout paiement.");
    }
}
