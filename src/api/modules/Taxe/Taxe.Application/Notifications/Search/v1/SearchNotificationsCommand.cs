using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;
using PayCom.WebApi.Taxe.Application.Notifications.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Notifications.Search.v1;
public class SearchNotificationsCommand : PaginationFilter, IRequest<PagedList<NotificationResponse>>
{
    public string? Message { get; init; }
    public string? Type { get; init; }
    public bool? IsRead { get; init; }
    public DateTime? DateDebut { get; init; }
    public DateTime? DateFin { get; init; }
} 
