# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.


# What is this stage?
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Builds the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Api/Carquitecture.API.csproj", "Api/"]
COPY ["Application/Carquitecture.Application/Carquitecture.Application.csproj", "Application/Carquitecture.Application/"]
COPY ["Domain/Carquitecture.Domain/Carquitecture.Domain.csproj", "Domain/Carquitecture.Domain/"]
COPY ["Infrastructure/Carquitecture.Infrastructure/Carquitecture.Infrastructure.csproj", "Infrastructure/Carquitecture.Infrastructure/"]
RUN dotnet restore "./Api/Carquitecture.API.csproj"
# It copies everything to the container, why? We already copied the csproj files and restored its packages.
COPY . .
WORKDIR "/src/Api"
RUN dotnet build "./Carquitecture.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# It compiles the app and its dependencies and prepares it for deployment
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Carquitecture.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Is this the executable?
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Carquitecture.API.dll"]