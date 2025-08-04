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
        public static void ConfigureAccountDaybookReport(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountDaybookReport>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_daybook_report_pkey");

                entity.ToTable("account_daybook_report");

                entity.HasIndex(e => e.TenantId, "account_daybook_report_company_id_index");

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
                entity.Property(e => e.TargetMove).HasColumnName("target_move");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_daybook_report_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_daybook_report_write_uid_fkey");

                // TODO: CHECK RELATION
                //entity.HasMany(d => d.AccountJournals).WithMany(p => p.AccountDaybookReports)
                entity.HasMany<AccountJournal>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountDaybookReportAccountJournalRel",
                        r => r.HasOne<AccountJournal>().WithMany()
                            .HasForeignKey("AccountJournalId")
                            .HasConstraintName("account_daybook_report_account_journal__account_journal_id_fkey"),
                        l => l.HasOne<AccountDaybookReport>().WithMany()
                            .HasForeignKey("AccountDaybookReportId")
                            .HasConstraintName("account_daybook_report_account_j_account_daybook_report_id_fkey"),
                        j =>
                        {
                            j.HasKey("AccountDaybookReportId", "AccountJournalId").HasName("account_daybook_report_account_journal_rel_pkey");
                            j.ToTable("account_daybook_report_account_journal_rel");
                            j.HasIndex(new[] { "AccountJournalId", "AccountDaybookReportId" }, "account_daybook_report_accoun_account_journal_id_account_da_idx");
                            j.IndexerProperty<Guid>("AccountDaybookReportId").HasColumnName("account_daybook_report_id");
                            j.IndexerProperty<Guid>("AccountJournalId").HasColumnName("account_journal_id");
                        });

                // TODO: CHECK RELATION
                //entity.HasMany(d => d.Accounts).WithMany(p => p.ReportLines1)
                entity.HasMany<AccountAccount>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountAccountDaybookReport",
                        r => r.HasOne<AccountAccount>().WithMany()
                            .HasForeignKey("AccountId")
                            .HasConstraintName("account_account_daybook_report_account_id_fkey"),
                        l => l.HasOne<AccountDaybookReport>().WithMany()
                            .HasForeignKey("ReportLineId")
                            .HasConstraintName("account_account_daybook_report_report_line_id_fkey"),
                        j =>
                        {
                            j.HasKey("ReportLineId", "AccountId").HasName("account_account_daybook_report_pkey");
                            j.ToTable("account_account_daybook_report");
                            j.HasIndex(new[] { "AccountId", "ReportLineId" }, "account_account_daybook_report_account_id_report_line_id_idx");
                            j.IndexerProperty<Guid>("ReportLineId").HasColumnName("report_line_id");
                            j.IndexerProperty<Guid>("AccountId").HasColumnName("account_id");
                        });
            });
        }
    }
}