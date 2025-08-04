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
        public static void ConfigureChangePasswordUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChangePasswordUser>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("change_password_user_pkey");

                entity.ToTable("change_password_user");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.NewPasswd).HasColumnName("new_passwd");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.UserLogin).HasColumnName("user_login");
                entity.Property(e => e.WizardId).HasColumnName("wizard_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("change_password_user_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("change_password_user_user_id_fkey");

                entity.HasOne(d => d.Wizard).WithMany(p => p.ChangePasswordUsers)
                    .HasForeignKey(d => d.WizardId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("change_password_user_wizard_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("change_password_user_write_uid_fkey");
            });
        }
    }
}