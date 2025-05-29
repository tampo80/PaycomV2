using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.CollecteTerrainSessions.Update.v1;
public record UpdateCollecteTerrainSessionCommand(
    [property: DefaultValue("Id de la session")]
    Guid Id,
    [property: DefaultValue("Description de la session")]
    string Description) : IRequest<UpdateCollecteTerrainSessionResponse>; 
