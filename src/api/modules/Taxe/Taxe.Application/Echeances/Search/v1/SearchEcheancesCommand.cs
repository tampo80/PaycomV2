using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using FSH.Framework.Core.Paging;
using MediatR;
using PayCom.WebApi.Taxe.Application.Echeances.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Echeances.Search.v1;

public class SearchEcheancesCommand : PaginationFilter, IRequest<PagedList<EcheanceResponse>>
{
    [DefaultValue(null)]
    public Guid? ObligationFiscaleId { get; set; }
    
    public string? Statut { get; set; }
} 
