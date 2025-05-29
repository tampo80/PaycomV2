using System;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.Echeances.AppliquerPenalite.v1;
public record AppliquerPenaliteCommand : IRequest<AppliquerPenaliteResponse>
{
    [Required]
    public Guid EcheanceId { get; init; }
    
    [Range(0.01, double.MaxValue, ErrorMessage = "Le montant de la pénalité doit être supérieur à zéro")]
    public double MontantPenalite { get; init; }
}
