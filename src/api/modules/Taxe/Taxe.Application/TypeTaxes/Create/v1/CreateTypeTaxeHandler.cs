using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using Shared.Enums;
using TypeTaxe = PayCom.WebApi.Taxe.Domain.TypeTaxe;

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
        string code = await GenerateUniqueCodeAsync(cancellationToken);
        
        // Créer un nouveau type de taxe avec le code généré
        var typeTaxe = TypeTaxe.Create(
            code,
            request.Nom,
            request.Description ?? string.Empty,
            request.EstPeriodique,
            request.FrequencePaiement,
            request.MontantBase,
            request.UniteMesure,
            request.NecessiteInspection
        );
        
        // Sauvegarder dans la base de données
        await repository.AddAsync(typeTaxe, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        
        logger.LogInformation("Type de taxe créé avec l'ID {TypeTaxeId} et le code {Code}", typeTaxe.Id, typeTaxe.Code);
        
        // Retourner la réponse
        return new CreateTypeTaxeResponse(typeTaxe.Id);
    }
    
    private async Task<string> GenerateUniqueCodeAsync(CancellationToken cancellationToken)
    {
        string code;
        bool codeExists;
        int attempts = 0;
        const int maxAttempts = 10;
        
        do
        {
            // Générer un code au format TX-YYYYMMDD-XXX
            var now = DateTime.UtcNow;
            var datePrefix = now.ToString("yyyyMMdd");
            var randomSuffix = Random.Shared.Next(100, 999);
            code = $"TX-{datePrefix}-{randomSuffix}";
            
            // Vérifier si le code existe déjà
            var existingTypeTaxe = await repository.GetBySpecAsync(
                new TypeTaxeByCodeSpec(code), cancellationToken);
            codeExists = existingTypeTaxe != null;
            
            attempts++;
        } while (codeExists && attempts < maxAttempts);
        
        if (codeExists)
        {
            // En dernier recours, utiliser un GUID
            code = $"TX-{Guid.NewGuid().ToString("N")[..8].ToUpper()}";
        }
        
        return code;
    }
} 
