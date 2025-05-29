using FSH.Framework.Core.Exceptions;

namespace PayCom.WebApi.Taxe.Domain.Exceptions;

public sealed class NotificationNotFoundException : NotFoundException
{
    public NotificationNotFoundException(Guid? id)
        :base($"La notification avec l'id {id} n'existe pas")
    {}
}
