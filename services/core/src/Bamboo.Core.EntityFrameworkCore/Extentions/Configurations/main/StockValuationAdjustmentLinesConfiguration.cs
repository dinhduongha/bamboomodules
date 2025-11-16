using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockValuationAdjustmentLines(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockValuationAdjustmentLines>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_valuation_adjustment_lines_pkey");

                        entity.ToTable("stock_valuation_adjustment_lines");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.CostId, "stock_valuation_adjustment_lines__cost_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AdditionalLandedCost).HasColumnName("additional_landed_cost");
                        entity.Property(e => e.CostId).HasColumnName("cost_id");
                        entity.Property(e => e.CostLineId).HasColumnName("cost_line_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.FinalCost).HasColumnName("final_cost");
                        entity.Property(e => e.FormerCost).HasColumnName("former_cost");
                        entity.Property(e => e.MoveId).HasColumnName("move_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.ProductId).HasColumnName("product_id");
                        entity.Property(e => e.Quantity).HasColumnName("quantity");
                        entity.Property(e => e.Volume).HasColumnName("volume");
                        entity.Property(e => e.Weight).HasColumnName("weight");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Cost).WithMany(p => p.StockValuationAdjustmentLines)
                            .HasForeignKey(d => d.CostId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("stock_valuation_adjustment_lines_cost_id_fkey");

                        entity.HasOne(d => d.CostLine).WithMany(p => p.StockValuationAdjustmentLines)
                            .HasForeignKey(d => d.CostLineId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_valuation_adjustment_lines_cost_line_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockValuationAdjustmentLinesCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_valuation_adjustment_lines_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_valuation_adjustment_lines_create_uid_fkey");

                        entity.HasOne(d => d.Move).WithMany(p => p.StockValuationAdjustmentLines)
                            .HasForeignKey(d => d.MoveId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_valuation_adjustment_lines_move_id_fkey");

                        // entity.HasOne(d => d.Product).WithMany(p => p.StockValuationAdjustmentLines) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("stock_valuation_adjustment_lines_product_id_fkey");
                        entity.HasOne(d => d.Product).WithMany()
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("stock_valuation_adjustment_lines_product_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockValuationAdjustmentLinesWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_valuation_adjustment_lines_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_valuation_adjustment_lines_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}