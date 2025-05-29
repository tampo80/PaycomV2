#!/bin/bash

# Parcourir tous les fichiers .cs dans src/api/modules/Taxe/Taxe.Application/
find src/api/modules/Taxe/Taxe.Application/ -name "*.cs" -type f | while read -r file; do
    # Remplacer "using PayCom.WebApi.Taxe.Application.Domain.Exceptions" par "using PayCom.WebApi.Taxe.Domain.Exceptions"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.Application\.Domain\./using PayCom.WebApi.Taxe.Domain./g' "$file"
    
    # Corriger également "using PayCom.WebApi.Taxe.Application.Domain;" si présent
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.Application\.Domain;/using PayCom.WebApi.Taxe.Domain;/g' "$file"
done

echo "Domain imports corrected successfully!" 