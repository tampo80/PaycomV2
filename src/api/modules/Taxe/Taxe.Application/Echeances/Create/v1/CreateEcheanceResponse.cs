using System;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.Echeances.Create.v1;
public record CreateEcheanceResponse
{
    public Guid Id { get; init; }
    public Guid ObligationFiscaleId { get; init; }
    public int AnneeImposition { get; init; }
    public int PeriodeImposition { get; init; }
    public DateTime DateEcheance { get; init; }
    public double MontantBase { get; init; }
    public double MontantPenalites { get; init; }
    public double MontantTotal { get; init; }
    public StatutEcheance Statut { get; init; }
}
