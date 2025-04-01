#!/bin/bash

# Set project names
PROJ_NAME="Registration"
echo "Project name is set to: $PROJ_NAME"
API_PROJECT_NAME="$PROJ_NAME.Api"
CORE_LIB_NAME="$PROJ_NAME.Core"
APPLICATION_LIB_NAME="$PROJ_NAME.Application"
INFRASTRUCTURE_LIB_NAME="$PROJ_NAME.Infrastructure"

# Define the services directory
SERVICES_DIR="Services/$PROJ_NAME"

echo "directory is set to: $SERVICES_DIR"
# Check if the services directory already exists
# Create the services directory
mkdir -p $SERVICES_DIR

# Navigate to the services directory
cd $SERVICES_DIR
echo "Navigating to the services directory: $SERVICES_DIR"

# Create the API project
dotnet new webapi -n $API_PROJECT_NAME -controllers

# Create the class library projects
dotnet new classlib -n $CORE_LIB_NAME
dotnet new classlib -n $APPLICATION_LIB_NAME
dotnet new classlib -n $INFRASTRUCTURE_LIB_NAME

#go to the solution directory

echo "Projects created successfully!"
cd ../..
echo "navigating to the solution directory"
# Add references to sln

dotnet sln add $SERVICES_DIR/$API_PROJECT_NAME/$API_PROJECT_NAME.csproj


echo "Projects successfully created in the 'services' folder and references established!"