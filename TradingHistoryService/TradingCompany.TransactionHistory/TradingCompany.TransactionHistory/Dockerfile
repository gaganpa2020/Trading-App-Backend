#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["TradingCompany.TransactionHistory/TradingCompany.TransactionHistory.csproj", "TradingCompany.TransactionHistory/"]
RUN dotnet restore "TradingCompany.TransactionHistory/TradingCompany.TransactionHistory.csproj"
COPY . .
WORKDIR "/src/TradingCompany.TransactionHistory"
RUN dotnet build "TradingCompany.TransactionHistory.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TradingCompany.TransactionHistory.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TradingCompany.TransactionHistory.dll"]