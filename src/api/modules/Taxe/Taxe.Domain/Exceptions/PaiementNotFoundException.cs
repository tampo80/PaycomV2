using FSH.Framework.Core.Exceptions;

namespace PayCom.WebApi.Taxe.Domain.Exceptions;

public sealed class PaiementNotFoundException : NotFoundException
{
    public PaiementNotFoundException(Guid id)
        : base($"Paiement avec l'id {id} n'existe pas")
    {}
}
