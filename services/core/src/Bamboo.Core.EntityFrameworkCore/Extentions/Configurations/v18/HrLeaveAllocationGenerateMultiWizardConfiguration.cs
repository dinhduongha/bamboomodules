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
        public static void ConfigureHrLeaveAllocationGenerateMultiWizard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrLeaveAllocationGenerateMultiWizard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_leave_allocation_generate_multi_wizard_pkey");

            entity.ToTable("hr_leave_allocation_generate_multi_wizard");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AccrualPlanId).HasColumnName("accrual_plan_id");
            entity.Property(e => e.AllocationMode).HasColumnName("allocation_mode");
            entity.Property(e => e.AllocationType).HasColumnName("allocation_type");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.DateFrom).HasColumnName("date_from");
            entity.Property(e => e.DateTo).HasColumnName("date_to");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.HolidayStatusId).HasColumnName("holiday_status_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.AccrualPlan).WithMany(p => p.HrLeaveAllocationGenerateMultiWizard)
                .HasForeignKey(d => d.AccrualPlanId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_leave_allocation_generate_multi_wizard_accrual_plan_id_fkey");

            entity.HasOne(d => d.Category).WithMany(p => p.HrLeaveAllocationGenerateMultiWizard)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_leave_allocation_generate_multi_wizard_category_id_fkey");

            // entity.HasOne(d => d.Company).WithMany(p => p.HrLeaveAllocationGenerateMultiWizard)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("hr_leave_allocation_generate_multi_wizard_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.HrLeaveAllocationGenerateMultiWizardCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_leave_allocation_generate_multi_wizard_create_uid_fkey");

            entity.HasOne(d => d.Department).WithMany(p => p.HrLeaveAllocationGenerateMultiWizard)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_leave_allocation_generate_multi_wizard_department_id_fkey");

            entity.HasOne(d => d.HolidayStatus).WithMany(p => p.HrLeaveAllocationGenerateMultiWizard)
                .HasForeignKey(d => d.HolidayStatusId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("hr_leave_allocation_generate_multi_wizar_holiday_status_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.HrLeaveAllocationGenerateMultiWizardWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_leave_allocation_generate_multi_wizard_write_uid_fkey");

            // entity.HasMany(d => d.HrEmployee).WithMany(p => p.HrLeaveAllocationGenerateMultiWizard)
            entity.HasMany(d => d.HrEmployee).WithMany(p => p.HrLeaveAllocationGenerateMultiWizard)
                .UsingEntity<Dictionary<string, object>>(
                    "HrEmployeeHrLeaveAllocationGenerateMultiWizardRel",
                    r => r.HasOne<HrEmployee>().WithMany()
                        .HasForeignKey("HrEmployeeId")
                        .HasConstraintName("hr_employee_hr_leave_allocation_generate_mu_hr_employee_id_fkey"),
                    l => l.HasOne<HrLeaveAllocationGenerateMultiWizard>().WithMany()
                        .HasForeignKey("HrLeaveAllocationGenerateMultiWizardId")
                        .HasConstraintName("hr_employee_hr_leave_allocati_hr_leave_allocation_generate_fkey"),
                    j =>
                    {
                        j.HasKey("HrLeaveAllocationGenerateMultiWizardId", "HrEmployeeId").HasName("hr_employee_hr_leave_allocation_generate_multi_wizard_rel_pkey");
                        j.ToTable("hr_employee_hr_leave_allocation_generate_multi_wizard_rel");
                        j.HasIndex(new[] { "HrEmployeeId", "HrLeaveAllocationGenerateMultiWizardId" }, "hr_employee_hr_leave_allocati_hr_employee_id_hr_leave_alloc_idx");
                        j.IndexerProperty<Guid>("HrLeaveAllocationGenerateMultiWizardId").HasColumnName("hr_leave_allocation_generate_multi_wizard_id");
                        j.IndexerProperty<Guid>("HrEmployeeId").HasColumnName("hr_employee_id");
                    });
            });
        }
    }
}