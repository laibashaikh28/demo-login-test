#!/bin/bash

# Function to print usage instructions
usage() {
    echo "Usage: $0 <Major|Minor|Patch> <current_version>"
    exit 1
}

# Check if correct number of arguments is provided
if [ "$#" -ne 2 ]; then
    usage
fi

# Extracting arguments
increment_type=$1
current_version=$2

# Splitting current version into Major, Minor, and Patch
IFS='.' read -r -a version_parts <<< "$current_version"
Major=${version_parts[0]}
Minor=${version_parts[1]}
Patch=${version_parts[2]}

# Increment version based on the specified type
case $increment_type in
    Major)
        Major=$((Major + 1))
        Minor=0
        Patch=0
        ;;
    Minor)
        Minor=$((Minor + 1))
        Patch=0
        ;;
    Patch)
        Patch=$((Patch + 1))
        ;;
    *)
        echo "Invalid increment type. Use 'Major', 'Minor', or 'Patch'."
        usage
        ;;
esac

# Print the new version
echo "$Major.$Minor.$Patch"
