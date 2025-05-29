#!/bin/bash

# Parcourir tous les fichiers .cs dans src/api/modules/Taxe/Taxe.Application/
find src/api/modules/Taxe/Taxe.Application/ -name "*.cs" -type f | while read -r file; do
    # Ajouter les using statements pour le domaine si nécessaire
    if ! grep -q "using PayCom.WebApi.Taxe.Domain;" "$file"; then
        # Ajouter après le dernier using statement ou au début du fichier
        if grep -q "^using " "$file"; then
            sed -i '' -e '/^using [^;]*;$/a\
using PayCom.WebApi.Taxe.Domain;' "$file"
        else
            sed -i '' '1s/^/using PayCom.WebApi.Taxe.Domain;\n/' "$file"
        fi
    fi
    
    # Ajouter les using statements pour les enums si nécessaire
    if ! grep -q "using PayCom.WebApi.Taxe.Domain.Enums;" "$file"; then
        # Ajouter après le dernier using statement ou après le using du domaine
        if grep -q "^using " "$file"; then
            sed -i '' -e '/^using [^;]*;$/a\
using PayCom.WebApi.Taxe.Domain.Enums;' "$file"
        else
            sed -i '' '1s/^/using PayCom.WebApi.Taxe.Domain.Enums;\n/' "$file"
        fi
    fi
    
    # Ajouter les using statements pour les événements si nécessaire
    if ! grep -q "using PayCom.WebApi.Taxe.Domain.Events;" "$file"; then
        # Ajouter après le dernier using statement ou après les autres using
        if grep -q "^using " "$file"; then
            sed -i '' -e '/^using [^;]*;$/a\
using PayCom.WebApi.Taxe.Domain.Events;' "$file"
        else
            sed -i '' '1s/^/using PayCom.WebApi.Taxe.Domain.Events;\n/' "$file"
        fi
    fi
done

echo "Domain using statements added successfully!" 