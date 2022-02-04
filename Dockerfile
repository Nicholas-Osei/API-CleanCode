FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
ENV ASPNETCORE_ENVIRONMENT=Development
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
# COPY . .

COPY ["LearnNico/LearnNico_Presentation.csproj", "LearnNico/"]
COPY ["Core-Application_Domain/Core-Application_Domain.csproj", "Core-Application_Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]

RUN dotnet restore "LearnNico/LearnNico_Presentation.csproj"
COPY . .
WORKDIR "/src/LearnNico"
RUN dotnet build "LearnNico_Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LearnNico_Presentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY "LearnNico/appsettings.json" "/app/AppSettings.json"
ENTRYPOINT ["dotnet", "LearnNico.dll"]