using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public static partial class ModelBuilderExtensions
{
    public static void ConfigureDmsDailyCheckpoint(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmsDailyCheckpoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dms_daily_checkpoint_pkey");

            entity.ToTable("dms_daily_checkpoint");

            entity.HasIndex(e => e.TenantId);
            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuidv7()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");
            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CheckpointDate);
            entity.Property(e => e.CheckpointType).HasColumnName("checkpoint_type");
            entity.Property(e => e.CheckInTime).HasColumnName("check_in_time");
            entity.Property(e => e.GeoLatitude).HasColumnName("geo_latitude");
            entity.Property(e => e.GeoLongitude).HasColumnName("geo_longitude");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.Photos);
            entity.Property(e => e.ProvisionPickingId).HasColumnName("provision_picking_id");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");

            entity.Property(e => e.CreatorId).HasColumnName("create_uid");

            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");

            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("dms_daily_checkpoint_user_id_fkey");

            entity.HasOne(d => d.ProvisionPicking)
                .WithMany()
                .HasForeignKey(d => d.ProvisionPickingId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("dms_daily_checkpoint_provision_picking_id_fkey");

            entity.TryConfigureExtraProperties();
            entity.TryConfigureObjectExtensions();
            entity.TryConfigureConcurrencyStamp();
        });
    }
}