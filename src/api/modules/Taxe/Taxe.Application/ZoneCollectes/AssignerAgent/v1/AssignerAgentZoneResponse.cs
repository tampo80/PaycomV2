using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
namespace PayCom.WebApi.Taxe.Application.ZoneCollectes.AssignerAgent.v1;

public record AssignerAgentZoneResponse(Guid ZoneId, Guid AgentId); 
