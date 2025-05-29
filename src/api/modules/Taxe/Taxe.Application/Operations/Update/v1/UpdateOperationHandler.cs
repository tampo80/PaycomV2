using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;
using PayCom.WebApi.Taxe.Application.Notifications.Update.v1;

namespace PayCom.WebApi.Taxe.Application.Operations.Update.v1;
public class UpdateOperationHandler(ILogger<UpdateOperationHandler> logger,
    [FromKeyedServices("taxe:operations")] IRepository<Operation> repository)
: IRequestHandler<UpdateOperationCommand, UpdateOperationResponse>
{
    public async Task<UpdateOperationResponse> Handle(UpdateOperationCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var operation = await repository.GetByIdAsync(request, cancellationToken);
        _ = operation ?? throw new OperationNotFoundException(request.Id);
        var updateOperation = operation.Update(request.Date, request.Description, request.Utilisateur);
        await repository.UpdateAsync(updateOperation, cancellationToken);
        logger.LogInformation("Operation avec l'id {operationId} mis à jour.", operation.Id);
        return new UpdateOperationResponse(updateOperation.Id);
    }
}
