using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public static partial class ModelBuilderExtensions
{
    public static void ConfigureDmsRouteLine(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmsRouteLine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dms_route_line_pkey");

            entity.ToTable("dms_route_line");

            entity.HasIndex(e => e.TenantId);
            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuidv7()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");
            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

            entity.Property(e => e.RouteId).HasColumnName("route_id");
            entity.Property(e => e.StockPickingId).HasColumnName("stock_picking_id");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.EstimatedArrivalTime).HasColumnName("estimated_arrival_time");
            entity.Property(e => e.ActualArrivalTime).HasColumnName("actual_arrival_time");

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
                .HasConstraintName("dms_route_line_route_id_fkey");

            entity.HasOne(d => d.StockPicking)
                .WithMany()
                .HasForeignKey(d => d.StockPickingId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("dms_route_line_stock_picking_id_fkey");

            entity.TryConfigureExtraProperties();
            entity.TryConfigureObjectExtensions();
            entity.TryConfigureConcurrencyStamp();
        });
    }
}