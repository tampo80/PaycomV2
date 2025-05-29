using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.CollecteTerrainSessions.Create.v1;
public record CreateCollecteTerrainSessionCommand(
    DateTime DateDebut,
    [property: DefaultValue("")]
    string Description,
    Guid AgentFiscalId,
    Guid ZoneCollecteId) : IRequest<CreateCollecteTerrainSessionResponse>; 
