using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;
using PayCom.WebApi.Taxe.Application.Villages.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Villages.Search.v1;
public class SearchVillagesCommand : PaginationFilter, IRequest<PagedList<VillageResponse>>
{
    public string? Nom { get; init; }
    public string? Code { get; init; }
    public Guid? CommuneId { get; init; }
} 
