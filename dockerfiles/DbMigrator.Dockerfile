# Sử dụng hình ảnh cơ sở ASP.NET Core runtime cho .NET 8
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#WORKDIR /app
FROM bamboo-base:latest

# Copy các file đã publish từ thư mục output
COPY apps/ .
#COPY conf/appsettings.json .
#COPY conf/appsettings.secrets.json .
ENTRYPOINT ["dotnet", "Bamboo.Admin.DbMigrator.dll"]