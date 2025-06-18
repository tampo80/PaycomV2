using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.TransactionPaiements.Get.v1;

public record TransactionPaiementResponse(
    Guid Id,
    string CodeTransaction,
    DateTime DateTransaction,
    decimal Montant,
    ModePaiement ModePaiement,
    decimal Frais,
    StatutPaiement Statut,
    Guid ContribuableId,
    string? NomContribuable,
    Guid? AgentFiscalId,
    string? NomAgent,
    string? Commentaire,
    string? LocalisationGPS,
    Guid? SessionCollecteId,
    string? NotesSession,
    DateTime DateCreation,
    DateTime? DateModification,
    Guid? ObligationFiscaleId,
    bool? EstPaiementTerrain,
    string? FournisseurPaiement,
    Paiement? Paiement = null
);
