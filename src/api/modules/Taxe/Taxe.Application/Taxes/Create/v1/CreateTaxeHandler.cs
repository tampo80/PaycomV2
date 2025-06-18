using FluentValidation;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace PayCom.WebApi.Taxe.Application.Taxes.Create.v1;
public sealed class CreateTaxeHandler(
    ILogger<CreateTaxeHandler> logger,
    [FromKeyedServices("taxe:taxes")] IRepository<Taxe.Domain.Taxe> repository)
    : IRequestHandler<CreateTaxeCommand, CreateTaxeResponse>
{
    public async Task<CreateTaxeResponse> Handle(CreateTaxeCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var taxe = Taxe.Domain.Taxe.Create(
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
        await repository.AddAsync(taxe, cancellationToken);
        logger.LogInformation("Taxe créée {echeancierId}", taxe.Id);
        return new CreateTaxeResponse(taxe.Id);
    }
}
