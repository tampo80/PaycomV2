using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.CollecteTerrainSessions.Create.v1;
public sealed class CreateCollecteTerrainSessionHandler(
    ILogger<CreateCollecteTerrainSessionHandler> logger,
    [FromKeyedServices("taxe:collecte-sessions")] IRepository<CollecteTerrainSession> repository) : IRequestHandler<CreateCollecteTerrainSessionCommand, CreateCollecteTerrainSessionResponse>
{
    public async Task<CreateCollecteTerrainSessionResponse> Handle(CreateCollecteTerrainSessionCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var session = CollecteTerrainSession.Create(request.AgentFiscalId, request.ZoneCollecteId, request.DateDebut, request.Description);
        await repository.AddAsync(session, cancellationToken);
        logger.LogInformation("Session de collecte terrain créée {sessionId}", session.Id);
        return new CreateCollecteTerrainSessionResponse(session.Id);
    }
} 
