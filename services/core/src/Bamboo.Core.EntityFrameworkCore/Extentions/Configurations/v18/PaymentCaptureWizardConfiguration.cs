using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AmountToCapture).HasColumnName("amount_to_capture");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.VoidRemainingAmount).HasColumnName("void_remaining_amount");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.PaymentCaptureWizardCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("payment_capture_wizard_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("payment_capture_wizard_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.PaymentCaptureWizardWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("payment_capture_wizard_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("payment_capture_wizard_write_uid_fkey");

                        // entity.HasMany(d => d.PaymentTransaction).WithMany(p => p.PaymentCaptureWizard)
                        entity.HasMany(d => d.PaymentTransaction).WithMany(p => p.PaymentCaptureWizard)
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

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}