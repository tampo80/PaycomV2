using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Echeances.Create.v1;
public sealed class CreateEcheanceHandler(
    ILogger<CreateEcheanceHandler> logger,
    [FromKeyedServices("taxe:echeances")] IRepository<Echeance> repository)
    : IRequestHandler<CreateEcheanceCommand, CreateEcheanceResponse>
{
    public async Task<CreateEcheanceResponse> Handle(
        CreateEcheanceCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        // Créer une nouvelle échéance en utilisant la méthode factory
        var echeance = Echeance.Create(
            request.ObligationFiscaleId,
            request.AnneeImposition,
            request.PeriodeImposition,
            request.DateEcheance,
            request.MontantBase,
            request.MontantPenalites,
            request.Statut);
        // Sauvegarder la nouvelle entité dans le repository
        await repository.AddAsync(echeance, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Échéance créée avec l'ID {EcheanceId}", echeance.Id);
        // Retourner la réponse avec les données de l'entité créée
        return new CreateEcheanceResponse
        {
            Id = echeance.Id,
            ObligationFiscaleId = echeance.ObligationFiscaleId,
            AnneeImposition = echeance.AnneeImposition,
            PeriodeImposition = echeance.PeriodeImposition,
            DateEcheance = echeance.DateEcheance,
            MontantBase = echeance.MontantBase,
            MontantPenalites = echeance.MontantPenalites,
            MontantTotal = echeance.MontantTotal,
            Statut = echeance.Statut
        };
    }
}
