# Estágio de compilação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /src

# Copia o csproj e restaura as dependências
COPY DevFreela.Messaging/DevFreela.Messaging.csproj ./
RUN dotnet restore

# Copia todo o código e compila
COPY DevFreela.Messaging/. ./
RUN dotnet publish -c Release -o out

# Estágio de execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /src/out .
ENTRYPOINT ["dotnet", "DevFreela.Messaging.dll"]