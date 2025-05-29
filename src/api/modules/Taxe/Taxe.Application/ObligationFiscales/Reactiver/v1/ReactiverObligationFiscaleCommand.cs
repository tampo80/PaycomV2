using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.ObligationFiscales.Reactiver.v1;
public record ReactiverObligationFiscaleCommand(Guid Id) : IRequest<ReactiverObligationFiscaleResponse>; 
