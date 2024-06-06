FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

COPY /*.csproj aspnetapp/
RUN dotnet restore aspnetapp

COPY . aspnetapp/

WORKDIR /source/aspnetapp
RUN dotnet publish -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

LABEL "com.centurylinklabs.watchtower.enable"="true"

COPY --from=build /app ./
ENTRYPOINT ["dotnet", "crudpcapi.dll"]