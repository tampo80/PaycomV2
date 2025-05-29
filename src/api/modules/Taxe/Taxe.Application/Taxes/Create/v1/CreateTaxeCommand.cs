using System;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.Taxes.Create.v1;
public record CreateTaxeCommand : IRequest<CreateTaxeResponse>
{
    [Required]
    public int AnneeImposition { get; init; } = DateTime.Now.Year;
    
    public double Taux { get; init; } = 0.0;
    public DateTime DateEcheance { get; init; } = new DateTime(DateTime.Now.Year, 12, 31);
    public double MontantDu { get; init; } = 0.0;
    public double MontantPaye { get; init; } = 0.0;
    public double SoldeRestant { get; init; } = 0.0;
    public double PrixUnitaire { get; init; } = 0.0;
    [StringLength(50)]
    public string UniteMesure { get; init; } = "Unité par défaut";
    [StringLength(500)]
    public string Caracteristiques { get; init; } = "Caractéristiques par défaut";
    public DateTime DateCreation { get; init; } = DateTime.Now;
    public DateTime DateDerniereModification { get; init; } = DateTime.Now;
}
