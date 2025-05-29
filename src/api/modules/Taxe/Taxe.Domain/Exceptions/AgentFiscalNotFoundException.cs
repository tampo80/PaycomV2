using FSH.Framework.Core.Exceptions;

namespace PayCom.WebApi.Taxe.Domain.Exceptions;

public sealed class AgentFiscalNotFoundException : NotFoundException
{
    public AgentFiscalNotFoundException(Guid id) 
        : base($"Agent avec cet l'id {id} n'existe pas")
    {
        
    }
    
}
