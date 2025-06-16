using System;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.ObligationFiscales.Update.v1;

public record UpdateObligationFiscaleCommand : IRequest<UpdateObligationFiscaleResponse>
{
    [Required]
    public Guid Id { get; init; }
    
    public Guid? ContribuableId { get; init; }
    public Guid? TypeTaxeId { get; init; }
    public Guid? CommuneId { get; init; }
    public DateTime? DateDebut { get; init; }
    public DateTime? DateFin { get; init; }
    public string? ReferenceProprieteBien { get; init; }
    public string? LocalisationGPS { get; init; }
    
    [Range(0, double.MaxValue, ErrorMessage = "Le montant personnalisé doit être supérieur ou égal à zéro")]
    public double? MontantPersonnalise { get; init; }
    
    public bool? EstActif { get; init; }
}
