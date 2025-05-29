using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.ObligationFiscales.Get.v1;
public record GetObligationFiscaleRequest(Guid Id) : IRequest<ObligationFiscaleResponse>; 
