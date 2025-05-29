using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Penalites.Delete.v1;
public class DeletePenaliteHandler(
    ILogger<DeletePenaliteHandler> logger,
    [FromKeyedServices("taxe:penalites")] IRepository<Penalite> repository) : IRequestHandler<DeletePenaliteCommand>
{
    public async Task Handle(DeletePenaliteCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var penalite = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = penalite ?? throw new PenaliteNotFoundException(request.Id);
        await repository.DeleteAsync(penalite, cancellationToken);
        logger.LogInformation("penalite avec l'id {penaliteId}", penalite.Id);
    }
    
}
