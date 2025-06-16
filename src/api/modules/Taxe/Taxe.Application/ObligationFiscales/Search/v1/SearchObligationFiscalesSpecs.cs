using Ardalis.Specification;
using PayCom.WebApi.Taxe.Domain;

namespace PayCom.WebApi.Taxe.Application.ObligationFiscales.Search.v1;

public sealed class SearchObligationFiscalesSpecs : Specification<ObligationFiscale>
{
    public SearchObligationFiscalesSpecs(SearchObligationFiscalesCommand request)
    {
        Query.Include(o => o.Contribuable)
             .Include(o => o.TypeTaxe)
             .Include(o => o.Commune)
             .Include(o => o.Echeances);

        // Filtres de base
        if (request.ContribuableId.HasValue)
        {
            Query.Where(o => o.ContribuableId == request.ContribuableId.Value);
        }

        if (request.TypeTaxeId.HasValue)
        {
            Query.Where(o => o.TypeTaxeId == request.TypeTaxeId.Value);
        }

        if (request.CommuneId.HasValue)
        {
            Query.Where(o => o.CommuneId == request.CommuneId.Value);
        }

        // Filtre par statut actif/inactif
        if (!request.IncludeInactives)
        {
            if (request.EstActif.HasValue)
            {
                Query.Where(o => o.EstActif == request.EstActif.Value);
            }
            else
            {
                Query.Where(o => o.EstActif == true);
            }
        }

        // Filtres par dates
        if (request.DateDebutMin.HasValue)
        {
            Query.Where(o => o.DateDebut >= request.DateDebutMin.Value);
        }

        if (request.DateDebutMax.HasValue)
        {
            Query.Where(o => o.DateDebut <= request.DateDebutMax.Value);
        }

        if (request.DateFinMin.HasValue)
        {
            Query.Where(o => o.DateFin >= request.DateFinMin.Value);
        }

        if (request.DateFinMax.HasValue)
        {
            Query.Where(o => o.DateFin <= request.DateFinMax.Value);
        }

        // Filtre par référence de propriété/bien
        if (!string.IsNullOrWhiteSpace(request.ReferenceProprieteBien))
        {
            Query.Where(o => o.ReferenceProprieteBien.Contains(request.ReferenceProprieteBien));
        }

        // Filtres par montant (basé sur le type de taxe)
        if (request.MontantMin.HasValue)
        {
            Query.Where(o => (o.TypeTaxe.MontantBase ?? 0) >= request.MontantMin.Value);
        }

        if (request.MontantMax.HasValue)
        {
            Query.Where(o => (o.TypeTaxe.MontantBase ?? 0) <= request.MontantMax.Value);
        }

        // Tri par défaut
        Query.OrderByDescending(o => o.Created)
             .ThenBy(o => o.Contribuable.Nom);

        // Pagination
        if (request.PageSize > 0)
        {
            Query.Skip((request.PageNumber - 1) * request.PageSize)
                 .Take(request.PageSize);
        }
    }
} 
