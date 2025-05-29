using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.ZoneCollectes.DesassignerAgent.v1;
public record DesassignerAgentZoneCommand(Guid ZoneId, Guid AgentId) : IRequest; 
