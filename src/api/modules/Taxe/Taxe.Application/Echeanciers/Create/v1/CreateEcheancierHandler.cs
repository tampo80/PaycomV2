using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Application.Contribuables.Create.v1;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Echeanciers.Create.v1;
public sealed class CreateEcheancierHandler(
    ILogger<CreateEcheancierHandler> logger,
    [FromKeyedServices("taxe:echeanciers")] IRepository<Echeancier> repository) : IRequestHandler<CreateEcheancierCommand, CreateEcheancierResponse>
{
    public async Task<CreateEcheancierResponse> Handle(CreateEcheancierCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var echeancier = Echeancier.Create(request.DateEcheance, request.MontantDu, request.MontantPaye);
        await repository.AddAsync(echeancier, cancellationToken);
        logger.LogInformation("Echeancier créé {echeancierId}", echeancier.Id);
        return new CreateEcheancierResponse(echeancier.Id);
    }
}
