#!/bin/sh
name="Bamboo"
#dotnet publish --sc --os linux /p:PublishSingleFile=true -o Output-Single/$name.Admin services/admin/$name.Admin/src/$name.Admin.HttpApi.Host/$name.Admin.HttpApi.Host.csproj
#dotnet publish --sc --os linux /p:PublishSingleFile=true -o Output-Single/$name.Admin services/admin/$name.Admin/src/$name.Admin.AuthServer/$name.Admin.AuthServer.csproj
#dotnet publish --sc --os linux /p:PublishSingleFile=true -o Output-Single/$name.Admin services/admin/$name.Admin/src/$name.Admin.HttpApi.Host.Bundle/$name.Admin.HttpApi.Host.Bundle.csproj

# dotnet publish --sc --os linux /p:PublishSingleFile=true -o Output-Single/Bamboo.Admin services/admin/Bamboo.Admin/src/Bamboo.Admin.HttpApi.Host/Bamboo.Admin.HttpApi.Host.csproj
# dotnet publish --sc --os linux /p:PublishSingleFile=true -o Output-Single/Bamboo.AuthServer services/admin/Bamboo.Admin/src/Bamboo.Admin.AuthServer/Bamboo.Admin.AuthServer.csproj
# dotnet publish --sc --os linux /p:PublishSingleFile=true -o Output-Single/Bamboo.Admin services/admin/Bamboo.Admin/src/Bamboo.Admin.HttpApi.Host.Bundle/Bamboo.Admin.HttpApi.Host.Bundle.csproj

#rm Output/$name.AuthServer/appsettings.secret*.*
#dotnet publish --sc --os linux -o Output/$name.Admin services/admin/$name.Admin/src/$name.Admin.HttpApi.Host/$name.Admin.HttpApi.Host.csproj
#rm Output/$name.Admin/appsettings.secret*.*

#Build whole solution
dotnet publish --sc --os linux -f net8.0 -o Output/$name.Admin services/admin/$name.Admin/$name.Admin.sln
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

