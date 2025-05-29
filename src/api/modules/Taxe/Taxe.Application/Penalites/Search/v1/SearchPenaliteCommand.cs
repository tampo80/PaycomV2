using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Application.Penalites.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Penalites.Search.v1;
public class SearchPenaliteCommand : PaginationFilter, IRequest<PagedList<PenaliteResponse>>
{
    public Guid Id { get; set; }
    public DateTime DateApplication { get; set; }
    public double Montant { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public Domain.Taxe TaxeConcernee { get; set; }
    
}
