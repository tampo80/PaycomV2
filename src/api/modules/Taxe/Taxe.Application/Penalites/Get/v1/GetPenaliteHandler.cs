using FSH.Framework.Core.Caching;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Penalites.Get.v1;
public sealed class GetPenaliteHandler(
    [FromKeyedServices("taxe:penalites")] IReadRepository<Penalite> repository,
    ICacheService cache) : IRequestHandler<GetPenaliteRequest, PenaliteResponse>
{
    public async Task<PenaliteResponse> Handle(GetPenaliteRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"Penalite {request.Id}", async () =>
            {
                var penaliteItem = await repository.GetByIdAsync(request.Id);
                if (penaliteItem == null) throw new PenaliteNotFoundException(request.Id);
                return new PenaliteResponse(penaliteItem.Id, penaliteItem.DateApplication, penaliteItem.Montant,
                    penaliteItem.Type, penaliteItem.Description, penaliteItem.TaxeConcernee);
            }, cancellationToken: cancellationToken);
        return item!;
    }
    
}
