#!/bin/sh
APP="Bamboo"
MOD="Core"

FOLDER="$APP"."$MOD"

# Normal modules
# rm -rf src/"$APP"."$MOD".EntityFrameworkCore/Migrations
dotnet ef migrations add Initial --startup-project host/"$APP"."$MOD".HttpApi.Host/"$APP"."$MOD".HttpApi.Host.csproj --project src/"$APP"."$MOD".EntityFrameworkCore/"$APP"."$MOD".EntityFrameworkCore.csproj --context "$MOD"DbContext
# dotnet ef database update --startup-project host/"$APP"."$MOD".HttpApi.Host/"$APP"."$MOD".HttpApi.Host.csproj --project src/"$APP"."$MOD".EntityFrameworkCore/"$APP"."$MOD".EntityFrameworkCore.csproj --context "$MOD"DbContext
# dotnet ef database update --startup-project host/Bamboo.Core.HttpApi.Host/Bamboo.Core.HttpApi.Host.csproj --project src/Bamboo.Core.EntityFrameworkCore/Bamboo.Core.EntityFrameworkCore.csproj --context CoreDbContext

# Admin module
# rm -rf host/"$APP"."$MOD".AuthServer/Migrations
# dotnet ef migrations add Initial --startup-project host/"$APP"."$MOD".AuthServer/"$APP"."$MOD".AuthServer.csproj --project host/"$APP"."$MOD".AuthServer/"$APP"."$MOD".AuthServer.csproj --context AuthServerDbContext
# dotnet ef database update --startup-project host/"$APP"."$MOD".AuthServer/"$APP"."$MOD".HttpApi.Host.csproj --project host/"$APP"."$MOD".AuthServer/"$APP"."$MOD".AuthServer.csproj --context AuthServerDbContext



