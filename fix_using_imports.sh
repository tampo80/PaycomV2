#!/bin/bash

# Parcourir tous les fichiers .cs dans src/api/modules/Taxe/Taxe.Application/
find src/api/modules/Taxe/Taxe.Application/ -name "*.cs" -type f | while read -r file; do
    # Remplacer "using PayCom.WebApi.Taxe.Application.Application" par "using PayCom.WebApi.Taxe.Application"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.Application\.Application/using PayCom.WebApi.Taxe.Application/g' "$file"
done

echo "Using import statements fixed successfully!" 