using Ardalis.Specification;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Application.Notifications.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Notifications.Search.v1;
public class SearchNotificationSpecs : EntitiesByPaginationFilterSpec<Notification, NotificationResponse>
{
    public SearchNotificationSpecs(SearchNotificationCommand command) : base(command)
        => Query.OrderBy(n => n.Type, !command.HasOrderBy())
            .Where(n => n.Type.Contains(command.Keyword), !string.IsNullOrEmpty(command.Keyword));
}
