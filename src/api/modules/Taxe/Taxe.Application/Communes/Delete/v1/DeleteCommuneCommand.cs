using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Communes.Delete.v1;
public class DeleteCommuneCommand : IRequest
{
    public Guid Id { get; set; }
    
    public DeleteCommuneCommand() { }
    
    public DeleteCommuneCommand(Guid id)
    {
        Id = id;
    }
}
