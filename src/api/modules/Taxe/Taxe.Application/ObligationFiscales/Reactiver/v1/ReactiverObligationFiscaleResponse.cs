using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
namespace PayCom.WebApi.Taxe.Application.ObligationFiscales.Reactiver.v1;

public record ReactiverObligationFiscaleResponse(Guid Id, bool EstActif); 
