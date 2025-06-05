using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Villages.Delete.v1;
public class DeleteVillageHandler(
    ILogger<DeleteVillageHandler> logger,
    [FromKeyedServices("taxe:villages")] IRepository<Village> repository) : IRequestHandler<DeleteVillageCommand>
{
    public async Task Handle(DeleteVillageCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        if (request.Id == null)
            throw new ArgumentException("L'ID du village ne peut pas être null", nameof(request.Id));
            
        var village = await repository.GetByIdAsync(request.Id.Value, cancellationToken);
        _ = village ?? throw new VillageNotFoundException(request.Id);
        await repository.DeleteAsync(village, cancellationToken);
        logger.LogInformation("Village with id {villageId} deleted.", request.Id);
    }
}
