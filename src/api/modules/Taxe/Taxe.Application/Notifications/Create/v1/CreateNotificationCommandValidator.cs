using FluentValidation;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Notifications.Create.v1;
public class CreateNotificationCommandValidator : AbstractValidator<CreateNotificationCommand>
{
    public CreateNotificationCommandValidator()
    {
        RuleFor(c => c.Type).NotEmpty().MinimumLength(2).MaximumLength(1000);
        RuleFor(c => c.DateEnvoi).NotEmpty();
        RuleFor(c => c.Contenu).NotEmpty();
    }
}
