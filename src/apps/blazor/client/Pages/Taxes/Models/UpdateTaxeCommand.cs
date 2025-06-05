using System.ComponentModel.DataAnnotations;

namespace PayCom.Blazor.Client.Pages.Taxes.Models;

public class UpdateTaxeCommand
{
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public int AnneeImposition { get; set; }
    
    [Required]
    [Range(0, 100)]
    public decimal Taux { get; set; }
    
    [Required]
    public DateTime DateEcheance { get; set; }
    
    [Required]
    [Range(0, double.MaxValue)]
    public decimal MontantDu { get; set; }
    
    [Range(0, double.MaxValue)]
    public decimal MontantPaye { get; set; }
    
    [Range(0, double.MaxValue)]
    public decimal SoldeRestant { get; set; }
    
    [Required]
    [Range(0, double.MaxValue)]
    public decimal PrixUnitaire { get; set; }
    
    [Required]
    public string UniteMesure { get; set; } = string.Empty;
    
    public string Caracteristiques { get; set; } = string.Empty;
    
    [Required]
    public Guid? TypeTaxeId { get; set; }
    
    [Required]
    public Guid? ContribuableId { get; set; }
} 
