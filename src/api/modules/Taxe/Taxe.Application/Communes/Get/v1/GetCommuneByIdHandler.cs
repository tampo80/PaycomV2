using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Communes.Get.v1;
public class GetCommuneByIdHandler(
    ILogger<GetCommuneByIdHandler> logger,
    [FromKeyedServices("taxe:communes")] IReadRepository<Commune> repository)
    : IRequestHandler<GetCommuneByIdQuery, GetCommuneByIdResponse>
{
    public async Task<GetCommuneByIdResponse> Handle(GetCommuneByIdQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var spec = new GetCommuneByIdSpec(request.Id);
        var commune = await repository.FirstOrDefaultAsync(spec, cancellationToken);
        if (commune == null)
        {
            throw new ApplicationException($"La commune avec l'ID {request.Id} n'existe pas.");
        }
        logger.LogInformation("Commune avec l'id: {CommuneId} récupérée", request.Id);
        return commune;
    }
}
