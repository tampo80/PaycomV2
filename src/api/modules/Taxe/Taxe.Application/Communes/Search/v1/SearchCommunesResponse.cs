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
public record CommuneDto(
    Guid Id,
    string Nom,
    TypeCommune Type,
    string Code,
    int NombreSecteurs,
    int NombreArrondissements,
    TypeChefLieu TypeChefLieu,
    string LogoUrl,
    string AdresseSiege,
    string Contact,
    string Email,
    string SiteWeb,
    Guid RegionId,
    string NomRegion,
    string CodeTenant,
    bool EstTenantActif,
    string NomCentreAdmin,
    string AdresseCentreAdmin,
    string ContactCentreAdmin,
    string EmailCentreAdmin,
    string ResponsableCentreAdmin,
    string DescriptionType,
    bool EstChefLieuRegion);
