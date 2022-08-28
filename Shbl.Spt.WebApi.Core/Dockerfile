#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Shbl.Spt.WebApi.Core/Shbl.Spt.WebApi.Core.csproj", "Shbl.Spt.WebApi.Core/"]
RUN dotnet restore "Shbl.Spt.WebApi.Core/Shbl.Spt.WebApi.Core.csproj"
COPY . .
WORKDIR "/src/Shbl.Spt.WebApi.Core"
RUN dotnet build "Shbl.Spt.WebApi.Core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shbl.Spt.WebApi.Core.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shbl.Spt.WebApi.Core.dll"]