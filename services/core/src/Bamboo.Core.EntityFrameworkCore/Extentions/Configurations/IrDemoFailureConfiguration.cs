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
        public static void ConfigureIrDemoFailure(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IrDemoFailure>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ir_demo_failure_pkey");

                entity.ToTable("ir_demo_failure");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Error).HasColumnName("error");
                entity.Property(e => e.ModuleId).HasColumnName("module_id");
                entity.Property(e => e.WizardId).HasColumnName("wizard_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_demo_failure_create_uid_fkey");

                entity.HasOne(d => d.Module).WithMany(p => p.IrDemoFailures)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ir_demo_failure_module_id_fkey");

                entity.HasOne(d => d.Wizard).WithMany(p => p.IrDemoFailures)
                    .HasForeignKey(d => d.WizardId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_demo_failure_wizard_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_demo_failure_write_uid_fkey");
            });
        }
    }
}