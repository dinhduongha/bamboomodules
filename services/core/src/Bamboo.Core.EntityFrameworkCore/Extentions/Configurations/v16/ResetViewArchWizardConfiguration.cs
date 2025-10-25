using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");
                        entity.Property(e => e.CompareViewId).HasColumnName("compare_view_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.ResetMode).HasColumnName("reset_mode");
                        entity.Property(e => e.ViewId).HasColumnName("view_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.CompareView).WithMany(p => p.ResetViewArchWizardCompareView)
                            .HasForeignKey(d => d.CompareViewId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("reset_view_arch_wizard_compare_view_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ResetViewArchWizardCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("reset_view_arch_wizard_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("reset_view_arch_wizard_create_uid_fkey");

                        entity.HasOne(d => d.View).WithMany(p => p.ResetViewArchWizardView)
                            .HasForeignKey(d => d.ViewId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("reset_view_arch_wizard_view_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ResetViewArchWizardWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("reset_view_arch_wizard_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("reset_view_arch_wizard_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}