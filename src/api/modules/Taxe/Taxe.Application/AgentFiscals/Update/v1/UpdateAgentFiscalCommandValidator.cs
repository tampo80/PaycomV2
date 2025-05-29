using FluentValidation;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.AgentFiscals.Update.v1;
public class UpdateAgentFiscalCommandValidator : AbstractValidator<UpdateAgentFiscalCommand>
{
    public UpdateAgentFiscalCommandValidator()
    {
        RuleFor(a => a.Nom).NotEmpty().MinimumLength(2).MaximumLength(100);
        RuleFor(a => a.Prenom).MaximumLength(1000);
        RuleFor(a => a.Identifiant).MaximumLength(1000);
        RuleFor(a => a.DateEmbauche).NotEmpty();
        RuleFor(a => a.LocalisationGPS).MaximumLength(1000);
        RuleFor(a => a.DateFinFonction).NotEmpty();
        RuleFor(a => a.Statut).NotEmpty();
    }
}
