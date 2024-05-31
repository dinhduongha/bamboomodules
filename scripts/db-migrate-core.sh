#!/bin/bash
name="Bamboo"
module="Core"
path="core"
dotnet ef migrations add Upgrade_ABP_8 --startup-project services/$path/host/$name.$module.HttpApi.Host/$name.$module.HttpApi.Host.csproj --project services/core/src/$name.$module.EntityFrameworkCore/$name.$module.EntityFrameworkCore.csproj --context $module"DbContext"


