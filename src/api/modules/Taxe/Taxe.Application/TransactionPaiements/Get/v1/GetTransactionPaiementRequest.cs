using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.TransactionPaiements.Get.v1;
public class GetTransactionPaiementRequest : IRequest<TransactionPaiementResponse>
{
    public Guid Id { get; set; }
    public string CodeTransaction { get; set; }
    public DateTime Date { get; set; }
    public double Montant { get; set; }
    public ModePaiement ModePaiement { get; set; }
    public double Frais { get; set; }
    public StatutPaiement Statut { get; set; }
    public Paiement Paiement { get; set; }
}
