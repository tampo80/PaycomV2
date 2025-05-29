# Correction des namespaces dans le module Taxe

Ce projet a effectué plusieurs modifications sur les namespaces dans les modules Taxe.Application et Taxe.Infrastructure pour harmoniser la structure avec le module de référence Catalog.

## Modifications effectuées

1. **Correction des namespaces de base dans Taxe.Application**
   - Modification de `namespace PayCom.WebApi.Taxe.[Entity]` vers `namespace PayCom.WebApi.Taxe.Application.[Entity]`
   - Script utilisé: `update_namespaces.sh`

2. **Élimination des doubles "Application" dans les namespaces**
   - Correction des cas où "Application" apparaissait deux fois: `PayCom.WebApi.Taxe.Application.Application` → `PayCom.WebApi.Taxe.Application`
   - Script utilisé: `fix_double_application.sh`

3. **Ajout des using statements pour les classes du domaine**
   - Ajout systématique des using statements pour les classes du domaine:
     - `using PayCom.WebApi.Taxe.Domain;`
     - `using PayCom.WebApi.Taxe.Domain.Events;`
     - `using PayCom.WebApi.Taxe.Domain.Enums;`
   - Script utilisé: `add_domain_using.sh`

4. **Nettoyage des using statements en double**
   - Suppression des directives using redondantes
   - Script utilisé: `fix_duplicate_using.sh`

5. **Correction des références incorrectes à "Application.Domain"**
   - Modification de `using PayCom.WebApi.Taxe.Application.Domain.Exceptions` vers `using PayCom.WebApi.Taxe.Domain.Exceptions`
   - Modification de `using PayCom.WebApi.Taxe.Application.Domain` vers `using PayCom.WebApi.Taxe.Domain`
   - Script utilisé: `fix_domain_imports.sh`

6. **Correction des imports dans Taxe.Infrastructure**
   - Ajout du segment "Application" manquant dans les imports:
     - `using PayCom.WebApi.Taxe.AgentFiscals...` → `using PayCom.WebApi.Taxe.Application.AgentFiscals...`
     - Et similaire pour Communes, Provinces, Regions, etc.
   - Script utilisé: `fix_infrastructure_imports.sh`

## Problèmes résiduels

1. **Erreurs de syntaxe dans certains fichiers**
   - Plusieurs fichiers contiennent des erreurs de syntaxe qui empêchent la compilation:
     - `UpdateCommuneHandler.cs`: problèmes avec les accolades, les conditions et les délimiteurs
     - `ChefLieuChangedHandler.cs`: problèmes similaires de syntaxe C#
   - Ces fichiers doivent être corrigés manuellement en les éditant un par un

2. **Références à des événements spécifiques**
   - Certains fichiers font référence à des classes d'événements spécifiques dans le Domain.Events
   - Ces références peuvent nécessiter une mise à jour manuelle pour pointer vers le bon namespace

## Convention de nommage à suivre

Pour maintenir la cohérence du projet, tous les namespaces dans le module Taxe.Application doivent suivre cette convention:

```csharp
namespace PayCom.WebApi.Taxe.Application.[Entity].[Operation].[Version];
```

Par exemple:
```csharp
namespace PayCom.WebApi.Taxe.Application.Communes.Get.v1;
```

De même, les imports dans Taxe.Infrastructure qui font référence aux classes de Taxe.Application doivent inclure le segment "Application":

```csharp
using PayCom.WebApi.Taxe.Application.[Entity].[Operation].[Version];
```
