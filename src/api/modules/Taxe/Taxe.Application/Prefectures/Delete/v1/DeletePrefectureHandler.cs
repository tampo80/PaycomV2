using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Prefectures.Delete.v1;
public class DeletePrefectureHandler(
    ILogger<DeletePrefectureHandler> logger,
    [FromKeyedServices("taxe:prefectures")] IRepository<Prefecture> repository) : IRequestHandler<DeletePrefectureCommand>
{
    public async Task Handle(DeletePrefectureCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var prefecture = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = prefecture?? throw new PrefectureNotFoundException(request.Id);
        await repository.DeleteAsync(prefecture, cancellationToken);
        logger.LogInformation("prefecture avec l'id {prefectureId} supprimée.", prefecture.Id);
    }
}
