# Sử dụng hình ảnh cơ sở ASP.NET Core runtime cho .NET 8
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Copy các file đã publish từ thư mục output
COPY bin/Bamboo.Admin .
# Copy file cấu hình bí mật
#COPY conf/appsettings.json .
#COPY conf/appsettings.secrets.json .
ENTRYPOINT ["dotnet", "Bamboo.Admin.AuthServer.dll"]