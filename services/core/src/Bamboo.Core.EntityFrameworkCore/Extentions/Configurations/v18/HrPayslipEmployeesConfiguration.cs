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
        public static void ConfigureHrPayslipEmployees(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrPayslipEmployees>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_payslip_employees_pkey");

            entity.ToTable("hr_payslip_employees");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

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
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.HrPayslipEmployeesCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_payslip_employees_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.HrPayslipEmployeesWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_payslip_employees_write_uid_fkey");

            // entity.HasMany(d => d.Employee).WithMany(p => p.Payslip)
            entity.HasMany(d => d.Employee).WithMany(p => p.Payslip)
                .UsingEntity<Dictionary<string, object>>(
                    "HrEmployeeGroupRel",
                    r => r.HasOne<HrEmployee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("hr_employee_group_rel_employee_id_fkey"),
                    l => l.HasOne<HrPayslipEmployees>().WithMany()
                        .HasForeignKey("PayslipId")
                        .HasConstraintName("hr_employee_group_rel_payslip_id_fkey"),
                    j =>
                    {
                        j.HasKey("PayslipId", "EmployeeId").HasName("hr_employee_group_rel_pkey");
                        j.ToTable("hr_employee_group_rel");
                        j.HasIndex(new[] { "EmployeeId", "PayslipId" }, "hr_employee_group_rel_employee_id_payslip_id_idx");
                        j.IndexerProperty<Guid>("PayslipId").HasColumnName("payslip_id");
                        j.IndexerProperty<Guid>("EmployeeId").HasColumnName("employee_id");
                    });
            });
        }
    }
}