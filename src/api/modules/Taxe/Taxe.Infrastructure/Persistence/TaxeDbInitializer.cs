using FSH.Framework.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PayCom.WebApi.Taxe.Domain;
using Shared.Enums;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PayCom.WebApi.Taxe.Infrastructure.Persistence;

public sealed class TaxeDbInitializer(ILogger<TaxeDbInitializer> logger,
    TaxeDbContext context) : IDbInitializer
{
    public async Task MigrateAsync(CancellationToken cancellationToken)
    {
        if ((await context.Database.GetPendingMigrationsAsync(cancellationToken)).Any())
        {
            await context.Database.MigrateAsync(cancellationToken).ConfigureAwait(false);
            logger.LogInformation("[{Tenant}] applied database migrations for taxe module", context.TenantInfo!.Identifier);
        }
    }

    public async Task SeedAsync(CancellationToken cancellationToken)
    {
        // Vérifier si la base de données contient déjà des données
        if (!await context.Contribuables.AnyAsync(cancellationToken))
        {
            // Créer et ajouter des données de base pour les types de contribuables
            logger.LogInformation("Initialisation des données de base pour le module Taxe");
            
            // Ajout d'un contribuable personne physique de test
            var contribuable1 = Contribuable.Create(
                "Dupont", 
                "Jean", 
                new DateTime(1980, 1, 1),
                "PP12345",
                string.Empty, // Pas de nom commercial pour une personne physique
                "123 Rue Principale, Ville",
                "12.345,6.789",
                "N/A",
                "+123456789",
                string.Empty,
                DateTime.UtcNow,
                StatutContribuable.Actif,
                Genre.Homme,
                TypeContribuable.PersonnePhysique,
                string.Empty,
                "jean.dupont@example.com",
                null // Pas d'utilisateur associé pour l'instant
            );
            
            // Ajout d'un contribuable personne physique de test avec utilisateur associé
            var contribuable3 = Contribuable.Create(
                "Martin", 
                "Marie", 
                new DateTime(1985, 5, 15),
                "PP54321",
                string.Empty, // Pas de nom commercial pour une personne physique
                "456 Avenue du Commerce, Ville",
                "12.345,6.789",
                "N/A",
                "+123456788",
                string.Empty,
                DateTime.UtcNow,
                StatutContribuable.Actif,
                Genre.Femme,
                TypeContribuable.PersonnePhysique,
                string.Empty,
                "marie.martin@example.com",
                Guid.Parse("00000000-0000-0000-0000-000000000002") // ID utilisateur fictif, à remplacer par un vrai ID
            );
            
            // Ajout d'un contribuable personne morale de test
            var contribuable2 = Contribuable.Create(
                "Entreprise ABC",
                string.Empty, // Pas de prénom pour une personne morale
                DateTime.MinValue, // Date non applicable
                "PM67890",
                "ABC Commerce",
                "456 Avenue des Affaires, Ville",
                "12.345,6.789",
                "Commerce",
                "+987654321",
                "+123456789",
                DateTime.UtcNow,
                StatutContribuable.Actif,
                Genre.Autre, // Non applicable
                TypeContribuable.PersonneMorale,
                "RC12345",
                "contact@abc-commerce.com",
                null // Pas d'utilisateur associé pour l'instant
            );
            
            // Ajout d'un agent fiscal collecteur de test
            var agentCollecteur = AgentFiscal.CreateCollecteur(
                "Martin",
                "Sophie",
                "AGT001",
                "12.345,6.789",
                DateTime.UtcNow,
                null, // Pas d'utilisateur associé pour l'instant
                "sophie.martin@example.com",
                "+123456789"
            );
            
            // Ajout d'un agent fiscal avec un utilisateur (pour tester la fonctionnalité d'authentification)
            var agentFiscalAvecUtilisateur = AgentFiscal.Create(
                "Dupont",
                "Jean",
                "AGT002",
                "12.345,6.789",
                DateTime.UtcNow,
                null,
                StatutAgent.Actif,
                Guid.Parse("00000000-0000-0000-0000-000000000001"), // ID utilisateur fictif, à remplacer par un vrai ID
                "jean.dupont@example.com",
                "+123456789",
                false,
                0
            );
            
            // Ajouter à la base de données
            await context.Contribuables.AddRangeAsync(new[] { contribuable1, contribuable2, contribuable3 }, cancellationToken);
            await context.AgentsFiscaux.AddRangeAsync(new[] { agentCollecteur, agentFiscalAvecUtilisateur }, cancellationToken);
            
            await context.SaveChangesAsync(cancellationToken);
            
            logger.LogInformation("Données initiales ajoutées avec succès pour le module Taxe");
        }
    }
}
