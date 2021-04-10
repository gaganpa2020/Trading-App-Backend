#!/bin/sh
v1="AuthenticationService/TradingCompany.AuthenticationService/"
echo $v1

echo "Building application"

dotnet build "AuthenticationService/TradingCompany.AuthenticationService/TradingCompany.AuthenticationService.sln" -c Release -o Build

echo "Publishing application"

dotnet publish "AuthenticationService/TradingCompany.AuthenticationService/TradingCompany.AuthenticationService.sln" -c Release -o Build