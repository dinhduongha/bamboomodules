using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockRequestCount(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockRequestCount>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_request_count_pkey");

                        entity.ToTable("stock_request_count");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccountingDate).HasColumnName("accounting_date");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.InventoryDate).HasColumnName("inventory_date");
                        entity.Property(e => e.SetCount).HasColumnName("set_count");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockRequestCountCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_request_count_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_request_count_create_uid_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.StockRequestCountUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_request_count_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_request_count_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockRequestCountWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_request_count_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_request_count_write_uid_fkey");

                        // entity.HasMany(d => d.StockQuant).WithMany(p => p.StockRequestCount)
                        entity.HasMany(d => d.StockQuant).WithMany(p => p.StockRequestCount)
                            .UsingEntity<Dictionary<string, object>>(
                                "StockQuantStockRequestCountRel",
                                r => r.HasOne<StockQuant>().WithMany()
                                    .HasForeignKey("StockQuantId")
                                    .HasConstraintName("stock_quant_stock_request_count_rel_stock_quant_id_fkey"),
                                l => l.HasOne<StockRequestCount>().WithMany()
                                    .HasForeignKey("StockRequestCountId")
                                    .HasConstraintName("stock_quant_stock_request_count_rel_stock_request_count_id_fkey"),
                                j =>
                                {
                                    j.HasKey("StockRequestCountId", "StockQuantId").HasName("stock_quant_stock_request_count_rel_pkey");
                                    j.ToTable("stock_quant_stock_request_count_rel");
                                    j.HasIndex(new[] { "StockQuantId", "StockRequestCountId" }, "stock_quant_stock_request_cou_stock_quant_id_stock_request__idx");
                                    j.IndexerProperty<Guid>("StockRequestCountId").HasColumnName("stock_request_count_id");
                                    j.IndexerProperty<Guid>("StockQuantId").HasColumnName("stock_quant_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}