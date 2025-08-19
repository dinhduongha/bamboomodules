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
        public static void ConfigureHrWorkEntry(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrWorkEntry>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_work_entry_pkey");

            entity.ToTable("hr_work_entry");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.EmployeeId, "hr_work_entry__employee_id_index");

            entity.HasIndex(e => e.WorkEntryTypeId, "hr_work_entry__work_entry_type_id_index");

            entity.HasIndex(e => new { e.ContractId, e.DateStart, e.DateStop }, "hr_work_entry_contract_date_start_stop_idx").HasFilter("(state = ANY (ARRAY[('draft'::character varying)::text, ('validated'::character varying)::text]))");

            entity.HasIndex(e => new { e.DateStart, e.DateStop }, "hr_work_entry_date_start_date_stop_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Active).HasColumnName("active");

            entity.Property(e => e.Conflict).HasColumnName("conflict");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.DateStart)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_start");
            entity.Property(e => e.DateStop)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_stop");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.LeaveId).HasColumnName("leave_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.WorkEntryTypeId).HasColumnName("work_entry_type_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.Company).WithMany(p => p.HrWorkEntry)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("hr_work_entry_company_id_fkey");

            entity.HasOne(d => d.Contract).WithMany(p => p.HrWorkEntry)
                .HasForeignKey(d => d.ContractId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("hr_work_entry_contract_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.HrWorkEntryCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_work_entry_create_uid_fkey");

            entity.HasOne(d => d.Department).WithMany(p => p.HrWorkEntry)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_work_entry_department_id_fkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.HrWorkEntry)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("hr_work_entry_employee_id_fkey");

            entity.HasOne(d => d.Leave).WithMany(p => p.HrWorkEntry)
                .HasForeignKey(d => d.LeaveId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_work_entry_leave_id_fkey");

            entity.HasOne(d => d.WorkEntryType).WithMany(p => p.HrWorkEntry)
                .HasForeignKey(d => d.WorkEntryTypeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_work_entry_work_entry_type_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.HrWorkEntryWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_work_entry_write_uid_fkey");
            });
        }
    }
}
