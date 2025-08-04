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
        public static void ConfigureStockInventoryConflict(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockInventoryConflict>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("stock_inventory_conflict_pkey");

                entity.ToTable("stock_inventory_conflict");

                entity.HasIndex(e => e.TenantId, "stock_inventory_conflict_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_inventory_conflict_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_inventory_conflict_write_uid_fkey");

                /// TODO:
                //entity.HasMany(d => d.StockQuants).WithMany(p => p.StockInventoryConflicts)
                entity.HasMany<StockQuant>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "StockConflictQuantRel",
                        r => r.HasOne<StockQuant>().WithMany()
                            .HasForeignKey("StockQuantId")
                            .HasConstraintName("stock_conflict_quant_rel_stock_quant_id_fkey"),
                        l => l.HasOne<StockInventoryConflict>().WithMany()
                            .HasForeignKey("StockInventoryConflictId")
                            .HasConstraintName("stock_conflict_quant_rel_stock_inventory_conflict_id_fkey"),
                        j =>
                        {
                            j.HasKey("StockInventoryConflictId", "StockQuantId").HasName("stock_conflict_quant_rel_pkey");
                            j.ToTable("stock_conflict_quant_rel");
                            j.HasIndex(new[] { "StockQuantId", "StockInventoryConflictId" }, "stock_conflict_quant_rel_stock_quant_id_stock_inventory_con_idx");
                        });

                /// TODO:
                //entity.HasMany(d => d.StockQuantsNavigation).WithMany(p => p.StockInventoryConflictsNavigation)
                entity.HasMany<StockQuant>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "StockInventoryConflictStockQuantRel",
                        r => r.HasOne<StockQuant>().WithMany()
                            .HasForeignKey("StockQuantId")
                            .HasConstraintName("stock_inventory_conflict_stock_quant_rel_stock_quant_id_fkey"),
                        l => l.HasOne<StockInventoryConflict>().WithMany()
                            .HasForeignKey("StockInventoryConflictId")
                            .HasConstraintName("stock_inventory_conflict_stock_stock_inventory_conflict_id_fkey"),
                        j =>
                        {
                            j.HasKey("StockInventoryConflictId", "StockQuantId").HasName("stock_inventory_conflict_stock_quant_rel_pkey");
                            j.ToTable("stock_inventory_conflict_stock_quant_rel");
                            j.HasIndex(new[] { "StockQuantId", "StockInventoryConflictId" }, "stock_inventory_conflict_stoc_stock_quant_id_stock_inventor_idx");
                        });
            });
        }
    }
}