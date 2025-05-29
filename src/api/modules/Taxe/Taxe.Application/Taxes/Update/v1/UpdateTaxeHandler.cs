using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Taxes.Update.v1;
public class UpdateTaxeHandler(
    ILogger<UpdateTaxeHandler> logger,
    [FromKeyedServices("taxe:taxes")] IRepository<Domain.Taxe> repository)
: IRequestHandler<UpdateTaxeCommand, UpdateTaxeResponse>
{
    public async Task<UpdateTaxeResponse> Handle(UpdateTaxeCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var taxe = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = taxe ?? throw new TaxeNotFoundException(request.Id);
        var updateTaxe = taxe.Update(
            request.AnneeImposition,
            request.Taux,
            request.DateEcheance,
            request.MontantDu,
            request.MontantPaye,
            request.SoldeRestant,
            request.PrixUnitaire,
            request.UniteMesure,
            request.Caracteristiques,
            request.DateCreation,
            request.DateDerniereModification
        );
        await repository.UpdateAsync(updateTaxe, cancellationToken);
        logger.LogInformation("Échéancier mis à jour avec l'ID {echeancierId}", taxe.Id);
        return new UpdateTaxeResponse(updateTaxe.Id);
    }
    
}
