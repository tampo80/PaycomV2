#!/bin/bash

# Liste des fichiers endpoints avec leurs entités respectives
declare -A files=(
  ["src/api/modules/Taxe/Taxe.Infrastructure/EndPoints/v1/TypeTaxeEndPoints.cs"]="TypeTaxes"
  ["src/api/modules/Taxe/Taxe.Infrastructure/EndPoints/v1/PenaliteEndPoints.cs"]="Penalites"
  ["src/api/modules/Taxe/Taxe.Infrastructure/EndPoints/v1/TransactionCollecteEndPoints.cs"]="TransactionCollectes"
  ["src/api/modules/Taxe/Taxe.Infrastructure/EndPoints/v1/OperationEndPoints.cs"]="Operations"
  ["src/api/modules/Taxe/Taxe.Infrastructure/EndPoints/v1/PaiementEndPoints.cs"]="Paiements"
  ["src/api/modules/Taxe/Taxe.Infrastructure/EndPoints/v1/NotificationEndPoints.cs"]="Notifications"
  ["src/api/modules/Taxe/Taxe.Infrastructure/EndPoints/v1/CollecteTerrainSessionEndPoints.cs"]="CollecteTerrainSessions"
  ["src/api/modules/Taxe/Taxe.Infrastructure/EndPoints/v1/VilleEndPoints.cs"]="Villes"
  ["src/api/modules/Taxe/Taxe.Infrastructure/EndPoints/v1/VillageEndPoints.cs"]="Villages"
  ["src/api/modules/Taxe/Taxe.Infrastructure/EndPoints/v1/ObligationFiscaleEndPoints.cs"]="ObligationFiscales"
  ["src/api/modules/Taxe/Taxe.Infrastructure/EndPoints/v1/EcheanceEndPoints.cs"]="Echeances"
  ["src/api/modules/Taxe/Taxe.Infrastructure/EndPoints/v1/PrefectureEndPoints.cs"]="Prefectures"
  ["src/api/modules/Taxe/Taxe.Infrastructure/EndPoints/v1/ZoneCollecteEndPoints.cs"]="ZoneCollectes"
  ["src/api/modules/Taxe/Taxe.Infrastructure/EndPoints/v1/AgentFiscalEndPoints.cs"]="AgentFiscals"
  ["src/api/modules/Taxe/Taxe.Infrastructure/EndPoints/v1/ContribuableEndPoint.cs"]="Contribuables"
  ["src/api/modules/Taxe/Taxe.Infrastructure/EndPoints/v1/RegionEndPoints.cs"]="Regions"
  ["src/api/modules/Taxe/Taxe.Infrastructure/EndPoints/v1/CreateCommuneEndpoint.cs"]="Communes"
  ["src/api/modules/Taxe/Taxe.Infrastructure/EndPoints/v1/GetCommuneEndpoint.cs"]="Communes"
  ["src/api/modules/Taxe/Taxe.Infrastructure/EndPoints/v1/UpdateCommuneEndpoint.cs"]="Communes"
  ["src/api/modules/Taxe/Taxe.Infrastructure/EndPoints/v1/DeleteCommuneEndpoint.cs"]="Communes"
  ["src/api/modules/Taxe/Taxe.Infrastructure/EndPoints/v1/SearchCommuneEndpoint.cs"]="Communes"
)

# Traiter chaque fichier individuellement
for file in "${!files[@]}"; do
  entity="${files[$file]}"
  
  if [ -f "$file" ]; then
    echo "Traitement du fichier: $file avec l'entité: $entity"
    
    # Utiliser sed pour remplacer les imports
    sed -i '' "s/using PayCom\.WebApi\.Taxe\.$entity\./using PayCom.WebApi.Taxe.Application.$entity./g" "$file"
  else
    echo "Fichier non trouvé: $file"
  fi
done

echo "Imports corrigés manuellement!" 