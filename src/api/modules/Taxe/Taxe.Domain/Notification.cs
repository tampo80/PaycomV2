using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using PayCom.WebApi.Taxe.Domain.Events.NotificationEvents;
using Shared.Enums;

namespace  PayCom.WebApi.Taxe.Domain;
public class Notification : AuditableEntity, IAggregateRoot
{
    public string Type { get; private set; } = string.Empty;
    public DateTime DateEnvoi { get; private set; }
    public string Contenu { get; private set; } = string.Empty;
    public bool EstLue { get; private set; }
    public DateTime? DateLecture { get; private set; }
    public StatutNotification Statut { get; private set; } = StatutNotification.Envoye;
    
    // Nouvelles propriétés pour la gestion des destinataires
    public TypeDestinataire TypeDestinataire { get; private set; } = TypeDestinataire.ContribuableSpecifique;
    public Guid? ContribuableId { get; private set; } // ID du contribuable spécifique (null pour les notifications générales)
    public Guid? AgentFiscalId { get; private set; } // ID de l'agent fiscal qui a créé la notification (optionnel)
    public string Titre { get; private set; } = string.Empty; // Titre de la notification
    public int Priorite { get; private set; } = 1; // Priorité de la notification (1 = faible, 2 = normale, 3 = élevée)
    public DateTime? DateExpiration { get; private set; } // Date d'expiration de la notification (optionnel)
    public bool EstArchivee { get; private set; } = false; // Indique si la notification est archivée

    // Propriétés de navigation
    public virtual Contribuable? Contribuable { get; private set; }
    public virtual AgentFiscal? AgentFiscal { get; private set; }

    private Notification() { }

    public Notification(Guid id, string type, DateTime dateEnvoi, string contenu, TypeDestinataire typeDestinataire, 
                       Guid? contribuableId = null, Guid? agentFiscalId = null, string titre = "", 
                       int priorite = 1, DateTime? dateExpiration = null)
    {
        Id = id;
        Type = type;
        DateEnvoi = dateEnvoi;
        Contenu = contenu;
        TypeDestinataire = typeDestinataire;
        ContribuableId = contribuableId;
        AgentFiscalId = agentFiscalId;
        Titre = string.IsNullOrEmpty(titre) ? ExtraireDebutContenu(contenu) : titre;
        Priorite = priorite;
        DateExpiration = dateExpiration;
        EstLue = false;
        DateLecture = null;
        Statut = StatutNotification.Envoye;
        EstArchivee = false;
        
        // Validation métier
        ValiderCoherenceDestinataire();
        
        QueueDomainEvent(new NotificationCreated { Notification = this });
    }

    public static Notification Create(string type, DateTime dateEnvoi, string contenu, 
                                    TypeDestinataire typeDestinataire, Guid? contribuableId = null, 
                                    Guid? agentFiscalId = null, string titre = "", int priorite = 1, 
                                    DateTime? dateExpiration = null)
    {
        return new Notification(Guid.NewGuid(), type, dateEnvoi, contenu, typeDestinataire, 
                              contribuableId, agentFiscalId, titre, priorite, dateExpiration);
    }

    // Factory methods pour créer des notifications spécifiques
    public static Notification CreatePourContribuable(Guid contribuableId, string type, string contenu, 
                                                     string titre = "", int priorite = 1, 
                                                     DateTime? dateExpiration = null, Guid? agentFiscalId = null)
    {
        return Create(type, DateTime.UtcNow, contenu, TypeDestinataire.ContribuableSpecifique, 
                     contribuableId, agentFiscalId, titre, priorite, dateExpiration);
    }

    public static Notification CreatePourTousLesContribuables(string type, string contenu, 
                                                            string titre = "", int priorite = 1, 
                                                            DateTime? dateExpiration = null, Guid? agentFiscalId = null)
    {
        return Create(type, DateTime.UtcNow, contenu, TypeDestinataire.TousLesContribuables, 
                     null, agentFiscalId, titre, priorite, dateExpiration);
    }

    public static Notification CreatePourAgentsFiscaux(string type, string contenu, 
                                                      string titre = "", int priorite = 1, 
                                                      DateTime? dateExpiration = null, Guid? agentFiscalId = null)
    {
        return Create(type, DateTime.UtcNow, contenu, TypeDestinataire.AgentsFiscaux, 
                     null, agentFiscalId, titre, priorite, dateExpiration);
    }

    public static Notification CreatePourAdministrateurs(string type, string contenu, 
                                                        string titre = "", int priorite = 1, 
                                                        DateTime? dateExpiration = null, Guid? agentFiscalId = null)
    {
        return Create(type, DateTime.UtcNow, contenu, TypeDestinataire.Administrateurs, 
                     null, agentFiscalId, titre, priorite, dateExpiration);
    }
    
    public Notification Update(string type, DateTime dateEnvoi, string contenu, 
                             TypeDestinataire? typeDestinataire = null, Guid? contribuableId = null, 
                             string titre = "", int? priorite = null, DateTime? dateExpiration = null)
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

        if (typeDestinataire.HasValue && TypeDestinataire != typeDestinataire.Value)
        {
            TypeDestinataire = typeDestinataire.Value;
            isUpdated = true;
        }

        if (ContribuableId != contribuableId)
        {
            ContribuableId = contribuableId;
            isUpdated = true;
        }

        if (!string.IsNullOrEmpty(titre) && Titre != titre)
        {
            Titre = titre;
            isUpdated = true;
        }

        if (priorite.HasValue && Priorite != priorite.Value)
        {
            Priorite = priorite.Value;
            isUpdated = true;
        }

        if (DateExpiration != dateExpiration)
        {
            DateExpiration = dateExpiration;
            isUpdated = true;
        }

        if (isUpdated)
        {
            // Validation métier après mise à jour
            ValiderCoherenceDestinataire();
            QueueDomainEvent(new NotificationUpdated { Notification = this });
        }
        
        return this;
    }

    public void MarquerCommeLue()
    {
        if (!EstLue)
        {
            EstLue = true;
            DateLecture = DateTime.UtcNow;
            Statut = StatutNotification.Lu;
            QueueDomainEvent(new NotificationMarqueeCommeLue { Notification = this });
        }
    }

    public void MarquerCommeRecue()
    {
        if (Statut == StatutNotification.Envoye)
        {
            Statut = StatutNotification.Recu;
            QueueDomainEvent(new NotificationUpdated { Notification = this });
        }
    }

    public void MarquerCommeEchouee()
    {
        Statut = StatutNotification.Echoue;
        QueueDomainEvent(new NotificationUpdated { Notification = this });
    }

    public void Archiver()
    {
        if (!EstArchivee)
        {
            EstArchivee = true;
            QueueDomainEvent(new NotificationUpdated { Notification = this });
        }
    }

    public void Desarchiver()
    {
        if (EstArchivee)
        {
            EstArchivee = false;
            QueueDomainEvent(new NotificationUpdated { Notification = this });
        }
    }

    // Méthodes métier pour déterminer la visibilité
    public bool EstVisiblePourContribuable(Guid contribuableId)
    {
        return TypeDestinataire switch
        {
            TypeDestinataire.ContribuableSpecifique => ContribuableId == contribuableId,
            TypeDestinataire.TousLesContribuables => true,
            _ => false
        };
    }

    public bool EstVisiblePourAgentFiscal()
    {
        return TypeDestinataire == TypeDestinataire.AgentsFiscaux;
    }

    public bool EstVisiblePourAdministrateur()
    {
        return TypeDestinataire == TypeDestinataire.Administrateurs;
    }

    public bool EstExpiree()
    {
        return DateExpiration.HasValue && DateTime.UtcNow > DateExpiration.Value;
    }

    public bool EstUrgente()
    {
        return Priorite >= 3;
    }

    // Méthodes privées
    private void ValiderCoherenceDestinataire()
    {
        if (TypeDestinataire == TypeDestinataire.ContribuableSpecifique && !ContribuableId.HasValue)
        {
            throw new InvalidOperationException("Une notification pour un contribuable spécifique doit avoir un ContribuableId.");
        }

        if (TypeDestinataire != TypeDestinataire.ContribuableSpecifique && ContribuableId.HasValue)
        {
            throw new InvalidOperationException($"Une notification de type {TypeDestinataire} ne peut pas avoir un ContribuableId spécifique.");
        }
    }

    private string ExtraireDebutContenu(string contenu)
    {
        if (string.IsNullOrEmpty(contenu))
            return "Notification";

        // Extraire les premiers mots du contenu pour créer un titre
        var mots = contenu.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var titre = string.Join(" ", mots.Take(5));
        
        return titre.Length > 50 ? titre.Substring(0, 47) + "..." : titre;
    }
}
