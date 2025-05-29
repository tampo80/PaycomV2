using Ardalis.Specification;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Communes.Update.v1;
public sealed class RegionsWithChefLieuSpec : Specification<Region>
{
    public RegionsWithChefLieuSpec(Guid communeId)
    {
        Query.Where(r => r.ChefLieuId == communeId);
    }
} 
