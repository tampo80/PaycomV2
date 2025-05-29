using MediatR;

namespace PayCom.WebApi.Taxe.Application.Contribuables.AssocierUtilisateur.v1;

public record AssocierUtilisateurContribuableCommand(
    Guid ContribuableId,
    Guid UtilisateurId) : IRequest<AssocierUtilisateurContribuableResponse>; 
