using FSH.Framework.Core.Caching;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Echeanciers.Get.v1;
public sealed class GetEcheancierHandler(
    [FromKeyedServices("taxe:echeanciers")] IReadRepository<Echeancier> repository,
    ICacheService cache) : IRequestHandler<GetEcheancierRequest, EcheancierResponse>
{
    public async Task<EcheancierResponse> Handle(GetEcheancierRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"echeancier: {request.Id}", async () =>
            {
                var echeancierItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (echeancierItem == null) throw new EcheancierNotFoundException(request.Id);
                return new EcheancierResponse(echeancierItem.Id, echeancierItem.DateEcheance, echeancierItem.MontantDu,
                    echeancierItem.MontantPaye);
            }, cancellationToken: cancellationToken);
        return item!;
    }
    
}
