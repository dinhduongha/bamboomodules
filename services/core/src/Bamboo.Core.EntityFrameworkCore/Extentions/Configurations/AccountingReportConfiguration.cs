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
        public static void ConfigureAccountingReport(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountingReport>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("accounting_report_pkey");

                entity.ToTable("accounting_report");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.AccountReportId).HasColumnName("account_report_id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DateFrom).HasColumnName("date_from");
                entity.Property(e => e.DateFromCmp).HasColumnName("date_from_cmp");
                entity.Property(e => e.DateTo).HasColumnName("date_to");
                entity.Property(e => e.DateToCmp).HasColumnName("date_to_cmp");
                entity.Property(e => e.DebitCredit).HasColumnName("debit_credit");
                entity.Property(e => e.EnableFilter).HasColumnName("enable_filter");
                entity.Property(e => e.FilterCmp).HasColumnName("filter_cmp");
                entity.Property(e => e.LabelFilter).HasColumnName("label_filter");
                entity.Property(e => e.TargetMove).HasColumnName("target_move");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.AccountReport).WithMany(p => p.AccountingReports)
                    .HasForeignKey(d => d.AccountReportId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("accounting_report_account_report_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("accounting_report_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("accounting_report_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("accounting_report_write_uid_fkey");

                //entity.HasMany(d => d.AccountJournals).WithMany(p => p.AccountingReports)
                entity.HasMany<AccountJournal>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountJournalAccountingReportRel",
                        r => r.HasOne<AccountJournal>().WithMany()
                            .HasForeignKey("AccountJournalId")
                            .HasConstraintName("account_journal_accounting_report_rel_account_journal_id_fkey"),
                        l => l.HasOne<AccountingReport>().WithMany()
                            .HasForeignKey("AccountingReportId")
                            .HasConstraintName("account_journal_accounting_report_rel_accounting_report_id_fkey"),
                        j =>
                        {
                            j.HasKey("AccountingReportId", "AccountJournalId").HasName("account_journal_accounting_report_rel_pkey");
                            j.ToTable("account_journal_accounting_report_rel");
                            j.HasIndex(new[] { "AccountJournalId", "AccountingReportId" }, "account_journal_accounting_re_account_journal_id_accounting_idx");
                            j.IndexerProperty<Guid>("AccountingReportId").HasColumnName("accounting_report_id");
                            j.IndexerProperty<Guid>("AccountJournalId").HasColumnName("account_journal_id");
                        });
            });
        }
    }
}