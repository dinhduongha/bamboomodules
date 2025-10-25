using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureHrAttendanceOvertime(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrAttendanceOvertime>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_attendance_overtime_pkey");

                        entity.ToTable("hr_attendance_overtime");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.EmployeeId, "hr_attendance_overtime__employee_id_index");

                        entity.HasIndex(e => new { e.EmployeeId, e.Date }, "hr_attendance_overtime_unique_employee_per_day")
                            .IsUnique()
                            .HasFilter("(adjustment IS FALSE)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Adjustment).HasColumnName("adjustment");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Date).HasColumnName("date");
                        entity.Property(e => e.Duration).HasColumnName("duration");
                        entity.Property(e => e.DurationReal).HasColumnName("duration_real");
                        entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrAttendanceOvertimeCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_attendance_overtime_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_attendance_overtime_create_uid_fkey");

                        entity.HasOne(d => d.Employee).WithMany(p => p.HrAttendanceOvertime)
                            .HasForeignKey(d => d.EmployeeId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("hr_attendance_overtime_employee_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrAttendanceOvertimeWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_attendance_overtime_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_attendance_overtime_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}