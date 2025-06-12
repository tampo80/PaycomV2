using System.ComponentModel.DataAnnotations;
using PayCom.Blazor.Infrastructure.Api;

namespace PayCom.Blazor.Client.Pages.Parametres.Localisation.Models;

public class CommuneDto
{
    public Guid Id { get; set; }
        
    [Required(ErrorMessage = "Le nom est requis")]
    [StringLength(100, ErrorMessage = "Le nom ne doit pas dépasser 100 caractères")]
    public string Nom { get; set; } = string.Empty;
        
    [StringLength(50, ErrorMessage = "Le code ne doit pas dépasser 50 caractères")]
    public string Code { get; set; } = string.Empty;
        
    [Required(ErrorMessage = "Le type est requis")]
    public TypeCommune Type { get; set; } = TypeCommune._0;
        
    public int NombreSecteurs { get; set; } = 0;
        
    public int NombreArrondissements { get; set; } = 0;
        
    public TypeChefLieu TypeChefLieu { get; set; } = TypeChefLieu._0;
        
    public string LogoUrl { get; set; } = string.Empty;
        
    public string AdresseSiege { get; set; } = string.Empty;
        
    public string Contact { get; set; } = string.Empty;
        
    public string Email { get; set; } = string.Empty;
        
    public string SiteWeb { get; set; } = string.Empty;
        
    [Required(ErrorMessage = "La région est requise")]
    public Guid RegionId { get; set; }
        
    public string NomRegion { get; set; } = string.Empty;
        
    public string CodeTenant { get; set; } = string.Empty;
        
    public string NomCentreAdmin { get; set; } = string.Empty;
        
    public string AdresseCentreAdmin { get; set; } = string.Empty;
        
    public string ContactCentreAdmin { get; set; } = string.Empty;
        
    public string EmailCentreAdmin { get; set; } = string.Empty;
        
    public string ResponsableCentreAdmin { get; set; } = string.Empty;

    public bool EstTenantActif { get; set; }

    public DateTime CreatedOn { get; set; }
}
