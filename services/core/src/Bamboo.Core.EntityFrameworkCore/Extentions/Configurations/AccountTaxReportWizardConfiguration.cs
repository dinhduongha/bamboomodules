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
        public static void ConfigureAccountTaxReportWizard(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountTaxReportWizard>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_tax_report_wizard_pkey");

                entity.ToTable("account_tax_report_wizard");

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

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_tax_report_wizard_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_tax_report_wizard_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_tax_report_wizard_write_uid_fkey");

                //entity.HasMany(d => d.AccountJournals).WithMany(p => p.AccountTaxReportWizards)
                entity.HasMany<AccountJournal>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountJournalAccountTaxReportWizardRel",
                        r => r.HasOne<AccountJournal>().WithMany()
                            .HasForeignKey("AccountJournalId")
                            .HasConstraintName("account_journal_account_tax_report_wiza_account_journal_id_fkey"),
                        l => l.HasOne<AccountTaxReportWizard>().WithMany()
                            .HasForeignKey("AccountTaxReportWizardId")
                            .HasConstraintName("account_journal_account_tax_r_account_tax_report_wizard_id_fkey"),
                        j =>
                        {
                            j.HasKey("AccountTaxReportWizardId", "AccountJournalId").HasName("account_journal_account_tax_report_wizard_rel_pkey");
                            j.ToTable("account_journal_account_tax_report_wizard_rel");
                            j.HasIndex(new[] { "AccountJournalId", "AccountTaxReportWizardId" }, "account_journal_account_tax_r_account_journal_id_account_ta_idx");
                            j.IndexerProperty<Guid>("AccountTaxReportWizardId").HasColumnName("account_tax_report_wizard_id");
                            j.IndexerProperty<Guid>("AccountJournalId").HasColumnName("account_journal_id");
                        });
            });
        }
    }
}