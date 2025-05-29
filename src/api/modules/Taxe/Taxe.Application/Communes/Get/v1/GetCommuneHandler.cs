using FSH.Framework.Core.Caching;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;
using Microsoft.Extensions.Logging;

namespace PayCom.WebApi.Taxe.Application.Communes.Get.v1;

public class GetCommuneHandler(
    ILogger<GetCommuneHandler> logger,
    [FromKeyedServices("taxe:communes")] IReadRepository<Commune> repository)
    : IRequestHandler<GetCommuneQuery, CommuneResponse>
{
    public async Task<CommuneResponse> Handle(GetCommuneQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var spec = new GetCommuneSpec(request.Id);
        var commune = await repository.FirstOrDefaultAsync(spec, cancellationToken);
        
        if (commune == null)
        {
            throw new ApplicationException($"La commune avec l'ID {request.Id} n'existe pas.");
        }
        
        logger.LogInformation("Commune avec l'id: {CommuneId} récupérée", request.Id);
        return commune;
    }
}
