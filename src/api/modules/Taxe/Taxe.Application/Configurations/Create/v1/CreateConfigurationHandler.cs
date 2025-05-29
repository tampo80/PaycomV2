using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Configurations.Create.v1;
public sealed class CreateConfigurationHandler(
    ILogger<CreateConfigurationHandler> logger,
    [FromKeyedServices("taxe:configurations")] IRepository<Configuration> repository) : IRequestHandler<CreateConfigurationCommand, CreateConfigurationResponse>
{
    public async Task<CreateConfigurationResponse> Handle(CreateConfigurationCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var configuration = Configuration.Create(request.Cle!, request.Valeur!, request.Description);
        await repository.AddAsync(configuration, cancellationToken);
        logger.LogInformation("Configuration créée {configurationId}", configuration.Id);
        return new CreateConfigurationResponse(configuration.Id);
    }
}
