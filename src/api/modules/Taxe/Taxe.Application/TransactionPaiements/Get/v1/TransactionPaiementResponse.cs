using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.TransactionPaiements.Get.v1;
public record TransactionPaiementResponse(
    Guid Id,
    string CodeTransaction,
    DateTime Date,
    double Montant,
    ModePaiement ModePaiement,
    double Frais,
    StatutPaiement Statut,
    Paiement Paiement);
