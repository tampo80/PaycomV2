using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Echeanciers.Get.v1;
public class GetEcheancierRequest : IRequest<EcheancierResponse>
{
    public Guid Id { get; set; }
    public DateTime DateEcheance { get; set; }
    public double MontantDu { get; set; }
    public double MontantPaye { get; set; }
}
