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
        public static void ConfigureHrLeave(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HrLeave>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("hr_leave_pkey");

                entity.ToTable("hr_leave");

                entity.HasIndex(e => e.TenantId, "hr_leave_company_id_index");

                entity.HasIndex(e => e.DateFrom, "hr_leave_date_from_index");

                entity.HasIndex(e => new { e.DateTo, e.DateFrom }, "hr_leave_date_to_date_from_index");

                entity.HasIndex(e => e.EmployeeId, "hr_leave_employee_id_index");

                entity.HasIndex(e => e.UserId, "hr_leave_user_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.CategoryId).HasColumnName("category_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DateFrom)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_from");
                entity.Property(e => e.DateTo)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_to");
                entity.Property(e => e.DepartmentId).HasColumnName("department_id");
                entity.Property(e => e.DurationDisplay).HasColumnName("duration_display");
                entity.Property(e => e.EmployeeCompanyId).HasColumnName("employee_company_id");
                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                entity.Property(e => e.FirstApproverId).HasColumnName("first_approver_id");
                entity.Property(e => e.HolidayAllocationId).HasColumnName("holiday_allocation_id");
                entity.Property(e => e.HolidayStatusId).HasColumnName("holiday_status_id");
                entity.Property(e => e.HolidayType).HasColumnName("holiday_type");
                entity.Property(e => e.ManagerId).HasColumnName("manager_id");
                entity.Property(e => e.MeetingId).HasColumnName("meeting_id");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.ModeCompanyId).HasColumnName("mode_company_id");
                entity.Property(e => e.MultiEmployee).HasColumnName("multi_employee");
                entity.Property(e => e.Notes).HasColumnName("notes");
                entity.Property(e => e.NumberOfDays).HasColumnName("number_of_days");
                entity.Property(e => e.OvertimeId).HasColumnName("overtime_id");
                entity.Property(e => e.ParentId).HasColumnName("parent_id");
                entity.Property(e => e.PrivateName).HasColumnName("private_name");
                entity.Property(e => e.ReportNote).HasColumnName("report_note");
                entity.Property(e => e.RequestDateFrom).HasColumnName("request_date_from");
                entity.Property(e => e.RequestDateFromPeriod).HasColumnName("request_date_from_period");
                entity.Property(e => e.RequestDateTo).HasColumnName("request_date_to");
                entity.Property(e => e.RequestHourFrom).HasColumnName("request_hour_from");
                entity.Property(e => e.RequestHourTo).HasColumnName("request_hour_to");
                entity.Property(e => e.RequestUnitHalf).HasColumnName("request_unit_half");
                entity.Property(e => e.RequestUnitHours).HasColumnName("request_unit_hours");
                entity.Property(e => e.SecondApproverId).HasColumnName("second_approver_id");
                entity.Property(e => e.State).HasColumnName("state");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Category).WithMany(p => p.HrLeaves)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_category_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_create_uid_fkey");

                entity.HasOne(d => d.Department).WithMany(p => p.HrLeaves)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_department_id_fkey");

                entity.HasOne(d => d.EmployeeCompany).WithMany()
                    .HasForeignKey(d => d.EmployeeCompanyId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_employee_company_id_fkey");

                entity.HasOne(d => d.Employee).WithMany(p => p.HrLeaveEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("hr_leave_employee_id_fkey");

                entity.HasOne(d => d.FirstApprover).WithMany(p => p.HrLeaveFirstApprovers)
                    .HasForeignKey(d => d.FirstApproverId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_first_approver_id_fkey");

                entity.HasOne(d => d.HolidayAllocation).WithMany(p => p.HrLeaves)
                    .HasForeignKey(d => d.HolidayAllocationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_holiday_allocation_id_fkey");

                entity.HasOne(d => d.HolidayStatus).WithMany(p => p.HrLeaves)
                    .HasForeignKey(d => d.HolidayStatusId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("hr_leave_holiday_status_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_manager_id_fkey");

                entity.HasOne(d => d.Meeting).WithMany(p => p.HrLeaves)
                    .HasForeignKey(d => d.MeetingId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_meeting_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.HrLeaves)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_message_main_attachment_id_fkey");

                entity.HasOne(d => d.ModeCompany).WithMany()
                    .HasForeignKey(d => d.ModeCompanyId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_mode_company_id_fkey");

                entity.HasOne(d => d.Overtime).WithMany(p => p.HrLeaves)
                    .HasForeignKey(d => d.OvertimeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_overtime_id_fkey");

                entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_parent_id_fkey");

                entity.HasOne(d => d.SecondApprover).WithMany(p => p.HrLeaveSecondApprovers)
                    .HasForeignKey(d => d.SecondApproverId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_second_approver_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_write_uid_fkey");

                //entity.HasMany(d => d.HrEmployees).WithMany(p => p.HrLeaves)
                entity.HasMany<HrEmployee>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "HrEmployeeHrLeaveRel",
                        r => r.HasOne<HrEmployee>().WithMany()
                            .HasForeignKey("HrEmployeeId")
                            .HasConstraintName("hr_employee_hr_leave_rel_hr_employee_id_fkey"),
                        l => l.HasOne<HrLeave>().WithMany()
                            .HasForeignKey("HrLeaveId")
                            .HasConstraintName("hr_employee_hr_leave_rel_hr_leave_id_fkey"),
                        j =>
                        {
                            j.HasKey("HrLeaveId", "HrEmployeeId").HasName("hr_employee_hr_leave_rel_pkey");
                            j.ToTable("hr_employee_hr_leave_rel");
                            j.HasIndex(new[] { "HrEmployeeId", "HrLeaveId" }, "hr_employee_hr_leave_rel_hr_employee_id_hr_leave_id_idx");
                        });
            });
        }
    }
}