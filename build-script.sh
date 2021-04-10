#!/bin/sh
authenticationService="AuthenticationService\TradingCompany.AuthenticationService/"
accountService="AccountService\TradingCompany.AccountService"
exchangeService="ExchangeService\TradingCompany.ExchangeService"
notificationService="NotificationService\TradingCompany.NotificationService"
tradingHistoryService="TradingHistoryService\TradingCompany.TransactionHistory"
tradingService="TradingService\TradingCompany.TradingService"

echo "Building Authentication Service"

dotnet build $authenticationService/TradingCompany.AuthenticationService.sln -c Release -o $authenticationService/Build

echo "Building Account Service"

dotnet build $accountService/TradingCompany.AccountService.sln -c Release -o $accountService/TradingCompany.AccountService/Build

echo "Building Exchange Service"

dotnet build $exchangeService/TradingCompany.ExchangeService.sln -c Release -o $exchangeService/TradingCompany.ExchangeService/Build

echo "Building Notification Service"

dotnet build $notificationService/TradingCompany.NotificationService.sln -c Release -o $notificationService/TradingCompany.NotificationService/Build


echo "Building Trading History Service"

dotnet build $tradingHistoryService/TradingCompany.TransactionHistory.sln -c Release -o $tradingHistoryService/TradingCompany.TransactionHistory/Build


echo "Building Trading Service"

dotnet build $tradingService/TradingCompany.TradingService.sln -c Release -o $tradingService/TradingCompany.TradingService/Build
