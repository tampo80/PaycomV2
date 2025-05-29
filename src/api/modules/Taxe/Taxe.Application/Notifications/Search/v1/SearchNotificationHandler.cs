using FSH.Framework.Core.Paging;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Application.Notifications.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Notifications.Search.v1;
public class SearchNotificationHandler(
    [FromKeyedServices("taxe:notifications")] IReadRepository<Notification> repository)
    : IRequestHandler<SearchNotificationCommand, PagedList<NotificationResponse>>
{
    public async Task<PagedList<NotificationResponse>> Handle(SearchNotificationCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var spec = new SearchNotificationSpecs(request);
        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);
        return new PagedList<NotificationResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
}
