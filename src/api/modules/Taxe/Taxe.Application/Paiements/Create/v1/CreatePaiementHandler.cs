using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Paiements.Create.v1;
public sealed class CreatePaiementHandler(
    ILogger<CreatePaiementHandler> logger,
    [FromKeyedServices("taxe:paiements")] IRepository<Paiement> repository)
    : IRequestHandler<CreatePaiementCommand, CreatePaiementResponse>
{
    public async Task<CreatePaiementResponse> Handle(CreatePaiementCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var paiement = Paiement.Create(request.Date, request.Montant, request.CodeTransaction, request.DateTransaction,
            request.FraisTransaction, request.InformationsSupplementaires);
        await repository.AddAsync(paiement, cancellationToken);
        logger.LogInformation("Paiement créé {paiementId}", paiement.Id);
        return new CreatePaiementResponse(paiement.Id);
    }
}
