using FluentValidation;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Communes.Create.v1;
public class CreateCommuneCommandValidator : AbstractValidator<CreateCommuneCommand>
{
    public CreateCommuneCommandValidator()
    {
        RuleFor(x => x.Nom)
            .NotEmpty().WithMessage("Le nom est obligatoire.")
            .MaximumLength(100).WithMessage("Le nom ne peut pas dépasser 100 caractères.");
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Le code est obligatoire.")
            .MaximumLength(10).WithMessage("Le code ne peut pas dépasser 10 caractères.");
        RuleFor(x => x.RegionId)
            .NotEmpty().WithMessage("L'identifiant de la région est obligatoire.");
        RuleFor(x => x.Contact)
            .MaximumLength(20).WithMessage("Le contact ne peut pas dépasser 20 caractères.");
        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("L'email n'est pas valide.")
            .MaximumLength(100).WithMessage("L'email ne peut pas dépasser 100 caractères.");
        RuleFor(c => c.Type).IsInEnum();
        RuleFor(c => c.NombreSecteurs).GreaterThanOrEqualTo(0).LessThanOrEqualTo(100);
        RuleFor(c => c.NombreArrondissements).GreaterThanOrEqualTo(0).LessThanOrEqualTo(20);
        RuleFor(c => c.TypeChefLieu).IsInEnum();
        RuleFor(c => c.LogoUrl).MaximumLength(500);
        RuleFor(c => c.AdresseSiege).NotEmpty().MaximumLength(200);
        RuleFor(c => c.SiteWeb).MaximumLength(100);
        
        // Validation des informations du centre administratif
        RuleFor(c => c.CodeTenant).NotEmpty().MaximumLength(20);
        RuleFor(c => c.NomCentreAdmin).NotEmpty().MaximumLength(100);
        RuleFor(c => c.AdresseCentreAdmin).NotEmpty().MaximumLength(200);
        RuleFor(c => c.ContactCentreAdmin).NotEmpty().MaximumLength(20);
        RuleFor(c => c.EmailCentreAdmin).EmailAddress().MaximumLength(100);
        RuleFor(c => c.ResponsableCentreAdmin).NotEmpty().MaximumLength(100);
    }
}
