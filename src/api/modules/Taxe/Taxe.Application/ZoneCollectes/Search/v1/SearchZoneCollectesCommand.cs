using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using FSH.Framework.Core.Paging;
using MediatR;
using PayCom.WebApi.Taxe.Application.ZoneCollectes.Get.v1;

namespace PayCom.WebApi.Taxe.Application.ZoneCollectes.Search.v1;
public record SearchZoneCollectesCommand(
    [property: DefaultValue(1)]
    int PageIndex = 1,
    [property: DefaultValue(10)]
    int PageSize = 10,
    [property: DefaultValue("")]
    string? SortBy = null,
    string? SearchTerm = null,
    [property: DefaultValue(null)]
    Guid? CommuneId = null) : IRequest<PagedList<ZoneCollecteResponse>>; 
