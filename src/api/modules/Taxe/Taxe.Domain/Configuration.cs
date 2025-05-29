using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using PayCom.WebApi.Taxe.Domain.Events.ConfigurationEvents;


namespace  PayCom.WebApi.Taxe.Domain;

public class Configuration : AuditableEntity, IAggregateRoot
{
    public string Cle { get; private set; } = string.Empty;
    public string Valeur { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;

    private Configuration() { }

    public Configuration(Guid id,string cle, string valeur, string description)
    {
        Id = id;
        Cle = cle;
        Valeur = valeur;
        Description = description;
        QueueDomainEvent( new ConfigurationCreated{Configuration = this});
    }

    public static Configuration Create(string cle, string valeur, string description)
    {
        return new Configuration(Guid.NewGuid(),cle, valeur, description);
    }
    
    public Configuration Update(string cle, string valeur, string description)
    {
        if (cle != Cle)
        {
            Cle = cle;
        }
        if (valeur != Valeur)   
        {
            Valeur = valeur;     
        }
        if (description != Description)
        {
            Description = description;
        }
        QueueDomainEvent(new ConfigurationUpdated{Configuration = this});
        return this;
    }
}
