using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.TransactionCollectes.Synchroniser.v1;
public record SynchroniserTransactionCommand(Guid Id) : IRequest<SynchroniserTransactionResponse>; 
