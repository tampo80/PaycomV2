#!/bin/bash

# Parcourir tous les fichiers .cs dans src/api/modules/Taxe/Taxe.Application/
find src/api/modules/Taxe/Taxe.Application/ -name "*.cs" -type f | while read -r file; do
    # Remplacer "namespace PayCom\.WebApi\.Taxe\.Application\.Application" par "namespace PayCom.WebApi.Taxe.Application"
    sed -i '' 's/namespace PayCom\.WebApi\.Taxe\.Application\.Application/namespace PayCom.WebApi.Taxe.Application/g' "$file"
done

echo "Double 'Application' namespaces corrected successfully!" 