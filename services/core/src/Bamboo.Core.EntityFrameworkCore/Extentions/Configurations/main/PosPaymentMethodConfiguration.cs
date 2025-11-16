using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigurePosPaymentMethod(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<PosPaymentMethod>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("pos_payment_method_pkey");

                        entity.ToTable("pos_payment_method");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.JournalId, "pos_payment_method__journal_id_index").HasFilter("(journal_id IS NOT NULL)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.IsCashCount).HasColumnName("is_cash_count");
                        entity.Property(e => e.IsOnlinePayment).HasColumnName("is_online_payment");
                        entity.Property(e => e.JournalId).HasColumnName("journal_id");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.OutstandingAccountId).HasColumnName("outstanding_account_id");
                        entity.Property(e => e.PaymentMethodType).HasColumnName("payment_method_type");
                        entity.Property(e => e.QrCodeMethod).HasColumnName("qr_code_method");
                        entity.Property(e => e.ReceivableAccountId).HasColumnName("receivable_account_id");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.SplitTransactions).HasColumnName("split_transactions");
                        entity.Property(e => e.UsePaymentTerminal).HasColumnName("use_payment_terminal");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.PosPaymentMethod) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("pos_payment_method_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_payment_method_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.PosPaymentMethodCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("pos_payment_method_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_payment_method_create_uid_fkey");

                        // entity.HasOne(d => d.Journal).WithMany(p => p.PosPaymentMethod) .HasForeignKey(d => d.JournalId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("pos_payment_method_journal_id_fkey");
                        entity.HasOne(d => d.Journal).WithMany()
                            .HasForeignKey(d => d.JournalId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("pos_payment_method_journal_id_fkey");

                        // entity.HasOne(d => d.OutstandingAccount).WithMany(p => p.PosPaymentMethodOutstandingAccount) .HasForeignKey(d => d.OutstandingAccountId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("pos_payment_method_outstanding_account_id_fkey");
                        entity.HasOne(d => d.OutstandingAccount).WithMany()
                            .HasForeignKey(d => d.OutstandingAccountId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("pos_payment_method_outstanding_account_id_fkey");

                        // entity.HasOne(d => d.ReceivableAccount).WithMany(p => p.PosPaymentMethodReceivableAccount) .HasForeignKey(d => d.ReceivableAccountId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("pos_payment_method_receivable_account_id_fkey");
                        entity.HasOne(d => d.ReceivableAccount).WithMany()
                            .HasForeignKey(d => d.ReceivableAccountId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("pos_payment_method_receivable_account_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.PosPaymentMethodWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("pos_payment_method_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_payment_method_write_uid_fkey");

                        // entity.HasMany(d => d.PaymentProvider).WithMany(p => p.PosPaymentMethod)
                        entity.HasMany(d => d.PaymentProvider).WithMany(p => p.PosPaymentMethod)
                            .UsingEntity<Dictionary<string, object>>(
                                "PaymentProviderPosPaymentMethodRel",
                                r => r.HasOne<PaymentProvider>().WithMany()
                                    .HasForeignKey("PaymentProviderId")
                                    .HasConstraintName("payment_provider_pos_payment_method_re_payment_provider_id_fkey"),
                                l => l.HasOne<PosPaymentMethod>().WithMany()
                                    .HasForeignKey("PosPaymentMethodId")
                                    .HasConstraintName("payment_provider_pos_payment_method__pos_payment_method_id_fkey"),
                                j =>
                                {
                                    j.HasKey("PosPaymentMethodId", "PaymentProviderId").HasName("payment_provider_pos_payment_method_rel_pkey");
                                    j.ToTable("payment_provider_pos_payment_method_rel");
                                    j.HasIndex(new[] { "PaymentProviderId", "PosPaymentMethodId" }, "payment_provider_pos_payment__payment_provider_id_pos_payme_idx");
                                    j.IndexerProperty<Guid>("PosPaymentMethodId").HasColumnName("pos_payment_method_id");
                                    j.IndexerProperty<Guid>("PaymentProviderId").HasColumnName("payment_provider_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}