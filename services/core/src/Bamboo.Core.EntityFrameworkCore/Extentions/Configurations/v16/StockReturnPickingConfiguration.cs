using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockReturnPicking(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockReturnPicking>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_return_picking_pkey");

            entity.ToTable("stock_return_picking");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.MoveDestExists).HasColumnName("move_dest_exists");
            entity.Property(e => e.OriginalLocationId).HasColumnName("original_location_id");
            entity.Property(e => e.ParentLocationId).HasColumnName("parent_location_id");
            entity.Property(e => e.PickingId).HasColumnName("picking_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.StockReturnPickingCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_return_picking_create_uid_fkey");

            entity.HasOne(d => d.Location).WithMany(p => p.StockReturnPickingLocation)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_return_picking_location_id_fkey");

            entity.HasOne(d => d.OriginalLocation).WithMany(p => p.StockReturnPickingOriginalLocation)
                .HasForeignKey(d => d.OriginalLocationId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_return_picking_original_location_id_fkey");

            entity.HasOne(d => d.ParentLocation).WithMany(p => p.StockReturnPickingParentLocation)
                .HasForeignKey(d => d.ParentLocationId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_return_picking_parent_location_id_fkey");

            entity.HasOne(d => d.Picking).WithMany(p => p.StockReturnPicking)
                .HasForeignKey(d => d.PickingId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_return_picking_picking_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.StockReturnPickingWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_return_picking_write_uid_fkey");
            });
        }
    }
}