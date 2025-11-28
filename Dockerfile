# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy the solution file
COPY *.sln .

# Copy all project files (*.csproj) needed for 'dotnet restore'
# This ensures NuGet dependencies are downloaded efficiently.
COPY src/CloudSchool.Transport.Core/*.csproj src/CloudSchool.Transport.Core/
COPY src/CloudSchool.Transport.Data/*.csproj src/CloudSchool.Transport.Data/
COPY src/CloudSchool.Transport.Services/*.csproj src/CloudSchool.Transport.Services/
COPY src/CloudSchool.Transport.Api/*.csproj src/CloudSchool.Transport.Api/
COPY src/CloudSchool.Transport.Tests/*.csproj src/CloudSchool.Transport.Tests/

# Restore all dependencies using the solution file
RUN dotnet restore

# Copy all remaining source code files
COPY . .

# Publish the API project
WORKDIR /src/src/CloudSchool.Transport.Api
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Create the final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Copy only the published output from the build stage
COPY --from=build /app/publish .

# Define the entry point for the container
ENTRYPOINT ["dotnet", "CloudSchool.Transport.Api.dll"]