using FSH.Framework.Core.Exceptions;

namespace PayCom.WebApi.Taxe.Domain.Exceptions;

public sealed class VilleNotFoundException : NotFoundException
{
    public VilleNotFoundException(Guid? id)
        : base($"La ville avec l'id {id} n'existe pas")
    {}
}
