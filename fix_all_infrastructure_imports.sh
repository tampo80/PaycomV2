#!/bin/bash

# Parcourir tous les fichiers .cs dans src/api/modules/Taxe/Taxe.Infrastructure/
find src/api/modules/Taxe/Taxe.Infrastructure/ -name "*.cs" -type f | while read -r file; do
    # Les imports de domain sont corrects (ne pas les toucher)
    # Corriger les imports pour toutes les entités
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.AgentFiscals\./using PayCom.WebApi.Taxe.Application.AgentFiscals./g' "$file"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.Communes\./using PayCom.WebApi.Taxe.Application.Communes./g' "$file"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.Provinces\./using PayCom.WebApi.Taxe.Application.Provinces./g' "$file"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.Regions\./using PayCom.WebApi.Taxe.Application.Regions./g' "$file"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.Taxes\./using PayCom.WebApi.Taxe.Application.Taxes./g' "$file"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.Contribuables\./using PayCom.WebApi.Taxe.Application.Contribuables./g' "$file"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.Documents\./using PayCom.WebApi.Taxe.Application.Documents./g' "$file"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.EventHandlers\./using PayCom.WebApi.Taxe.Application.EventHandlers./g' "$file"
    
    # Ajout des autres entités trouvées
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.TypeTaxes\./using PayCom.WebApi.Taxe.Application.TypeTaxes./g' "$file"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.Penalites\./using PayCom.WebApi.Taxe.Application.Penalites./g' "$file"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.TransactionCollectes\./using PayCom.WebApi.Taxe.Application.TransactionCollectes./g' "$file"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.Operations\./using PayCom.WebApi.Taxe.Application.Operations./g' "$file"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.Paiements\./using PayCom.WebApi.Taxe.Application.Paiements./g' "$file"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.Notifications\./using PayCom.WebApi.Taxe.Application.Notifications./g' "$file"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.CollecteTerrainSessions\./using PayCom.WebApi.Taxe.Application.CollecteTerrainSessions./g' "$file"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.Villes\./using PayCom.WebApi.Taxe.Application.Villes./g' "$file"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.Villages\./using PayCom.WebApi.Taxe.Application.Villages./g' "$file"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.ObligationFiscales\./using PayCom.WebApi.Taxe.Application.ObligationFiscales./g' "$file"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.Echeances\./using PayCom.WebApi.Taxe.Application.Echeances./g' "$file"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.Prefectures\./using PayCom.WebApi.Taxe.Application.Prefectures./g' "$file"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.ZoneCollectes\./using PayCom.WebApi.Taxe.Application.ZoneCollectes./g' "$file"
    
    # Ne pas toucher aux imports de Domain et Infrastructure
done

echo "Tous les imports dans Taxe.Infrastructure ont été corrigés!" 