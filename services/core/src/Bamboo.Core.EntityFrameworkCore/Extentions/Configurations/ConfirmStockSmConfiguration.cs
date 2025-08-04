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
        public static void ConfigureConfirmStockSm(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfirmStockSm>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("confirm_stock_sms_pkey");

                entity.ToTable("confirm_stock_sms");

                entity.HasIndex(e => e.TenantId, "stock_confirm_stock_sms_company_id_index");

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
                    .HasConstraintName("confirm_stock_sms_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("confirm_stock_sms_write_uid_fkey");

                //entity.HasMany(d => d.StockPickings).WithMany(p => p.ConfirmStockSms)
                entity.HasMany<StockPicking>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "StockPickingSmsRel",
                        r => r.HasOne<StockPicking>().WithMany()
                            .HasForeignKey("StockPickingId")
                            .HasConstraintName("stock_picking_sms_rel_stock_picking_id_fkey"),
                        l => l.HasOne<ConfirmStockSm>().WithMany()
                            .HasForeignKey("ConfirmStockSmsId")
                            .HasConstraintName("stock_picking_sms_rel_confirm_stock_sms_id_fkey"),
                        j =>
                        {
                            j.HasKey("ConfirmStockSmsId", "StockPickingId").HasName("stock_picking_sms_rel_pkey");
                            j.ToTable("stock_picking_sms_rel");
                            j.HasIndex(new[] { "StockPickingId", "ConfirmStockSmsId" }, "stock_picking_sms_rel_stock_picking_id_confirm_stock_sms_id_idx");
                        });
            });
        }
    }
}