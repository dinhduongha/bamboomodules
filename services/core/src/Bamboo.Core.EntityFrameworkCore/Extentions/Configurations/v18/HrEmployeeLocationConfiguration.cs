using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureHrEmployeeLocation(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrEmployeeLocation>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_employee_location_pkey");

                        entity.ToTable("hr_employee_location");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => new { e.EmployeeId, e.Date }, "hr_employee_location_uniq_exceptional_per_day").IsUnique();

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
                        entity.Property(e => e.Date).HasColumnName("date");
                        entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                        entity.Property(e => e.WorkLocationId).HasColumnName("work_location_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrEmployeeLocationCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_employee_location_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_employee_location_create_uid_fkey");

                        entity.HasOne(d => d.Employee).WithMany(p => p.HrEmployeeLocation)
                            .HasForeignKey(d => d.EmployeeId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("hr_employee_location_employee_id_fkey");

                        entity.HasOne(d => d.WorkLocation).WithMany(p => p.HrEmployeeLocation)
                            .HasForeignKey(d => d.WorkLocationId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("hr_employee_location_work_location_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrEmployeeLocationWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_employee_location_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_employee_location_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}