using FluentValidation;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Notifications.Update.v1;
public class UpdateNotificationCommandValidator : AbstractValidator<UpdateNotificationCommand>
{
    public UpdateNotificationCommandValidator()
    {
        RuleFor(n => n.Type).NotEmpty();
        RuleFor(n => n.DateEnvoi).NotEmpty();
        RuleFor(n => n.Contenu).NotEmpty();
    }
}
