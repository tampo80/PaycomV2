using System.ComponentModel.DataAnnotations;

namespace PayCom.Blazor.Client.Pages.Taxes.Models;

public class TypeTaxeDto
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Le nom est requis")]
    [StringLength(100, ErrorMessage = "Le nom ne doit pas dépasser 100 caractères")]
    public string Nom { get; set; } = string.Empty;

    [Required(ErrorMessage = "La description est requise")]
    [StringLength(500, ErrorMessage = "La description ne doit pas dépasser 500 caractères")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le montant de base est requis")]
    [Range(0, double.MaxValue, ErrorMessage = "Le montant de base doit être supérieur ou égal à 0")]
    public decimal MontantBase { get; set; }

    [Required(ErrorMessage = "La fréquence de paiement est requise")]
    [StringLength(50, ErrorMessage = "La fréquence de paiement ne doit pas dépasser 50 caractères")]
    public string FrequencePaiement { get; set; } = string.Empty;
} 
