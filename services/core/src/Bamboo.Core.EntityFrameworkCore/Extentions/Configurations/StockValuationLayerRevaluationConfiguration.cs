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
        public static void ConfigureStockValuationLayerRevaluation(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockValuationLayerRevaluation>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("stock_valuation_layer_revaluation_pkey");

                entity.ToTable("stock_valuation_layer_revaluation");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.AccountId).HasColumnName("account_id");
                entity.Property(e => e.AccountJournalId).HasColumnName("account_journal_id");
                entity.Property(e => e.AddedValue).HasColumnName("added_value");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Date).HasColumnName("date");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.Reason).HasColumnName("reason");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Account).WithMany(p => p.StockValuationLayerRevaluations)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_valuation_layer_revaluation_account_id_fkey");

                entity.HasOne(d => d.AccountJournal).WithMany(p => p.StockValuationLayerRevaluations)
                    .HasForeignKey(d => d.AccountJournalId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_valuation_layer_revaluation_account_journal_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("stock_valuation_layer_revaluation_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_valuation_layer_revaluation_create_uid_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.StockValuationLayerRevaluations)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("stock_valuation_layer_revaluation_product_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_valuation_layer_revaluation_write_uid_fkey");

                //entity.HasMany(d => d.StockValuationLayers).WithMany(p => p.StockValuationLayerRevaluations)
                entity.HasMany<StockValuationLayer>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "StockValuationLayerStockValuationLayerRevaluationRel",
                        r => r.HasOne<StockValuationLayer>().WithMany()
                            .HasForeignKey("StockValuationLayerId")
                            .HasConstraintName("stock_valuation_layer_stock_valua_stock_valuation_layer_id_fkey"),
                        l => l.HasOne<StockValuationLayerRevaluation>().WithMany()
                            .HasForeignKey("StockValuationLayerRevaluationId")
                            .HasConstraintName("stock_valuation_layer_stock_v_stock_valuation_layer_revalu_fkey"),
                        j =>
                        {
                            j.HasKey("StockValuationLayerRevaluationId", "StockValuationLayerId").HasName("stock_valuation_layer_stock_valuation_layer_revaluation_re_pkey");
                            j.ToTable("stock_valuation_layer_stock_valuation_layer_revaluation_rel");
                            j.HasIndex(new[] { "StockValuationLayerId", "StockValuationLayerRevaluationId" }, "stock_valuation_layer_stock_v_stock_valuation_layer_id_stoc_idx");
                            j.IndexerProperty<Guid>("StockValuationLayerRevaluationId").HasColumnName("stock_valuation_layer_revaluation_id");
                            j.IndexerProperty<Guid>("StockValuationLayerId").HasColumnName("stock_valuation_layer_id");
                        });
            });
        }
    }
}