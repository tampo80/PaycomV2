using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.CollecteTerrainSessions.Get.v1;
public record GetCollecteTerrainSessionRequest(Guid Id) : IRequest<CollecteTerrainSessionResponse>; 
