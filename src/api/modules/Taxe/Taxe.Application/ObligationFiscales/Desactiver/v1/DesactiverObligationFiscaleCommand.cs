using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.ObligationFiscales.Desactiver.v1;
public record DesactiverObligationFiscaleCommand(Guid Id) : IRequest<DesactiverObligationFiscaleResponse>; 
