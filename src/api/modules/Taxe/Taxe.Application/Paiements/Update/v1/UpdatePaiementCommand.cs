using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.Paiements.Update.v1;
public record UpdatePaiementCommand(
    Guid Id,
    decimal Montant,
    DateTime Date,
    ModePaiement ModePaiement,
    string CodeTransaction,
    DateTime DateTransaction,
    StatutPaiement Statut,
    decimal FraisTransaction,
    string InformationsSupplementaires) : IRequest<UpdatePaiementResponse>;
