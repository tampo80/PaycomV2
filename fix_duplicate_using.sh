#!/bin/bash

# Parcourir tous les fichiers .cs dans src/api/modules/Taxe/Taxe.Application/
find src/api/modules/Taxe/Taxe.Application/ -name "*.cs" -type f | while read -r file; do
    # Créer un fichier temporaire avec les using dédoublonnés
    awk '!seen[$0]++' "$file" > "$file.tmp"
    
    # Remplacer le fichier original par le fichier temporaire
    mv "$file.tmp" "$file"
done

echo "Duplicate using statements removed successfully!" 