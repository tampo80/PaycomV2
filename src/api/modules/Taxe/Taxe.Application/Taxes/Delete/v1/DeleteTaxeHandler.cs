using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain.Exceptions;

namespace PayCom.WebApi.Taxe.Application.Taxes.Delete.v1;
public class DeleteTaxeHandler(
    ILogger<DeleteTaxeHandler> logger,
    [FromKeyedServices("taxe:taxes")] IRepository<Taxe.Domain.Taxe> repository) : IRequestHandler<DeleteTaxeCommand>
{
    public async Task Handle(DeleteTaxeCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var taxe = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = taxe ?? throw new TaxeNotFoundException(request.Id);
        await repository.DeleteAsync(taxe, cancellationToken);
        logger.LogInformation("Taxe avec l'id: {Id} supprimée.", request.Id);
    }
    
}
