using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.Penalites.Get.v1;

public record PenaliteResponse(
    Guid Id,
    Guid EcheanceId,
    Guid ObligationFiscaleId,
    TypePenalite TypePenalite,
    decimal MontantPenalite,
    decimal TauxPenalite,
    DateTime DateCalcul,
    DateTime DateApplication,
    int NombreJoursRetard,
    string? Motif,
    string? Observation,
    StatutPenalite Statut,
    bool EstAnnulee,
    DateTime? DateAnnulation,
    string? MotifAnnulation,
    DateTime Created,
    DateTime LastModified,
    // Propriétés de navigation pour l'affichage
    string? ContribuableNom = null,
    string? TypeTaxeNom = null,
    string? CommuneNom = null,
    DateTime? DateEcheance = null,
    decimal? MontantEcheance = null);
