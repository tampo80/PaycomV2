using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Penalites.Update.v1;
public class UpdatePenaliteHandler(
    ILogger<UpdatePenaliteHandler> logger,
    [FromKeyedServices("taxe:penalites")] IRepository<Penalite> repository)
: IRequestHandler<UpdatePenaliteCommand, UpdatePenaliteResponse>
{
    public async Task<UpdatePenaliteResponse> Handle(UpdatePenaliteCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var penalite = await repository.GetByIdAsync(request, cancellationToken);
        _ = penalite ?? throw new PenaliteNotFoundException(request.Id);
        var updatePenalite = penalite.Update(request.DateApplication, request.Montant, request.Type,
            request.Description, request.TaxeConcernee);
        await repository.UpdateAsync(updatePenalite, cancellationToken);
        logger.LogInformation("Penalite avec l'id {penaliteId} mis à jour", penalite.Id);
        return new UpdatePenaliteResponse(updatePenalite.Id);
    }
    
}
