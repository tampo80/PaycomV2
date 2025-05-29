using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;
using PayCom.WebApi.Taxe.Application.Prefectures.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Prefectures.Search.v1;
public class SearchPrefecturesCommand : PaginationFilter, IRequest<PagedList<PrefectureResponse>>
{
    public string? Nom { get; init; }
    public string? Code { get; init; }
    public Guid? RegionId { get; init; }
} 
