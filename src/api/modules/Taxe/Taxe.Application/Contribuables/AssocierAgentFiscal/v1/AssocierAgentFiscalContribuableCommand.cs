using MediatR;

namespace PayCom.WebApi.Taxe.Application.Contribuables.AssocierAgentFiscal.v1;

public record AssocierAgentFiscalContribuableCommand(Guid ContribuableId, Guid AgentFiscalId) : IRequest<AssocierAgentFiscalContribuableResponse>; 
