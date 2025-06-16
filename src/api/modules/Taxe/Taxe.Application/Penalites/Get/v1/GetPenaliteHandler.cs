using FSH.Framework.Core.Caching;
using FSH.Framework.Core.Exceptions;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Penalites.Get.v1;

public sealed class GetPenaliteHandler(
    [FromKeyedServices("taxe:penalites")] IReadRepository<Penalite> repository)
    : IRequestHandler<GetPenaliteRequest, PenaliteResponse>
{
    public async Task<PenaliteResponse> Handle(GetPenaliteRequest request, CancellationToken cancellationToken)
    {
        var penalite = await repository.GetByIdAsync(request.Id, cancellationToken);
        
        if (penalite == null)
        {
            throw new NotFoundException($"Pénalité avec l'ID {request.Id} non trouvée");
        }

        return new PenaliteResponse(
            penalite.Id,
            penalite.EcheanceId,
            penalite.ObligationFiscaleId,
            penalite.TypePenalite,
            penalite.MontantPenalite,
            penalite.TauxPenalite,
            penalite.DateCalcul,
            penalite.DateApplication,
            penalite.NombreJoursRetard,
            penalite.Motif,
            penalite.Observation,
            penalite.Statut,
            penalite.EstAnnulee,
            penalite.DateAnnulation,
            penalite.MotifAnnulation,
            penalite.Created.DateTime,
            penalite.LastModified.DateTime);
    }
}
