using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Echeanciers.Delete.v1;
public class DeleteEcheancierHandler(
    ILogger<DeleteEcheancierHandler> logger,
    [FromKeyedServices("taxe:echeanciers")]
    IRepository<Echeancier> repository) : IRequestHandler<DeleteEcheancierCommand>
{
    public async Task Handle(DeleteEcheancierCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var echeancier = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = echeancier ?? throw new EcheancierNotFoundException(request.Id);
        await repository.DeleteAsync(echeancier, cancellationToken);
        logger.LogInformation("Echeancier avec l'id {echeancierId} supprimé.", echeancier.Id);
    }
}
