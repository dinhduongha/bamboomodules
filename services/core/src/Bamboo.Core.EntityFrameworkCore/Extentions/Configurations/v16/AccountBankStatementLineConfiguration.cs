using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountBankStatementLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountBankStatementLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_bank_statement_line_pkey");

                        entity.ToTable("account_bank_statement_line");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.MoveId, "account_bank_statement_line__move_id_index");

                        entity.HasIndex(e => new { e.JournalId, e.TenantId, e.InternalIndex }, "account_bank_statement_line_main_idx");

                        entity.HasIndex(e => new { e.JournalId, e.TenantId, e.InternalIndex }, "account_bank_statement_line_orphan_idx").HasFilter("(statement_id IS NULL)");

                        entity.HasIndex(e => new { e.JournalId, e.TenantId, e.InternalIndex }, "account_bank_statement_line_unreconciled_idx").HasFilter("((NOT is_reconciled) OR (is_reconciled IS NULL))");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccountNumber).HasColumnName("account_number");
                        entity.Property(e => e.Amount).HasColumnName("amount");
                        entity.Property(e => e.AmountCurrency).HasColumnName("amount_currency");
                        entity.Property(e => e.AmountResidual).HasColumnName("amount_residual");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                        entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                        entity.Property(e => e.ForeignCurrencyId).HasColumnName("foreign_currency_id");
                        entity.Property(e => e.InternalIndex).HasColumnName("internal_index");
                        entity.Property(e => e.IsReconciled).HasColumnName("is_reconciled");
                        entity.Property(e => e.JournalId).HasColumnName("journal_id");
                        entity.Property(e => e.MoveId).HasColumnName("move_id");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.PartnerName).HasColumnName("partner_name");
                        entity.Property(e => e.PaymentRef).HasColumnName("payment_ref");
                        entity.Property(e => e.PosSessionId).HasColumnName("pos_session_id");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.StatementId).HasColumnName("statement_id");
                        entity.Property(e => e.TransactionDetails)
                            .HasColumnType("jsonb")
                            .HasColumnName("transaction_details");
                        entity.Property(e => e.TransactionType).HasColumnName("transaction_type");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.AccountBankStatementLine) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_bank_statement_line_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_bank_statement_line_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountBankStatementLineCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_bank_statement_line_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_bank_statement_line_create_uid_fkey");

                        // entity.HasOne(d => d.Currency).WithMany(p => p.AccountBankStatementLineCurrency) .HasForeignKey(d => d.CurrencyId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_bank_statement_line_currency_id_fkey");
                        entity.HasOne(d => d.Currency).WithMany()
                            .HasForeignKey(d => d.CurrencyId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_bank_statement_line_currency_id_fkey");

                        entity.HasOne(d => d.Employee).WithMany(p => p.AccountBankStatementLine)
                            .HasForeignKey(d => d.EmployeeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_bank_statement_line_employee_id_fkey");

                        // entity.HasOne(d => d.ForeignCurrency).WithMany(p => p.AccountBankStatementLineForeignCurrency) .HasForeignKey(d => d.ForeignCurrencyId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_bank_statement_line_foreign_currency_id_fkey");
                        entity.HasOne(d => d.ForeignCurrency).WithMany()
                            .HasForeignKey(d => d.ForeignCurrencyId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_bank_statement_line_foreign_currency_id_fkey");

                        // entity.HasOne(d => d.Journal).WithMany(p => p.AccountBankStatementLine) .HasForeignKey(d => d.JournalId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_bank_statement_line_journal_id_fkey");
                        entity.HasOne(d => d.Journal).WithMany()
                            .HasForeignKey(d => d.JournalId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_bank_statement_line_journal_id_fkey");

                        entity.HasOne(d => d.Move).WithMany(p => p.AccountBankStatementLine)
                            .HasForeignKey(d => d.MoveId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("account_bank_statement_line_move_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.AccountBankStatementLine) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("account_bank_statement_line_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_bank_statement_line_partner_id_fkey");

                        entity.HasOne(d => d.PosSession).WithMany(p => p.AccountBankStatementLine)
                            .HasForeignKey(d => d.PosSessionId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_bank_statement_line_pos_session_id_fkey");

                        entity.HasOne(d => d.Statement).WithMany(p => p.AccountBankStatementLine)
                            .HasForeignKey(d => d.StatementId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_bank_statement_line_statement_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountBankStatementLineWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_bank_statement_line_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_bank_statement_line_write_uid_fkey");

                        // entity.HasMany(d => d.AccountPayment).WithMany(p => p.AccountBankStatementLine)
                        entity.HasMany(d => d.AccountPayment).WithMany(p => p.AccountBankStatementLine)
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountPaymentAccountBankStatementLineRel",
                                r => r.HasOne<AccountPayment>().WithMany()
                                    .HasForeignKey("AccountPaymentId")
                                    .HasConstraintName("account_payment_account_bank_statement__account_payment_id_fkey"),
                                l => l.HasOne<AccountBankStatementLine>().WithMany()
                                    .HasForeignKey("AccountBankStatementLineId")
                                    .HasConstraintName("account_payment_account_bank__account_bank_statement_line__fkey"),
                                j =>
                                {
                                    j.HasKey("AccountBankStatementLineId", "AccountPaymentId").HasName("account_payment_account_bank_statement_line_rel_pkey");
                                    j.ToTable("account_payment_account_bank_statement_line_rel");
                                    j.HasIndex(new[] { "AccountPaymentId", "AccountBankStatementLineId" }, "account_payment_account_bank__account_payment_id_account_ba_idx");
                                    j.IndexerProperty<Guid>("AccountBankStatementLineId").HasColumnName("account_bank_statement_line_id");
                                    j.IndexerProperty<Guid>("AccountPaymentId").HasColumnName("account_payment_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}