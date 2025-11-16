using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockReplenishmentOption(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockReplenishmentOption>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_replenishment_option_pkey");

                        entity.ToTable("stock_replenishment_option");

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
                        entity.Property(e => e.ProductId).HasColumnName("product_id");
                        entity.Property(e => e.ReplenishmentInfoId).HasColumnName("replenishment_info_id");
                        entity.Property(e => e.RouteId).HasColumnName("route_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockReplenishmentOptionCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_replenishment_option_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_replenishment_option_create_uid_fkey");

                        // entity.HasOne(d => d.Product).WithMany(p => p.StockReplenishmentOption) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_replenishment_option_product_id_fkey");
                        entity.HasOne(d => d.Product).WithMany()
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_replenishment_option_product_id_fkey");

                        entity.HasOne(d => d.ReplenishmentInfo).WithMany(p => p.StockReplenishmentOption)
                            .HasForeignKey(d => d.ReplenishmentInfoId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_replenishment_option_replenishment_info_id_fkey");

                        entity.HasOne(d => d.Route).WithMany(p => p.StockReplenishmentOption)
                            .HasForeignKey(d => d.RouteId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_replenishment_option_route_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockReplenishmentOptionWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_replenishment_option_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_replenishment_option_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}