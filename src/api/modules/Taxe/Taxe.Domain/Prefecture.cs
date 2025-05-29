using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using PayCom.WebApi.Taxe.Domain.Events.PrefectureEvents;

namespace PayCom.WebApi.Taxe.Domain;
public class Prefecture : AuditableEntity, IAggregateRoot
{
    public string Nom { get; private set; } = string.Empty;
    public string Code { get; private set; } = string.Empty;

    private Prefecture() { }

    public Prefecture(Guid id,string nom, string code)
    {
        Id = id;
        Nom = nom;
        Code = code;
        QueueDomainEvent( new PrefectureCreated{Prefecture = this});
        
    }

    public static Prefecture Create(string nom, string code)
    {
        return new Prefecture(Guid.NewGuid(),nom, code);
    }
    
    public Prefecture Update(string nom, string code)
    {
       if( Nom != nom)
       {
           Nom = nom;
       }
         if(Code != code)
         {
                Code = code;
         }
        QueueDomainEvent(new PrefectureUpdated{Prefecture = this});
        return this;
    }
    
}
