using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.ObligationFiscales.Delete.v1;
public record DeleteObligationFiscaleCommand(Guid Id) : IRequest; 
