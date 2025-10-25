using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.EmployeeId, "hr_attendance__employee_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CheckIn)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("check_in");
                        entity.Property(e => e.CheckOut)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("check_out");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                        entity.Property(e => e.ExpectedHours).HasColumnName("expected_hours");
                        entity.Property(e => e.InBrowser).HasColumnName("in_browser");
                        entity.Property(e => e.InCity).HasColumnName("in_city");
                        entity.Property(e => e.InCountryName).HasColumnName("in_country_name");
                        entity.Property(e => e.InIpAddress).HasColumnName("in_ip_address");
                        entity.Property(e => e.InLatitude).HasColumnName("in_latitude");
                        entity.Property(e => e.InLongitude).HasColumnName("in_longitude");
                        entity.Property(e => e.InMode).HasColumnName("in_mode");
                        entity.Property(e => e.OutBrowser).HasColumnName("out_browser");
                        entity.Property(e => e.OutCity).HasColumnName("out_city");
                        entity.Property(e => e.OutCountryName).HasColumnName("out_country_name");
                        entity.Property(e => e.OutIpAddress).HasColumnName("out_ip_address");
                        entity.Property(e => e.OutLatitude).HasColumnName("out_latitude");
                        entity.Property(e => e.OutLongitude).HasColumnName("out_longitude");
                        entity.Property(e => e.OutMode).HasColumnName("out_mode");
                        entity.Property(e => e.OvertimeHours).HasColumnName("overtime_hours");
                        entity.Property(e => e.OvertimeStatus).HasColumnName("overtime_status");
                        entity.Property(e => e.ValidatedOvertimeHours).HasColumnName("validated_overtime_hours");
                        entity.Property(e => e.WorkedHours).HasColumnName("worked_hours");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrAttendanceCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_attendance_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_attendance_create_uid_fkey");

                        entity.HasOne(d => d.Employee).WithMany(p => p.HrAttendance)
                            .HasForeignKey(d => d.EmployeeId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("hr_attendance_employee_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrAttendanceWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_attendance_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_attendance_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}