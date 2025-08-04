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
        public static void ConfigureHrExpenseSheet(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HrExpenseSheet>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("hr_expense_sheet_pkey");

                entity.ToTable("hr_expense_sheet");

                entity.HasIndex(e => e.State, "hr_expense_sheet_state_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AccountMoveId).HasColumnName("account_move_id");
                entity.Property(e => e.AccountingDate).HasColumnName("accounting_date");
                entity.Property(e => e.AddressId).HasColumnName("address_id");
                entity.Property(e => e.AmountResidual).HasColumnName("amount_residual");
                entity.Property(e => e.ApprovalDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("approval_date");
                entity.Property(e => e.BankJournalId).HasColumnName("bank_journal_id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                entity.Property(e => e.DepartmentId).HasColumnName("department_id");
                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                entity.Property(e => e.JournalId).HasColumnName("journal_id");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.PaymentState).HasColumnName("payment_state");
                entity.Property(e => e.State).HasColumnName("state");
                entity.Property(e => e.TotalAmount).HasColumnName("total_amount");
                entity.Property(e => e.TotalAmountTaxes).HasColumnName("total_amount_taxes");
                entity.Property(e => e.UntaxedAmount).HasColumnName("untaxed_amount");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.AccountMove).WithMany(p => p.HrExpenseSheets)
                    .HasForeignKey(d => d.AccountMoveId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("hr_expense_sheet_account_move_id_fkey");

                entity.HasOne(d => d.Address).WithMany(p => p.HrExpenseSheets)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_expense_sheet_address_id_fkey");

                entity.HasOne(d => d.BankJournal).WithMany(p => p.HrExpenseSheetBankJournals)
                    .HasForeignKey(d => d.BankJournalId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_expense_sheet_bank_journal_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("hr_expense_sheet_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_expense_sheet_create_uid_fkey");

                entity.HasOne<ResCurrency>().WithMany()
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_expense_sheet_currency_id_fkey");

                entity.HasOne(d => d.Department).WithMany(p => p.HrExpenseSheets)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_expense_sheet_department_id_fkey");

                entity.HasOne(d => d.Employee).WithMany(p => p.HrExpenseSheets)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("hr_expense_sheet_employee_id_fkey");

                entity.HasOne(d => d.Journal).WithMany(p => p.HrExpenseSheetJournals)
                    .HasForeignKey(d => d.JournalId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_expense_sheet_journal_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.HrExpenseSheets)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_expense_sheet_message_main_attachment_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_expense_sheet_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_expense_sheet_write_uid_fkey");
            });
        }
    }
}