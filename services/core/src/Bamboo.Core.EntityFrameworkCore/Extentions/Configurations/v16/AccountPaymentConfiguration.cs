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
        public static void ConfigureAccountPayment(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountPayment>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_payment_pkey");

            entity.ToTable("account_payment");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.MessageMainAttachmentId, "account_payment__message_main_attachment_id_index").HasFilter("(message_main_attachment_id IS NOT NULL)");

            entity.HasIndex(e => e.MoveId, "account_payment_move_id_index");

            entity.HasIndex(e => e.OutstandingAccountId, "account_payment__outstanding_account_id_index").HasFilter("(outstanding_account_id IS NOT NULL)");

            entity.HasIndex(e => e.PairedInternalTransferPaymentId, "account_payment_paired_internal_transfer_payment_id_index").HasFilter("(paired_internal_transfer_payment_id IS NOT NULL)");

            entity.HasIndex(e => e.SourcePaymentId, "account_payment_source_payment_id_index").HasFilter("(source_payment_id IS NOT NULL)");

            entity.HasIndex(e => new { e.JournalId, e.TenantId }, "account_payment_journal_id_company_id_idx");

            entity.HasIndex(e => new { e.JournalId, e.TenantId }, "account_payment_unmatched_idx").HasFilter("((NOT is_matched) OR (is_matched IS NULL))");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.AmountCompanyCurrencySigned).HasColumnName("amount_company_currency_signed");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DestinationAccountId).HasColumnName("destination_account_id");
            entity.Property(e => e.DestinationJournalId).HasColumnName("destination_journal_id");
            entity.Property(e => e.ForceOutstandingAccountId).HasColumnName("force_outstanding_account_id");
            entity.Property(e => e.IsInternalTransfer).HasColumnName("is_internal_transfer");
            entity.Property(e => e.IsMatched).HasColumnName("is_matched");
            entity.Property(e => e.IsReconciled).HasColumnName("is_reconciled");
            entity.Property(e => e.IsSent).HasColumnName("is_sent");
            entity.Property(e => e.JournalId).HasColumnName("journal_id");
            entity.Property(e => e.Memo).HasColumnName("memo");
            entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
            entity.Property(e => e.MoveId).HasColumnName("move_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.OutstandingAccountId).HasColumnName("outstanding_account_id");
            entity.Property(e => e.PairedInternalTransferPaymentId).HasColumnName("paired_internal_transfer_payment_id");
            entity.Property(e => e.PartnerBankId).HasColumnName("partner_bank_id");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.PartnerType).HasColumnName("partner_type");
            entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
            entity.Property(e => e.PaymentMethodLineId).HasColumnName("payment_method_line_id");
            entity.Property(e => e.PaymentReference).HasColumnName("payment_reference");
            entity.Property(e => e.PaymentTokenId).HasColumnName("payment_token_id");
            entity.Property(e => e.PaymentTransactionId).HasColumnName("payment_transaction_id");
            entity.Property(e => e.PaymentType).HasColumnName("payment_type");
            entity.Property(e => e.PosOrderId).HasColumnName("pos_order_id");
            entity.Property(e => e.PosPaymentMethodId).HasColumnName("pos_payment_method_id");
            entity.Property(e => e.PosSessionId).HasColumnName("pos_session_id");
            entity.Property(e => e.SourcePaymentId).HasColumnName("source_payment_id");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.Company).WithMany(p => p.AccountPayment)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("account_payment_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountPaymentCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_payment_create_uid_fkey");

            // entity.HasOne(d => d.Currency).WithMany(p => p.AccountPayment)
            entity.HasOne(d => d.Currency).WithMany()
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_payment_currency_id_fkey");

            entity.HasOne(d => d.DestinationAccount).WithMany()
                .HasForeignKey(d => d.DestinationAccountId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_payment_destination_account_id_fkey");

            entity.HasOne(d => d.DestinationJournal).WithMany(p => p.AccountPayment)
                .HasForeignKey(d => d.DestinationJournalId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_payment_destination_journal_id_fkey");

            entity.HasOne(d => d.ForceOutstandingAccount).WithMany()
                .HasForeignKey(d => d.ForceOutstandingAccountId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_payment_force_outstanding_account_id_fkey");

            // entity.HasOne(d => d.Journal).WithMany(p => p.AccountPayment)
            entity.HasOne(d => d.Journal).WithMany()
                .HasForeignKey(d => d.JournalId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("account_payment_journal_id_fkey");

            // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.AccountPayment)
            entity.HasOne(d => d.MessageMainAttachment).WithMany()
                .HasForeignKey(d => d.MessageMainAttachmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_payment_message_main_attachment_id_fkey");

            entity.HasOne(d => d.Move).WithMany(p => p.AccountPayment)
                .HasForeignKey(d => d.MoveId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_payment_move_id_fkey");

            entity.HasOne(d => d.OutstandingAccount).WithMany()
                .HasForeignKey(d => d.OutstandingAccountId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_payment_outstanding_account_id_fkey");

            entity.HasOne(d => d.PairedInternalTransferPayment).WithMany(p => p.InversePairedInternalTransferPayment)
                .HasForeignKey(d => d.PairedInternalTransferPaymentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_payment_paired_internal_transfer_payment_id_fkey");

            entity.HasOne(d => d.PartnerBank).WithMany(p => p.AccountPayment)
                .HasForeignKey(d => d.PartnerBankId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("account_payment_partner_bank_id_fkey");

            // entity.HasOne(d => d.Partner).WithMany(p => p.AccountPayment)
            entity.HasOne(d => d.Partner).WithMany()
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("account_payment_partner_id_fkey");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.AccountPayment)
                .HasForeignKey(d => d.PaymentMethodId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_payment_payment_method_id_fkey");

            entity.HasOne(d => d.PaymentMethodLine).WithMany(p => p.AccountPayment)
                .HasForeignKey(d => d.PaymentMethodLineId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_payment_payment_method_line_id_fkey");

            entity.HasOne(d => d.PaymentToken).WithMany(p => p.AccountPayment)
                .HasForeignKey(d => d.PaymentTokenId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_payment_payment_token_id_fkey");

            entity.HasOne(d => d.PaymentTransaction).WithMany(p => p.AccountPayment)
                .HasForeignKey(d => d.PaymentTransactionId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_payment_payment_transaction_id_fkey");

            entity.HasOne(d => d.PosOrder).WithMany(p => p.AccountPayment)
                .HasForeignKey(d => d.PosOrderId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_payment_pos_order_id_fkey");

            entity.HasOne(d => d.PosPaymentMethod).WithMany(p => p.AccountPayment)
                .HasForeignKey(d => d.PosPaymentMethodId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_payment_pos_payment_method_id_fkey");

            entity.HasOne(d => d.PosSession).WithMany(p => p.AccountPayment)
                .HasForeignKey(d => d.PosSessionId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_payment_pos_session_id_fkey");

            entity.HasOne(d => d.SourcePayment).WithMany(p => p.InverseSourcePayment)
                .HasForeignKey(d => d.SourcePaymentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_payment_source_payment_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountPaymentWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_payment_write_uid_fkey");
            });
        }
    }
}
