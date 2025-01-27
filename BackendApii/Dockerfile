FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["BackendApii/BackendApii.csproj", "BackendApii/"]
RUN dotnet restore "./BackendApii/BackendApii.csproj"
COPY . .
WORKDIR "/src/BackendApii"
RUN dotnet publish "./BackendApii.csproj" -c Release -o /app/publish /p:UseAppHost=false
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BackendApii.dll"]