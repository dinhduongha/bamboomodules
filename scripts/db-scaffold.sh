#!/bin/bash
name="Bamboo"
module="Core"
path="core"

# SCAFFOLD DATA
# MY SQL
#dotnet ef dbcontext scaffold 'Server=host; port=port;Database=db;User=user;Password=password;' "Pomelo.EntityFrameworkCore.MySql" --namespace "$name"."$module".Entities -o ../"$name"."$module".Domain/Entities -c "$module"DbContext --startup-project host/"$name"."$module".HttpApi.Host/"$name"."$module".HttpApi.Host.csproj --project src/"$name"."$module".EntityFrameworkCore/"$name"."$module".EntityFrameworkCore.csproj  --context-dir "$module"DbContext --force #--data-annotations

# PostgreSQL
## With annotations
# dotnet ef dbcontext scaffold 'Host=127.0.0.1; Port=5432;Database=odoo18_base_uuid;User ID=postgres;Password=q5HfFQqZWocp9ZPp;' "Npgsql.EntityFrameworkCore.PostgreSQL" -o Entities -c "$module"DbContext --startup-project host/"$name"."$module".HttpApi.Host/"$name"."$module".HttpApi.Host.csproj --project src/"$name"."$module".EntityFrameworkCore/"$name"."$module".EntityFrameworkCore.csproj --context-dir "$module"DbContext --force --data-annotations --verbose

## With Fluent API
#dotnet ef dbcontext scaffold 'Host=127.0.0.1; Port=5432;Database=odoo18_base_uuid;User ID=postgres;Password=q5HfFQqZWocp9ZPp;' "Npgsql.EntityFrameworkCore.PostgreSQL" -o Entities -c "$module"DbContext --startup-project host/"$name"."$module".HttpApi.Host/"$name"."$module".HttpApi.Host.csproj --project src/"$name"."$module".EntityFrameworkCore/"$name"."$module".EntityFrameworkCore.csproj --context-dir "$module"DbContext --force --verbose

##
dotnet ef dbcontext scaffold 'Host=3.0.46.229; Port=5434;Database=odoo16_extras;User ID=postgres;Password=bP9BwXWGIIq03TYk;' "Npgsql.EntityFrameworkCore.PostgreSQL" -o Models -c "$module"DbContext --startup-project host/"$name"."$module".HttpApi.Host/"$name"."$module".HttpApi.Host.csproj --project src/"$name"."$module".EntityFrameworkCore/"$name"."$module".EntityFrameworkCore.csproj --context-dir "$module"DbContext --force --data-annotations --verbose

# dotnet ef dbcontext scaffold 'Host=3.0.46.229; Port=5434;Database=odoo16_extras;User ID=postgres;Password=bP9BwXWGIIq03TYk;' "Npgsql.EntityFrameworkCore.PostgreSQL" -o Entities -c "$module"DbContext --startup-project host/"$name"."$module".HttpApi.Host/"$name"."$module".HttpApi.Host.csproj --project src/"$name"."$module".EntityFrameworkCore/"$name"."$module".EntityFrameworkCore.csproj --context-dir "$module"DbContext --force --verbose
