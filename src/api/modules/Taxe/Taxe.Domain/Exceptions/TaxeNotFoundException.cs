using FSH.Framework.Core.Exceptions;

namespace PayCom.WebApi.Taxe.Domain.Exceptions;

public sealed class TaxeNotFoundException : NotFoundException
{
    public TaxeNotFoundException(Guid? id)
        : base($"La taxe avec l'id {id} n'existe pas")
    {}
    
}
