using Ardalis.Specification;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Application.Notifications.Get.v1;

namespace PayCom.WebApi.Taxe.Application.Notifications.Search.v1;
public class SearchNotificationSpecs : Specification<Notification, NotificationResponse>
{
    public SearchNotificationSpecs(SearchNotificationCommand command)
    {
        // Appliquer les filtres de base
        Query.Where(n => n.Type.Contains(command.Keyword), !string.IsNullOrEmpty(command.Keyword));
        
        // Tri
        Query.OrderBy(n => n.Type, !command.HasOrderBy());
        
        // Pagination
        Query.Skip((command.PageNumber - 1) * command.PageSize)
             .Take(command.PageSize);
        
        // Projection explicite vers NotificationResponse
        Query.Select(n => new NotificationResponse(
            n.Id,
            n.Type,
            n.DateEnvoi,
            n.Contenu,
            n.EstLue,
            n.DateLecture,
            n.Statut,
            n.TypeDestinataire,
            n.ContribuableId,
            n.AgentFiscalId,
            n.Titre,
            n.Priorite,
            n.DateExpiration,
            n.EstArchivee
        ));
    }
}
