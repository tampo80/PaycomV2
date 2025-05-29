#!/bin/bash

# Liste de tous les motifs à corriger (ne pas inclure Domain et Infrastructure)
entities=(
  "TypeTaxes"
  "Penalites"
  "TransactionCollectes"
  "Operations"
  "Paiements"
  "Notifications"
  "CollecteTerrainSessions"
  "Villes"
  "Villages"
  "ObligationFiscales"
  "Echeances"
  "Prefectures"
  "ZoneCollectes"
  "AgentFiscals"
  "Communes"
  "Provinces"
  "Regions"
  "Taxes"
  "Contribuables"
  "Documents"
  "EventHandlers"
)

# Parcourir chaque fichier .cs dans Taxe.Infrastructure
find src/api/modules/Taxe/Taxe.Infrastructure -name "*.cs" -type f | while read -r file; do
  echo "Traitement du fichier: $file"
  # Pour chaque entité, effectuer le remplacement
  for entity in "${entities[@]}"; do
    # Utiliser perl pour les substitutions (plus fiable que sed sur certains systèmes)
    perl -i -pe "s/using PayCom\.WebApi\.Taxe\.$entity\./using PayCom.WebApi.Taxe.Application.$entity./g" "$file"
  done
done

echo "Imports corrigés avec succès!" 