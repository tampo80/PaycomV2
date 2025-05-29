using FSH.Framework.Core.Exceptions;

namespace PayCom.WebApi.Taxe.Domain.Exceptions;

public sealed class PrefectureNotFoundException : NotFoundException
{
    public PrefectureNotFoundException(Guid? id)
        : base($"La prefecture avec l'id {id} n'existe pas")
    {}
}
