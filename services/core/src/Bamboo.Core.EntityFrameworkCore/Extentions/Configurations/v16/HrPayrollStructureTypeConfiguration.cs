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
        public static void ConfigureHrPayrollStructureType(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrPayrollStructureType>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_payroll_structure_type_pkey");

            entity.ToTable("hr_payroll_structure_type");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.DefaultResourceCalendarId).HasColumnName("default_resource_calendar_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.Country).WithMany(p => p.HrPayrollStructureType)
            entity.HasOne(d => d.Country).WithMany()
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_payroll_structure_type_country_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.HrPayrollStructureTypeCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_payroll_structure_type_create_uid_fkey");

            entity.HasOne(d => d.DefaultResourceCalendar).WithMany(p => p.HrPayrollStructureType)
                .HasForeignKey(d => d.DefaultResourceCalendarId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_payroll_structure_type_default_resource_calendar_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.HrPayrollStructureTypeWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_payroll_structure_type_write_uid_fkey");
            });
        }
    }
}