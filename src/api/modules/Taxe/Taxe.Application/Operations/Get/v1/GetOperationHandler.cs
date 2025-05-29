using FSH.Framework.Core.Caching;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Operations.Get.v1;
public sealed class GetOperationHandler(
    [FromKeyedServices("taxe:operations")]
    IReadRepository<Operation> repository,
    ICacheService cache) : IRequestHandler<GetOperationRequest, OperationResponse>
{
    public async Task<OperationResponse> Handle(GetOperationRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"Operation: {request.Id}", async () =>
            {
                var operationItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (operationItem == null) throw new OperationNotFoundException(request.Id);
                return new OperationResponse(operationItem.Id, operationItem.Date, operationItem.Description,
                    operationItem.Utilisateur);
            }, cancellationToken: cancellationToken);
        return item!;
    }
}
