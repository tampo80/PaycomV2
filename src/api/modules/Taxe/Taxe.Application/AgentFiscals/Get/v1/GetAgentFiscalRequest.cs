using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.AgentFiscals.Get.v1;
public class GetAgentFiscalRequest : IRequest<AgentFiscalResponse>
{
    public Guid Id { get; set; }
    public GetAgentFiscalRequest(Guid id) => Id = id;
}
