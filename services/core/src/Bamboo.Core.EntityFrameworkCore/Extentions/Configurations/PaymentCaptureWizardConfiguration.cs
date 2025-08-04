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
        public static void ConfigurePaymentCaptureWizard(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentCaptureWizard>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("payment_capture_wizard_pkey");

                entity.ToTable("payment_capture_wizard");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AmountToCapture).HasColumnName("amount_to_capture");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.VoidRemainingAmount).HasColumnName("void_remaining_amount");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("payment_capture_wizard_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("payment_capture_wizard_write_uid_fkey");

                entity.HasMany(d => d.PaymentTransactions).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "PaymentCaptureWizardPaymentTransactionRel",
                        r => r.HasOne<PaymentTransaction>().WithMany()
                            .HasForeignKey("PaymentTransactionId")
                            .HasConstraintName("payment_capture_wizard_payment_tran_payment_transaction_id_fkey"),
                        l => l.HasOne<PaymentCaptureWizard>().WithMany()
                            .HasForeignKey("PaymentCaptureWizardId")
                            .HasConstraintName("payment_capture_wizard_payment_t_payment_capture_wizard_id_fkey"),
                        j =>
                        {
                            j.HasKey("PaymentCaptureWizardId", "PaymentTransactionId").HasName("payment_capture_wizard_payment_transaction_rel_pkey");
                            j.ToTable("payment_capture_wizard_payment_transaction_rel");
                            j.HasIndex(new[] { "PaymentTransactionId", "PaymentCaptureWizardId" }, "payment_capture_wizard_paymen_payment_transaction_id_paymen_idx");
                            j.IndexerProperty<Guid>("PaymentCaptureWizardId").HasColumnName("payment_capture_wizard_id");
                            j.IndexerProperty<Guid>("PaymentTransactionId").HasColumnName("payment_transaction_id");
                        });
            });
        }
    }
}