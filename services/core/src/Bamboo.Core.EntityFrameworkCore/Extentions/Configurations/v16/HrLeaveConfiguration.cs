using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.DateFrom, "hr_leave__date_from_index");

                        entity.HasIndex(e => e.EmployeeId, "hr_leave__employee_id_index");

                        entity.HasIndex(e => e.MessageMainAttachmentId, "hr_leave__message_main_attachment_id_index").HasFilter("(message_main_attachment_id IS NOT NULL)");

                        entity.HasIndex(e => e.UserId, "hr_leave__user_id_index");

                        entity.HasIndex(e => new { e.DateTo, e.DateFrom }, "hr_leave_date_to_date_from_index");

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
                        entity.Property(e => e.HolidayStatusId).HasColumnName("holiday_status_id");
                        entity.Property(e => e.ManagerId).HasColumnName("manager_id");
                        entity.Property(e => e.MeetingId).HasColumnName("meeting_id");
                        entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                        entity.Property(e => e.Notes).HasColumnName("notes");
                        entity.Property(e => e.NumberOfDays).HasColumnName("number_of_days");
                        entity.Property(e => e.NumberOfHours).HasColumnName("number_of_hours");
                        entity.Property(e => e.OvertimeId).HasColumnName("overtime_id");
                        entity.Property(e => e.PrivateName).HasColumnName("private_name");
                        entity.Property(e => e.RequestDateFrom).HasColumnName("request_date_from");
                        entity.Property(e => e.RequestDateFromPeriod).HasColumnName("request_date_from_period");
                        entity.Property(e => e.RequestDateTo).HasColumnName("request_date_to");
                        entity.Property(e => e.RequestHourFrom).HasColumnName("request_hour_from");
                        entity.Property(e => e.RequestHourTo).HasColumnName("request_hour_to");
                        entity.Property(e => e.RequestUnitHalf).HasColumnName("request_unit_half");
                        entity.Property(e => e.RequestUnitHours).HasColumnName("request_unit_hours");
                        entity.Property(e => e.ResourceCalendarId).HasColumnName("resource_calendar_id");
                        entity.Property(e => e.SecondApproverId).HasColumnName("second_approver_id");
                        entity.Property(e => e.State).HasColumnName("state");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.HrLeaveCompany) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_leave_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_leave_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrLeaveCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_leave_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_leave_create_uid_fkey");

                        entity.HasOne(d => d.Department).WithMany(p => p.HrLeave)
                            .HasForeignKey(d => d.DepartmentId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_leave_department_id_fkey");

                        // entity.HasOne(d => d.EmployeeCompany).WithMany(p => p.HrLeaveEmployeeCompany) .HasForeignKey(d => d.EmployeeCompanyId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_leave_employee_company_id_fkey");
                        entity.HasOne(d => d.EmployeeCompany).WithMany()
                            .HasForeignKey(d => d.EmployeeCompanyId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_leave_employee_company_id_fkey");

                        entity.HasOne(d => d.Employee).WithMany(p => p.HrLeaveEmployee)
                            .HasForeignKey(d => d.EmployeeId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("hr_leave_employee_id_fkey");

                        entity.HasOne(d => d.FirstApprover).WithMany(p => p.HrLeaveFirstApprover)
                            .HasForeignKey(d => d.FirstApproverId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_leave_first_approver_id_fkey");

                        entity.HasOne(d => d.HolidayStatus).WithMany(p => p.HrLeave)
                            .HasForeignKey(d => d.HolidayStatusId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("hr_leave_holiday_status_id_fkey");

                        entity.HasOne(d => d.Manager).WithMany(p => p.HrLeaveManager)
                            .HasForeignKey(d => d.ManagerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_leave_manager_id_fkey");

                        entity.HasOne(d => d.Meeting).WithMany(p => p.HrLeave)
                            .HasForeignKey(d => d.MeetingId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_leave_meeting_id_fkey");

                        // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.HrLeave) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_leave_message_main_attachment_id_fkey");
                        entity.HasOne(d => d.MessageMainAttachment).WithMany()
                            .HasForeignKey(d => d.MessageMainAttachmentId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_leave_message_main_attachment_id_fkey");

                        entity.HasOne(d => d.Overtime).WithMany(p => p.HrLeave)
                            .HasForeignKey(d => d.OvertimeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_leave_overtime_id_fkey");

                        entity.HasOne(d => d.ResourceCalendar).WithMany(p => p.HrLeave)
                            .HasForeignKey(d => d.ResourceCalendarId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_leave_resource_calendar_id_fkey");

                        entity.HasOne(d => d.SecondApprover).WithMany(p => p.HrLeaveSecondApprover)
                            .HasForeignKey(d => d.SecondApproverId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_leave_second_approver_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.HrLeaveUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_leave_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_leave_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrLeaveWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_leave_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_leave_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}