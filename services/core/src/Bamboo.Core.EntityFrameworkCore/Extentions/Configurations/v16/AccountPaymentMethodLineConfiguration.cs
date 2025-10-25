using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountPaymentMethodLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountPaymentMethodLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_payment_method_line_pkey");

                        entity.ToTable("account_payment_method_line");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.JournalId).HasColumnName("journal_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.PaymentAccountId).HasColumnName("payment_account_id");
                        entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
                        entity.Property(e => e.PaymentProviderId).HasColumnName("payment_provider_id");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountPaymentMethodLineCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_payment_method_line_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_payment_method_line_create_uid_fkey");

                        // entity.HasOne(d => d.Journal).WithMany(p => p.AccountPaymentMethodLine) .HasForeignKey(d => d.JournalId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_payment_method_line_journal_id_fkey");
                        entity.HasOne(d => d.Journal).WithMany()
                            .HasForeignKey(d => d.JournalId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_payment_method_line_journal_id_fkey");

                        // entity.HasOne(d => d.PaymentAccount).WithMany(p => p.AccountPaymentMethodLine) .HasForeignKey(d => d.PaymentAccountId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("account_payment_method_line_payment_account_id_fkey");
                        entity.HasOne(d => d.PaymentAccount).WithMany()
                            .HasForeignKey(d => d.PaymentAccountId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_payment_method_line_payment_account_id_fkey");

                        entity.HasOne(d => d.PaymentMethod).WithMany(p => p.AccountPaymentMethodLine)
                            .HasForeignKey(d => d.PaymentMethodId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_payment_method_line_payment_method_id_fkey");

                        entity.HasOne(d => d.PaymentProvider).WithMany(p => p.AccountPaymentMethodLine)
                            .HasForeignKey(d => d.PaymentProviderId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_payment_method_line_payment_provider_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountPaymentMethodLineWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_payment_method_line_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_payment_method_line_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}