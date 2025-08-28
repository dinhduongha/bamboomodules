using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountCommonJournalReport(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountCommonJournalReport>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_common_journal_report_pkey");

                        entity.ToTable("account_common_journal_report");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AmountCurrency).HasColumnName("amount_currency");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
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

                        // entity.HasOne(d => d.Company).WithMany(p => p.AccountCommonJournalReport) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("account_common_journal_report_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("account_common_journal_report_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountCommonJournalReportCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_common_journal_report_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_common_journal_report_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountCommonJournalReportWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_common_journal_report_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_common_journal_report_write_uid_fkey");

                        // entity.HasMany(d => d.AccountJournal).WithMany(p => p.AccountCommonJournalReport)
                        entity.HasMany(d => d.AccountJournal).WithMany(p => p.AccountCommonJournalReport)
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountCommonJournalReportAccountJournalRel",
                                r => r.HasOne<AccountJournal>().WithMany()
                                    .HasForeignKey("AccountJournalId")
                                    .HasConstraintName("account_common_journal_report_account_j_account_journal_id_fkey"),
                                l => l.HasOne<AccountCommonJournalReport>().WithMany()
                                    .HasForeignKey("AccountCommonJournalReportId")
                                    .HasConstraintName("account_common_journal_report_account_common_journal_repor_fkey"),
                                j =>
                                {
                                    j.HasKey("AccountCommonJournalReportId", "AccountJournalId").HasName("account_common_journal_report_account_journal_rel_pkey");
                                    j.ToTable("account_common_journal_report_account_journal_rel");
                                    j.HasIndex(new[] { "AccountJournalId", "AccountCommonJournalReportId" }, "account_common_journal_report_account_journal_id_account_co_idx");
                                    j.IndexerProperty<Guid>("AccountCommonJournalReportId").HasColumnName("account_common_journal_report_id");
                                    j.IndexerProperty<Guid>("AccountJournalId").HasColumnName("account_journal_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}