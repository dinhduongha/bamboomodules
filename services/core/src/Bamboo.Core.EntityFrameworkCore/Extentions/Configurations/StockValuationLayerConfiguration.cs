using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
// TODO: Hãy chắc chắn rằng bạn đã thêm using cho namespace chứa Models của mình ở đây
// Ví dụ: using YourProject.Models;
using Bamboo.Core.Models;
namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockValuationLayer(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockValuationLayer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("stock_valuation_layer_pkey");

                entity.ToTable("stock_valuation_layer");

                entity.HasIndex(e => e.AccountMoveLineId, "stock_valuation_layer_account_move_line_id_index");

                entity.HasIndex(e => new { e.ProductId, e.RemainingQty, e.StockMoveId, e.TenantId, e.CreationTime }, "stock_valuation_layer_index");

                entity.HasIndex(e => e.StockMoveId, "stock_valuation_layer_stock_move_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AccountMoveId).HasColumnName("account_move_id");
                entity.Property(e => e.AccountMoveLineId).HasColumnName("account_move_line_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.PriceDiffValue).HasColumnName("price_diff_value");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
                entity.Property(e => e.RemainingQty).HasColumnName("remaining_qty");
                entity.Property(e => e.RemainingValue).HasColumnName("remaining_value");
                entity.Property(e => e.StockMoveId).HasColumnName("stock_move_id");
                entity.Property(e => e.StockValuationLayerId).HasColumnName("stock_valuation_layer_id");
                entity.Property(e => e.UnitCost).HasColumnName("unit_cost");
                entity.Property(e => e.Value).HasColumnName("value");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.AccountMove).WithMany(p => p.StockValuationLayers)
                    .HasForeignKey(d => d.AccountMoveId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_valuation_layer_account_move_id_fkey");

                entity.HasOne(d => d.AccountMoveLine).WithMany(p => p.StockValuationLayers)
                    .HasForeignKey(d => d.AccountMoveLineId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_valuation_layer_account_move_line_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_valuation_layer_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_valuation_layer_create_uid_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.StockValuationLayers)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_valuation_layer_product_id_fkey");

                entity.HasOne(d => d.StockMove).WithMany(p => p.StockValuationLayers)
                    .HasForeignKey(d => d.StockMoveId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_valuation_layer_stock_move_id_fkey");

                entity.HasOne(d => d.StockValuationLayerNavigation).WithMany(p => p.InverseStockValuationLayerNavigation)
                    .HasForeignKey(d => d.StockValuationLayerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_valuation_layer_stock_valuation_layer_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_valuation_layer_write_uid_fkey");
            });
        }
    }
}