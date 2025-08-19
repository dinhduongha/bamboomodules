using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAuthTotpRateLimitLog(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AuthTotpRateLimitLog>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("auth_totp_rate_limit_log_pkey");

            entity.ToTable("auth_totp_rate_limit_log");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => new { e.UserId, e.LimitType, e.CreationTime }, "auth_totp_rate_limit_log_user_id_limit_type_create_date_idx");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Ip).HasColumnName("ip");
            entity.Property(e => e.LimitType).HasColumnName("limit_type");
            entity.Property(e => e.Scope).HasColumnName("scope");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.AuthTotpRateLimitLogCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("auth_totp_rate_limit_log_create_uid_fkey");

            // entity.HasOne(d => d.User).WithMany(p => p.AuthTotpRateLimitLogUser)
            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("auth_totp_rate_limit_log_user_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.AuthTotpRateLimitLogWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("auth_totp_rate_limit_log_write_uid_fkey");
            });
        }
    }
}