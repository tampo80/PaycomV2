using FSH.Framework.Core.Exceptions;

namespace PayCom.WebApi.Taxe.Domain.Exceptions;

public sealed class VillageNotFoundException : NotFoundException
{
    public VillageNotFoundException(Guid? id)
        : base($"Le village avec l'id {id} n'existe pas")
    {}
    
}
