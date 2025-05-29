using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.TransactionPaiements.Delete.v1;
public record DeleteTransactionPaiementCommand(Guid? Id) : IRequest;
