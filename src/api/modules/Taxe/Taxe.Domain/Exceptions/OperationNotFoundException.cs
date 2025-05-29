using FSH.Framework.Core.Exceptions;

namespace PayCom.WebApi.Taxe.Domain.Exceptions;

public sealed class OperationNotFoundException : NotFoundException
{
    public OperationNotFoundException(Guid? id)
        : base($"L'operation avec l'id {id} n'existe pas")
    {}
}
