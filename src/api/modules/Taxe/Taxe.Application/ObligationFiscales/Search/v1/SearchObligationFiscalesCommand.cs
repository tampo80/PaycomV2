using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using FSH.Framework.Core.Paging;
using MediatR;
using PayCom.WebApi.Taxe.Application.ObligationFiscales.Get.v1;

namespace PayCom.WebApi.Taxe.Application.ObligationFiscales.Search.v1;

public class SearchObligationFiscalesCommand : PaginationFilter, IRequest<PagedList<ObligationFiscaleResponse>>
{
    public Guid? ContribuableId { get; set; }
    public Guid? TypeTaxeId { get; set; }
    public Guid? CommuneId { get; set; }
    public bool? EstActif { get; set; } = true;
    public DateTime? DateDebutMin { get; set; }
    public DateTime? DateDebutMax { get; set; }
    public DateTime? DateFinMin { get; set; }
    public DateTime? DateFinMax { get; set; }
    public string? ReferenceProprieteBien { get; set; }
    public decimal? MontantMin { get; set; }
    public decimal? MontantMax { get; set; }
    public bool IncludeInactives { get; set; } = false;
} 
