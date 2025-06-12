using Ardalis.Specification;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Communes.Get.v1;
public class GetCommuneByIdSpec : Specification<Commune, GetCommuneByIdResponse>, ISingleResultSpecification<Commune>
{
    public GetCommuneByIdSpec(Guid id)
    {
        Query
            .Include(c => c.Region)
            .Where(c => c.Id == id);
            
        Query.Select(c => new GetCommuneByIdResponse(
            c.Id,
            c.Nom,
            c.Type,
            c.Code,
            c.NombreSecteurs,
            c.NombreArrondissements,
            c.TypeChefLieu,
            c.LogoUrl,
            c.AdresseSiege,
            c.Contact,
            c.Email,
            c.SiteWeb,
            c.RegionId,
            c.Region != null ? c.Region.Nom : "Non défini",
            c.CodeTenant,
            c.EstTenantActif,
            c.NomCentreAdmin,
            c.AdresseCentreAdmin,
            c.ContactCentreAdmin,
            c.EmailCentreAdmin,
            c.ResponsableCentreAdmin,
            c.DescriptionType,
            c.EstChefLieuRegion));
    }
}
