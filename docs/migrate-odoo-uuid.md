# HOW TO MIGRATE ODOO DATABASE TO ABP

## Task

For compatible with ABP, and use GUID for primary key, we need:

- Convert all primary key to GUID. Default value is `next_uuid()`
- Map all `company_id` column to TenantId
- Map all `create_uid` to CreatorId
- Map all `write_uid` to LastModifierId
- Map all `create_date` to CreationTime
- Map all `write_date` to LastModificationTime
- Convert all foreign key to GUID

## Environment

- Ubuntu 24.04
- PostgreSQL 17
- `pgloader` with small patch (has `int-to-uuid` function)
- Customer file `pgloader-odoo18-data-full-uuid.conf`
- File `create-generic.sql` for create database with custom function `next_uuid()`

## A. Prepare

### 1. Prepare Source Database

To migrate from odoo, at database source, we must ensure:

- Must config as `multi-company`.
- All tables with `create_date` column must `not NULL`. Run command to fix:
  `./scripts/db-src-update-null-date.sh`
- All tables with `company_id` column. Run command to fix:
  `./scripts/db-src-update-null-company-id.sh`

  After this step, you can check by run `company-id-null-check.sql` inside pgAdmin.

### 2. Prepare ABP C# Projects

- Clone source code
  `git clone https://github/dinhduongha/bamboomodules/`
- Customize `entities` in 'Bamboo.Core.Models' as you want. You can add column, but don't remove any column. Remove columns cause error when migrate data from old odoo database.
- Update `appsetings.secrets.json` files:

  - Database host/db/user/password
  - Redis

## B. EASY WAY - MOVE DATA ONLY

### 1. Prepare Destination Database

Run command:
`psql -p 5432 -h 127.0.0.1 -U postgres -f create-generic`

After this step, `bamboo_core` database with custom `next_uuid` created.

### 2. Create migrations and update database with C# Bamboo.Admin project (Optional)

Run command:
`./scripts/db-migrate-admin.sh`

### 3. Create migrations and update database with C# Bamboo.Core project

Run command:
`./scripts/db-migrate-core.sh`

### 4. Migrate data from old odoo18 database

Edit your `pgloader-odoo18-data-full-uuid.sh` with correct database/user/password then run command:
`./scripts/pgloader-odoo18-data-full-uuid.sh`

Voila, after this step, your `bamboo_core` database has updated (or clone) data with `Id` type is `GUID`, many extra columns added, and full compatible with ABP.

## C. HARD WAY

Just do this in case you want to `scaffold` from your database.

### 1. Create new database for entities

    Run command:
    `psql -p 5432 -h 127.0.0.1 -U postgres -f create-generic`

### 2. Migrate old database to new database with UUID compatible

#### 2.1 Odoo 16:

    pgloader --verbose pgloader-odoo16-18-schema-full-uuid.conf

#### 2.2 Odoo 18:

    pgloader --verbose pgloader-odoo16-18-schema-full-uuid.conf

After this step, we have a new database with `same` table/column/data similar origin, but all primary key and foreign key is GUID.

## II. Scaffold Entities

    cd service/core
    ../../scripts/db-scaffold.sh

After this step, we have all Entities and CoreDbContext.cs. We must update these file for compatible with ABP.

## III. Update Entities

### 1. Update class Entity:

Search:
`^public partial class\s+(\w+)`

Replace with:

```
public partial class $1: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
```

### 2. Replace Id

Search:
`public Guid Id { get; set; }`

Replace with:

```
public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }
```

### 3. Replace CreateUid

Search:
`public Guid\? CreateUid { get; set; }`

Replace with:

`public Guid? CreatorId { get; set; }`

### 4. Replace WriteUid

Search:
`public Guid\? WriteUid { get; set; }`

Replace with:

`public Guid? LastModifierId { get; set; }`

### 5. Replace CreateDate

Search:
`public DateTime\? CreateDate { get; set; }`

Replace with:

`public DateTime CreationTime { get; set; }`

### 6. Replace WriteDate

Search:
`public DateTime\? WriteDate { get; set; }`

Replace with:

`public DateTime? LastModificationTime { get; set; }`

### 7. Replace ForeignKey CreateUid

Search:
`\[ForeignKey\("CreateUid"\)\]$`

Replace with:

`[ForeignKey("CreatorId")]`

### 7. Replace ForeignKey WriteUid

Search:
`\[ForeignKey\("WriteUid"\)\]`

Replace with:

`[ForeignKey("LastModifierId")]`

### 8. Replace ForeignKey CompanyId

Search:
`\[ForeignKey\("CompanyId"\)\]`

Replace with:

`[ForeignKey("TenantId")]`

### 9. Replace/Disable InverseProperty

Search:
`\[InverseProperty.*$`

Replace with:

`//$0\n    [NotMapped]`

### 10. Disable Index

Search:
`\[Index.*$`

Replace with:

`//$0`

### 11. Remove using Microsoft.EntityFrameworkCore;

Search:
`using Microsoft.EntityFrameworkCore;`

Replace with:

`using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;```

### 12. Note

Search files not contains IMultiTenant
`^public\s+partial\s+class\b(?!.*\bIMultiTenant\b).*`

### 13. Find file not contains TenantId

`grep -L -R --include="*.cs" 'public Guid? TenantId { get; set; }' . | sort`

## IV. Update Fluent API

### 1. Company

Search
`entity.HasOne\(d => d.Company\).WithMany.*$`
Replace with:
`entity.HasOne<ResCompany>().WithMany()`

Search
`.HasForeignKey(d => d.CompanyId)`
Replace with:
`.HasForeignKey(d => d.TenantId)`

### 2. Create

Search
`entity.HasOne\(d => d.CreateU\).*$`
Replace with:
`entity.HasOne<ResUser>().WithMany()`

Search
`entity.Property(e => e.CreateUid)`
Replace with:
`entity.Property(e => e.CreatorId)`

Search
`entity.Property(e => e.CreateDate)`
Replace with:
`entity.Property(e => e.CreationTime)`

Search
`.HasForeignKey(d => d.CreateUid)`
Replace with:
`.HasForeignKey(d => d.CreatorId)`

### 3. Write

Search
`entity.HasOne\(d => d.WriteU\).WithMany.*$`
Replace with:
`entity.HasOne<ResUser>().WithMany()`

Search
`entity.Property(e => e.WriteUid)`
Replace with:
`entity.Property(e => e.LastModifierId)`

Search
`entity.Property(e => e.WriteDate)`
Replace with:
`entity.Property(e => e.LastModificationTime)`

Search
`.HasForeignKey(d => d.WriteUid)`
Replace with:
`.HasForeignKey(d => d.LastModifierId)`

### 4. Partner

Search
`entity.HasOne\(d => d.Partner\).WithMany.*$`
Replace with:
`entity.HasOne<ResPartner>().WithMany()`

### 5. ResCountry

Search
`entity.HasOne\(d => d.Country\).WithMany.*$`
Replace with:
`entity.HasOne<ResCountry>().WithMany()`

### 5. ResCurrency

Search
`entity.HasOne\(d => d.Currency\).WithMany.*$`
Replace with:
`entity.HasOne<ResCurrency>().WithMany()`

### 6. ResLang and more

## V. Migrations DB Schema and Data

Run command as follow:
`./scripts/db-migrate-core.sh`

## VI. Conflict

Some Entity is conflict between Odoo 16 and Odoo 16, so you must resolve in C# Entity source code:

- Many entities with `name` column has data type is `string` (odoo 16) vs `jsonb` (odoo 18).
- Relation `employee_category_rel.emp_id` renamed to `employee_category_rel.employee_id`.

## VII. Todos

- Many entities have columns with `InverseProperties`. We must investigate to enable/disable.
- Add annotation [RelationField] for Entities's properties. We should do this to bypass table `ir_model_fields` in database.
- Complete JsonRPC and generic APIs.
