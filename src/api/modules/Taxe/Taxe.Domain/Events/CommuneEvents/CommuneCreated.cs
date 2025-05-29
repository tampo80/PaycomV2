using FSH.Framework.Core.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;

namespace PayCom.WebApi.Taxe.Domain.Events.CommuneEvents;

public sealed record CommuneCreated(
    Guid Id,
    string Nom,
    TypeCommune Type,
    string Code,
    int NombreSecteurs,
    int NombreArrondissements,
    string LogoUrl,
    string AdresseSiege,
    string Contact,
    string Email,
    string SiteWeb,
    Guid RegionId,
    string CodeTenant,
    bool EstTenantActif,
    string NomCentreAdmin,
    string AdresseCentreAdmin,
    string ContactCentreAdmin,
    string EmailCentreAdmin,
    string ResponsableCentreAdmin) : DomainEvent;
