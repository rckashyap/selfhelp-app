FROM mcr.Microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./SelfHelp.API/SelfHelp.API.csproj"
RUN dotnet publish "./SelfHelp.API/SelfHelp.API.csproj" -c release -o /app --no-restore

FROM mcr.Microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./
EXPOSE 5000

ENTRYPOINT ["dotnet", "SelfHelp.API.dll"]