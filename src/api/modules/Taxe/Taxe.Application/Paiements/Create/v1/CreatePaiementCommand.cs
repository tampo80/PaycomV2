using System;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.Paiements.Create.v1;
public record CreatePaiementCommand : IRequest<CreatePaiementResponse>
{
    [Required]
    public DateTime Date { get; init; }
    
    public decimal Montant { get; init; }
    public ModePaiement ModePaiement { get; init; }
    [StringLength(100)]
    public string CodeTransaction { get; init; } = string.Empty;
    public DateTime DateTransaction { get; init; }
    public StatutPaiement Statut { get; init; } = StatutPaiement.EnAttente;
    public decimal FraisTransaction { get; init; } = 0.0m;
    [StringLength(500)]
    public string InformationsSupplementaires { get; init; } = string.Empty;
    
    [Required]
    public Guid EcheanceId { get; init; }
}
