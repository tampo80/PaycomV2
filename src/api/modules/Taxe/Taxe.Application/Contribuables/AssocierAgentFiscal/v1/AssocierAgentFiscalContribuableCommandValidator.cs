using FluentValidation;

namespace PayCom.WebApi.Taxe.Application.Contribuables.AssocierAgentFiscal.v1;

public class AssocierAgentFiscalContribuableCommandValidator : AbstractValidator<AssocierAgentFiscalContribuableCommand>
{
    public AssocierAgentFiscalContribuableCommandValidator()
    {
        RuleFor(x => x.ContribuableId).NotEmpty().WithMessage("L'identifiant du contribuable est requis");
        RuleFor(x => x.AgentFiscalId).NotEmpty().WithMessage("L'identifiant de l'agent fiscal est requis");
    }
} 
