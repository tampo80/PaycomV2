using FSH.Framework.Core.Exceptions;

namespace PayCom.WebApi.Taxe.Domain.Exceptions;

public sealed class ConfigurationNotFoundException : NotFoundException
{
    public ConfigurationNotFoundException(Guid id)
        :base($"La configuration avec l'id {id} n'existe pas")
    {}
    
}
