using System.ComponentModel.DataAnnotations;
using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.Penalites.Update.v1;

public record UpdatePenaliteCommand(
    [Required] Guid Id,
    [Required] decimal MontantPenalite,
    [Required] decimal TauxPenalite,
    [Required] DateTime DateApplication,
    [Required] int NombreJoursRetard,
    string? Motif = null,
    string? Observation = null) : IRequest<UpdatePenaliteResponse>;
