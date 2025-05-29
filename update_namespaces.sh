#!/bin/bash

# Parcourir tous les fichiers .cs dans src/api/modules/Taxe/Taxe.Application/
find src/api/modules/Taxe/Taxe.Application/ -name "*.cs" -type f | while read -r file; do
    # Remplacer "namespace PayCom.WebApi.Taxe.[Entity]" par "namespace PayCom.WebApi.Taxe.Application.[Entity]"
    sed -i '' 's/namespace PayCom\.WebApi\.Taxe\.\([^\.]*\)\./namespace PayCom.WebApi.Taxe.Application.\1./g' "$file"
    
    # Remplacer les records sealed par des records simples
    sed -i '' 's/public sealed record/public record/g' "$file"
done

echo "Namespaces updated successfully!" 