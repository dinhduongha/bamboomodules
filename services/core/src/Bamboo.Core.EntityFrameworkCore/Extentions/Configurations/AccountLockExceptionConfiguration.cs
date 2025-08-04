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
        public static void ConfigureAccountLockException(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountLockException>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_lock_exception_pkey");

                entity.ToTable("account_lock_exception");

                entity.HasIndex(e => new { e.TenantId, e.UserId, e.EndDatetime }, "account_lock_exception_company_id_end_datetime_idx").HasFilter("(active = true)");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CompanyLockDate).HasColumnName("company_lock_date");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.EndDatetime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("end_datetime");
                entity.Property(e => e.LockDate).HasColumnName("lock_date");
                entity.Property(e => e.LockDateField).HasColumnName("lock_date_field");
                entity.Property(e => e.Reason).HasColumnName("reason");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_lock_exception_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_lock_exception_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_lock_exception_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_lock_exception_write_uid_fkey");
            });
        }
    }
}