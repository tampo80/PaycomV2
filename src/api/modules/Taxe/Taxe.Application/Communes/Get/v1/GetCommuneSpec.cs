using Ardalis.Specification;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Communes.Get.v1;
public class GetCommuneSpec : Specification<Commune, CommuneResponse>, ISingleResultSpecification
{
    public GetCommuneSpec(Guid id)
    {
        Query
            .Include(c => c.Region)
            .Where(c => c.Id == id);
            
        Query.Select(c => new CommuneResponse(
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
            c.CodeTenant,
            c.EstTenantActif,
            c.NomCentreAdmin,
            c.AdresseCentreAdmin,
            c.ContactCentreAdmin,
            c.EmailCentreAdmin,
            c.ResponsableCentreAdmin,
            c.DescriptionType));
    }
}
