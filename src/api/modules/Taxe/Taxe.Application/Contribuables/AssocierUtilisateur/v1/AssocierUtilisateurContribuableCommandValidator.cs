using FluentValidation;

namespace PayCom.WebApi.Taxe.Application.Contribuables.AssocierUtilisateur.v1;

public class AssocierUtilisateurContribuableCommandValidator : AbstractValidator<AssocierUtilisateurContribuableCommand>
{
    public AssocierUtilisateurContribuableCommandValidator()
    {
        RuleFor(c => c.ContribuableId).NotEmpty();
        RuleFor(c => c.UtilisateurId).NotEmpty();
    }
} 
