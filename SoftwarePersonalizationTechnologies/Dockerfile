#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SoftwarePersonalizationTechnologies/SoftwarePersonalizationTechnologies.csproj", "SoftwarePersonalizationTechnologies/"]
RUN dotnet restore "SoftwarePersonalizationTechnologies/SoftwarePersonalizationTechnologies.csproj"
COPY . .
WORKDIR "/src/SoftwarePersonalizationTechnologies"
RUN dotnet build "SoftwarePersonalizationTechnologies.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SoftwarePersonalizationTechnologies.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SoftwarePersonalizationTechnologies.dll"]