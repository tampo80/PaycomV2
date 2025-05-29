using System.ComponentModel;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;
using MediatR;

namespace PayCom.WebApi.Taxe.Application.TransactionCollectes.Update.v1;
public record UpdateTransactionCollecteCommand(
    [property: DefaultValue("ID de la transaction")]
    Guid Id,
    [property: DefaultValue("Référence du paiement")]
    string? ReferencePaiement,
    [property: DefaultValue("Notes sur la transaction")]
    string? Notes) : IRequest<UpdateTransactionCollecteResponse>; 
