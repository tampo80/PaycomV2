using MediatR;

namespace PayCom.WebApi.Taxe.Application.CollecteTerrainSessions.Cloturer.v1;

public class CloturerSessionCommand : IRequest<CloturerSessionResponse>
{
    public Guid SessionId { get; set; }
}

public class CloturerSessionResponse
{
    public Guid Id { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
} 
