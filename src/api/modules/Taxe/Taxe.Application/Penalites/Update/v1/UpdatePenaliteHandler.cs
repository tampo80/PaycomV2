using FSH.Framework.Core.Exceptions;
using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Penalites.Update.v1;

public sealed class UpdatePenaliteHandler(
    [FromKeyedServices("taxe:penalites")] IRepository<Penalite> repository)
    : IRequestHandler<UpdatePenaliteCommand, UpdatePenaliteResponse>
{
    public async Task<UpdatePenaliteResponse> Handle(UpdatePenaliteCommand request, CancellationToken cancellationToken)
    {
        var penalite = await repository.GetByIdAsync(request.Id, cancellationToken);
        
        if (penalite == null)
        {
            throw new NotFoundException($"Pénalité avec l'ID {request.Id} non trouvée");
        }

        penalite.Modifier(
            request.MontantPenalite,
            request.TauxPenalite,
            request.DateApplication,
            request.NombreJoursRetard,
            request.Motif,
            request.Observation);

        await repository.UpdateAsync(penalite, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);

        return new UpdatePenaliteResponse(penalite.Id);
    }
}
