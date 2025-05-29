using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.AgentFiscals.Delete.v1;
public record DeleteAgentFiscalCommand(Guid Id) : IRequest;
