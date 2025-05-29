using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.AgentFiscals.Delete.v1;
public sealed class DeleteAgentFiscalHandler(
    ILogger<DeleteAgentFiscalHandler> logger,
    [FromKeyedServices("taxe:agentfiscals")]
    IRepository<AgentFiscal> repository) : IRequestHandler<DeleteAgentFiscalCommand>
{
    public async Task Handle(DeleteAgentFiscalCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var agentFiscal = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = agentFiscal ?? throw new AgentFiscalNotFoundException(request.Id);
        await repository.DeleteAsync(agentFiscal, cancellationToken);
        logger.LogInformation("agentFiscal avec l'id : {agentFiscalId} supprimé", agentFiscal.Id);
    }
}
