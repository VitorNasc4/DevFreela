FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src/temp

COPY  src .  

RUN dotnet restore "DevFreela.Messaging/DevFreela.Messaging.csproj"
WORKDIR /src/temp/DevFreela.Messaging
RUN dotnet build "DevFreela.Messaging.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DevFreela.Messaging.csproj" -c Release -o /app/publish

FROM base AS final
RUN addgroup --system appuser && adduser --system appuser --ingroup appuser
WORKDIR /app
USER appuser
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevFreela.Messaging.dll"]