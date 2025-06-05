using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;
using PayCom.WebApi.Taxe.Application.Notifications.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Notifications.Search.v1;
public class SearchNotificationCommand : PaginationFilter, IRequest<PagedList<NotificationResponse>>
{
    public Guid Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public DateTime DateEnvoi { get; set; }
    public string Contenu { get; set; } = string.Empty;
}
