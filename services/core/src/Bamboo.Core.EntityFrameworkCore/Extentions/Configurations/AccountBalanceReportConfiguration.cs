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
        public static void ConfigureAccountBalanceReport(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountBalanceReport>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_balance_report_pkey");

                entity.ToTable("account_balance_report");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
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

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_balance_report_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_balance_report_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_balance_report_write_uid_fkey");

                // TODO: CHECK RELATION
                //entity.HasMany(d => d.AccountAccounts).WithMany(p => p.AccountBalanceReports)
                entity.HasMany<AccountAccount>().WithMany()
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

                // TODO: CHECK RELATION
                //entity.HasMany(d => d.AccountAnalyticAccounts).WithMany(p => p.AccountBalanceReports)
                entity.HasMany<AccountAnalyticAccount>().WithMany()
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

                // TODO: CHECK RELATION
                //entity.HasMany(d => d.Journals).WithMany(p => p.Accounts)
                entity.HasMany<AccountJournal>().WithMany()
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

                //entity.HasMany(d => d.ResPartners).WithMany(p => p.AccountBalanceReports)
                entity.HasMany<ResPartner>().WithMany()
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
            });
        }
    }
}