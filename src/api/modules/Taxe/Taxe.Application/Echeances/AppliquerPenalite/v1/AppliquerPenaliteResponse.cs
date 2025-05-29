using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
namespace PayCom.WebApi.Taxe.Application.Echeances.AppliquerPenalite.v1;

public record AppliquerPenaliteResponse(Guid Id, decimal MontantPenalite, decimal MontantTotal); 
