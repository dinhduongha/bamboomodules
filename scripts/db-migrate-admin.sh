#!/bin/bash
name="Bamboo"
module="Admin"
path="admin"
# dotnet ef migrations add Upgrade_ABP_8 --startup-project services/$path/$name.$module/src/$name.$module.HttpApi.Host/$name.$module.HttpApi.Host.csproj --project services/$path/$name.$module/src/$name.$module.EntityFrameworkCore/$name.$module.EntityFrameworkCore.csproj --context $module"DbContext"

### MIGRATIONS ###
# dotnet ef migrations add Upgrade_ABP_8 --startup-project services/admin/Bamboo.Admin/src/Bamboo.Admin.HttpApi.Host/Bamboo.Admin.HttpApi.Host.csproj --project services/admin/Bamboo.Admin/src/Bamboo.Admin.EntityFrameworkCore/Bamboo.Admin.EntityFrameworkCore.csproj --context Admin"DbContext"

### UPDATE DATABASE ###
# dotnet ef database update --startup-project services/admin/Bamboo.Admin/src/Bamboo.Admin.HttpApi.Host/Bamboo.Admin.HttpApi.Host.csproj --project services/admin/Bamboo.Admin/src/Bamboo.Admin.EntityFrameworkCore/Bamboo.Admin.EntityFrameworkCore.csproj --context Admin"DbContext"

### ANOTHER WAY ###
cd services/admin/Bamboo.Admin/src && abp create-migration-and-run-migrator Bamboo.Admin.EntityFrameworkCore && cd -
