using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;
using PayCom.WebApi.Taxe.Application.Paiements.Get.v1;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.Paiements.Search.v1;
public class SearchPaiementCommand : PaginationFilter, IRequest<PagedList<PaiementResponse>>
{
    public Guid Id { get; set; }
    public double Montant { get; set; }
    public ModePaiement ModePaiement { get; set; }
    public string CodeTransaction { get; set; }
    public DateTime DateTransaction { get; set; }
    public StatutPaiement Statut { get; set; }
    public double FraisTransaction { get; set; }
    public string InformationSupplementaires { get; set; }
    
}
