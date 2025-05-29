using MediatR;

namespace PayCom.WebApi.Todo.Features.Update.v1;
public sealed record UpdateTodoCommand(
    Guid Id,
    string? Title,
    string? Note = null): IRequest<UpdateTodoResponse>;



