#!/bin/sh
name="Bamboo"
dotnet publish --sc --os linux /p:PublishSingleFile=true -o Output/$name.Admin services//admin/$name.Admin/src/$name.Admin.HttpApi.Host/$name.Admin.HttpApi.Host.csproj
rm Output/$name.Admin/appsettings.*
#scp Output/$name.Admin/$name.* bamboo@127.0.0.1:/opt/bamboo/admin/dotnet/

