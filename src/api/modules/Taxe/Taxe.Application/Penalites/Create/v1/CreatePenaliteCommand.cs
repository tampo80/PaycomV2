using System;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.Penalites.Create.v1;

public record CreatePenaliteCommand(
    [Required] Guid EcheanceId,
    [Required] Guid ObligationFiscaleId,
    [Required] TypePenalite TypePenalite,
    [Required] decimal MontantPenalite,
    [Required] decimal TauxPenalite,
    [Required] DateTime DateCalcul,
    [Required] DateTime DateApplication,
    [Required] int NombreJoursRetard,
    string? Motif = null,
    string? Observation = null) : IRequest<CreatePenaliteResponse>;
