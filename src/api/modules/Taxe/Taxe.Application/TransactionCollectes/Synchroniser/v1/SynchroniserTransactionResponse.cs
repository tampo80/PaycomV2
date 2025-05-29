using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
namespace PayCom.WebApi.Taxe.Application.TransactionCollectes.Synchroniser.v1;

public record SynchroniserTransactionResponse(Guid Id, bool EstSynchronise); 
