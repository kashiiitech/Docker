
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY DockerFrontend.csproj .
RUN dotnet restore "DockerFrontend.csproj"
COPY . .
RUN dotnet publish "DockerFrontend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM nginx:alpine
COPY --from=build /app/publish/wwwroot /usr/share/nginx/html