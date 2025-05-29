using FluentValidation;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Configurations.Update.v1;
public class UpdateConfigurationCommandValidator : AbstractValidator<UpdateConfigurationCommand>
{
    public UpdateConfigurationCommandValidator()
    {
        RuleFor(c => c.Cle).NotEmpty().MinimumLength(2).MaximumLength(1000);
        RuleFor(c => c.Valeur).NotEmpty().MinimumLength(2).MaximumLength(1000);
        RuleFor(c => c.Description).MaximumLength(1000);
    }
}
