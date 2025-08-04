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
        public static void ConfigureHrAttendance(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HrAttendance>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("hr_attendance_pkey");

                entity.ToTable("hr_attendance");

                entity.HasIndex(e => e.TenantId, "hr_attendance_company_id_index");

                entity.HasIndex(e => e.EmployeeId, "hr_attendance_employee_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CheckIn)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("check_in");
                entity.Property(e => e.CheckOut)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("check_out");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                entity.Property(e => e.WorkedHours).HasColumnName("worked_hours");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_attendance_create_uid_fkey");

                entity.HasOne(d => d.Employee).WithMany(p => p.HrAttendances)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("hr_attendance_employee_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_attendance_write_uid_fkey");
            });
        }
    }
}