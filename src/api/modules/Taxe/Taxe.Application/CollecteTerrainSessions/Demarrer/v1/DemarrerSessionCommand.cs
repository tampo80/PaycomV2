using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.CollecteTerrainSessions.Demarrer.v1;
public record DemarrerSessionCommand(Guid Id) : IRequest<DemarrerSessionResponse>; 
