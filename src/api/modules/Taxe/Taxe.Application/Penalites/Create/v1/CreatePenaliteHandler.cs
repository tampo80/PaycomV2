using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Penalites.Create.v1;
public sealed class CreatePenaliteHandler(
    ILogger<CreatePenaliteHandler> logger,
    [FromKeyedServices("taxe:penalites")] IRepository<Penalite> repository,
    [FromKeyedServices("taxe:taxes")] IReadRepository<Domain.Taxe> taxeRepository)
: IRequestHandler<CreatePenaliteCommand, CreatePenaliteResponse>
{
    public async Task<CreatePenaliteResponse> Handle(CreatePenaliteCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        // Récupérer la taxe concernée à partir de son ID
        var taxe = await taxeRepository.GetByIdAsync(request.TaxeConcerneeId, cancellationToken);
        if (taxe == null)
        {
            logger.LogWarning("Taxe {TaxeId} non trouvée pour la création de pénalité", request.TaxeConcerneeId);
            throw new TaxeNotFoundException(request.TaxeConcerneeId);
        }
        // Créer la pénalité avec la taxe récupérée
        var penalite = Penalite.Create(request.DateApplication, request.Montant, request.Type, request.Description, taxe);
        await repository.AddAsync(penalite, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Pénalité créée {PenaliteId} pour la taxe {TaxeId}", penalite.Id, request.TaxeConcerneeId);
        return new CreatePenaliteResponse(penalite.Id);
    }
}
