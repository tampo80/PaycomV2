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
    public bool? EstActif { get; set; } = true;
} 
