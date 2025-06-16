using FSH.Framework.Core.Exceptions;
using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Penalites.Delete.v1;

public sealed class DeletePenaliteHandler(
    [FromKeyedServices("taxe:penalites")] IRepository<Penalite> repository)
    : IRequestHandler<DeletePenaliteCommand>
{
    public async Task Handle(DeletePenaliteCommand request, CancellationToken cancellationToken)
    {
        var penalite = await repository.GetByIdAsync(request.Id, cancellationToken);
        
        if (penalite == null)
        {
            throw new NotFoundException($"Pénalité avec l'ID {request.Id} non trouvée");
        }

        await repository.DeleteAsync(penalite, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }
}
