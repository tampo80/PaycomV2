using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Operations.Delete.v1;
public class DeleteOperationHandler(
    ILogger<DeleteOperationHandler> logger,
    [FromKeyedServices("taxe:operations")]
    IRepository<Operation> repository) : IRequestHandler<DeleteOperationCommand>
{
    public async Task Handle(DeleteOperationCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var operation = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = operation ?? throw new OperationNotFoundException(request.Id);
        await repository.DeleteAsync(operation, cancellationToken);
        logger.LogInformation("Operation avec l'id: {operationId} supprimée.", cancellationToken);
    }
}
