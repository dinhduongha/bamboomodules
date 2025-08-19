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
        public static void ConfigureStockPickingToBatch(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockPickingToBatch>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_picking_to_batch_pkey");

            entity.ToTable("stock_picking_to_batch");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.BatchId).HasColumnName("batch_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsCreateDraft).HasColumnName("is_create_draft");
            entity.Property(e => e.Mode).HasColumnName("mode");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.Batch).WithMany(p => p.StockPickingToBatch)
                .HasForeignKey(d => d.BatchId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_picking_to_batch_batch_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.StockPickingToBatchCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_picking_to_batch_create_uid_fkey");

            // entity.HasOne(d => d.User).WithMany(p => p.StockPickingToBatchUser)
            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_picking_to_batch_user_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.StockPickingToBatchWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_picking_to_batch_write_uid_fkey");
            });
        }
    }
}
