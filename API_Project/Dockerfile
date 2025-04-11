# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln ./
COPY API_Project/*.csproj ./API_Project/
RUN dotnet restore

COPY . .
WORKDIR /app/API_Project
RUN dotnet publish -c Release -o out

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/API_Project/out ./
ENTRYPOINT ["dotnet", "API_Project.dll"]
