using FSH.Framework.Core.Exceptions;

namespace PayCom.WebApi.Taxe.Domain.Exceptions;

public sealed class CommuneNotFoundException : NotFoundException
{
    public CommuneNotFoundException(Guid id)
        : base($"La commune avec l'id {id} n'existe pas")
    {}
    
}
