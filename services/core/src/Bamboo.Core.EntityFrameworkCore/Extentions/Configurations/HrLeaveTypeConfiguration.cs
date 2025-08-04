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
        public static void ConfigureHrLeaveType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HrLeaveType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("hr_leave_type_pkey");

                entity.ToTable("hr_leave_type");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.AllocationNotifSubtypeId).HasColumnName("allocation_notif_subtype_id");
                entity.Property(e => e.AllocationValidationType).HasColumnName("allocation_validation_type");
                entity.Property(e => e.Color).HasColumnName("color");
                entity.Property(e => e.ColorName).HasColumnName("color_name");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreateCalendarMeeting).HasColumnName("create_calendar_meeting");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.EmployeeRequests).HasColumnName("employee_requests");
                entity.Property(e => e.IconId).HasColumnName("icon_id");
                entity.Property(e => e.LeaveNotifSubtypeId).HasColumnName("leave_notif_subtype_id");
                entity.Property(e => e.LeaveValidationType).HasColumnName("leave_validation_type");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.OvertimeDeductible).HasColumnName("overtime_deductible");
                entity.Property(e => e.RequestUnit).HasColumnName("request_unit");
                entity.Property(e => e.RequiresAllocation).HasColumnName("requires_allocation");
                entity.Property(e => e.ResponsibleId).HasColumnName("responsible_id");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.SupportDocument).HasColumnName("support_document");
                entity.Property(e => e.TimeType).HasColumnName("time_type");
                entity.Property(e => e.Unpaid).HasColumnName("unpaid");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.AllocationNotifSubtype).WithMany(p => p.HrLeaveTypeAllocationNotifSubtypes)
                    .HasForeignKey(d => d.AllocationNotifSubtypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_type_allocation_notif_subtype_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_type_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_type_create_uid_fkey");

                entity.HasOne(d => d.Icon).WithMany(p => p.HrLeaveTypes)
                    .HasForeignKey(d => d.IconId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_type_icon_id_fkey");

                entity.HasOne(d => d.LeaveNotifSubtype).WithMany(p => p.HrLeaveTypeLeaveNotifSubtypes)
                    .HasForeignKey(d => d.LeaveNotifSubtypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_type_leave_notif_subtype_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.ResponsibleId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_type_responsible_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_type_write_uid_fkey");

                entity.HasMany(d => d.ResUsers).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "HrLeaveTypeResUsersRel",
                        r => r.HasOne<ResUser>().WithMany()
                            .HasForeignKey("ResUsersId")
                            .HasConstraintName("hr_leave_type_res_users_rel_res_users_id_fkey"),
                        l => l.HasOne<HrLeaveType>().WithMany()
                            .HasForeignKey("HrLeaveTypeId")
                            .HasConstraintName("hr_leave_type_res_users_rel_hr_leave_type_id_fkey"),
                        j =>
                        {
                            j.HasKey("HrLeaveTypeId", "ResUsersId").HasName("hr_leave_type_res_users_rel_pkey");
                            j.ToTable("hr_leave_type_res_users_rel");
                            j.HasIndex(new[] { "ResUsersId", "HrLeaveTypeId" }, "hr_leave_type_res_users_rel_res_users_id_hr_leave_type_id_idx");
                            j.IndexerProperty<Guid>("HrLeaveTypeId").HasColumnName("hr_leave_type_id");
                            j.IndexerProperty<Guid>("ResUsersId").HasColumnName("res_users_id");
                        });
            });
        }
    }
}