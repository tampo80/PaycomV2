using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Echeanciers.Update.v1;
public class UpdateEcheancierHandler(
    ILogger<UpdateEcheancierHandler> logger,
    [FromKeyedServices("taxe:echeanciers")] IRepository<Echeancier> repository) 
    : IRequestHandler<UpdateEcheancierCommand, UpdateEcheancierResponse>
{
    public async Task<UpdateEcheancierResponse> Handle(UpdateEcheancierCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var echeancier = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = echeancier ?? throw new EcheancierNotFoundException(request.Id);
        var updateEcheancier = echeancier.Update(request.DateEcheance, request.MontantDu, request.MontantPaye);
        await repository.UpdateAsync(updateEcheancier, cancellationToken);
        logger.LogInformation("Echeancier avec l'id {echeancierId} mis à jour.", echeancier.Id);
        return new UpdateEcheancierResponse(echeancier.Id);
    }
}
