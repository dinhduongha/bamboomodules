#!/bin/bash
name="Bamboo"
module="Core"
path="core"

### MIGRATIONS ###
# dotnet ef migrations add Initial --startup-project services/core/host/Bamboo.Core.HttpApi.Host/Bamboo.Core.HttpApi.Host.csproj --project services/core/src/Bamboo.Core.EntityFrameworkCore/Bamboo.Core.EntityFrameworkCore.csproj --context "CoreDbContext"
# dotnet ef migrations add Initial --startup-project services/$path/host/$name.$module.HttpApi.Host/$name.$module.HttpApi.Host.csproj --project services/$path/src/$name.$module.EntityFrameworkCore/$name.$module.EntityFrameworkCore.csproj --context $module"DbContext"

### NEW MIGRATIONS ###
# dotnet ef migrations add Upgrade_ABP_8 --startup-project services/$path/host/$name.$module.HttpApi.Host/$name.$module.HttpApi.Host.csproj --project services/$path/src/$name.$module.EntityFrameworkCore/$name.$module.EntityFrameworkCore.csproj --context $module"DbContext"

### UPDATE DATABASE ###
# echo "dotnet ef database update --startup-project services/$path/host/$name.$module.HttpApi.Host/$name.$module.HttpApi.Host.csproj --project services/$path/src/$name.$module.EntityFrameworkCore/$name.$module.EntityFrameworkCore.csproj --context $module"DbContext""
# dotnet ef database update --startup-project services/$path/host/$name.$module.HttpApi.Host/$name.$module.HttpApi.Host.csproj --project services/$path/src/$name.$module.EntityFrameworkCore/$name.$module.EntityFrameworkCore.csproj --context $module"DbContext"
# dotnet ef database update --startup-project services/core/host/Bamboo.Core.HttpApi.Host/Bamboo.Core.HttpApi.Host.csproj --project services/core/src/Bamboo.Core.EntityFrameworkCore/Bamboo.Core.EntityFrameworkCore.csproj --context CoreDbContext

### ALTERNATIVE WAY ###
# cd services/core && abp create-migration-and-run-migrator src/Bamboo.Core.EntityFrameworkCore

### RE-INIT ALL ###
# rm -rf services/core/src/Bamboo.Core.EntityFrameworkCore/Migrations
dotnet ef migrations add Initial --startup-project services/core/host/Bamboo.Core.HttpApi.Host/Bamboo.Core.HttpApi.Host.csproj --project services/core/src/Bamboo.Core.EntityFrameworkCore/Bamboo.Core.EntityFrameworkCore.csproj --context "CoreDbContext" && dotnet ef database update --startup-project services/core/host/Bamboo.Core.HttpApi.Host/Bamboo.Core.HttpApi.Host.csproj --project services/core/src/Bamboo.Core.EntityFrameworkCore/Bamboo.Core.EntityFrameworkCore.csproj --context CoreDbContext


dotnet ef dbcontext info  --startup-project services/core/host/Bamboo.Core.HttpApi.Host/Bamboo.Core.HttpApi.Host.csproj --project services/core/src/Bamboo.Core.EntityFrameworkCore/Bamboo.Core.EntityFrameworkCore.csproj --context "CoreDbContext"