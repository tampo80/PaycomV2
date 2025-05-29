using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Villages.Update.v1;
public class UpdateVillageHandler(
    ILogger<UpdateVillageHandler> logger,
    [FromKeyedServices("taxe:villages")] IRepository<Village> repository)
: IRequestHandler<UpdateVillageCommand, UpdateVillageResponse>
{
    public async Task<UpdateVillageResponse> Handle(UpdateVillageCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var village = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = village ?? throw new VillageNotFoundException(request.Id);
        
        var updateVillage = village.Update(
            request.Nom,
            request.Code);
        await repository.UpdateAsync(village, cancellationToken);
        logger.LogInformation("Village mis à jour avec l'id {villageId}", request.Id);
        return new UpdateVillageResponse(updateVillage.Id);
    }
    
}
