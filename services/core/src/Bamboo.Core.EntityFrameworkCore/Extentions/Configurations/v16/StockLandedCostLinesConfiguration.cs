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
        public static void ConfigureStockLandedCostLines(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockLandedCostLines>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_landed_cost_lines_pkey");

            entity.ToTable("stock_landed_cost_lines");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CostId).HasColumnName("cost_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PriceUnit).HasColumnName("price_unit");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.SplitMethod).HasColumnName("split_method");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.Account).WithMany(p => p.StockLandedCostLines)
            entity.HasOne(d => d.Account).WithMany()
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_landed_cost_lines_account_id_fkey");

            entity.HasOne(d => d.Cost).WithMany(p => p.StockLandedCostLines)
                .HasForeignKey(d => d.CostId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("stock_landed_cost_lines_cost_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.StockLandedCostLinesCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_landed_cost_lines_create_uid_fkey");

            // entity.HasOne(d => d.Product).WithMany(p => p.StockLandedCostLines)
            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("stock_landed_cost_lines_product_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.StockLandedCostLinesWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_landed_cost_lines_write_uid_fkey");
            });
        }
    }
}