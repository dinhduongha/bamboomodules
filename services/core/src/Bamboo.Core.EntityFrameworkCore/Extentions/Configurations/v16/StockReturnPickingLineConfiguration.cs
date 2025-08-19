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
        public static void ConfigureStockReturnPickingLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockReturnPickingLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_return_picking_line_pkey");

            entity.ToTable("stock_return_picking_line");

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
            entity.Property(e => e.MoveId).HasColumnName("move_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.ToRefund).HasColumnName("to_refund");
            entity.Property(e => e.WizardId).HasColumnName("wizard_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.StockReturnPickingLineCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_return_picking_line_create_uid_fkey");

            entity.HasOne(d => d.Move).WithMany(p => p.StockReturnPickingLine)
                .HasForeignKey(d => d.MoveId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_return_picking_line_move_id_fkey");

            // entity.HasOne(d => d.Product).WithMany(p => p.StockReturnPickingLine)
            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("stock_return_picking_line_product_id_fkey");

            entity.HasOne(d => d.Wizard).WithMany(p => p.StockReturnPickingLine)
                .HasForeignKey(d => d.WizardId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_return_picking_line_wizard_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.StockReturnPickingLineWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_return_picking_line_write_uid_fkey");
            });
        }
    }
}