using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountBalanceReport(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountBalanceReport>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_balance_report_pkey");

                        entity.ToTable("account_balance_report");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DateFrom).HasColumnName("date_from");
                        entity.Property(e => e.DateTo).HasColumnName("date_to");
                        entity.Property(e => e.DisplayAccount).HasColumnName("display_account");
                        entity.Property(e => e.TargetMove).HasColumnName("target_move");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.AccountBalanceReport) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("account_balance_report_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("account_balance_report_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountBalanceReportCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_balance_report_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_balance_report_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountBalanceReportWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_balance_report_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_balance_report_write_uid_fkey");

                        // entity.HasMany(d => d.AccountAccount).WithMany(p => p.AccountBalanceReport)
                        entity.HasMany(d => d.AccountAccount).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountAccountAccountBalanceReportRel",
                                r => r.HasOne<AccountAccount>().WithMany()
                                    .HasForeignKey("AccountAccountId")
                                    .HasConstraintName("account_account_account_balance_report__account_account_id_fkey"),
                                l => l.HasOne<AccountBalanceReport>().WithMany()
                                    .HasForeignKey("AccountBalanceReportId")
                                    .HasConstraintName("account_account_account_balance__account_balance_report_id_fkey"),
                                j =>
                                {
                                    j.HasKey("AccountBalanceReportId", "AccountAccountId").HasName("account_account_account_balance_report_rel_pkey");
                                    j.ToTable("account_account_account_balance_report_rel");
                                    j.HasIndex(new[] { "AccountAccountId", "AccountBalanceReportId" }, "account_account_account_balan_account_account_id_account_ba_idx");
                                    j.IndexerProperty<Guid>("AccountBalanceReportId").HasColumnName("account_balance_report_id");
                                    j.IndexerProperty<Guid>("AccountAccountId").HasColumnName("account_account_id");
                                });

                        // entity.HasMany(d => d.AccountAnalyticAccount).WithMany(p => p.AccountBalanceReport)
                        entity.HasMany(d => d.AccountAnalyticAccount).WithMany(p => p.AccountBalanceReport)
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountTrialBalanceAnalyticRel",
                                r => r.HasOne<AccountAnalyticAccount>().WithMany()
                                    .HasForeignKey("AccountAnalyticAccountId")
                                    .HasConstraintName("account_trial_balance_analytic_account_analytic_account_id_fkey"),
                                l => l.HasOne<AccountBalanceReport>().WithMany()
                                    .HasForeignKey("AccountBalanceReportId")
                                    .HasConstraintName("account_trial_balance_analytic_r_account_balance_report_id_fkey"),
                                j =>
                                {
                                    j.HasKey("AccountBalanceReportId", "AccountAnalyticAccountId").HasName("account_trial_balance_analytic_rel_pkey");
                                    j.ToTable("account_trial_balance_analytic_rel");
                                    j.HasIndex(new[] { "AccountAnalyticAccountId", "AccountBalanceReportId" }, "account_trial_balance_analyti_account_analytic_account_id_a_idx");
                                    j.IndexerProperty<Guid>("AccountBalanceReportId").HasColumnName("account_balance_report_id");
                                    j.IndexerProperty<Guid>("AccountAnalyticAccountId").HasColumnName("account_analytic_account_id");
                                });

                        // entity.HasMany(d => d.Journal).WithMany(p => p.Account)
                        entity.HasMany(d => d.Journal).WithMany(p => p.Account)
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountBalanceReportJournalRel",
                                r => r.HasOne<AccountJournal>().WithMany()
                                    .HasForeignKey("JournalId")
                                    .HasConstraintName("account_balance_report_journal_rel_journal_id_fkey"),
                                l => l.HasOne<AccountBalanceReport>().WithMany()
                                    .HasForeignKey("AccountId")
                                    .HasConstraintName("account_balance_report_journal_rel_account_id_fkey"),
                                j =>
                                {
                                    j.HasKey("AccountId", "JournalId").HasName("account_balance_report_journal_rel_pkey");
                                    j.ToTable("account_balance_report_journal_rel");
                                    j.HasIndex(new[] { "JournalId", "AccountId" }, "account_balance_report_journal_rel_journal_id_account_id_idx");
                                    j.IndexerProperty<Guid>("AccountId").HasColumnName("account_id");
                                    j.IndexerProperty<Guid>("JournalId").HasColumnName("journal_id");
                                });

                        // entity.HasMany(d => d.ResPartner).WithMany(p => p.AccountBalanceReport)
                        entity.HasMany(d => d.ResPartner).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountBalanceReportResPartnerRel",
                                r => r.HasOne<ResPartner>().WithMany()
                                    .HasForeignKey("ResPartnerId")
                                    .HasConstraintName("account_balance_report_res_partner_rel_res_partner_id_fkey"),
                                l => l.HasOne<AccountBalanceReport>().WithMany()
                                    .HasForeignKey("AccountBalanceReportId")
                                    .HasConstraintName("account_balance_report_res_partn_account_balance_report_id_fkey"),
                                j =>
                                {
                                    j.HasKey("AccountBalanceReportId", "ResPartnerId").HasName("account_balance_report_res_partner_rel_pkey");
                                    j.ToTable("account_balance_report_res_partner_rel");
                                    j.HasIndex(new[] { "ResPartnerId", "AccountBalanceReportId" }, "account_balance_report_res_pa_res_partner_id_account_balanc_idx");
                                    j.IndexerProperty<Guid>("AccountBalanceReportId").HasColumnName("account_balance_report_id");
                                    j.IndexerProperty<Guid>("ResPartnerId").HasColumnName("res_partner_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}