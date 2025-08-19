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
        public static void ConfigureHrExpenseSheet(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrExpenseSheet>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_expense_sheet_pkey");

            entity.ToTable("hr_expense_sheet");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.MessageMainAttachmentId, "hr_expense_sheet__message_main_attachment_id_index").HasFilter("(message_main_attachment_id IS NOT NULL)");

            entity.HasIndex(e => e.State, "hr_expense_sheet__state_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AccountMoveId).HasColumnName("account_move_id");
            entity.Property(e => e.AccountingDate).HasColumnName("accounting_date");
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.AmountResidual).HasColumnName("amount_residual");
            entity.Property(e => e.ApprovalDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("approval_date");
            entity.Property(e => e.ApprovalState).HasColumnName("approval_state");
            entity.Property(e => e.BankJournalId).HasColumnName("bank_journal_id");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EmployeeJournalId).HasColumnName("employee_journal_id");
            entity.Property(e => e.JournalId).HasColumnName("journal_id");
            entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PaymentMethodLineId).HasColumnName("payment_method_line_id");
            entity.Property(e => e.PaymentState).HasColumnName("payment_state");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.TotalAmount).HasColumnName("total_amount");
            entity.Property(e => e.TotalTaxAmount).HasColumnName("total_tax_amount");
            entity.Property(e => e.TotalAmountTaxes).HasColumnName("total_amount_taxes");
            entity.Property(e => e.UntaxedAmount).HasColumnName("untaxed_amount");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.AccountMove).WithMany()
                .HasForeignKey(d => d.AccountMoveId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("hr_expense_sheet_account_move_id_fkey");

            entity.HasOne(d => d.Address).WithMany()
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_expense_sheet_address_id_fkey");

            entity.HasOne(d => d.BankJournal).WithMany(p => p.HrExpenseSheetBankJournal)
                .HasForeignKey(d => d.BankJournalId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_expense_sheet_bank_journal_id_fkey");

            // entity.HasOne(d => d.Company).WithMany(p => p.HrExpenseSheet)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("hr_expense_sheet_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.HrExpenseSheetCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_expense_sheet_create_uid_fkey");

            // entity.HasOne(d => d.Currency).WithMany(p => p.HrExpenseSheet)
            entity.HasOne(d => d.Currency).WithMany()
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_expense_sheet_currency_id_fkey");

            entity.HasOne(d => d.Department).WithMany(p => p.HrExpenseSheet)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_expense_sheet_department_id_fkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.HrExpenseSheet)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("hr_expense_sheet_employee_id_fkey");

            entity.HasOne(d => d.EmployeeJournal).WithMany(p => p.HrExpenseSheetEmployeeJournal)
                .HasForeignKey(d => d.EmployeeJournalId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_expense_sheet_employee_journal_id_fkey");

            // entity.HasOne(d => d.Journal).WithMany(p => p.HrExpenseSheetJournal)
            entity.HasOne(d => d.Journal).WithMany()
                .HasForeignKey(d => d.JournalId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_expense_sheet_journal_id_fkey");

            // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.HrExpenseSheet)
            entity.HasOne(d => d.MessageMainAttachment).WithMany()
                .HasForeignKey(d => d.MessageMainAttachmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_expense_sheet_message_main_attachment_id_fkey");

            entity.HasOne(d => d.PaymentMethodLine).WithMany(p => p.HrExpenseSheet)
                .HasForeignKey(d => d.PaymentMethodLineId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_expense_sheet_payment_method_line_id_fkey");

            // entity.HasOne(d => d.User).WithMany(p => p.HrExpenseSheetUser)
            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_expense_sheet_user_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.HrExpenseSheetWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_expense_sheet_write_uid_fkey");
            });
        }
    }
}
