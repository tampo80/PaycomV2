using System;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.Echeances.Create.v1;
public record CreateEcheanceCommand : IRequest<CreateEcheanceResponse>
{
    [Required]
    public Guid ObligationFiscaleId { get; init; }
    
    public int AnneeImposition { get; init; }
    public int PeriodeImposition { get; init; }
    public DateTime DateEcheance { get; init; }
    public double MontantBase { get; init; }
    public double MontantPenalites { get; init; } = 0.0;
    public StatutEcheance Statut { get; init; } = StatutEcheance.EnAttente;
}
