#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Teste.API/Teste.API.csproj", "Teste.API/"]
COPY ["Teste.Application/Teste.Application.csproj", "Teste.Application/"]
COPY ["Teste.Domain/Teste.Domain.csproj", "Teste.Domain/"]
COPY ["Teste.CrossCutting/Teste.CrossCutting.csproj", "Teste.CrossCutting/"]
COPY ["Teste.Infrastructure/Teste.Infrastructure.csproj", "Teste.Infrastructure/"]
RUN dotnet restore "./Teste.API/Teste.API.csproj"
COPY . .
WORKDIR "/src/Teste.API"
RUN dotnet build "./Teste.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Teste.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Teste.API.dll"]