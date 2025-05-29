using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;
namespace PayCom.WebApi.Taxe.Application.Configurations.Delete.v1;
public class DeleteConfigurationHandler(
    ILogger<DeleteConfigurationHandler> logger,
    [FromKeyedServices("taxe:configurations")]
    IRepository<Configuration> repository) : IRequestHandler<DeleteConfigurationCommand>
{
    public async Task Handle(DeleteConfigurationCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var configuration = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = configuration ?? throw new ConfigurationNotFoundException(request.Id);
        await repository.DeleteAsync(configuration, cancellationToken);
        logger.LogInformation("configuration avec l'id: {configurationId} supprimée.", configuration.Id);
    }
}
