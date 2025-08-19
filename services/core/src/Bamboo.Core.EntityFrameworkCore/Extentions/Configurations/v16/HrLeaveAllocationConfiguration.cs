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
        public static void ConfigureHrLeaveAllocation(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrLeaveAllocation>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_leave_allocation_pkey");

            entity.ToTable("hr_leave_allocation");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.DateFrom, "hr_leave_allocation__date_from_index");

            entity.HasIndex(e => e.EmployeeId, "hr_leave_allocation__employee_id_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AccrualPlanId).HasColumnName("accrual_plan_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.ActualLastcall).HasColumnName("actual_lastcall");
            entity.Property(e => e.AllocationType).HasColumnName("allocation_type");
            entity.Property(e => e.AlreadyAccrued).HasColumnName("already_accrued");
            entity.Property(e => e.ApproverId).HasColumnName("approver_id");
            entity.Property(e => e.CarriedOverDaysExpirationDate).HasColumnName("carried_over_days_expiration_date");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.DateFrom).HasColumnName("date_from");
            entity.Property(e => e.DateTo).HasColumnName("date_to");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.EmployeeCompanyId).HasColumnName("employee_company_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.ExpiringCarryoverDays).HasColumnName("expiring_carryover_days");
            entity.Property(e => e.HolidayStatusId).HasColumnName("holiday_status_id");
            entity.Property(e => e.LastExecutedCarryoverDate).HasColumnName("last_executed_carryover_date");
            entity.Property(e => e.HolidayType).HasColumnName("holiday_type");
            entity.Property(e => e.Lastcall).HasColumnName("lastcall");
            entity.Property(e => e.ManagerId).HasColumnName("manager_id");
            entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
            entity.Property(e => e.ModeCompanyId).HasColumnName("mode_company_id");
            entity.Property(e => e.MultiEmployee).HasColumnName("multi_employee");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Nextcall).HasColumnName("nextcall");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.NumberOfDays).HasColumnName("number_of_days");
            entity.Property(e => e.NumberOfHoursDisplay).HasColumnName("number_of_hours_display");
            entity.Property(e => e.OvertimeId).HasColumnName("overtime_id");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.PrivateName).HasColumnName("private_name");
            entity.Property(e => e.SecondApproverId).HasColumnName("second_approver_id");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");
            entity.Property(e => e.YearlyAccruedAmount).HasColumnName("yearly_accrued_amount");

            entity.HasOne(d => d.AccrualPlan).WithMany(p => p.HrLeaveAllocation)
                .HasForeignKey(d => d.AccrualPlanId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_leave_allocation_accrual_plan_id_fkey");

            entity.HasOne(d => d.Approver).WithMany(p => p.HrLeaveAllocationApprover)
                .HasForeignKey(d => d.ApproverId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_leave_allocation_approver_id_fkey");

            entity.HasOne(d => d.Category).WithMany(p => p.HrLeaveAllocation)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_leave_allocation_category_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.HrLeaveAllocationCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_leave_allocation_create_uid_fkey");

            entity.HasOne(d => d.Department).WithMany(p => p.HrLeaveAllocation)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_leave_allocation_department_id_fkey");

            entity.HasOne(d => d.EmployeeCompany).WithMany()
                .HasForeignKey(d => d.EmployeeCompanyId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_leave_allocation_employee_company_id_fkey");

            // v16-Compat
            //entity.HasOne(d => d.EmployeeCompany).WithMany()
            //    .HasForeignKey(d => d.EmployeeCompanyId)
            //    .OnDelete(DeleteBehavior.SetNull)
            //    .HasConstraintName("hr_leave_allocation_employee_company_id_fkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.HrLeaveAllocationEmployee)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("hr_leave_allocation_employee_id_fkey");

            entity.HasOne(d => d.HolidayStatus).WithMany(p => p.HrLeaveAllocation)
                .HasForeignKey(d => d.HolidayStatusId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("hr_leave_allocation_holiday_status_id_fkey");

            entity.HasOne(d => d.Manager).WithMany(p => p.HrLeaveAllocationManager)
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_leave_allocation_manager_id_fkey");

            // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.HrLeaveAllocation)
            entity.HasOne(d => d.MessageMainAttachment).WithMany()
                .HasForeignKey(d => d.MessageMainAttachmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_leave_allocation_message_main_attachment_id_fkey");

            entity.HasOne(d => d.ModeCompany).WithMany()
                .HasForeignKey(d => d.ModeCompanyId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_leave_allocation_mode_company_id_fkey");

            entity.HasOne(d => d.Overtime).WithMany(p => p.HrLeaveAllocation)
                .HasForeignKey(d => d.OvertimeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_leave_allocation_overtime_id_fkey");

            entity.HasOne(d => d.SecondApprover).WithMany(p => p.HrLeaveAllocationSecondApprover)
                .HasForeignKey(d => d.SecondApproverId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_leave_allocation_second_approver_id_fkey");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_leave_allocation_parent_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.HrLeaveAllocationWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_leave_allocation_write_uid_fkey");

            // entity.HasMany(d => d.HrEmployee).WithMany(p => p.HrLeaveAllocation)
            entity.HasMany(d => d.HrEmployee).WithMany(p => p.HrLeaveAllocation)
                .UsingEntity<Dictionary<string, object>>(
                    "HrEmployeeHrLeaveAllocationRel",
                    r => r.HasOne<HrEmployee>().WithMany()
                        .HasForeignKey("HrEmployeeId")
                        .HasConstraintName("hr_employee_hr_leave_allocation_rel_hr_employee_id_fkey"),
                    l => l.HasOne<HrLeaveAllocation>().WithMany()
                        .HasForeignKey("HrLeaveAllocationId")
                        .HasConstraintName("hr_employee_hr_leave_allocation_rel_hr_leave_allocation_id_fkey"),
                    j =>
                    {
                        j.HasKey("HrLeaveAllocationId", "HrEmployeeId").HasName("hr_employee_hr_leave_allocation_rel_pkey");
                        j.ToTable("hr_employee_hr_leave_allocation_rel");
                        j.HasIndex(new[] { "HrEmployeeId", "HrLeaveAllocationId" }, "hr_employee_hr_leave_allocati_hr_employee_id_hr_leave_alloc_idx");
                        j.IndexerProperty<Guid>("HrLeaveAllocationId").HasColumnName("hr_leave_allocation_id");
                        j.IndexerProperty<Guid>("HrEmployeeId").HasColumnName("hr_employee_id");
                    });
            });
        }
    }
}
