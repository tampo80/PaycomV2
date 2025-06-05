using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Application.TransactionPaiements.Get.v1;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.TransactionPaiements.Search.v1;
public class SearchTransactionPaiementCommand : PaginationFilter, IRequest<PagedList<TransactionPaiementResponse>>
{
    public Guid Id { get; set; }
    public string CodeTransaction { get; set; }
    public DateTime Date { get; set; }
    public decimal Montant { get; set; }
    public ModePaiement ModePaiement { get; set; }
    public decimal Frais { get; set; }
    public StatutPaiement Statut { get; set; } 
    public Paiement Paiement { get; set; } 
}
