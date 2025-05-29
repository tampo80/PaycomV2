using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Paiements.Update.v1;
public class UpdatePaiementHandler(
    ILogger<UpdatePaiementHandler> logger,
    [FromKeyedServices("taxe:paiements")] IRepository<Paiement> repository)
    : IRequestHandler<UpdatePaiementCommand, UpdatePaiementResponse>
{
    public async Task<UpdatePaiementResponse> Handle(UpdatePaiementCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var paiement = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = paiement ?? throw new PaiementNotFoundException(request.Id);
        var updatePaiement = paiement.Update(request.Date, request.Montant, request.CodeTransaction,
            request.DateTransaction,
            request.FraisTransaction, request.InformationsSupplementaires);
        await repository.UpdateAsync(updatePaiement, cancellationToken);
        logger.LogInformation("Paiement avec l'id {paiememntId} mis à jour.", paiement.Id);
        return new UpdatePaiementResponse(updatePaiement.Id);
    }
}
