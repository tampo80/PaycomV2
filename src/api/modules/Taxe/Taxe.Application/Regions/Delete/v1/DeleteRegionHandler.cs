using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Regions.Delete.v1;
public sealed class DeleteRegionHandler(
    [FromKeyedServices("taxe:regions")] IRepository<Region> repository,
    ILogger<DeleteRegionHandler> logger)
    : IRequestHandler<DeleteRegionCommand>
{
    public async Task Handle(DeleteRegionCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        // Get the existing region
        var region = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (region == null)
        {
            logger.LogWarning("Region {RegionId} not found for deletion", request.Id);
            throw new RegionNotFoundException(request.Id);
        }
        // Delete the region
        await repository.DeleteAsync(region, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Region {RegionId} deleted successfully", request.Id);
    }
}
