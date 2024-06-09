# Usar a imagem base do SDK do .NET 8.0
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Definir o diretório de trabalho
WORKDIR /app

# Copiar os arquivos .csproj e restaurar as dependências
COPY . ./
RUN dotnet restore

# Compilar o projeto
RUN dotnet publish -c Release -o out

# Usar a imagem base do runtime do .NET 8.0
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Definir o diretório de trabalho
WORKDIR /app

# Copiar os arquivos compilados do estágio anterior
COPY --from=build /app/out .

# Definir o comando de entrada
ENTRYPOINT ["dotnet", "TechChallenge_ControleContatos.dll"]
