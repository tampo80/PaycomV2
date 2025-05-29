using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Configurations.Update.v1;
public class UpdateConfigurationHandler(
    ILogger<UpdateConfigurationHandler> logger,
    [FromKeyedServices("taxe:configurations")]
    IRepository<Configuration> repository) : IRequestHandler<UpdateConfigurationCommand, UpdateConfigurationResponse>
{
    public async Task<UpdateConfigurationResponse> Handle(UpdateConfigurationCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var configuration = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = configuration ?? throw new ConfigurationNotFoundException(request.Id);
        var updateConfiguration = configuration.Update(request.Cle, request.Valeur, request.Description);
        await repository.UpdateAsync(updateConfiguration, cancellationToken);
        logger.LogInformation("Configuration avec l'id: {configurationId} mis à jour.", configuration.Id);
        return new UpdateConfigurationResponse(updateConfiguration.Id);
    }
}
