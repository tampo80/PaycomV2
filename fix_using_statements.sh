#!/bin/bash

# Parcourir tous les fichiers .cs dans src/api/modules/Taxe/Taxe.Application/
find src/api/modules/Taxe/Taxe.Application/ -name "*.cs" -type f | while read -r file; do
    # Remplacer "using PayCom.WebApi.Taxe.[Entity]" par "using PayCom.WebApi.Taxe.Application.[Entity]"
    sed -i '' 's/using PayCom\.WebApi\.Taxe\.\([^\.]*\)\./using PayCom.WebApi.Taxe.Application.\1./g' "$file"
done

echo "Using statements updated successfully!" 