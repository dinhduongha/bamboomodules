using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureL10nLatamCheck(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<L10nLatamCheck>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("l10n_latam_check_pkey");

                        entity.ToTable("l10n_latam_check");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => new { e.Name, e.PaymentMethodLineId }, "l10n_latam_check_unique")
                            .IsUnique()
                            .HasFilter("(outstanding_line_id IS NOT NULL)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Amount).HasColumnName("amount");
                        entity.Property(e => e.BankId).HasColumnName("bank_id");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CurrentJournalId).HasColumnName("current_journal_id");
                        entity.Property(e => e.IssueState).HasColumnName("issue_state");
                        entity.Property(e => e.IssuerVat).HasColumnName("issuer_vat");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.OutstandingLineId).HasColumnName("outstanding_line_id");
                        entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
                        entity.Property(e => e.PaymentId).HasColumnName("payment_id");
                        entity.Property(e => e.PaymentMethodLineId).HasColumnName("payment_method_line_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Bank).WithMany(p => p.L10nLatamCheck)
                            .HasForeignKey(d => d.BankId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("l10n_latam_check_bank_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.L10nLatamCheck) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("l10n_latam_check_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("l10n_latam_check_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.L10nLatamCheckCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("l10n_latam_check_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("l10n_latam_check_create_uid_fkey");

                        entity.HasOne(d => d.CurrentJournal).WithMany(p => p.L10nLatamCheck)
                            .HasForeignKey(d => d.CurrentJournalId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("l10n_latam_check_current_journal_id_fkey");

                        entity.HasOne(d => d.OutstandingLine).WithMany(p => p.L10nLatamCheck)
                            .HasForeignKey(d => d.OutstandingLineId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("l10n_latam_check_outstanding_line_id_fkey");

                        entity.HasOne(d => d.Payment).WithMany(p => p.L10nLatamCheck)
                            .HasForeignKey(d => d.PaymentId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("l10n_latam_check_payment_id_fkey");

                        entity.HasOne(d => d.PaymentMethodLine).WithMany(p => p.L10nLatamCheck)
                            .HasForeignKey(d => d.PaymentMethodLineId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("l10n_latam_check_payment_method_line_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.L10nLatamCheckWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("l10n_latam_check_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("l10n_latam_check_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}