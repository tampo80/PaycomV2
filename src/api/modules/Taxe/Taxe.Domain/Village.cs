using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using PayCom.WebApi.Taxe.Domain.Events.VillageEvents;


namespace  PayCom.WebApi.Taxe.Domain;
public class Village : AuditableEntity, IAggregateRoot
{
    public string Nom { get; private set; } = string.Empty;
    public string Code { get; private set; } = string.Empty;

    private Village() { }

    public Village(Guid id,string nom, string code)
    {
        Id = id;
        Nom = nom;
        Code = code;
        QueueDomainEvent( new VillageCreated{Village = this});
    }

    public static Village Create(string nom, string code)
    {
        return new Village(Guid.NewGuid(),nom, code);
    }
    
    public Village Update(string nom, string code)
    {
        bool isUpdated = false;

        if (Nom != nom)
        {
            Nom = nom;
            isUpdated = true;
        }

        if (Code != code)
        {
            Code = code;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new VillageUpdated{Village = this});
        }

        return this;
    }
}
