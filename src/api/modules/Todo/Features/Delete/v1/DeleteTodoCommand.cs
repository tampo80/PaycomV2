using MediatR;

namespace PayCom.WebApi.Todo.Features.Delete.v1;
public sealed record DeleteTodoCommand(
    Guid Id) : IRequest;



