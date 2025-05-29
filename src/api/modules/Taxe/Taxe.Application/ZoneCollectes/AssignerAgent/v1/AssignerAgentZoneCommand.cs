using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.ZoneCollectes.AssignerAgent.v1;
public record AssignerAgentZoneCommand(Guid ZoneId, Guid AgentId) : IRequest<AssignerAgentZoneResponse>; 
