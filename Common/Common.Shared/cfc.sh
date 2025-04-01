#!/bin/bash

# Base directory (current directory)
base_dir="."

# Define an associative array of folders and their files
declare -A structure=(
    ["Bases"]="BaseError.cs BaseResponseGeneric.cs BaseResponse.cs BaseResponsePagination.cs"
    ["Behaviours"]="LoggingBehaviour.cs PerformanceBehaviour.cs ValidationBehaviour.cs"
    ["Exceptions"]="ValidationExceptionCustom.cs"
)

# Iterate through the associative array to create folders and files
for folder in "${!structure[@]}"; do
    mkdir -p "$base_dir/$folder"  # Create the folder if it doesn't exist
    for file in ${structure[$folder]}; do
        touch "$base_dir/$folder/$file"  # Create each file inside the folder
    done
done

echo "Folders and files created successfully!"