using FSH.Framework.Core.Exceptions;

namespace PayCom.WebApi.Taxe.Domain.Exceptions;

public sealed class TransactionPaiementNotFoundException : NotFoundException
{
    public TransactionPaiementNotFoundException(Guid? id)
        : base($"La transaction avec l'id {id} n'existe pas")
    {}
    
}
