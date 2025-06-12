using Ardalis.Specification;
using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Application.TypeTaxes.Get.v1;
using PayCom.WebApi.Taxe.Domain;
using System.Linq.Expressions;

namespace PayCom.WebApi.Taxe.Application.TypeTaxes.Search.v1;

public class SearchTypeTaxeSpecs : Specification<TypeTaxe, TypeTaxeResponse>
{
    public SearchTypeTaxeSpecs(SearchTypeTaxesCommand request)
    {
        Query.OrderByDescending(x => x.Created);

        if (!string.IsNullOrEmpty(request.SearchTerm))
        {
            // Recherche par nom ou description
            Query.Where(x => 
                x.Nom.Contains(request.SearchTerm) || 
                x.Description.Contains(request.SearchTerm) ||
                x.Code.Contains(request.SearchTerm));
        }

        // Pagination
        Query.Skip((request.PageNumber - 1) * request.PageSize)
             .Take(request.PageSize);

        // Mapper la réponse
        Query.Select(typeTaxe => new TypeTaxeResponse
        {
            Id = typeTaxe.Id,
            Code = typeTaxe.Code,
            Nom = typeTaxe.Nom,
            Description = typeTaxe.Description,
            EstPeriodique = typeTaxe.EstPeriodique,
            FrequencePaiement = typeTaxe.FrequencePaiement,
            //MontantBase = typeTaxe.TauxBase,
            UniteMesure = typeTaxe.UniteMesure,
            NecessiteInspection = typeTaxe.NecessiteInspection
        });
    }
} 
