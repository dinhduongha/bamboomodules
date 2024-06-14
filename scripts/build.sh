#!/bin/sh
name="Bamboo"
#dotnet publish --sc --os linux /p:PublishSingleFile=true -o Output/$name.Admin services//admin/$name.Admin/src/$name.Admin.HttpApi.Host/$name.Admin.HttpApi.Host.csproj
#dotnet publish --sc --os linux -o Output/$name.AuthServer services/admin/$name.Admin/src/$name.Admin.AuthServer/$name.Admin.AuthServer.csproj
#rm Output/$name.AuthServer/appsettings.secret*.*
#dotnet publish --sc --os linux -o Output/$name.Admin services/admin/$name.Admin/src/$name.Admin.HttpApi.Host/$name.Admin.HttpApi.Host.csproj
#rm Output/$name.Admin/appsettings.secret*.*

dotnet publish --sc --os linux -o Output/$name.Admin services/admin/$name.Admin/$name.Admin.sln
rm Output/$name.Admin/appsettings.secret*.*

# dotnet publish --sc --os linux -o Output/Bamboo.Admin services/admin/Bamboo.Admin/Bamboo.Admin.sln
# rm Output/Bamboo.Admin/appsettings.secret*.*
# dotnet publish --sc --os linux -o Output/Bamboo.MVC apps/Bamboo.Web.MVC.sln
# rm Output/Bamboo.MVC/appsettings.secret*.*

# dotnet publish --sc --os linux -o Output/Bamboo.Core services/core/Bamboo.Core.sln
# rm Output/Bamboo.Core/appsettings.secret*.*

# dotnet publish --sc --os linux -o Output/Bamboo.Blazor apps/Bamboo.Web.Blazor.sln

# scp -r Output/$name.AuthServer/$name.* bamboo@127.0.0.1:/opt/bamboo/admin/dotnet/
# scp -r Output/$name.Admin/$name.* bamboo@127.0.0.1:/opt/bamboo/admin/dotnet/
# scp -r Output/$name.Bundle/$name.* bamboo@127.0.0.1:/opt/bamboo/admin/dotnet/

