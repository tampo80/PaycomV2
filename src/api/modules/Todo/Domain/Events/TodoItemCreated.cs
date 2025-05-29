﻿
using FSH.Framework.Core.Caching;
using FSH.Framework.Core.Domain.Events;
using PayCom.WebApi.Todo.Features.Get.v1;
using MediatR;
using Microsoft.Extensions.Logging;

namespace PayCom.WebApi.Todo.Domain.Events;
public record TodoItemCreated(Guid Id, string Title, string Note) : DomainEvent;

public class TodoItemCreatedEventHandler(
    ILogger<TodoItemCreatedEventHandler> logger,
    ICacheService cache)
    : INotificationHandler<TodoItemCreated>
{
    public async Task Handle(TodoItemCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("handling todo item created domain event..");
        var cacheResponse = new GetTodoResponse(notification.Id, notification.Title, notification.Note);
        await cache.SetAsync($"todo:{notification.Id}", cacheResponse, cancellationToken: cancellationToken);
    }
}
