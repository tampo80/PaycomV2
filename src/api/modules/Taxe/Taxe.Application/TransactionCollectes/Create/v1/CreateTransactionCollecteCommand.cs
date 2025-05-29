using System;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.TransactionCollectes.Create.v1;
public record CreateTransactionCollecteCommand : IRequest<CreateTransactionCollecteResponse>
{
    [Required]
    public Guid EcheanceId { get; init; }
    
    public Guid? SessionId { get; init; }
    [Range(0.01, double.MaxValue, ErrorMessage = "Le montant payé doit être supérieur à zéro")]
    public double MontantPaye { get; init; }
    [StringLength(50)]
    public string ModePaiement { get; init; }
    [StringLength(100)]
    public string? ReferencePaiement { get; init; }
    [StringLength(500)]
    public string? Notes { get; init; }
}
