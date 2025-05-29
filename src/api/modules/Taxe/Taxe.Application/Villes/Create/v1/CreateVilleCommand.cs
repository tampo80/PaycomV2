using System;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.Villes.Create.v1;
public record CreateVilleCommand : IRequest<CreateVilleResponse>
{
    [Required]
    [StringLength(100)]
    public string Nom { get; init; }
    
    public string Description { get; init; }
    public string Code { get; init; }
    public Guid PrefectureId { get; init; }
} 
