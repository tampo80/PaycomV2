using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;
using PayCom.WebApi.Taxe.Application.Communes.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Communes.Search.v1;
public sealed class SearchCommuneCommand : PaginationFilter, IRequest<PagedList<CommuneResponse>>
{
    
    public string? Nom { get; set; }
    public string? Code { get; set; }
}
