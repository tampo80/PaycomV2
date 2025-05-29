using FSH.Framework.Core.Exceptions;

namespace PayCom.WebApi.Taxe.Domain.Exceptions;

public sealed class PenaliteNotFoundException : NotFoundException
{
    public PenaliteNotFoundException(Guid id)
        : base($"La penalite avec l'id {id} n'existe pas")
    {}
    
}
