using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using PayCom.WebApi.Taxe.Domain.Events.CollecteTerrainSessionEvents;
using Shared.Enums;

namespace  PayCom.WebApi.Taxe.Domain;

public class CollecteTerrainSession : AuditableEntity, IAggregateRoot
{
    public Guid AgentFiscalId { get; private set; }
    public virtual AgentFiscal AgentFiscal { get; private set; } = default!;
    
    public Guid ZoneCollecteId { get; private set; }
    public virtual ZoneCollecte ZoneCollecte { get; private set; } = default!;
    
    public DateTime DateDebut { get; private set; }
    public DateTime? DateFin { get; private set; }
    public StatutSession Statut { get; private set; }
    public string Notes { get; private set; } = string.Empty;
    
    // Navigation property pour les transactions
    private readonly List<TransactionCollecte> _transactions = new();
    public virtual IReadOnlyCollection<TransactionCollecte> Transactions => _transactions.AsReadOnly();

    private CollecteTerrainSession() { }

    public CollecteTerrainSession(Guid id, Guid agentFiscalId, Guid zoneCollecteId, 
                                 DateTime dateDebut, DateTime? dateFin, StatutSession statut, string notes)
    {
        Id = id;
        AgentFiscalId = agentFiscalId;
        ZoneCollecteId = zoneCollecteId;
        DateDebut = dateDebut;
        DateFin = dateFin;
        Statut = statut;
        Notes = notes;
        
        QueueDomainEvent(new CollecteTerrainSessionCreated { Session = this });
    }

    public static CollecteTerrainSession Create(Guid agentFiscalId, Guid zoneCollecteId, 
                                             DateTime dateDebut, string notes)
    {
        return new CollecteTerrainSession(Guid.NewGuid(), agentFiscalId, zoneCollecteId, 
                                        dateDebut, null, StatutSession.EnCours, notes);
    }

    public CollecteTerrainSession Update(Guid agentFiscalId, Guid zoneCollecteId, 
                                       DateTime dateDebut, DateTime? dateFin, StatutSession statut, string notes)
    {
        bool isUpdated = false;

        if (AgentFiscalId != agentFiscalId)
        {
            AgentFiscalId = agentFiscalId;
            isUpdated = true;
        }

        if (ZoneCollecteId != zoneCollecteId)
        {
            ZoneCollecteId = zoneCollecteId;
            isUpdated = true;
        }

        if (DateDebut != dateDebut)
        {
            DateDebut = dateDebut;
            isUpdated = true;
        }

        if (DateFin != dateFin)
        {
            DateFin = dateFin;
            isUpdated = true;
        }

        if (Statut != statut)
        {
            Statut = statut;
            isUpdated = true;
        }

        if (Notes != notes)
        {
            Notes = notes;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new CollecteTerrainSessionUpdated { Session = this });
        }

        return this;
    }

    public void Demarrer()
    {
        if (Statut != StatutSession.EnCours)
        {
            Statut = StatutSession.EnCours;
            DateDebut = DateTime.UtcNow;
            QueueDomainEvent(new SessionCollecteDemarree { Session = this });
        }
    }

    public void Terminer(string notes = "")
    {
        if (Statut == StatutSession.EnCours)
        {
            Statut = StatutSession.Terminee;
            DateFin = DateTime.UtcNow;
            
            if (!string.IsNullOrWhiteSpace(notes))
            {
                Notes = notes;
            }
            
            QueueDomainEvent(new SessionCollecteTerminee { Session = this });
        }
    }

    public void Annuler(string raison)
    {
        if (Statut == StatutSession.EnCours)
        {
            Statut = StatutSession.Annulee;
            DateFin = DateTime.UtcNow;
            Notes = raison;
            QueueDomainEvent(new SessionCollecteAnnulee { Session = this, Raison = raison });
        }
    }

    public void AjouterTransaction(TransactionCollecte transaction)
    {
        if (Statut == StatutSession.EnCours)
        {
            _transactions.Add(transaction);
            QueueDomainEvent(new TransactionAjouteeSession { Session = this, Transaction = transaction });
        }
    }
} 
