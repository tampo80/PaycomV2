using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using Shared.Enums;

namespace PayCom.WebApi.Taxe.Application.TypeTaxes.Create.v1;

public sealed class CreateTypeTaxeHandler(
    ILogger<CreateTypeTaxeHandler> logger,
    [FromKeyedServices("taxe:types-taxe")] IRepository<PayCom.WebApi.Taxe.Domain.TypeTaxe> repository)
    : IRequestHandler<CreateTypeTaxeCommand, CreateTypeTaxeResponse>
{
    public async Task<CreateTypeTaxeResponse> Handle(CreateTypeTaxeCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        // Générer un code unique pour le type de taxe
        string code = $"TX-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";
        
        // Convertir la chaîne FrequencePaiement en enum
        if (!Enum.TryParse<FrequencePaiement>(request.FrequencePaiement, out var frequencePaiement))
        {
            frequencePaiement = FrequencePaiement.Mensuel; // Valeur par défaut
        }
        
        // Créer un nouveau type de taxe
        var typeTaxe = PayCom.WebApi.Taxe.Domain.TypeTaxe.Create(
            code,
            request.Nom,
            request.Description,
            true, // EstPeriodique par défaut
            frequencePaiement,
            Convert.ToDecimal(request.MontantBase),
            "Unité", // UniteMesure par défaut
            false // NecessiteInspection par défaut
        );
        
        // Sauvegarder dans la base de données
        await repository.AddAsync(typeTaxe, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        
        logger.LogInformation("Type de taxe créé avec l'ID {TypeTaxeId}", typeTaxe.Id);
        
        // Retourner la réponse
        return new CreateTypeTaxeResponse(typeTaxe.Id);
    }
} 
