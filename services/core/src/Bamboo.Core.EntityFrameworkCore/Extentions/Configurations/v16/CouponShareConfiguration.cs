using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureCouponShare(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<CouponShare>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("coupon_share_pkey");

                        entity.ToTable("coupon_share");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

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
                        entity.Property(e => e.ProgramId).HasColumnName("program_id");
                        entity.Property(e => e.Redirect).HasColumnName("redirect");
                        entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Coupon).WithMany(p => p.CouponShare)
                            .HasForeignKey(d => d.CouponId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("coupon_share_coupon_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.CouponShareCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("coupon_share_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("coupon_share_create_uid_fkey");

                        entity.HasOne(d => d.Program).WithMany(p => p.CouponShare)
                            .HasForeignKey(d => d.ProgramId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("coupon_share_program_id_fkey");

                        // entity.HasOne(d => d.Website).WithMany(p => p.CouponShare) .HasForeignKey(d => d.WebsiteId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("coupon_share_website_id_fkey");
                        entity.HasOne(d => d.Website).WithMany()
                            .HasForeignKey(d => d.WebsiteId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("coupon_share_website_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.CouponShareWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("coupon_share_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("coupon_share_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}