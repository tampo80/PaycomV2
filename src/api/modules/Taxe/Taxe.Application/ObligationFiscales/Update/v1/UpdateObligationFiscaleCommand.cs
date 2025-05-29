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
    
    public DateTime? DateFin { get; init; }
    [Range(0, double.MaxValue, ErrorMessage = "Le montant personnalisé doit être supérieur ou égal à zéro")]
    public double? MontantPersonnalise { get; init; }
}
