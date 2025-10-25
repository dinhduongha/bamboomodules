using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureConfirmStockSms(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ConfirmStockSms>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("confirm_stock_sms_pkey");

                        entity.ToTable("confirm_stock_sms");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ConfirmStockSmsCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("confirm_stock_sms_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("confirm_stock_sms_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ConfirmStockSmsWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("confirm_stock_sms_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("confirm_stock_sms_write_uid_fkey");

                        // entity.HasMany(d => d.StockPicking).WithMany(p => p.ConfirmStockSms)
                        entity.HasMany(d => d.StockPicking).WithMany(p => p.ConfirmStockSms)
                            .UsingEntity<Dictionary<string, object>>(
                                "StockPickingSmsRel",
                                r => r.HasOne<StockPicking>().WithMany()
                                    .HasForeignKey("StockPickingId")
                                    .HasConstraintName("stock_picking_sms_rel_stock_picking_id_fkey"),
                                l => l.HasOne<ConfirmStockSms>().WithMany()
                                    .HasForeignKey("ConfirmStockSmsId")
                                    .HasConstraintName("stock_picking_sms_rel_confirm_stock_sms_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ConfirmStockSmsId", "StockPickingId").HasName("stock_picking_sms_rel_pkey");
                                    j.ToTable("stock_picking_sms_rel");
                                    j.HasIndex(new[] { "StockPickingId", "ConfirmStockSmsId" }, "stock_picking_sms_rel_stock_picking_id_confirm_stock_sms_id_idx");
                                    j.IndexerProperty<Guid>("ConfirmStockSmsId").HasColumnName("confirm_stock_sms_id");
                                    j.IndexerProperty<Guid>("StockPickingId").HasColumnName("stock_picking_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}