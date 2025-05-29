using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Echeances.Get.v1;
public record GetEcheanceRequest(Guid Id) : IRequest<EcheanceResponse>; 
