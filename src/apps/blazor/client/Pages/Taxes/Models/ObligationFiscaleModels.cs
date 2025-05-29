using System;
using System.ComponentModel.DataAnnotations;

namespace PayCom.Blazor.Client.Pages.Taxes.Models
{
    // DTO pour les obligations fiscales
    public class ObligationFiscaleDto
    {
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Le contribuable est requis")]
        public Guid ContribuableId { get; set; }
        public string NomContribuable { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Le type de taxe est requis")]
        public Guid TypeTaxeId { get; set; }
        public string NomTypeTaxe { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "La date de début est requise")]
        public DateTime DateDebut { get; set; } = DateTime.Now;
        
        public DateTime? DateFin { get; set; }
        
        public decimal MontantCalcule { get; set; }
        
        public decimal? MontantPersonnalise { get; set; }
        
        public bool EstActif { get; set; } = true;
        
        public string FrequencePaiement { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
    }

    // DTO simplifié pour les références de type de taxe
    public class TypeTaxeRefDto
    {
        public Guid Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal MontantBase { get; set; }
        public string FrequencePaiement { get; set; } = string.Empty;
    }

    // DTO simplifié pour les références de contribuable
    public class ContribuableRefDto
    {
        public Guid Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public string NumeroIdentification { get; set; } = string.Empty;
        
        // Propriété calculée pour afficher le nom complet
        public string NomComplet => $"{Nom} {Prenom}";
    }
} 
