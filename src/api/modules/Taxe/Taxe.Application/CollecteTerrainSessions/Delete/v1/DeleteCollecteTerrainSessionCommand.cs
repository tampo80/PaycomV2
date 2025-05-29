using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.CollecteTerrainSessions.Delete.v1;
public record DeleteCollecteTerrainSessionCommand(Guid Id) : IRequest; 
