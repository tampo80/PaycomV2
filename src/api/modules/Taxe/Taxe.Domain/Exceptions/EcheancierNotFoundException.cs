using FSH.Framework.Core.Exceptions;

namespace PayCom.WebApi.Taxe.Domain.Exceptions;

public sealed class EcheancierNotFoundException : NotFoundException
{
    public EcheancierNotFoundException(Guid id)
        : base($"Echeancier avec l'id {id} n'existe pas")
    {}
    
    
}
