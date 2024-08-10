#!/bin/bash
name="Bamboo"
module="Core"
path="core"

# Migration Entities
# dotnet ef migrations add Initial --startup-project services/core/host/Bamboo.Core.HttpApi.Host/Bamboo.Core.HttpApi.Host.csproj --project services/core/src/Bamboo.Core.EntityFrameworkCore/Bamboo.Core.EntityFrameworkCore.csproj --context "CoreDbContext"
#dotnet ef migrations add Initial --startup-project services/$path/host/$name.$module.HttpApi.Host/$name.$module.HttpApi.Host.csproj --project services/$path/src/$name.$module.EntityFrameworkCore/$name.$module.EntityFrameworkCore.csproj --context $module"DbContext"

#dotnet ef migrations add Upgrade_ABP_8 --startup-project services/$path/host/$name.$module.HttpApi.Host/$name.$module.HttpApi.Host.csproj --project services/$path/src/$name.$module.EntityFrameworkCore/$name.$module.EntityFrameworkCore.csproj --context $module"DbContext"

# Update database
#echo "dotnet ef database update --startup-project services/$path/host/$name.$module.HttpApi.Host/$name.$module.HttpApi.Host.csproj --project services/$path/src/$name.$module.EntityFrameworkCore/$name.$module.EntityFrameworkCore.csproj --context $module"DbContext""
#dotnet ef database update --startup-project services/$path/host/$name.$module.HttpApi.Host/$name.$module.HttpApi.Host.csproj --project services/$path/src/$name.$module.EntityFrameworkCore/$name.$module.EntityFrameworkCore.csproj --context $module"DbContext"

#dotnet ef database update --startup-project services/core/host/Bamboo.Core.HttpApi.Host/Bamboo.Core.HttpApi.Host.csproj --project services/core/src/Bamboo.Core.EntityFrameworkCore/Bamboo.Core.EntityFrameworkCore.csproj --context CoreDbContext
# OR
# cd services/core
# abp create-migration-and-run-migrator src/Bamboo.Core.EntityFrameworkCore

# SCAFFOLD DATA
# MY SQL
#dotnet ef dbcontext scaffold 'Server=host; port=port;Database=db;User=user;Password=password;' "Pomelo.EntityFrameworkCore.MySql" --namespace "$name"."$module".Entities -o ../"$name"."$module".Domain/Entities -c "$module"DbContext --startup-project host/"$name"."$module".HttpApi.Host/"$name"."$module".HttpApi.Host.csproj --project src/"$name"."$module".EntityFrameworkCore/"$name"."$module".EntityFrameworkCore.csproj  --context-dir "$module"DbContext --force #--data-annotations

# PostgreSQL
#dotnet ef dbcontext scaffold 'Host=host; Port=port;Database=db;User ID=user;Password=password;' "Npgsql.EntityFrameworkCore.PostgreSQL" -o Entities -c "$module"DbContext --startup-project host/"$name"."$module".HttpApi.Host/"$name"."$module".HttpApi.Host.csproj --project src/"$name"."$module".EntityFrameworkCore/"$name"."$module".EntityFrameworkCore.csproj --context-dir "$module"DbContext --force --data-annotations

