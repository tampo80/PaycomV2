using FluentValidation;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Penalites.Update.v1;
public class UpdatePenaliteCommandValidator : AbstractValidator<UpdatePenaliteCommand>
{
    public UpdatePenaliteCommandValidator()
    {
        RuleFor(p => p.DateApplication).NotEmpty();
        RuleFor(p => p.Montant).NotEmpty();
        RuleFor(p => p.Type).NotEmpty();
        RuleFor(p => p.Description).NotEmpty();
        RuleFor(p => p.TaxeConcernee).NotEmpty();
    }
    
}
