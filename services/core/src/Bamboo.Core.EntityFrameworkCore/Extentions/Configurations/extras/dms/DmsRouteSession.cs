using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public static partial class ModelBuilderExtensions
{
    public static void ConfigureDmsRouteSession(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmsRouteSession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dms_route_session_pkey");

            entity.ToTable("dms_route_session");

            entity.HasIndex(e => e.TenantId);
            entity.HasIndex(e => e.OrganizationUnitId);
            entity.HasIndex(e => e.RouteId);
            entity.HasIndex(e => e.UserId);
            entity.HasIndex(e => e.SessionDate);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuidv7()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");
            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

            entity.Property(e => e.RouteId).HasColumnName("route_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.SessionDate).HasColumnName("session_date");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.ActualDistanceKm).HasColumnName("actual_distance_km");
            entity.Property(e => e.MissedVisitsCount).HasColumnName("missed_visits_count");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Notes).HasColumnName("notes");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");

            entity.Property(e => e.CreatorId).HasColumnName("create_uid");

            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");

            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.Route)
                .WithMany()
                .HasForeignKey(d => d.RouteId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("dms_route_session_route_id_fkey");

            entity.HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("dms_route_session_user_id_fkey");

            entity.TryConfigureExtraProperties();
            entity.TryConfigureObjectExtensions();
            entity.TryConfigureConcurrencyStamp();
        });
    }
}