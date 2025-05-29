using FSH.Framework.Core.Exceptions;

namespace PayCom.WebApi.Taxe.Domain.Exceptions;

public sealed class ContribuableNotFoundException : NotFoundException
{
    public ContribuableNotFoundException(Guid id)
        : base($"Le contribuable avec l'id {id} n'existe pas")
    {}
}
