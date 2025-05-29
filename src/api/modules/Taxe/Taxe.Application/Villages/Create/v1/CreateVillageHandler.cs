using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Application.Taxes.Create.v1;

namespace PayCom.WebApi.Taxe.Application.Villages.Create.v1;
public sealed class CreateVillageHandler(
    ILogger<CreateVillageHandler> logger,
    [FromKeyedServices("taxe:villages")] IRepository<Village> repository)
: IRequestHandler<CreateVillageCommand, CreateVillageResponse>
{
    public async Task<CreateVillageResponse> Handle(CreateVillageCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var village = Village.Create(
            request.Nom,
            request.Code
        );
        await repository.AddAsync(village, cancellationToken);
        logger.LogInformation("Village créé {villageId}", village.Id);
        return new CreateVillageResponse(village.Id);
    }
}
