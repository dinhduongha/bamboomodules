using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountPaymentRegister(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountPaymentRegister>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_payment_register_pkey");

                        entity.ToTable("account_payment_register");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Amount).HasColumnName("amount");
                        entity.Property(e => e.CanEditWizard).HasColumnName("can_edit_wizard");
                        entity.Property(e => e.CanGroupPayments).HasColumnName("can_group_payments");
                        entity.Property(e => e.Communication).HasColumnName("communication");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                        entity.Property(e => e.CustomUserAmount).HasColumnName("custom_user_amount");
                        entity.Property(e => e.CustomUserCurrencyId).HasColumnName("custom_user_currency_id");
                        entity.Property(e => e.GroupPayment).HasColumnName("group_payment");
                        entity.Property(e => e.InstallmentsMode).HasColumnName("installments_mode");
                        entity.Property(e => e.JournalId).HasColumnName("journal_id");
                        entity.Property(e => e.PartnerBankId).HasColumnName("partner_bank_id");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.PartnerType).HasColumnName("partner_type");
                        entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
                        entity.Property(e => e.PaymentDifferenceHandling).HasColumnName("payment_difference_handling");
                        entity.Property(e => e.PaymentMethodLineId).HasColumnName("payment_method_line_id");
                        entity.Property(e => e.PaymentTokenId).HasColumnName("payment_token_id");
                        entity.Property(e => e.PaymentType).HasColumnName("payment_type");
                        entity.Property(e => e.SourceAmount).HasColumnName("source_amount");
                        entity.Property(e => e.SourceAmountCurrency).HasColumnName("source_amount_currency");
                        entity.Property(e => e.SourceCurrencyId).HasColumnName("source_currency_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");
                        entity.Property(e => e.WriteoffAccountId).HasColumnName("writeoff_account_id");
                        entity.Property(e => e.WriteoffLabel).HasColumnName("writeoff_label");

                        // entity.HasOne(d => d.Company).WithMany(p => p.AccountPaymentRegister) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_payment_register_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_payment_register_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountPaymentRegisterCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_payment_register_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_payment_register_create_uid_fkey");

                        // entity.HasOne(d => d.Currency).WithMany(p => p.AccountPaymentRegisterCurrency) .HasForeignKey(d => d.CurrencyId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_payment_register_currency_id_fkey");
                        entity.HasOne(d => d.Currency).WithMany()
                            .HasForeignKey(d => d.CurrencyId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_payment_register_currency_id_fkey");

                        // entity.HasOne(d => d.CustomUserCurrency).WithMany(p => p.AccountPaymentRegisterCustomUserCurrency) .HasForeignKey(d => d.CustomUserCurrencyId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_payment_register_custom_user_currency_id_fkey");
                        entity.HasOne(d => d.CustomUserCurrency).WithMany()
                            .HasForeignKey(d => d.CustomUserCurrencyId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_payment_register_custom_user_currency_id_fkey");

                        // entity.HasOne(d => d.Journal).WithMany(p => p.AccountPaymentRegister) .HasForeignKey(d => d.JournalId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_payment_register_journal_id_fkey");
                        entity.HasOne(d => d.Journal).WithMany()
                            .HasForeignKey(d => d.JournalId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_payment_register_journal_id_fkey");

                        entity.HasOne(d => d.PartnerBank).WithMany(p => p.AccountPaymentRegister)
                            .HasForeignKey(d => d.PartnerBankId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_payment_register_partner_bank_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.AccountPaymentRegister) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("account_payment_register_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_payment_register_partner_id_fkey");

                        entity.HasOne(d => d.PaymentMethodLine).WithMany(p => p.AccountPaymentRegister)
                            .HasForeignKey(d => d.PaymentMethodLineId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_payment_register_payment_method_line_id_fkey");

                        entity.HasOne(d => d.PaymentToken).WithMany(p => p.AccountPaymentRegister)
                            .HasForeignKey(d => d.PaymentTokenId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_payment_register_payment_token_id_fkey");

                        // entity.HasOne(d => d.SourceCurrency).WithMany(p => p.AccountPaymentRegisterSourceCurrency) .HasForeignKey(d => d.SourceCurrencyId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_payment_register_source_currency_id_fkey");
                        entity.HasOne(d => d.SourceCurrency).WithMany()
                            .HasForeignKey(d => d.SourceCurrencyId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_payment_register_source_currency_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountPaymentRegisterWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_payment_register_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_payment_register_write_uid_fkey");

                        // entity.HasOne(d => d.WriteoffAccount).WithMany(p => p.AccountPaymentRegister) .HasForeignKey(d => d.WriteoffAccountId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_payment_register_writeoff_account_id_fkey");
                        entity.HasOne(d => d.WriteoffAccount).WithMany()
                            .HasForeignKey(d => d.WriteoffAccountId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_payment_register_writeoff_account_id_fkey");

                        // entity.HasMany(d => d.Line).WithMany(p => p.Wizard)
                        entity.HasMany(d => d.Line).WithMany(p => p.Wizard)
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountPaymentRegisterMoveLineRel",
                                r => r.HasOne<AccountMoveLine>().WithMany()
                                    .HasForeignKey("LineId")
                                    .HasConstraintName("account_payment_register_move_line_rel_line_id_fkey"),
                                l => l.HasOne<AccountPaymentRegister>().WithMany()
                                    .HasForeignKey("WizardId")
                                    .HasConstraintName("account_payment_register_move_line_rel_wizard_id_fkey"),
                                j =>
                                {
                                    j.HasKey("WizardId", "LineId").HasName("account_payment_register_move_line_rel_pkey");
                                    j.ToTable("account_payment_register_move_line_rel");
                                    j.HasIndex(new[] { "LineId", "WizardId" }, "account_payment_register_move_line_rel_line_id_wizard_id_idx");
                                    j.IndexerProperty<Guid>("WizardId").HasColumnName("wizard_id");
                                    j.IndexerProperty<Guid>("LineId").HasColumnName("line_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}