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
        public static void ConfigureResDeviceLog(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ResDeviceLog>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("res_device_log_pkey");

            entity.ToTable("res_device_log");

            entity.HasIndex(e => new { e.UserId, e.SessionIdentifier, e.Platform, e.Browser, e.LastActivity, e.Id }, "res_device_log__composite_idx").HasFilter("(revoked = false)");

            entity.HasIndex(e => e.LastActivity, "res_device_log__last_activity_index");

            entity.HasIndex(e => e.SessionIdentifier, "res_device_log__session_identifier_index");

            entity.HasIndex(e => e.UserId, "res_device_log__user_id_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Browser).HasColumnName("browser");
            entity.Property(e => e.City).HasColumnName("city");
            entity.Property(e => e.Country).HasColumnName("country");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.DeviceType).HasColumnName("device_type");
            entity.Property(e => e.FirstActivity)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("first_activity");
            entity.Property(e => e.IpAddress).HasColumnName("ip_address");
            entity.Property(e => e.LastActivity)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_activity");
            entity.Property(e => e.Platform).HasColumnName("platform");
            entity.Property(e => e.Revoked).HasColumnName("revoked");
            entity.Property(e => e.SessionIdentifier).HasColumnName("session_identifier");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.ResDeviceLogCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("res_device_log_create_uid_fkey");

            // entity.HasOne(d => d.User).WithMany(p => p.ResDeviceLogUser)
            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("res_device_log_user_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.ResDeviceLogWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("res_device_log_write_uid_fkey");
            });
        }
    }
}