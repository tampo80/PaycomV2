using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;


namespace PayCom.WebApi.Taxe.Application.Communes.Search.v1;
public record SearchCommunesResponse(
    IReadOnlyList<CommuneDto> Items,
    int PageNumber,
    int PageSize,
    int TotalCount,
    int TotalPages);

public class CommuneDto
{
    public Guid Id { get; set; }
    public string Nom { get; set; }
    public TypeCommune Type { get; set; }
    public string Code { get; set; }
    public int NombreSecteurs { get; set; }
    public int NombreArrondissements { get; set; }
    public TypeChefLieu TypeChefLieu { get; set; }
    public string LogoUrl { get; set; }
    public string AdresseSiege { get; set; }
    public string Contact { get; set; }
    public string Email { get; set; }
    public string SiteWeb { get; set; }
    public Guid RegionId { get; set; }
    public string NomRegion { get; set; }
    public string CodeTenant { get; set; }
    public bool EstTenantActif { get; set; }
    public string NomCentreAdmin { get; set; }
    public string AdresseCentreAdmin { get; set; }
    public string ContactCentreAdmin { get; set; }
    public string EmailCentreAdmin { get; set; }
    public string ResponsableCentreAdmin { get; set; }
    public string DescriptionType { get; set; }
    public bool EstChefLieuRegion { get; set; }
}
