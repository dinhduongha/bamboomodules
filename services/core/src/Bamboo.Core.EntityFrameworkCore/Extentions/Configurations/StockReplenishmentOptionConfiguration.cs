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
        public static void ConfigureStockReplenishmentOption(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockReplenishmentOption>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("stock_replenishment_option_pkey");

                entity.ToTable("stock_replenishment_option");

                entity.HasIndex(e => e.TenantId, "stock_replenishment_option_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
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

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_replenishment_option_create_uid_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.StockReplenishmentOptions)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_replenishment_option_product_id_fkey");

                entity.HasOne(d => d.ReplenishmentInfo).WithMany(p => p.StockReplenishmentOptions)
                    .HasForeignKey(d => d.ReplenishmentInfoId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_replenishment_option_replenishment_info_id_fkey");

                entity.HasOne(d => d.Route).WithMany(p => p.StockReplenishmentOptions)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_replenishment_option_route_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_replenishment_option_write_uid_fkey");
            });
        }
    }
}