using System;
using System.ComponentModel.DataAnnotations;

namespace PayCom.Blazor.Client.Pages.Contribuables.Models
{
    // Définition des énumérations partagées
    public enum GenreType
    {
        Homme = 0,
        Femme = 1
    }

    public enum StatutContribuableType
    {
        Actif = 0,
        Inactif = 1,
        EnAttente = 2
    }

    public enum TypeContribuableType
    {
        PersonnePhysique = 0,
        PersonneMorale = 1
    }

    // Attribut de validation personnalisé pour les champs obligatoires uniquement pour les personnes physiques
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RequiredForPersonnePhysiqueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var contribuable = (ContribuableDto)validationContext.ObjectInstance;
            
            if (contribuable.TypeContribuable == TypeContribuableType.PersonnePhysique)
            {
                if (value == null || (value is string stringValue && string.IsNullOrWhiteSpace(stringValue)))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            
            return ValidationResult.Success;
        }
    }

    // Attribut de validation personnalisé pour les champs obligatoires uniquement pour les personnes morales
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RequiredForPersonneMoraleAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var contribuable = (ContribuableDto)validationContext.ObjectInstance;
            
            if (contribuable.TypeContribuable == TypeContribuableType.PersonneMorale)
            {
                if (value == null || (value is string stringValue && string.IsNullOrWhiteSpace(stringValue)))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            
            return ValidationResult.Success;
        }
    }

    // DTO pour les contribuables
    public class ContribuableDto
    {
        public Guid Id { get; set; }
        
        // Champs spécifiques aux personnes physiques
        [RequiredForPersonnePhysique(ErrorMessage = "Le nom est requis pour une personne physique")]
        [StringLength(100, ErrorMessage = "Le nom ne doit pas dépasser 100 caractères")]
        public string Nom { get; set; } = string.Empty;
        
        [RequiredForPersonnePhysique(ErrorMessage = "Le prénom est requis pour une personne physique")]
        [StringLength(100, ErrorMessage = "Le prénom ne doit pas dépasser 100 caractères")]
        public string Prenom { get; set; } = string.Empty;
        
        [RequiredForPersonnePhysique(ErrorMessage = "La date de naissance est requise pour une personne physique")]
        public DateTime? DateNaissance { get; set; } = DateTime.Now.AddYears(-30);
        
        [RequiredForPersonnePhysique(ErrorMessage = "Le genre est requis pour une personne physique")]
        public GenreType? Genre { get; set; } = GenreType.Homme;
        
        // Type de contribuable (personne physique ou morale)
        [Required(ErrorMessage = "Le type de contribuable est requis")]
        public TypeContribuableType TypeContribuable { get; set; } = TypeContribuableType.PersonnePhysique;
        
        // Champs spécifiques aux personnes morales
        [RequiredForPersonneMorale(ErrorMessage = "La raison sociale est requise pour une personne morale")]
        [StringLength(100, ErrorMessage = "La raison sociale ne doit pas dépasser 100 caractères")]
        public string RaisonSociale { get; set; } = string.Empty;
        
        [RequiredForPersonneMorale(ErrorMessage = "Le RCCM est requis pour une personne morale")]
        [StringLength(50, ErrorMessage = "Le RCCM ne doit pas dépasser 50 caractères")]
        public string RCCM { get; set; } = string.Empty;
        
        [RequiredForPersonneMorale(ErrorMessage = "Le NIF est requis pour une personne morale")]
        [StringLength(50, ErrorMessage = "Le NIF ne doit pas dépasser 50 caractères")]
        public string NIF { get; set; } = string.Empty;
        
        [RequiredForPersonneMorale(ErrorMessage = "La date de création est requise pour une personne morale")]
        public DateTime? DateCreationEntreprise { get; set; } = DateTime.Now.AddYears(-1);
        
        [RequiredForPersonneMorale(ErrorMessage = "Le secteur d'activité est requis pour une personne morale")]
        [StringLength(100, ErrorMessage = "Le secteur d'activité ne doit pas dépasser 100 caractères")]
        public string SecteurActivite { get; set; } = string.Empty;
        
        public decimal? CapitalSocial { get; set; }
        
        [RequiredForPersonneMorale(ErrorMessage = "La forme juridique est requise pour une personne morale")]
        [StringLength(50, ErrorMessage = "La forme juridique ne doit pas dépasser 50 caractères")]
        public string FormeJuridique { get; set; } = string.Empty;
        
        [RequiredForPersonneMorale(ErrorMessage = "Le représentant légal est requis pour une personne morale")]
        [StringLength(100, ErrorMessage = "Le nom du représentant légal ne doit pas dépasser 100 caractères")]
        public string RepresentantLegal { get; set; } = string.Empty;
        
        // Champs communs
        [Required(ErrorMessage = "Le numéro d'identification est requis")]
        [StringLength(50, ErrorMessage = "Le numéro d'identification ne doit pas dépasser 50 caractères")]
        public string NumeroIdentification { get; set; } = string.Empty;
        
        [StringLength(100, ErrorMessage = "Le nom commercial ne doit pas dépasser 100 caractères")]
        public string NomCommercial { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "L'adresse est requise")]
        [StringLength(200, ErrorMessage = "L'adresse ne doit pas dépasser 200 caractères")]
        public string Adresse { get; set; } = string.Empty;
        
        public string LocalisationGPS { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Le type d'activité est requis")]
        [StringLength(100, ErrorMessage = "Le type d'activité ne doit pas dépasser 100 caractères")]
        public string TypeActivite { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Le contact principal est requis")]
        [StringLength(50, ErrorMessage = "Le contact principal ne doit pas dépasser 50 caractères")]
        public string ContactPrincipal { get; set; } = string.Empty;
        
        [StringLength(50, ErrorMessage = "Le contact secondaire ne doit pas dépasser 50 caractères")]
        public string ContactSecondaire { get; set; } = string.Empty;
        
        [StringLength(100, ErrorMessage = "L'email ne doit pas dépasser 100 caractères")]
        [EmailAddress(ErrorMessage = "Format d'email invalide")]
        public string Email { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "La date d'enregistrement est requise")]
        public DateTime? DateEnregistrement { get; set; } = DateTime.Now;
        
        [Required(ErrorMessage = "Le statut du contribuable est requis")]
        public StatutContribuableType Statut { get; set; } = StatutContribuableType.Actif;
        
        // Association avec un utilisateur
        public Guid? UtilisateurId { get; set; }
        
        // Association avec un agent fiscal
        public Guid? AgentFiscalId { get; set; }
    }

    // Méthodes d'extension pour la conversion entre les énumérations API et locales
    public static class EnumExtensions
    {
        public static GenreType MapGenre(PayCom.Blazor.Infrastructure.Api.Genre apiGenre)
        {
            return apiGenre switch
            {
                PayCom.Blazor.Infrastructure.Api.Genre._0 => GenreType.Homme,
                PayCom.Blazor.Infrastructure.Api.Genre._1 => GenreType.Femme,
                _ => GenreType.Homme
            };
        }

        public static StatutContribuableType MapStatut(PayCom.Blazor.Infrastructure.Api.StatutContribuable apiStatut)
        {
            return apiStatut switch
            {
                PayCom.Blazor.Infrastructure.Api.StatutContribuable._0 => StatutContribuableType.Actif,
                PayCom.Blazor.Infrastructure.Api.StatutContribuable._1 => StatutContribuableType.Inactif,
                PayCom.Blazor.Infrastructure.Api.StatutContribuable._2 => StatutContribuableType.EnAttente,
                _ => StatutContribuableType.Actif
            };
        }

        public static TypeContribuableType MapTypeContribuable(PayCom.Blazor.Infrastructure.Api.TypeContribuable apiType)
        {
            return apiType switch
            {
                PayCom.Blazor.Infrastructure.Api.TypeContribuable._0 => TypeContribuableType.PersonnePhysique,
                PayCom.Blazor.Infrastructure.Api.TypeContribuable._1 => TypeContribuableType.PersonneMorale,
                _ => TypeContribuableType.PersonnePhysique
            };
        }

        public static PayCom.Blazor.Infrastructure.Api.Genre MapToApiGenre(GenreType localGenre)
        {
            return localGenre switch
            {
                GenreType.Homme => PayCom.Blazor.Infrastructure.Api.Genre._0,
                GenreType.Femme => PayCom.Blazor.Infrastructure.Api.Genre._1,
                _ => PayCom.Blazor.Infrastructure.Api.Genre._0
            };
        }

        public static PayCom.Blazor.Infrastructure.Api.StatutContribuable MapToApiStatut(StatutContribuableType localStatut)
        {
            return localStatut switch
            {
                StatutContribuableType.Actif => PayCom.Blazor.Infrastructure.Api.StatutContribuable._0,
                StatutContribuableType.Inactif => PayCom.Blazor.Infrastructure.Api.StatutContribuable._1,
                StatutContribuableType.EnAttente => PayCom.Blazor.Infrastructure.Api.StatutContribuable._2,
                _ => PayCom.Blazor.Infrastructure.Api.StatutContribuable._0
            };
        }

        public static PayCom.Blazor.Infrastructure.Api.TypeContribuable MapToApiTypeContribuable(TypeContribuableType localType)
        {
            return localType switch
            {
                TypeContribuableType.PersonnePhysique => PayCom.Blazor.Infrastructure.Api.TypeContribuable._0,
                TypeContribuableType.PersonneMorale => PayCom.Blazor.Infrastructure.Api.TypeContribuable._1,
                _ => PayCom.Blazor.Infrastructure.Api.TypeContribuable._0
            };
        }
    }
} 
