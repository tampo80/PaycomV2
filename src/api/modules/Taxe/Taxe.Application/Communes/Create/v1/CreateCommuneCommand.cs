using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.Communes.Create.v1;

public class CreateCommuneCommand : IRequest<CreateCommuneResponse>
{
    [DefaultValue("Nom de la commune")]
    public string Nom { get; set; } = string.Empty;
    
    [DefaultValue(TypeCommune.Urbaine)]
    public TypeCommune Type { get; set; } = TypeCommune.Urbaine;
    
    [DefaultValue("Code de la commune")]
    public string Code { get; set; } = string.Empty;
    
    [DefaultValue(0)]
    public int NombreSecteurs { get; set; }
    
    public int NombreArrondissements { get; set; }
    
    [DefaultValue(TypeChefLieu.Aucun)]
    public TypeChefLieu TypeChefLieu { get; set; } = TypeChefLieu.Aucun;
    
    [DefaultValue("https://example.com/logo.png")]
    public string LogoUrl { get; set; } = string.Empty;
    
    [DefaultValue("123 Rue Principale")]
    public string AdresseSiege { get; set; } = string.Empty;
    
    [DefaultValue("+123456789")]
    public string Contact { get; set; } = string.Empty;
    
    [DefaultValue("contact@commune.org")]
    public string Email { get; set; } = string.Empty;
    
    [DefaultValue("www.commune.org")]
    public string SiteWeb { get; set; } = string.Empty;
    
    public Guid RegionId { get; set; }
    
    [DefaultValue("CODE_TENANT")]
    public string CodeTenant { get; set; } = string.Empty;
    
    [DefaultValue("Centre Administratif")]
    public string NomCentreAdmin { get; set; } = string.Empty;
    
    [DefaultValue("123 Rue Administrative")]
    public string AdresseCentreAdmin { get; set; } = string.Empty;
    
    [DefaultValue("+123456789")]
    public string ContactCentreAdmin { get; set; } = string.Empty;
    
    [DefaultValue("admin@centre.org")]
    public string EmailCentreAdmin { get; set; } = string.Empty;
    
    [DefaultValue("Responsable du Centre")]
    public string ResponsableCentreAdmin { get; set; } = string.Empty;
}
