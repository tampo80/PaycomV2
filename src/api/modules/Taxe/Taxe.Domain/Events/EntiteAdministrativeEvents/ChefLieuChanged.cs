using MediatR;

namespace PayCom.WebApi.Taxe.Domain.Events.EntiteAdministrativeEvents;

public class ChefLieuChanged : INotification
{
    public string TypeEntite { get; }
    public Guid EntiteId { get; }
    public Guid? AncienChefLieuId { get; }
    public Guid? NouveauChefLieuId { get; }

    public ChefLieuChanged(string typeEntite, Guid entiteId, Guid? ancienChefLieuId, Guid? nouveauChefLieuId)
    {
        TypeEntite = typeEntite;
        EntiteId = entiteId;
        AncienChefLieuId = ancienChefLieuId;
        NouveauChefLieuId = nouveauChefLieuId;
    }
} 
