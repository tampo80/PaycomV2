using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Operations.Create.v1;
public sealed class CreateOperationHandler (ILogger<CreateOperationHandler> logger,
    [FromKeyedServices("taxe:operations")] IRepository<Operation> repository)
: IRequestHandler<CreateOperationCommand, CreateOperationResponse>
{
    public async Task<CreateOperationResponse> Handle(CreateOperationCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var operation = Operation.Create(request.Date, request.Description, request.Utilisateur);
        await repository.AddAsync(operation, cancellationToken);
        logger.LogInformation("Opération créée {operationId}", operation.Id);
        return new CreateOperationResponse(operation.Id);
    }
}
