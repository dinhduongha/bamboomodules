#!/bin/bash
name="Bamboo"
module="Admin"
path="admin"
dotnet ef migrations add Upgrade_ABP_8 --startup-project services/$path/$name.$module/src/$name.$module.HttpApi.Host/$name.$module.HttpApi.Host.csproj --project services/$path/$name.$module/src/$name.$module.EntityFrameworkCore/$name.$module.EntityFrameworkCore.csproj --context $module"DbContext"

#abp create-migration-and-run-migrator Bamboo.Admin.EntityFrameworkCore
