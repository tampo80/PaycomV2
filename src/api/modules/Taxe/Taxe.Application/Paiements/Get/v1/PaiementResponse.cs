using Shared.Enums;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Paiements.Get.v1;
public record PaiementResponse(
    Guid Id,
    DateTime Date,
    decimal Montant,
    ModePaiement ModePaiement,
    string CodeTransaction,
    DateTime DateTransaction,
    StatutPaiement Status,
    decimal FraisTransaction,
    string InformationsSupplementaires,
    Guid ContribuableId,
    Guid? EcheanceId,
    Guid? AgentFiscalId,
    string? ContribuableNom = null,
    string? TypeTaxeNom = null,
    string? AgentFiscalNom = null);
