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
    
    public double Montant { get; init; }
    public ModePaiement ModePaiement { get; init; }
    [StringLength(100)]
    public string CodeTransaction { get; init; }
    public DateTime DateTransaction { get; init; }
    public StatutPaiement Statut { get; init; } = StatutPaiement.EnAttente;
    public double FraisTransaction { get; init; } = 0.0;
    [StringLength(500)]
    public string InformationsSupplementaires { get; init; }
}
