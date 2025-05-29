using Shared.Enums;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Paiements.Get.v1;
public record PaiementResponse(
    Guid Id,
    DateTime Date,
    double Montant,
    ModePaiement ModePaiement,
    string CodeTransaction,
    DateTime DateTransaction,
    double FraisTransaction,
    string InformationsSupplementaires,
    StatutPaiement Status);
