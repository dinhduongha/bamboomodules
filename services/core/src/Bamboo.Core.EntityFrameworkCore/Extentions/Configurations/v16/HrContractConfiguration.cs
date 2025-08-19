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
        public static void ConfigureHrContract(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrContract>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_contract_pkey");

            entity.ToTable("hr_contract");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.DateStart, "hr_contract__date_start_index");

            entity.HasIndex(e => e.EmployeeId, "hr_contract__employee_id_index");

            entity.HasIndex(e => e.ResourceCalendarId, "hr_contract__resource_calendar_id_index");

            entity.HasIndex(e => e.SchedulePay, "hr_contract__schedule_pay_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.AnalyticAccountId).HasColumnName("analytic_account_id");

            entity.Property(e => e.ContractTypeId).HasColumnName("contract_type_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Da).HasColumnName("da");
            entity.Property(e => e.DateEnd).HasColumnName("date_end");
            entity.Property(e => e.DateGeneratedFrom)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_generated_from");
            entity.Property(e => e.DateGeneratedTo)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_generated_to");
            entity.Property(e => e.DateStart).HasColumnName("date_start");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.HrResponsibleId).HasColumnName("hr_responsible_id");
            entity.Property(e => e.Hra).HasColumnName("hra");
            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.JournalId).HasColumnName("journal_id");
            entity.Property(e => e.KanbanState).HasColumnName("kanban_state");
            entity.Property(e => e.LastGenerationDate).HasColumnName("last_generation_date");
            entity.Property(e => e.MealAllowance).HasColumnName("meal_allowance");
            entity.Property(e => e.MedicalAllowance).HasColumnName("medical_allowance");
            entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.OtherAllowance).HasColumnName("other_allowance");
            entity.Property(e => e.ResourceCalendarId).HasColumnName("resource_calendar_id");
            entity.Property(e => e.SchedulePay).HasColumnName("schedule_pay");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.StructId).HasColumnName("struct_id");
            entity.Property(e => e.StructureTypeId).HasColumnName("structure_type_id");
            entity.Property(e => e.TravelAllowance).HasColumnName("travel_allowance");
            entity.Property(e => e.TrialDateEnd).HasColumnName("trial_date_end");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.Wage).HasColumnName("wage");
            entity.Property(e => e.WorkEntrySource).HasColumnName("work_entry_source");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.AnalyticAccount).WithMany(p => p.HrContract)
                .HasForeignKey(d => d.AnalyticAccountId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_contract_analytic_account_id_fkey");

            // entity.HasOne(d => d.Company).WithMany(p => p.HrContract)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("hr_contract_company_id_fkey");

            entity.HasOne(d => d.ContractType).WithMany(p => p.HrContractContractType)
                .HasForeignKey(d => d.ContractTypeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_contract_contract_type_id_fkey");

            // v16-Compat     
            entity.HasOne(d => d.ContractType).WithMany(p => p.HrContract)
                .HasForeignKey(d => d.ContractTypeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_contract_contract_type2_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.HrContractCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_contract_create_uid_fkey");

            entity.HasOne(d => d.Department).WithMany(p => p.HrContract)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_contract_department_id_fkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.HrContract)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_contract_employee_id_fkey");

            entity.HasOne(d => d.HrResponsible).WithMany()
                .HasForeignKey(d => d.HrResponsibleId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_contract_hr_responsible_id_fkey");

            entity.HasOne(d => d.Job).WithMany(p => p.HrContract)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_contract_job_id_fkey");

            // entity.HasOne(d => d.Journal).WithMany(p => p.HrContract)
            entity.HasOne(d => d.Journal).WithMany()
                .HasForeignKey(d => d.JournalId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_contract_journal_id_fkey");

            // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.HrContract)
            entity.HasOne(d => d.MessageMainAttachment).WithMany()
                .HasForeignKey(d => d.MessageMainAttachmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_contract_message_main_attachment_id_fkey");

            entity.HasOne(d => d.ResourceCalendar).WithMany(p => p.HrContract)
                .HasForeignKey(d => d.ResourceCalendarId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("hr_contract_resource_calendar_id_fkey");

            entity.HasOne(d => d.Struct).WithMany(p => p.HrContract)
                .HasForeignKey(d => d.StructId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_contract_struct_id_fkey");

            entity.HasOne(d => d.StructureType).WithMany(p => p.HrContract)
                .HasForeignKey(d => d.StructureTypeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_contract_structure_type_id_fkey");

            entity.HasOne(d => d.Type).WithMany(p => p.HrContractTypeNavigation)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("hr_contract_type_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.HrContractWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_contract_write_uid_fkey");
            });
        }
    }
}
