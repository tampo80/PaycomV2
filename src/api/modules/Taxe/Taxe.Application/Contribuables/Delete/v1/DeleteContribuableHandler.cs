using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Contribuables.Delete.v1;
public class DeleteContribuableHandler(
    ILogger<DeleteContribuableHandler> logger,
    [FromKeyedServices("taxe:contribuables")]
    IRepository<Contribuable> repository) : IRequestHandler<DeleteContribuableCommand>
{
    public async Task Handle(DeleteContribuableCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var contribuable = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = contribuable ?? throw new ContribuableNotFoundException(request.Id);
        await repository.DeleteAsync(contribuable, cancellationToken);
        logger.LogInformation("contribuable avec l'id: {contribuableId} supprimé.", contribuable.Id);
    }
}
