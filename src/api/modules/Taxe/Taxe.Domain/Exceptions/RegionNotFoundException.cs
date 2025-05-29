using FSH.Framework.Core.Exceptions;

namespace PayCom.WebApi.Taxe.Domain.Exceptions;

public sealed class RegionNotFoundException : NotFoundException
{
    public RegionNotFoundException(Guid? id)
        : base($"La region avec l'id {id} n'existe pas")
    {}
    
}
