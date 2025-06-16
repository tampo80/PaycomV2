using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;
using PayCom.WebApi.Taxe.Application.Penalites.Get.v1;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.Penalites.Search.v1;

public class SearchPenalitesCommand : PaginationFilter, IRequest<PagedList<PenaliteResponse>>
{
    public Guid? ObligationFiscaleId { get; set; }
    public Guid? EcheanceId { get; set; }
    public Guid? ContribuableId { get; set; }
    public TypePenalite? TypePenalite { get; set; }
    public StatutPenalite? Statut { get; set; }
    public DateTime? DateCalculMin { get; set; }
    public DateTime? DateCalculMax { get; set; }
    public DateTime? DateApplicationMin { get; set; }
    public DateTime? DateApplicationMax { get; set; }
    public decimal? MontantMin { get; set; }
    public decimal? MontantMax { get; set; }
    public bool? EstAnnulee { get; set; }
    public bool IncludeAnnulees { get; set; } = false;
} 
