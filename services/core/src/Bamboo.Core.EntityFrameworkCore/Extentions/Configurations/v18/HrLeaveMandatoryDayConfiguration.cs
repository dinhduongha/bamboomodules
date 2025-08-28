using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureHrLeaveMandatoryDay(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrLeaveMandatoryDay>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_leave_mandatory_day_pkey");

                        entity.ToTable("hr_leave_mandatory_day");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Color).HasColumnName("color");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.EndDate).HasColumnName("end_date");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.ResourceCalendarId).HasColumnName("resource_calendar_id");
                        entity.Property(e => e.StartDate).HasColumnName("start_date");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.HrLeaveMandatoryDay) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("hr_leave_mandatory_day_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("hr_leave_mandatory_day_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrLeaveMandatoryDayCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_leave_mandatory_day_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_leave_mandatory_day_create_uid_fkey");

                        entity.HasOne(d => d.ResourceCalendar).WithMany(p => p.HrLeaveMandatoryDay)
                            .HasForeignKey(d => d.ResourceCalendarId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_leave_mandatory_day_resource_calendar_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrLeaveMandatoryDayWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_leave_mandatory_day_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_leave_mandatory_day_write_uid_fkey");

                        // entity.HasMany(d => d.HrDepartment).WithMany(p => p.HrLeaveMandatoryDay)
                        entity.HasMany(d => d.HrDepartment).WithMany(p => p.HrLeaveMandatoryDay)
                            .UsingEntity<Dictionary<string, object>>(
                                "HrDepartmentHrLeaveMandatoryDayRel",
                                r => r.HasOne<HrDepartment>().WithMany()
                                    .HasForeignKey("HrDepartmentId")
                                    .HasConstraintName("hr_department_hr_leave_mandatory_day_rel_hr_department_id_fkey"),
                                l => l.HasOne<HrLeaveMandatoryDay>().WithMany()
                                    .HasForeignKey("HrLeaveMandatoryDayId")
                                    .HasConstraintName("hr_department_hr_leave_mandatory_hr_leave_mandatory_day_id_fkey"),
                                j =>
                                {
                                    j.HasKey("HrLeaveMandatoryDayId", "HrDepartmentId").HasName("hr_department_hr_leave_mandatory_day_rel_pkey");
                                    j.ToTable("hr_department_hr_leave_mandatory_day_rel");
                                    j.HasIndex(new[] { "HrDepartmentId", "HrLeaveMandatoryDayId" }, "hr_department_hr_leave_mandat_hr_department_id_hr_leave_man_idx");
                                    j.IndexerProperty<Guid>("HrLeaveMandatoryDayId").HasColumnName("hr_leave_mandatory_day_id");
                                    j.IndexerProperty<Guid>("HrDepartmentId").HasColumnName("hr_department_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}