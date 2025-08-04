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
        public static void ConfigurePosPaymentMethod(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PosPaymentMethod>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pos_payment_method_pkey");

                entity.ToTable("pos_payment_method");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.IsCashCount).HasColumnName("is_cash_count");
                entity.Property(e => e.JournalId).HasColumnName("journal_id");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.OutstandingAccountId).HasColumnName("outstanding_account_id");
                entity.Property(e => e.ReceivableAccountId).HasColumnName("receivable_account_id");
                entity.Property(e => e.SplitTransactions).HasColumnName("split_transactions");
                entity.Property(e => e.UsePaymentTerminal).HasColumnName("use_payment_terminal");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_payment_method_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_payment_method_create_uid_fkey");

                entity.HasOne(d => d.Journal).WithMany(p => p.PosPaymentMethods)
                    .HasForeignKey(d => d.JournalId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("pos_payment_method_journal_id_fkey");

                entity.HasOne(d => d.OutstandingAccount).WithMany(p => p.PosPaymentMethodOutstandingAccounts)
                    .HasForeignKey(d => d.OutstandingAccountId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("pos_payment_method_outstanding_account_id_fkey");

                entity.HasOne(d => d.ReceivableAccount).WithMany(p => p.PosPaymentMethodReceivableAccounts)
                    .HasForeignKey(d => d.ReceivableAccountId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("pos_payment_method_receivable_account_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_payment_method_write_uid_fkey");

                //entity.HasMany(d => d.PaymentProviders).WithMany(p => p.PosPaymentMethods)
                entity.HasMany<PaymentProvider>().WithMany()
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
            });
        }
    }
}