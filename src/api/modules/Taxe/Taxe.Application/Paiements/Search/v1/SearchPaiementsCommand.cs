using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;
using PayCom.WebApi.Taxe.Application.Paiements.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Paiements.Search.v1;
public class SearchPaiementsCommand : PaginationFilter, IRequest<PagedList<PaiementResponse>>
{
    public string? Reference { get; init; }
    public string? ModePaiement { get; init; }
    public double? MontantMin { get; init; }
    public double? MontantMax { get; init; }
    public DateTime? DateDebut { get; init; }
    public DateTime? DateFin { get; init; }
} 
