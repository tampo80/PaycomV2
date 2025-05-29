using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Paiements.Delete.v1;
public class DeletePaiementHandler(
    ILogger<DeletePaiementHandler> logger,
    [FromKeyedServices("taxe:paiements")]
    IRepository<Paiement> repository) : IRequestHandler<DeletePaiementCommand>
{
    public async Task Handle(DeletePaiementCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var paiement = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = paiement ?? throw new PaiementNotFoundException(request.Id);
        await repository.DeleteAsync(paiement, cancellationToken);
        logger.LogInformation("Paiement avec l'id: {paiement.Id} supprimé.", paiement.Id);
    }
}
