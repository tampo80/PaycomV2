using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
namespace PayCom.WebApi.Taxe.Application.TransactionCollectes.Get.v1;

public record TransactionCollecteResponse(
    Guid Id,
    Guid EcheanceId,
    Guid? SessionId,
    decimal MontantPaye,
    string ModePaiement,
    string? ReferencePaiement,
    string? Notes,
    DateTime DateTransaction,
    bool EstSynchronise); 
