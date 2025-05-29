using MediatR;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.Configurations.Get.v1;
public class GetConfigurationRequest : IRequest<ConfigurationResponse>
{
    public Guid Id { get; set; }
    public string Cle { get; set; }
    public string Valeur { get; set; }
    public string Description { get; set; }
    
}
