using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureSaleOrderCouponPoints(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<SaleOrderCouponPoints>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("sale_order_coupon_points_pkey");

                        entity.ToTable("sale_order_coupon_points");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => new { e.OrderId, e.CouponId }, "sale_order_coupon_points_order_coupon_unique").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CouponId).HasColumnName("coupon_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.OrderId).HasColumnName("order_id");
                        entity.Property(e => e.Points).HasColumnName("points");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Coupon).WithMany(p => p.SaleOrderCouponPoints)
                            .HasForeignKey(d => d.CouponId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("sale_order_coupon_points_coupon_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.SaleOrderCouponPointsCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("sale_order_coupon_points_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sale_order_coupon_points_create_uid_fkey");

                        entity.HasOne(d => d.Order).WithMany(p => p.SaleOrderCouponPoints)
                            .HasForeignKey(d => d.OrderId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("sale_order_coupon_points_order_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.SaleOrderCouponPointsWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("sale_order_coupon_points_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sale_order_coupon_points_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}