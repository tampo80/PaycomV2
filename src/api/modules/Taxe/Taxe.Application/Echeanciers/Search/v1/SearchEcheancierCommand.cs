using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;
using PayCom.WebApi.Taxe.Application.Echeanciers.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Echeanciers.Search.v1;
public class SearchEcheancierCommand : PaginationFilter, IRequest<PagedList<EcheancierResponse>>
{
    public Guid Id { get; set; }
    public DateTime DateEcheanc { get; set; }
    public double MontantDu { get; set; }
    public double MontantPaye { get; set; }
}
