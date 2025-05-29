using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.TransactionCollectes.Get.v1;
public record GetTransactionCollecteRequest(Guid Id) : IRequest<TransactionCollecteResponse>; 
