using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public static partial class ModelBuilderExtensions
{
    public static void ConfigureDmsGeofence(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmsGeofence>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dms_geofence_pkey");

            entity.ToTable("dms_geofence");

            entity.HasIndex(e => e.TenantId);
            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuidv7()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");
            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.RadiusMeters).HasColumnName("radius_meters");
            entity.Property(e => e.PolygonGeoJson).HasColumnName("polygon_geo_json");
            entity.Property(e => e.CenterLatitude).HasColumnName("center_latitude");
            entity.Property(e => e.CenterLongitude).HasColumnName("center_longitude");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.AlertOnEnter).HasColumnName("alert_on_enter");
            entity.Property(e => e.AlertOnExit).HasColumnName("alert_on_exit");

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