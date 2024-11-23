#!/bin/bash
name="Bamboo"
module="Admin"
path="admin"

#dotnet ef migrations add Initial --startup-project services/admin/Bamboo.Admin/src/Bamboo.Admin.HttpApi.Host/Bamboo.Admin.HttpApi.Host.csproj --project services/admin/Bamboo.Admin/src/Bamboo.Admin.EntityFrameworkCore/Bamboo.Admin.EntityFrameworkCore.csproj --context "AdminDbContext"

#dotnet ef migrations add Upgrade_ABP_8 --startup-project services/$path/$name.$module/src/$name.$module.HttpApi.Host/$name.$module.HttpApi.Host.csproj --project services/$path/$name.$module/src/$name.$module.EntityFrameworkCore/$name.$module.EntityFrameworkCore.csproj --context $module"DbContext"

# cd services\admin\Bamboo.Admin\src
# abp create-migration-and-run-migrator Bamboo.Admin.EntityFrameworkCore
