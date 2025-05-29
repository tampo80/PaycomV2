using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.ZoneCollectes.Delete.v1;
public record DeleteZoneCollecteCommand(Guid Id) : IRequest; 
