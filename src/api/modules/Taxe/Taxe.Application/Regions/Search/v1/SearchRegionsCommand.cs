using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.Regions.Search.v1;
public sealed class SearchRegionsCommand : PaginationFilter, IRequest<PagedList<RegionResponse>>
{
    public string Nom { get; init; } = string.Empty;
    public string Code { get; init; } = string.Empty;
}
