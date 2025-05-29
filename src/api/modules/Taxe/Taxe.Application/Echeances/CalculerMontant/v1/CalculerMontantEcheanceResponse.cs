using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
namespace PayCom.WebApi.Taxe.Application.Echeances.CalculerMontant.v1;

public record CalculerMontantEcheanceResponse(Guid Id, decimal MontantCalcule); 
