using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.Contribuables.Get.v1;
public class GetContribuableRequest : IRequest<ContribuableResponse>
{
    public Guid Id { get; set; }
    
    public GetContribuableRequest(Guid id) => Id = id;
}
