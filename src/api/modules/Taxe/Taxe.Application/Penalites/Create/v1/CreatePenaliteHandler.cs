using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PayCom.WebApi.Taxe.Domain;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.Penalites.Create.v1;

public sealed class CreatePenaliteHandler(
    [FromKeyedServices("taxe:penalites")] IRepository<Penalite> repository)
    : IRequestHandler<CreatePenaliteCommand, CreatePenaliteResponse>
{
    public async Task<CreatePenaliteResponse> Handle(CreatePenaliteCommand request, CancellationToken cancellationToken)
    {
        var penalite = Penalite.Create(
            request.EcheanceId,
            request.ObligationFiscaleId,
            request.TypePenalite,
            request.MontantPenalite,
            request.TauxPenalite,
            request.DateCalcul,
            request.DateApplication,
            request.NombreJoursRetard,
            request.Motif,
            request.Observation);

        await repository.AddAsync(penalite, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);

        return new CreatePenaliteResponse(penalite.Id);
    }
}
