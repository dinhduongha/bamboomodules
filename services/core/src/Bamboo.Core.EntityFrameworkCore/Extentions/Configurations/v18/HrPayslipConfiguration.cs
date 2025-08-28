using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureHrPayslip(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrPayslip>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_payslip_pkey");

                        entity.ToTable("hr_payslip");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.State, "hr_payslip__state_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

                        entity.Property(e => e.ContractId).HasColumnName("contract_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CreditNote).HasColumnName("credit_note");
                        entity.Property(e => e.Date).HasColumnName("date");
                        entity.Property(e => e.DateFrom).HasColumnName("date_from");
                        entity.Property(e => e.DateTo).HasColumnName("date_to");
                        entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                        entity.Property(e => e.JournalId).HasColumnName("journal_id");
                        entity.Property(e => e.MoveId).HasColumnName("move_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.Note).HasColumnName("note");
                        entity.Property(e => e.Number).HasColumnName("number");
                        entity.Property(e => e.Paid).HasColumnName("paid");
                        entity.Property(e => e.PayslipRunId).HasColumnName("payslip_run_id");
                        entity.Property(e => e.State).HasColumnName("state");
                        entity.Property(e => e.StructId).HasColumnName("struct_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.HrPayslip) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_payslip_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_payslip_company_id_fkey");

                        entity.HasOne(d => d.Contract).WithMany(p => p.HrPayslip)
                            .HasForeignKey(d => d.ContractId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_payslip_contract_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrPayslipCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_payslip_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_payslip_create_uid_fkey");

                        entity.HasOne(d => d.Employee).WithMany(p => p.HrPayslip)
                            .HasForeignKey(d => d.EmployeeId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("hr_payslip_employee_id_fkey");

                        // entity.HasOne(d => d.Journal).WithMany(p => p.HrPayslip) .HasForeignKey(d => d.JournalId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("hr_payslip_journal_id_fkey");
                        entity.HasOne(d => d.Journal).WithMany()
                            .HasForeignKey(d => d.JournalId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("hr_payslip_journal_id_fkey");

                        entity.HasOne(d => d.Move).WithMany(p => p.HrPayslip)
                            .HasForeignKey(d => d.MoveId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_payslip_move_id_fkey");

                        entity.HasOne(d => d.PayslipRun).WithMany(p => p.HrPayslip)
                            .HasForeignKey(d => d.PayslipRunId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_payslip_payslip_run_id_fkey");

                        entity.HasOne(d => d.Struct).WithMany(p => p.HrPayslip)
                            .HasForeignKey(d => d.StructId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_payslip_struct_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrPayslipWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_payslip_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_payslip_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}