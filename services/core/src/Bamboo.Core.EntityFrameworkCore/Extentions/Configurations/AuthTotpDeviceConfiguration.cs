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
        public static void ConfigureAuthTotpDevice(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthTotpDevice>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("auth_totp_device_pkey");

                entity.ToTable("auth_totp_device");

                entity.HasIndex(e => new { e.UserId, e.Index }, "auth_totp_device_user_id_index_idx");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.CreationTime)
                    .HasDefaultValueSql("(now() AT TIME ZONE 'utc'::text)")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.ExpirationDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("expiration_date");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.Index).HasColumnName("index");
                entity.Property(e => e.Key).HasColumnName("key");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Scope).HasColumnName("scope");
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("auth_totp_device_user_id_fkey");
            });
        }
    }
}