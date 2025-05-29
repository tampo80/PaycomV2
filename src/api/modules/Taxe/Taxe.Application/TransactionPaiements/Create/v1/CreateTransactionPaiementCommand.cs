using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using PayCom.WebApi.Taxe.Domain;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.TransactionPaiements.Create.v1;
public record CreateTransactionPaiementCommand(
    [property: DefaultValue("code de transaction")]
    string CodeTransaction,
    [property: DefaultValue("2025-01-01")]
    DateTime Date,
    [property: DefaultValue(1000.0)] 
    double Montant,
    [property: DefaultValue(ModePaiement.MobileMoney)] 
    ModePaiement ModePaiement,
    [property: DefaultValue("Orange")] 
    string FournisseurPaiement,
    [property: DefaultValue("0123456789")] 
    string NumeroReference,
    [property: DefaultValue(10.0)] 
    double Frais,
    [property: DefaultValue(StatutPaiement.Reussi)] 
    StatutPaiement Statut,
    [property: DefaultValue("REF123456789")] 
    string ReferenceBancaire,
    [property: DefaultValue("{}")] 
    string DonneesTechniques,
    [property: DefaultValue(null)] 
    Paiement Paiement
) : IRequest<CreateTransactionPaiementResponse>;
