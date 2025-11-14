# Sử dụng hình ảnh cơ sở ASP.NET Core runtime cho .NET 9
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#WORKDIR /app
#EXPOSE 80

FROM bamboo-base:latest
# Copy các file đã publish từ thư mục output
COPY bin/Bamboo.Admin .
# Copy các file cấu hình
#COPY conf/appsettings.json .
#COPY conf/appsettings.secrets.json .
ENTRYPOINT ["dotnet", "Bamboo.Admin.HttpApi.Host.dll"]