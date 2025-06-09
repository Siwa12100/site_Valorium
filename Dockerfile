FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8080

RUN useradd -m appuser

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY siteValorium/siteValorium.csproj ./siteValorium/
RUN dotnet restore siteValorium/siteValorium.csproj

COPY siteValorium/ ./siteValorium/
COPY siteValorium.sln ./

WORKDIR /src/siteValorium
RUN dotnet clean && rm -rf bin obj
RUN dotnet build siteValorium.csproj -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
WORKDIR /src/siteValorium
RUN dotnet clean && rm -rf bin obj
RUN dotnet publish siteValorium.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN chown -R appuser:appuser /app
USER appuser
ENTRYPOINT ["dotnet", "siteValorium.dll"]