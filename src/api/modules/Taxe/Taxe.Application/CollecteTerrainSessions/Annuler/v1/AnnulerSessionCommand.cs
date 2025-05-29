using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.CollecteTerrainSessions.Annuler.v1;
public record AnnulerSessionCommand(
    [property: DefaultValue("ID de la session")]
    Guid SessionId,
    [property: DefaultValue("Raison de l'annulation")]
    string Raison) : IRequest<AnnulerSessionResponse>; 
