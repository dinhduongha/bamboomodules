using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountCashbookReport(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountCashbookReport>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_cashbook_report_pkey");

                        entity.ToTable("account_cashbook_report");

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
                        entity.Property(e => e.InitialBalance).HasColumnName("initial_balance");
                        entity.Property(e => e.Sortby).HasColumnName("sortby");
                        entity.Property(e => e.TargetMove).HasColumnName("target_move");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountCashbookReportCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_cashbook_report_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_cashbook_report_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountCashbookReportWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_cashbook_report_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_cashbook_report_write_uid_fkey");

                        // entity.HasMany(d => d.Account).WithMany(p => p.ReportLineNavigation)
                        entity.HasMany(d => d.Account).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountAccountCashbookReport",
                                r => r.HasOne<AccountAccount>().WithMany()
                                    .HasForeignKey("AccountId")
                                    .HasConstraintName("account_account_cashbook_report_account_id_fkey"),
                                l => l.HasOne<AccountCashbookReport>().WithMany()
                                    .HasForeignKey("ReportLineId")
                                    .HasConstraintName("account_account_cashbook_report_report_line_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ReportLineId", "AccountId").HasName("account_account_cashbook_report_pkey");
                                    j.ToTable("account_account_cashbook_report");
                                    j.HasIndex(new[] { "AccountId", "ReportLineId" }, "account_account_cashbook_report_account_id_report_line_id_idx");
                                    j.IndexerProperty<Guid>("ReportLineId").HasColumnName("report_line_id");
                                    j.IndexerProperty<Guid>("AccountId").HasColumnName("account_id");
                                });

                        // entity.HasMany(d => d.AccountJournal).WithMany(p => p.AccountCashbookReport)
                        entity.HasMany(d => d.AccountJournal).WithMany(p => p.AccountCashbookReport)
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountCashbookReportAccountJournalRel",
                                r => r.HasOne<AccountJournal>().WithMany()
                                    .HasForeignKey("AccountJournalId")
                                    .HasConstraintName("account_cashbook_report_account_journal_account_journal_id_fkey"),
                                l => l.HasOne<AccountCashbookReport>().WithMany()
                                    .HasForeignKey("AccountCashbookReportId")
                                    .HasConstraintName("account_cashbook_report_account_account_cashbook_report_id_fkey"),
                                j =>
                                {
                                    j.HasKey("AccountCashbookReportId", "AccountJournalId").HasName("account_cashbook_report_account_journal_rel_pkey");
                                    j.ToTable("account_cashbook_report_account_journal_rel");
                                    j.HasIndex(new[] { "AccountJournalId", "AccountCashbookReportId" }, "account_cashbook_report_accou_account_journal_id_account_ca_idx");
                                    j.IndexerProperty<Guid>("AccountCashbookReportId").HasColumnName("account_cashbook_report_id");
                                    j.IndexerProperty<Guid>("AccountJournalId").HasColumnName("account_journal_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}