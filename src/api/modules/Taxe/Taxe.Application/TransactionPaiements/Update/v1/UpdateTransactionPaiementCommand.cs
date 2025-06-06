using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.TransactionPaiements.Update.v1;
public record UpdateTransactionPaiementCommand
(
    Guid Id,
    string CodeTransaction,
    DateTime Date,
    decimal Montant,
    ModePaiement ModePaiement,
    string FournisseurPaiement,
    string NumeroReference,
    decimal Frais,
    StatutPaiement Statut,
    string ReferenceBancaire,
    string DonneesTechniques,
    Paiement Paiement
) : IRequest<UpdateTransactionPaiementResponse>;
