using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;
using PayCom.WebApi.Taxe.Application.Penalites.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Penalites.Search.v1;
public class SearchPenalitesCommand : PaginationFilter, IRequest<PagedList<PenaliteResponse>>
{
    public string? Libelle { get; init; }
    public double? Montant { get; init; }
    public string? Type { get; init; }
} 
