using MediatR;

namespace PayCom.WebApi.Taxe.Application.Communes.Get.v1;
public class GetCommuneQuery : IRequest<CommuneResponse>
{
    public Guid Id { get; set; }
    
    public GetCommuneQuery() { }
    
    public GetCommuneQuery(Guid id)
    {
        Id = id;
    }
} 
