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
        public static void ConfigureAccountReportGeneralLedger(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountReportGeneralLedger>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_report_general_ledger_pkey");

                entity.ToTable("account_report_general_ledger");

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
                entity.Property(e => e.InitialBalance).HasColumnName("initial_balance");
                entity.Property(e => e.Sortby).HasColumnName("sortby");
                entity.Property(e => e.TargetMove).HasColumnName("target_move");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_report_general_ledger_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_report_general_ledger_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_report_general_ledger_write_uid_fkey");

                //entity.HasMany(d => d.AccountAccounts).WithMany(p => p.AccountReportGeneralLedgers)
                entity.HasMany<AccountAccount>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountAccountAccountReportGeneralLedgerRel",
                        r => r.HasOne<AccountAccount>().WithMany()
                            .HasForeignKey("AccountAccountId")
                            .HasConstraintName("account_account_account_report_general__account_account_id_fkey"),
                        l => l.HasOne<AccountReportGeneralLedger>().WithMany()
                            .HasForeignKey("AccountReportGeneralLedgerId")
                            .HasConstraintName("account_account_account_repor_account_report_general_ledge_fkey"),
                        j =>
                        {
                            j.HasKey("AccountReportGeneralLedgerId", "AccountAccountId").HasName("account_account_account_report_general_ledger_rel_pkey");
                            j.ToTable("account_account_account_report_general_ledger_rel");
                            j.HasIndex(new[] { "AccountAccountId", "AccountReportGeneralLedgerId" }, "account_account_account_repor_account_account_id_account_re_idx");
                            j.IndexerProperty<Guid>("AccountReportGeneralLedgerId").HasColumnName("account_report_general_ledger_id");
                            j.IndexerProperty<Guid>("AccountAccountId").HasColumnName("account_account_id");
                        });

                //entity.HasMany(d => d.AccountAnalyticAccounts).WithMany(p => p.AccountReportGeneralLedgers)
                entity.HasMany<AccountAnalyticAccount>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountAnalyticAccountAccountReportGeneralLedgerRel",
                        r => r.HasOne<AccountAnalyticAccount>().WithMany()
                            .HasForeignKey("AccountAnalyticAccountId")
                            .HasConstraintName("account_analytic_account_acco_account_analytic_account_id_fkey1"),
                        l => l.HasOne<AccountReportGeneralLedger>().WithMany()
                            .HasForeignKey("AccountReportGeneralLedgerId")
                            .HasConstraintName("account_analytic_account_acco_account_report_general_ledge_fkey"),
                        j =>
                        {
                            j.HasKey("AccountReportGeneralLedgerId", "AccountAnalyticAccountId").HasName("account_analytic_account_account_report_general_ledger_rel_pkey");
                            j.ToTable("account_analytic_account_account_report_general_ledger_rel");
                            j.HasIndex(new[] { "AccountAnalyticAccountId", "AccountReportGeneralLedgerId" }, "account_analytic_account_acco_account_analytic_account_id__idx1");
                            j.IndexerProperty<Guid>("AccountReportGeneralLedgerId").HasColumnName("account_report_general_ledger_id");
                            j.IndexerProperty<Guid>("AccountAnalyticAccountId").HasColumnName("account_analytic_account_id");
                        });

                //entity.HasMany(d => d.Journals).WithMany(p => p.AccountsNavigation)
                entity.HasMany<AccountJournal>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountReportGeneralLedgerJournalRel",
                        r => r.HasOne<AccountJournal>().WithMany()
                            .HasForeignKey("JournalId")
                            .HasConstraintName("account_report_general_ledger_journal_rel_journal_id_fkey"),
                        l => l.HasOne<AccountReportGeneralLedger>().WithMany()
                            .HasForeignKey("AccountId")
                            .HasConstraintName("account_report_general_ledger_journal_rel_account_id_fkey"),
                        j =>
                        {
                            j.HasKey("AccountId", "JournalId").HasName("account_report_general_ledger_journal_rel_pkey");
                            j.ToTable("account_report_general_ledger_journal_rel");
                            j.HasIndex(new[] { "JournalId", "AccountId" }, "account_report_general_ledger_journal_journal_id_account_id_idx");
                            j.IndexerProperty<Guid>("AccountId").HasColumnName("account_id");
                            j.IndexerProperty<Guid>("JournalId").HasColumnName("journal_id");
                        });

                //entity.HasMany(d => d.ResPartners).WithMany(p => p.AccountReportGeneralLedgers)
                entity.HasMany<ResPartner>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountReportGeneralLedgerResPartnerRel",
                        r => r.HasOne<ResPartner>().WithMany()
                            .HasForeignKey("ResPartnerId")
                            .HasConstraintName("account_report_general_ledger_res_partner_r_res_partner_id_fkey"),
                        l => l.HasOne<AccountReportGeneralLedger>().WithMany()
                            .HasForeignKey("AccountReportGeneralLedgerId")
                            .HasConstraintName("account_report_general_ledger_account_report_general_ledge_fkey"),
                        j =>
                        {
                            j.HasKey("AccountReportGeneralLedgerId", "ResPartnerId").HasName("account_report_general_ledger_res_partner_rel_pkey");
                            j.ToTable("account_report_general_ledger_res_partner_rel");
                            j.HasIndex(new[] { "ResPartnerId", "AccountReportGeneralLedgerId" }, "account_report_general_ledger_res_partner_id_account_report_idx");
                            j.IndexerProperty<Guid>("AccountReportGeneralLedgerId").HasColumnName("account_report_general_ledger_id");
                            j.IndexerProperty<Guid>("ResPartnerId").HasColumnName("res_partner_id");
                        });
            });
        }
    }
}