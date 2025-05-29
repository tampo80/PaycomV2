using MediatR;

namespace PayCom.WebApi.Taxe.Application.AgentFiscals.AssocierUtilisateur.v1;

public record AssocierUtilisateurAgentCommand(
    Guid AgentId,
    Guid UtilisateurId) : IRequest<AssocierUtilisateurAgentResponse>; 
