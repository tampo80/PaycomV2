using FluentValidation;

namespace PayCom.WebApi.Taxe.Application.AgentFiscals.AssocierUtilisateur.v1;

public class AssocierUtilisateurAgentCommandValidator : AbstractValidator<AssocierUtilisateurAgentCommand>
{
    public AssocierUtilisateurAgentCommandValidator()
    {
        RuleFor(a => a.AgentId).NotEmpty();
        RuleFor(a => a.UtilisateurId).NotEmpty();
    }
} 
