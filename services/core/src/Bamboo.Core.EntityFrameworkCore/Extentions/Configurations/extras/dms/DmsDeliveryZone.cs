using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public static partial class ModelBuilderExtensions
{
    public static void ConfigureDmsDeliveryZone(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmsDeliveryZone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dms_delivery_zone_pkey");

            entity.ToTable("dms_delivery_zone");

            entity.HasIndex(e => e.TenantId);
            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuidv7()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");
            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

            entity.Property(e => e.ZoneCode).HasColumnName("zone_code");
            entity.Property(e => e.ZoneName).HasColumnName("zone_name");
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.GeoJsonPolygon);

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");

            entity.Property(e => e.CreatorId).HasColumnName("create_uid");

            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");

            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.TryConfigureExtraProperties();
            entity.TryConfigureObjectExtensions();
            entity.TryConfigureConcurrencyStamp();
        });
    }
}