using System.Data;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using FluentValidation;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.Contribuables.Create.v1;
public class CreateContribuableCommandValidator : AbstractValidator<CreateContribuableCommand>
{
    public CreateContribuableCommandValidator()
    {
        // Règles communes (toujours appliquées)
        RuleFor(c => c.NumeroIdentification).NotEmpty().WithMessage("Le numéro d'identification est requis.").MinimumLength(2).MaximumLength(50);
        RuleFor(c => c.Adresse).NotEmpty().WithMessage("L'adresse est requise.").MinimumLength(5).MaximumLength(200);
        RuleFor(c => c.ContactPrincipal).NotEmpty().WithMessage("Le contact principal est requis.").MinimumLength(8).MaximumLength(50);
        RuleFor(c => c.Email).EmailAddress().When(c => !string.IsNullOrEmpty(c.Email)).WithMessage("L'adresse email n'est pas valide.").MaximumLength(100);
        RuleFor(c => c.TypeActivite).NotEmpty().WithMessage("Le type d'activité est requis.").MinimumLength(2).MaximumLength(100);
        
        // Validation de la date d'enregistrement - rejeter seulement les dates manifestement invalides
        RuleFor(c => c.DateEnregistrement)
            .Must(date => date?.Year > 1900)
            .WithMessage("La date d'enregistrement doit être une date valide.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("La date d'enregistrement ne peut pas être dans le futur.");
        
        // Validation des enums - accepter toutes les valeurs définies dans l'enum (y compris 0)
        RuleFor(c => c.Statut)
            .IsInEnum().WithMessage("Le statut du contribuable doit être une valeur valide.");
            
        RuleFor(c => c.TypeContribuable)
            .IsInEnum().WithMessage("Le type de contribuable doit être une valeur valide.");

        // Règles pour Personne Physique
        When(c => c.TypeContribuable == TypeContribuable.PersonnePhysique, () =>
        {
            RuleFor(c => c.Nom).NotEmpty().WithMessage("Le nom est requis pour une personne physique.").MinimumLength(2).MaximumLength(100);
            RuleFor(c => c.Prenom).NotEmpty().WithMessage("Le prénom est requis pour une personne physique.").MinimumLength(2).MaximumLength(100);
            RuleFor(c => c.DateNaissance)
                .Must(date => date?.Year > 1900)
                .WithMessage("La date de naissance est requise pour une personne physique.")
                .LessThan(DateTime.Now).WithMessage("La date de naissance doit être dans le passé.");
            
            RuleFor(c => c.Genre)
                .IsInEnum().WithMessage("Le genre doit être une valeur valide.");
            
            // S'assurer que les champs de personne morale ne sont pas remplis inutilement
           
        });

        // Règles pour Personne Morale
        When(c => c.TypeContribuable == TypeContribuable.PersonneMorale, () =>
        {
            RuleFor(c => c.NomCommercial).NotEmpty().WithMessage("La raison sociale (nom commercial) est requise pour une personne morale.").MinimumLength(2).MaximumLength(100);
            RuleFor(c => c.NIF).NotEmpty().WithMessage("Le NIF est requis pour une personne morale.").MinimumLength(5).MaximumLength(50);
            RuleFor(c => c.NumeroRegistreCommerce).NotEmpty().WithMessage("Le numéro de registre de commerce est requis pour une personne morale.").MinimumLength(5).MaximumLength(50);
            RuleFor(c => c.FormeJuridique).NotEmpty().WithMessage("La forme juridique est requise pour une personne morale.").MinimumLength(2).MaximumLength(50);
            RuleFor(c => c.RepresentantLegal).NotEmpty().WithMessage("Le représentant légal est requis pour une personne morale.").MinimumLength(2).MaximumLength(100);
            RuleFor(c => c.DateCreationEntreprise).NotNull().WithMessage("La date de création de l'entreprise est requise pour une personne morale.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("La date de création ne peut pas être dans le futur.");
            RuleFor(c => c.SecteurActivite).NotEmpty().WithMessage("Le secteur d'activité est requis pour une personne morale.").MinimumLength(2).MaximumLength(100);

          
        });

        // Règles optionnelles communes
        RuleFor(c => c.ContactSecondaire).MaximumLength(50).When(c => !string.IsNullOrEmpty(c.ContactSecondaire));
        RuleFor(c => c.LocalisationGPS).MaximumLength(100).When(c => !string.IsNullOrEmpty(c.LocalisationGPS));
    }
}
