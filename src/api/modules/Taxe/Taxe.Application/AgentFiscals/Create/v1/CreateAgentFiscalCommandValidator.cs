using FluentValidation;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.AgentFiscals.Create.v1;
public class CreateAgentFiscalCommandValidator : AbstractValidator<CreateAgentFiscalCommand>
{
    public CreateAgentFiscalCommandValidator()
    {
        RuleFor(a => a.Nom).NotEmpty().MinimumLength(2).MaximumLength(100);
        RuleFor(a => a.Prenom).NotEmpty().MinimumLength(2).MaximumLength(1000);
        RuleFor(a => a.Identifiant).NotEmpty().MinimumLength(2).MaximumLength(1000);
        RuleFor(a => a.LocalisationGPS).NotEmpty().MinimumLength(2).MaximumLength(1000);
        RuleFor(a => a.DateEmbauche).NotEmpty();
        RuleFor(a => a.DateFinFonction).NotEmpty();
        RuleFor(a => a.Statut).IsInEnum();
    }
}
