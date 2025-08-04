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
        public static void ConfigureAccountReportPartnerLedger(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountReportPartnerLedger>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_report_partner_ledger_pkey");

                entity.ToTable("account_report_partner_ledger");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.AmountCurrency).HasColumnName("amount_currency");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DateFrom).HasColumnName("date_from");
                entity.Property(e => e.DateTo).HasColumnName("date_to");
                entity.Property(e => e.Reconciled).HasColumnName("reconciled");
                entity.Property(e => e.ResultSelection).HasColumnName("result_selection");
                entity.Property(e => e.TargetMove).HasColumnName("target_move");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_report_partner_ledger_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_report_partner_ledger_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_report_partner_ledger_write_uid_fkey");

                //entity.HasMany(d => d.AccountJournals).WithMany(p => p.AccountReportPartnerLedgers)
                entity.HasMany<AccountJournal>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountJournalAccountReportPartnerLedgerRel",
                        r => r.HasOne<AccountJournal>().WithMany()
                            .HasForeignKey("AccountJournalId")
                            .HasConstraintName("account_journal_account_report_partner__account_journal_id_fkey"),
                        l => l.HasOne<AccountReportPartnerLedger>().WithMany()
                            .HasForeignKey("AccountReportPartnerLedgerId")
                            .HasConstraintName("account_journal_account_repor_account_report_partner_ledge_fkey"),
                        j =>
                        {
                            j.HasKey("AccountReportPartnerLedgerId", "AccountJournalId").HasName("account_journal_account_report_partner_ledger_rel_pkey");
                            j.ToTable("account_journal_account_report_partner_ledger_rel");
                            j.HasIndex(new[] { "AccountJournalId", "AccountReportPartnerLedgerId" }, "account_journal_account_repor_account_journal_id_account_re_idx");
                            j.IndexerProperty<Guid>("AccountReportPartnerLedgerId").HasColumnName("account_report_partner_ledger_id");
                            j.IndexerProperty<Guid>("AccountJournalId").HasColumnName("account_journal_id");
                        });

                //entity.HasMany(d => d.ResPartners).WithMany(p => p.AccountReportPartnerLedgers)
                entity.HasMany<ResPartner>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountReportPartnerLedgerResPartnerRel",
                        r => r.HasOne<ResPartner>().WithMany()
                            .HasForeignKey("ResPartnerId")
                            .HasConstraintName("account_report_partner_ledger_res_partner_r_res_partner_id_fkey"),
                        l => l.HasOne<AccountReportPartnerLedger>().WithMany()
                            .HasForeignKey("AccountReportPartnerLedgerId")
                            .HasConstraintName("account_report_partner_ledger_account_report_partner_ledge_fkey"),
                        j =>
                        {
                            j.HasKey("AccountReportPartnerLedgerId", "ResPartnerId").HasName("account_report_partner_ledger_res_partner_rel_pkey");
                            j.ToTable("account_report_partner_ledger_res_partner_rel");
                            j.HasIndex(new[] { "ResPartnerId", "AccountReportPartnerLedgerId" }, "account_report_partner_ledger_res_partner_id_account_report_idx");
                            j.IndexerProperty<Guid>("AccountReportPartnerLedgerId").HasColumnName("account_report_partner_ledger_id");
                            j.IndexerProperty<Guid>("ResPartnerId").HasColumnName("res_partner_id");
                        });
            });
        }
    }
}