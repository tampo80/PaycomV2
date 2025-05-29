using System;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.Echeanciers.Create.v1;
public record CreateEcheancierCommand : IRequest<CreateEcheancierResponse>
{
    [Required]
    public DateTime DateEcheance { get; init; }
    
    public double MontantDu { get; init; }
    public double MontantPaye { get; init; } = 0.0;
}
