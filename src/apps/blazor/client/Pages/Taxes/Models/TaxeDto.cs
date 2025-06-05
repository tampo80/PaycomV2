using System.ComponentModel.DataAnnotations;

namespace PayCom.Blazor.Client.Pages.Taxes.Models;

public class TaxeDto
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "L'année d'imposition est requise")]
    [Range(2000, 2100, ErrorMessage = "L'année d'imposition doit être comprise entre 2000 et 2100")]
    public int AnneeImposition { get; set; } = DateTime.Now.Year;

    [Required(ErrorMessage = "Le taux est requis")]
    [Range(0, 100, ErrorMessage = "Le taux doit être compris entre 0 et 100")]
    public decimal Taux { get; set; }

    [Required(ErrorMessage = "La date d'échéance est requise")]
    public DateTime DateEcheance { get; set; } = DateTime.Now.AddMonths(1);

    [Required(ErrorMessage = "Le montant dû est requis")]
    [Range(0, double.MaxValue, ErrorMessage = "Le montant dû doit être supérieur ou égal à 0")]
    public decimal MontantDu { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Le montant payé doit être supérieur ou égal à 0")]
    public decimal MontantPaye { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Le solde restant doit être supérieur ou égal à 0")]
    public decimal SoldeRestant { get; set; }

    [Required(ErrorMessage = "Le prix unitaire est requis")]
    [Range(0, double.MaxValue, ErrorMessage = "Le prix unitaire doit être supérieur ou égal à 0")]
    public decimal PrixUnitaire { get; set; }

    [Required(ErrorMessage = "L'unité de mesure est requise")]
    [StringLength(50, ErrorMessage = "L'unité de mesure ne doit pas dépasser 50 caractères")]
    public string UniteMesure { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "Les caractéristiques ne doivent pas dépasser 500 caractères")]
    public string Caracteristiques { get; set; } = string.Empty;
    
    // Relations
    public Guid? TypeTaxeId { get; set; }
    public string TypeTaxeNom { get; set; } = string.Empty;
    
    public Guid? ContribuableId { get; set; }
    public string ContribuableNom { get; set; } = string.Empty;
} 
