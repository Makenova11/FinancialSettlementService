FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FinancialSettlementService.csproj", "."]
RUN dotnet restore "./FinancialSettlementService.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "FinancialSettlementService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FinancialSettlementService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinancialSettlementService.dll"]