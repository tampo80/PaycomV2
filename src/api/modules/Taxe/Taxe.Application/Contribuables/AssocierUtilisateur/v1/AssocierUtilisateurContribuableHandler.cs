using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Exceptions;
using System.Linq.Expressions;
using Ardalis.Specification;

namespace PayCom.WebApi.Taxe.Application.Contribuables.AssocierUtilisateur.v1;

public sealed class AssocierUtilisateurContribuableHandler(
    ILogger<AssocierUtilisateurContribuableHandler> logger,
    [FromKeyedServices("taxe:contribuables")]
    IRepository<Contribuable> repository) : IRequestHandler<AssocierUtilisateurContribuableCommand, AssocierUtilisateurContribuableResponse>
{
    public async Task<AssocierUtilisateurContribuableResponse> Handle(AssocierUtilisateurContribuableCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        // Vérifier si l'utilisateur est déjà associé à un autre contribuable
        var utilisateurDejaAssocieSpec = new UtilisateurDejaAssocieSpecification(request.UtilisateurId, request.ContribuableId);
        var contribuablesAvecMemeUtilisateur = await repository.ListAsync(utilisateurDejaAssocieSpec, cancellationToken);
        
        if (contribuablesAvecMemeUtilisateur.Any())
        {
            throw new InvalidOperationException($"L'utilisateur avec l'ID {request.UtilisateurId} est déjà associé à un autre contribuable. Un utilisateur ne peut être associé qu'à un seul contribuable.");
        }
        
        var contribuable = await repository.GetByIdAsync(request.ContribuableId, cancellationToken);
        _ = contribuable ?? throw new ContribuableNotFoundException(request.ContribuableId);
        
        contribuable.AssocierUtilisateur(request.UtilisateurId);
        
        await repository.UpdateAsync(contribuable, cancellationToken);
        
        logger.LogInformation("Contribuable avec l'id : {ContribuableId} associé à l'utilisateur : {UtilisateurId}", 
            contribuable.Id, request.UtilisateurId);
            
        return new AssocierUtilisateurContribuableResponse(contribuable.Id, request.UtilisateurId);
    }
}

public class UtilisateurDejaAssocieSpecification : Specification<Contribuable>
{
    public UtilisateurDejaAssocieSpecification(Guid utilisateurId, Guid contribuableId)
    {
        Query.Where(c => c.UtilisateurId == utilisateurId && c.Id != contribuableId);
    }
} 
