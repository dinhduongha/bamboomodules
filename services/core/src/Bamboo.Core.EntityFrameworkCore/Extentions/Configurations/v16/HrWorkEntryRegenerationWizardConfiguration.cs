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
        public static void ConfigureHrWorkEntryRegenerationWizard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrWorkEntryRegenerationWizard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_work_entry_regeneration_wizard_pkey");

            entity.ToTable("hr_work_entry_regeneration_wizard");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

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
            entity.Property(e => e.DateFrom).HasColumnName("date_from");
            entity.Property(e => e.DateTo).HasColumnName("date_to");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.HrWorkEntryRegenerationWizardCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_work_entry_regeneration_wizard_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.HrWorkEntryRegenerationWizardWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_work_entry_regeneration_wizard_write_uid_fkey");

            // entity.HasMany(d => d.HrEmployee).WithMany(p => p.HrWorkEntryRegenerationWizard)
            entity.HasMany(d => d.HrEmployee).WithMany(p => p.HrWorkEntryRegenerationWizard)
                .UsingEntity<Dictionary<string, object>>(
                    "HrEmployeeHrWorkEntryRegenerationWizardRel",
                    r => r.HasOne<HrEmployee>().WithMany()
                        .HasForeignKey("HrEmployeeId")
                        .HasConstraintName("hr_employee_hr_work_entry_regeneration_wiza_hr_employee_id_fkey"),
                    l => l.HasOne<HrWorkEntryRegenerationWizard>().WithMany()
                        .HasForeignKey("HrWorkEntryRegenerationWizardId")
                        .HasConstraintName("hr_employee_hr_work_entry_reg_hr_work_entry_regeneration_w_fkey"),
                    j =>
                    {
                        j.HasKey("HrWorkEntryRegenerationWizardId", "HrEmployeeId").HasName("hr_employee_hr_work_entry_regeneration_wizard_rel_pkey");
                        j.ToTable("hr_employee_hr_work_entry_regeneration_wizard_rel");
                        j.HasIndex(new[] { "HrEmployeeId", "HrWorkEntryRegenerationWizardId" }, "hr_employee_hr_work_entry_reg_hr_employee_id_hr_work_entry__idx");
                        j.IndexerProperty<Guid>("HrWorkEntryRegenerationWizardId").HasColumnName("hr_work_entry_regeneration_wizard_id");
                        j.IndexerProperty<Guid>("HrEmployeeId").HasColumnName("hr_employee_id");
                    });
            });
        }
    }
}