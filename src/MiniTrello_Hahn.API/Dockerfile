# Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["MiniTrello_Hahn.API/MiniTrello_Hahn.API.csproj", "MiniTrello_Hahn.API/"]
COPY ["MiniTrello_Hahn.Application/MiniTrello_Hahn.Application.csproj", "MiniTrello_Hahn.Application/"]
COPY ["MiniTrello_Hahn.Domain/MiniTrello_Hahn.Domain.csproj", "MiniTrello_Hahn.Domain/"]
COPY ["MiniTrello_Hahn.Infrastructure/MiniTrello_Hahn.Infrastructure.csproj", "MiniTrello_Hahn.Infrastructure/"]

RUN dotnet restore "MiniTrello_Hahn.API/MiniTrello_Hahn.API.csproj"

COPY . .
WORKDIR "/src/MiniTrello_Hahn.API"
RUN dotnet build "MiniTrello_Hahn.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MiniTrello_Hahn.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiniTrello_Hahn.API.dll"]

