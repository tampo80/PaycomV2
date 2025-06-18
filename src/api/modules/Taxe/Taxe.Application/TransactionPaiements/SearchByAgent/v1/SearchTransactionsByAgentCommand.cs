using FSH.Framework.Core.Paging;
using MediatR;
using PayCom.WebApi.Taxe.Application.TransactionPaiements.Get.v1;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.TransactionPaiements.SearchByAgent.v1;

public class SearchTransactionsByAgentCommand : PaginationFilter, IRequest<PagedList<TransactionPaiementResponse>>
{
    public Guid? AgentFiscalId { get; set; }
    public Guid? ContribuableId { get; set; }
    public DateTime? DateDebut { get; set; }
    public DateTime? DateFin { get; set; }
    public ModePaiement? ModePaiement { get; set; }
    public StatutPaiement? Statut { get; set; }
    public decimal? MontantMin { get; set; }
    public decimal? MontantMax { get; set; }
    public string? SearchTerm { get; set; }
}
