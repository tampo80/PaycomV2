using System;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.Penalites.Create.v1;
public record CreatePenaliteCommand : IRequest<CreatePenaliteResponse>
{
    [Required]
    public DateTime DateApplication { get; init; }
    
    public double Montant { get; init; }
    [StringLength(100)]
    public string Type { get; init; }
    [StringLength(500)]
    public string Description { get; init; }
    public Guid TaxeConcerneeId { get; init; }
}
