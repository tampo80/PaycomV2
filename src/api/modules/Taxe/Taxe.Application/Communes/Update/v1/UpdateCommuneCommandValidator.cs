using FluentValidation;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Communes.Update.v1;
public class UpdateCommuneCommandValidator : AbstractValidator<UpdateCommuneCommand>
{
    public UpdateCommuneCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Nom).NotEmpty().MinimumLength(2).MaximumLength(100);
        RuleFor(c => c.Type).IsInEnum();
        RuleFor(c => c.Code).NotEmpty().MaximumLength(50);
        RuleFor(c => c.NombreSecteurs).GreaterThanOrEqualTo(0).LessThanOrEqualTo(100);
        RuleFor(c => c.NombreArrondissements).GreaterThanOrEqualTo(0).LessThanOrEqualTo(20);
        RuleFor(c => c.TypeChefLieu).IsInEnum();
        RuleFor(c => c.LogoUrl).MaximumLength(500);
        RuleFor(c => c.AdresseSiege).NotEmpty().MaximumLength(200);
        RuleFor(c => c.Contact).NotEmpty().MaximumLength(30);
        RuleFor(c => c.Email).NotEmpty().EmailAddress().MaximumLength(100);
        RuleFor(c => c.SiteWeb).MaximumLength(100);
        RuleFor(c => c.RegionId).NotEmpty();
        
        // Validation des informations du centre administratif
        RuleFor(c => c.CodeTenant).NotEmpty().MaximumLength(20);
        RuleFor(c => c.NomCentreAdmin).NotEmpty().MaximumLength(100);
        RuleFor(c => c.AdresseCentreAdmin).NotEmpty().MaximumLength(200);
        RuleFor(c => c.ContactCentreAdmin).NotEmpty().MaximumLength(20);
        RuleFor(c => c.EmailCentreAdmin).EmailAddress().MaximumLength(100);
        RuleFor(c => c.ResponsableCentreAdmin).NotEmpty().MaximumLength(100);
    }
}
