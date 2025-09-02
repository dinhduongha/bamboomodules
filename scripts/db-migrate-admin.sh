#!/bin/bash
name="Bamboo"
module="Admin"
path="admin"

### MIGRATIONS ###
#

# dotnet ef migrations add Initial --startup-project services/$path/$name.$module/src/$name.$module.HttpApi.Host/$name.$module.HttpApi.Host.csproj --project services/$path/$name.$module/src/$name.$module.EntityFrameworkCore/$name.$module.EntityFrameworkCore.csproj --context $module"DbContext"

# dotnet ef migrations add Initial --startup-project services/admin/Bamboo.Admin/src/Bamboo.Admin.HttpApi.Host/Bamboo.Admin.HttpApi.Host.csproj --project services/admin/Bamboo.Admin/src/Bamboo.Admin.EntityFrameworkCore/Bamboo.Admin.EntityFrameworkCore.csproj --context Admin"DbContext"

### UPDATE DATABASE ###
# dotnet ef database update --startup-project services/$path/$name.$module/src/$name.$module.HttpApi.Host/$name.$module.HttpApi.Host.csproj --project services/$path/$name.$module/src/$name.$module.EntityFrameworkCore/$name.$module.EntityFrameworkCore.csproj --context $module"DbContext"

# dotnet ef database update --startup-project services/admin/Bamboo.Admin/src/Bamboo.Admin.HttpApi.Host/Bamboo.Admin.HttpApi.Host.csproj --project services/admin/Bamboo.Admin/src/Bamboo.Admin.EntityFrameworkCore/Bamboo.Admin.EntityFrameworkCore.csproj --context Admin"DbContext"

# echo $PWD && cd services/$path/$name.$module/src/$name.$module.DbMigrator && dotnet run --project $name.$module.DbMigrator.csproj && cd -
# echo $PWD && cd services/admin/Bamboo.Admin/src/Bamboo.Admin.DbMigrator && dotnet run --project Bamboo.Admin.DbMigrator.csproj && cd -

### ANOTHER WAY ###
# echo $PWD && cd services/admin/Bamboo.Admin/src && abp create-migration-and-run-migrator Bamboo.Admin.EntityFrameworkCore && cd -
