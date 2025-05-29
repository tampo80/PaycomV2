using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Prefectures.Update.v1;
public class UpdatePrefectureHandler(
    ILogger<UpdatePrefectureHandler> logger,
    [FromKeyedServices("taxe:prefectures")] IRepository<Prefecture> repository)
: IRequestHandler<UpdatePrefectureCommand, UpdatePrefectureResponse>
{
    public async Task<UpdatePrefectureResponse> Handle(UpdatePrefectureCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var prefecture = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = prefecture ?? throw new PrefectureNotFoundException(request.Id);
        var updatePrefecture = prefecture.Update(request.Nom, request.Code);
        await repository.UpdateAsync(updatePrefecture, cancellationToken);
        logger.LogInformation("Prefecture avec l'id {prefectureId}", prefecture.Id);
        return new UpdatePrefectureResponse(updatePrefecture.Id);
    }
    
}
