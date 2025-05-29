using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Prefectures.Create.v1;
public sealed class CreatePrefectureHandler(
    ILogger<CreatePrefectureHandler> logger,
    [FromKeyedServices("taxe:prefectures")] IRepository<Prefecture> repository)
: IRequestHandler<CreatePrefectureCommand, CreatePrefectureResponse>
{
    public async Task<CreatePrefectureResponse> Handle(CreatePrefectureCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var prefecture = Prefecture.Create(request.Nom, request.Code);
        await repository.AddAsync(prefecture, cancellationToken);
        logger.LogInformation("Prefecture crée {prefectureId}", prefecture.Id);
        return new CreatePrefectureResponse(prefecture.Id);
    }
    
}
