FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MasterMind/MasterMind.csproj", "MasterMind/"]
RUN dotnet restore "MasterMind/MasterMind.csproj"
COPY . .
WORKDIR "/src/MasterMind"
RUN dotnet build "MasterMind.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MasterMind.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MasterMind.dll"]
