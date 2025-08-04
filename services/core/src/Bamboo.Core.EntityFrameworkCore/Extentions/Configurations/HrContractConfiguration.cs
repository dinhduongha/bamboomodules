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
        public static void ConfigureHrContract(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HrContract>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("hr_contract_pkey");

                entity.ToTable("hr_contract");

                entity.HasIndex(e => e.DateStart, "hr_contract_date_start_index");

                entity.HasIndex(e => e.ResourceCalendarId, "hr_contract_resource_calendar_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.ContractTypeId).HasColumnName("contract_type_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DateEnd).HasColumnName("date_end");
                entity.Property(e => e.DateStart).HasColumnName("date_start");
                entity.Property(e => e.DepartmentId).HasColumnName("department_id");
                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                entity.Property(e => e.HrResponsibleId).HasColumnName("hr_responsible_id");
                entity.Property(e => e.JobId).HasColumnName("job_id");
                entity.Property(e => e.KanbanState).HasColumnName("kanban_state");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Notes).HasColumnName("notes");
                entity.Property(e => e.ResourceCalendarId).HasColumnName("resource_calendar_id");
                entity.Property(e => e.State).HasColumnName("state");
                entity.Property(e => e.StructureTypeId).HasColumnName("structure_type_id");
                entity.Property(e => e.TrialDateEnd).HasColumnName("trial_date_end");
                entity.Property(e => e.Wage).HasColumnName("wage");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("hr_contract_company_id_fkey");

                entity.HasOne(d => d.ContractType).WithMany(p => p.HrContracts)
                    .HasForeignKey(d => d.ContractTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_contract_contract_type_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_contract_create_uid_fkey");

                entity.HasOne(d => d.Department).WithMany(p => p.HrContracts)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_contract_department_id_fkey");

                entity.HasOne(d => d.Employee).WithMany(p => p.HrContracts)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_contract_employee_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.HrResponsibleId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_contract_hr_responsible_id_fkey");

                entity.HasOne(d => d.Job).WithMany(p => p.HrContracts)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_contract_job_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.HrContracts)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_contract_message_main_attachment_id_fkey");

                entity.HasOne(d => d.ResourceCalendar).WithMany(p => p.HrContracts)
                    .HasForeignKey(d => d.ResourceCalendarId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_contract_resource_calendar_id_fkey");

                entity.HasOne(d => d.StructureType).WithMany(p => p.HrContracts)
                    .HasForeignKey(d => d.StructureTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_contract_structure_type_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_contract_write_uid_fkey");
            });
        }
    }
}