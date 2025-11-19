#!/bin/sh
name="Bamboo"
DEST_DIR=bin
#dotnet publish --sc --os linux /p:PublishSingleFile=true -o $DEST_DIR/$name.Admin services/admin/$name.Admin/src/$name.Admin.HttpApi.Host/$name.Admin.HttpApi.Host.csproj

#dotnet publish --sc --os linux -o $DEST_DIR/$name.AuthServer services/admin/$name.Admin/src/$name.Admin.AuthServer/$name.Admin.AuthServer.csproj
#rm $DEST_DIR/$name.AuthServer/appsettings.secret*.*
#dotnet publish --sc --os linux -o $DEST_DIR/$name.Admin services/admin/$name.Admin/src/$name.Admin.HttpApi.Host/$name.Admin.HttpApi.Host.csproj
#rm $DEST_DIR/$name.Admin/appsettings.secret*.*

############################
#
# BUILD API SERVICE

#dotnet publish --sc --os linux -f net8.0 -o $DEST_DIR/$name.Admin services/admin/$name.Admin/$name.Admin.sln
#rm $DEST_DIR/$name.Admin/appsettings.secret*.*

#dotnet publish --sc --os linux -f net8.0 -o $DEST_DIR/$name.Core services/core/$name.Core.sln
#rm $DEST_DIR/$name.Core/appsettings.secret*.*

#dotnet publish --sc --os linux -f net8.0 -o $DEST_DIR/$name.Web3 services/core/$name.Web3.sln
#rm $DEST_DIR/$name.Web3/appsettings.secret*.*

dotnet publish --sc --os linux -f net10.0 -o bin/Bamboo.Admin services/admin/Bamboo.Admin.slnx
rm -f bin/Bamboo.Admin/appsettings.secret*.*
dotnet publish --sc --os linux -f net10.0 -o bin/Bamboo.Core services/core/Bamboo.Core.slnx
#rm -f bin/Bamboo.Core/appsettings.secret*.*

############################
#
# BUILD WEB APP

# dotnet publish --sc --os linux -o $DEST_DIR/$name.MVC apps/$name.Web.MVC.sln
# rm $DEST_DIR/$name.MVC/appsettings.secret*.*
# dotnet publish --sc --os linux -o $DEST_DIR/$name.Blazor apps/$name.Web.Blazor.sln

# dotnet publish --sc --os linux -f net8.0 -o bin/Bamboo.MVC apps/Bamboo.Web.MVC.sln
# rm bin/Bamboo.MVC/appsettings.secret*.*\
# dotnet publish --sc --os linux -f net8.0 -o bin/Bamboo.Blazor apps/Bamboo.Web.Blazor.sln


# scp -r $DEST_DIR/$name.AuthServer/$name.* bamboo@127.0.0.1:/opt/bamboo/admin/dotnet/
# scp -r $DEST_DIR/$name.Admin/$name.* bamboo@127.0.0.1:/opt/bamboo/admin/dotnet/
# scp -r $DEST_DIR/$name.Bundle/$name.* bamboo@127.0.0.1:/opt/bamboo/admin/dotnet/
# docker image rm bamboo-admin bamboo-app-core bamboo-auth-server
