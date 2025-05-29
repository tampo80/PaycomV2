using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;


namespace PayCom.WebApi.Taxe.Application.Communes.Delete.v1;
public sealed class DeleteCommuneHandler(
    ILogger<DeleteCommuneHandler> logger,
    [FromKeyedServices("taxe:communes")]
    IRepository<Commune> repository) : IRequestHandler<DeleteCommuneCommand>
{
    public async Task Handle(DeleteCommuneCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var commune = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = commune ?? throw new CommuneNotFoundException(request.Id);
        await repository.DeleteAsync(commune, cancellationToken);
        logger.LogInformation("commune avec l'id : {communeId} supprimé", commune.Id);
    }
}
