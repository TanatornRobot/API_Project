# 1. ใช้ .NET SDK base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# 2. สร้างแยกจาก SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 3. Copy และ Restore packages
COPY "./API_Project.csproj" "./"
RUN dotnet restore "./API_Project.csproj"

# 4. Copy ทั้งโปรเจกต์และ Build
COPY . .
RUN dotnet publish "API_Project.csproj" -c Release -o /app/publish

# 5. สร้าง final image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "API_Project.dll"]
