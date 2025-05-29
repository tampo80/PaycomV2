using FluentValidation;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.Contribuables.Update.v1;
public class UpdateContribuableCommandValidator : AbstractValidator<UpdateContribuableCommand>
{
    public UpdateContribuableCommandValidator()
    {
        // Validation de l'ID requis pour la mise à jour
        RuleFor(c => c.Id).NotEmpty().WithMessage("L'ID du contribuable est requis pour la mise à jour.");
        
        // Règles communes (toujours appliquées)
        RuleFor(c => c.NumeroIdentification).NotEmpty().WithMessage("Le numéro d'identification est requis.").MinimumLength(2).MaximumLength(50);
        RuleFor(c => c.Adresse).NotEmpty().WithMessage("L'adresse est requise.").MinimumLength(5).MaximumLength(200);
        RuleFor(c => c.ContactPrincipal).NotEmpty().WithMessage("Le contact principal est requis.").MinimumLength(8).MaximumLength(50);
        RuleFor(c => c.Email).EmailAddress().When(c => !string.IsNullOrEmpty(c.Email)).WithMessage("L'adresse email n'est pas valide.").MaximumLength(100);
        RuleFor(c => c.TypeActivite).NotEmpty().WithMessage("Le type d'activité est requis.").MinimumLength(2).MaximumLength(100);
        RuleFor(c => c.DateEnregistrement).NotEmpty().WithMessage("La date d'enregistrement est requise.");
        
        // Validation des enums requis - vérifier qu'ils ne sont pas à leur valeur par défaut
        RuleFor(c => c.Statut).NotEqual(default(StatutContribuable)).WithMessage("Le statut du contribuable est requis.");
        RuleFor(c => c.TypeContribuable).NotEqual(default(TypeContribuable)).WithMessage("Le type de contribuable est requis.");

        // Règles pour Personne Physique
        When(c => c.TypeContribuable == TypeContribuable.PersonnePhysique, () =>
        {
            RuleFor(c => c.Nom).NotEmpty().WithMessage("Le nom est requis pour une personne physique.").MinimumLength(2).MaximumLength(100);
            RuleFor(c => c.Prenom).NotEmpty().WithMessage("Le prénom est requis pour une personne physique.").MinimumLength(2).MaximumLength(100);
            RuleFor(c => c.DateNaissance).NotEqual(default(DateTime)).WithMessage("La date de naissance est requise pour une personne physique.")
                .LessThan(DateTime.Now).WithMessage("La date de naissance doit être dans le passé.");
            RuleFor(c => c.Genre).NotEqual(default(Genre)).WithMessage("Le genre est requis pour une personne physique.");
            
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
