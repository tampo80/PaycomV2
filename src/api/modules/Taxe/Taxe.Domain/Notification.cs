using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using PayCom.WebApi.Taxe.Domain.Events.NotificationEvents;


namespace  PayCom.WebApi.Taxe.Domain;
public class Notification : AuditableEntity, IAggregateRoot
{
    public string Type { get; private set; } = string.Empty;
    public DateTime DateEnvoi { get; private set; }
    public string Contenu { get; private set; } = string.Empty;
    public bool EstLue { get; private set; }
    public DateTime? DateLecture { get; private set; }
    //public StatutNotification Statut { get; private set; } // Enum type

    private Notification() { }

    public Notification(Guid id, string type, DateTime dateEnvoi, string contenu)
    {
        Id = id;
        Type = type;
        DateEnvoi = dateEnvoi;
        Contenu = contenu;
        EstLue = false;
        DateLecture = null;
        QueueDomainEvent( new NotificationCreated{Notification = this});
    }

    public static Notification Create(string type, DateTime dateEnvoi, string contenu)
    {
        return new Notification(Guid.NewGuid(), type, dateEnvoi, contenu);
    }
    
    public Notification Update(string type, DateTime dateEnvoi, string contenu)
    {
        bool isUpdated = false;

        if (Type != type)
        {
            Type = type;
            isUpdated = true;
        }

        if (DateEnvoi != dateEnvoi)
        {
            DateEnvoi = dateEnvoi;
            isUpdated = true;
        }

        if (Contenu != contenu)
        {
            Contenu = contenu;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new NotificationUpdated{Notification = this});
        }
        return this;
    }

    public void MarquerCommeLue()
    {
        if (!EstLue)
        {
            EstLue = true;
            DateLecture = DateTime.UtcNow;
            QueueDomainEvent(new NotificationMarqueeCommeLue { Notification = this });
        }
    }
}
