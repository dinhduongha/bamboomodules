using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public static partial class ModelBuilderExtensions
{
    public static void ConfigureDmsRoute(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmsRoute>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dms_route_pkey");

            entity.ToTable("dms_route");

            entity.HasIndex(e => e.TenantId);
            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuidv7()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");
            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

            entity.Property(e => e.RouteCode).HasColumnName("route_code");
            entity.Property(e => e.PlannedDate).HasColumnName("planned_date");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TotalDistanceKm).HasColumnName("total_distance_km");
            entity.Property(e => e.EstimatedTimeHours).HasColumnName("estimated_time_hours");
            entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");
            entity.Property(e => e.PlannedByUserId).HasColumnName("planned_by_user_id");
            entity.Property(e => e.StartCheckpointId).HasColumnName("start_checkpoint_id");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");

            entity.Property(e => e.CreatorId).HasColumnName("create_uid");

            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");

            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.Property(e => e.RouteTemplateId).HasColumnName("route_template_id");
            entity.Property(e => e.IsDynamic).HasColumnName("is_dynamic").HasDefaultValue(true);
            entity.Property(e => e.Date).HasColumnName("date");


            entity.HasOne(d => d.Vehicle)
                .WithMany()
                .HasForeignKey(d => d.VehicleId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("dms_route_vehicle_id_fkey");

            entity.HasOne(d => d.PlannedByUser)
                .WithMany()
                .HasForeignKey(d => d.PlannedByUserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("dms_route_planned_by_user_id_fkey");

            entity.HasOne(d => d.RouteTemplate)
                .WithMany()
                .HasForeignKey(d => d.RouteTemplateId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("dms_route_route_template_id_fkey");

            entity.TryConfigureExtraProperties();
            entity.TryConfigureObjectExtensions();
            entity.TryConfigureConcurrencyStamp();
        });
    }
}