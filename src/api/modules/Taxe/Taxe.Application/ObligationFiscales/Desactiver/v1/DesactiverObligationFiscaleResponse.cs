using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
namespace PayCom.WebApi.Taxe.Application.ObligationFiscales.Desactiver.v1;

public record DesactiverObligationFiscaleResponse(Guid Id, bool EstActif); 
