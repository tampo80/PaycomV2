using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using FSH.Framework.Core.Paging;
using MediatR;
using PayCom.WebApi.Taxe.Application.ZoneCollectes.Get.v1;

namespace PayCom.WebApi.Taxe.Application.ZoneCollectes.Search.v1;

public sealed class  SearchZoneCollectesCommand : PaginationFilter, IRequest<PagedList<GetZoneCollecteResponse>>
{
    public string? SearchTerm { get; set; }
    public Guid? CommuneId { get; set; }
    
   
    
 
} 
