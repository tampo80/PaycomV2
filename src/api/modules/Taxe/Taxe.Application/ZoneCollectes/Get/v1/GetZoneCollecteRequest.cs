using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.ZoneCollectes.Get.v1;
public record GetZoneCollecteRequest(Guid Id) : IRequest<GetZoneCollecteResponse>; 
