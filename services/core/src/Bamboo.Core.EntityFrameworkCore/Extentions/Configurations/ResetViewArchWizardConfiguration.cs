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
        public static void ConfigureResetViewArchWizard(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResetViewArchWizard>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("reset_view_arch_wizard_pkey");

                entity.ToTable("reset_view_arch_wizard");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.CompareViewId).HasColumnName("compare_view_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.ResetMode).HasColumnName("reset_mode");
                entity.Property(e => e.ViewId).HasColumnName("view_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.CompareView).WithMany(p => p.ResetViewArchWizardCompareViews)
                    .HasForeignKey(d => d.CompareViewId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("reset_view_arch_wizard_compare_view_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("reset_view_arch_wizard_create_uid_fkey");

                entity.HasOne(d => d.View).WithMany(p => p.ResetViewArchWizardViews)
                    .HasForeignKey(d => d.ViewId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("reset_view_arch_wizard_view_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("reset_view_arch_wizard_write_uid_fkey");
            });
        }
    }
}