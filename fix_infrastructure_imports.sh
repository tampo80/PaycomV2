#!/bin/bash

# Parcourir tous les fichiers .cs dans src/api/modules/Taxe/Taxe.Infrastructure/
find src/api/modules/Taxe/Taxe.Infrastructure/ -name "*.cs" -type f | while read -r file; do
    # Corriger les imports pour les AgentFiscals
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.AgentFiscals\./using PayCom.WebApi.Taxe.Application.AgentFiscals./g' "$file"
    
    # Corriger les imports pour les autres modules potentiels (par analogie)
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.Communes\./using PayCom.WebApi.Taxe.Application.Communes./g' "$file"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.Provinces\./using PayCom.WebApi.Taxe.Application.Provinces./g' "$file"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.Regions\./using PayCom.WebApi.Taxe.Application.Regions./g' "$file"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.Taxes\./using PayCom.WebApi.Taxe.Application.Taxes./g' "$file"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.Contribuables\./using PayCom.WebApi.Taxe.Application.Contribuables./g' "$file"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.Documents\./using PayCom.WebApi.Taxe.Application.Documents./g' "$file"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.EventHandlers\./using PayCom.WebApi.Taxe.Application.EventHandlers./g' "$file"
    
    # Ajouter d'autres entités au besoin selon la structure de l'application
done

echo "Infrastructure imports corrected successfully!" 