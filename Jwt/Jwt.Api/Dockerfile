#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Jwt/Jwt.Api/Jwt.Api.csproj", "Jwt/Jwt.Api/"]
RUN dotnet restore "Jwt/Jwt.Api/Jwt.Api.csproj"
COPY . .
WORKDIR "/src/Jwt/Jwt.Api"
RUN dotnet build "Jwt.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Jwt.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Jwt.Api.dll"]