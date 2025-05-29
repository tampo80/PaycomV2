using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;
using PayCom.WebApi.Taxe.Application.Prefectures.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Prefectures.Search.v1;
public class SearchPrefectureCommand : PaginationFilter, IRequest<PagedList<PrefectureResponse>>
{
    public Guid Id { get; set; }
    public string Nom { get; set; }
    public string Code { get; set; }
}
