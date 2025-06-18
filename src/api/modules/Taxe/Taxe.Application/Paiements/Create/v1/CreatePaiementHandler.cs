using FSH.Framework.Core.Persistence;
using PayCom.WebApi.Taxe.Domain.Events;
using PayCom.WebApi.Taxe.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using PayCom.WebApi.Taxe.Application.Paiements.Specifications;

namespace PayCom.WebApi.Taxe.Application.Paiements.Create.v1;
public sealed class CreatePaiementHandler(
    ILogger<CreatePaiementHandler> logger,
    [FromKeyedServices("taxe:paiements")] IRepository<Paiement> repository,
    [FromKeyedServices("taxe:contribuables")] IRepository<Contribuable> contribuableRepository)
    : IRequestHandler<CreatePaiementCommand, CreatePaiementResponse>
{
    public async Task<CreatePaiementResponse> Handle(CreatePaiementCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        // Vérifier que le contribuable existe
        var contribuable = await contribuableRepository.GetByIdAsync(request.ContribuableId, cancellationToken);
        if (contribuable == null)
        {
            throw new InvalidOperationException($"Contribuable non trouvé avec l'ID {request.ContribuableId}");
        }
        
        // Générer un code de transaction unique si nécessaire
        var codeTransaction = await EnsureUniqueTransactionCode(request.CodeTransaction, cancellationToken);
        
        // Convertir Guid.Empty vers null pour les paiements libres
        var echeanceId = request.EcheanceId == Guid.Empty ? null : (Guid?)request.EcheanceId;
        
        var paiement = Paiement.Create(
            request.Date, 
            request.Montant, 
            request.ModePaiement,
            codeTransaction, 
            request.DateTransaction,
            request.Statut,
            request.FraisTransaction, 
            request.InformationsSupplementaires,
            request.ContribuableId,
            echeanceId,
            agentFiscalId: null);
            
        await repository.AddAsync(paiement, cancellationToken);
        logger.LogInformation("Paiement créé {paiementId} par contribuable {contribuableId} avec code transaction {codeTransaction}, EcheanceId: {echeanceId}", 
            paiement.Id, request.ContribuableId, codeTransaction, echeanceId?.ToString() ?? "NULL (paiement libre)");
        return new CreatePaiementResponse(paiement.Id);
    }
    
    private async Task<string> EnsureUniqueTransactionCode(string originalCode, CancellationToken cancellationToken)
    {
        var codeTransaction = originalCode;
        var attempts = 0;
        const int maxAttempts = 5;
        
        while (attempts < maxAttempts)
        {
            // Vérifier si le code existe déjà en utilisant la spécification
            var spec = new PaiementByCodeTransactionSpec(codeTransaction);
            var existingPaiement = await repository.FirstOrDefaultAsync(spec, cancellationToken);
                
            if (existingPaiement == null)
            {
                return codeTransaction; // Code unique trouvé
            }
            
            // Générer un nouveau code
            attempts++;
            var timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
            var guidPart = Guid.NewGuid().ToString("N")[..8];
            codeTransaction = $"PAY-{timestamp}-{guidPart.ToUpper()}-{attempts}";
            
            logger.LogWarning("Conflit de code de transaction détecté. Tentative {attempts}: {newCode}", 
                attempts, codeTransaction);
        }
        
        throw new InvalidOperationException($"Impossible de générer un code de transaction unique après {maxAttempts} tentatives");
    }
}
