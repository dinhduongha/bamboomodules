using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountAgedTrialBalance(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountAgedTrialBalance>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_aged_trial_balance_pkey");

            entity.ToTable("account_aged_trial_balance");

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
            entity.Property(e => e.PeriodLength).HasColumnName("period_length");
            entity.Property(e => e.ResultSelection).HasColumnName("result_selection");
            entity.Property(e => e.TargetMove).HasColumnName("target_move");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.Company).WithMany(p => p.AccountAgedTrialBalance)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("account_aged_trial_balance_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountAgedTrialBalanceCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_aged_trial_balance_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountAgedTrialBalanceWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_aged_trial_balance_write_uid_fkey");

            // entity.HasMany(d => d.AccountJournal).WithMany(p => p.AccountAgedTrialBalance)
            entity.HasMany(d => d.AccountJournal).WithMany(p => p.AccountAgedTrialBalance)
                .UsingEntity<Dictionary<string, object>>(
                    "AccountAgedTrialBalanceAccountJournalRel",
                    r => r.HasOne<AccountJournal>().WithMany()
                        .HasForeignKey("AccountJournalId")
                        .HasConstraintName("account_aged_trial_balance_account_jour_account_journal_id_fkey"),
                    l => l.HasOne<AccountAgedTrialBalance>().WithMany()
                        .HasForeignKey("AccountAgedTrialBalanceId")
                        .HasConstraintName("account_aged_trial_balance_ac_account_aged_trial_balance_i_fkey"),
                    j =>
                    {
                        j.HasKey("AccountAgedTrialBalanceId", "AccountJournalId").HasName("account_aged_trial_balance_account_journal_rel_pkey");
                        j.ToTable("account_aged_trial_balance_account_journal_rel");
                        j.HasIndex(new[] { "AccountJournalId", "AccountAgedTrialBalanceId" }, "account_aged_trial_balance_ac_account_journal_id_account_ag_idx");
                        j.IndexerProperty<Guid>("AccountAgedTrialBalanceId").HasColumnName("account_aged_trial_balance_id");
                        j.IndexerProperty<Guid>("AccountJournalId").HasColumnName("account_journal_id");
                    });

            // entity.HasMany(d => d.ResPartner).WithMany(p => p.AccountAgedTrialBalance)
            entity.HasMany(d => d.ResPartner).WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "AccountAgedTrialBalanceResPartnerRel",
                    r => r.HasOne<ResPartner>().WithMany()
                        .HasForeignKey("ResPartnerId")
                        .HasConstraintName("account_aged_trial_balance_res_partner_rel_res_partner_id_fkey"),
                    l => l.HasOne<AccountAgedTrialBalance>().WithMany()
                        .HasForeignKey("AccountAgedTrialBalanceId")
                        .HasConstraintName("account_aged_trial_balance_re_account_aged_trial_balance_i_fkey"),
                    j =>
                    {
                        j.HasKey("AccountAgedTrialBalanceId", "ResPartnerId").HasName("account_aged_trial_balance_res_partner_rel_pkey");
                        j.ToTable("account_aged_trial_balance_res_partner_rel");
                        j.HasIndex(new[] { "ResPartnerId", "AccountAgedTrialBalanceId" }, "account_aged_trial_balance_re_res_partner_id_account_aged_t_idx");
                        j.IndexerProperty<Guid>("AccountAgedTrialBalanceId").HasColumnName("account_aged_trial_balance_id");
                        j.IndexerProperty<Guid>("ResPartnerId").HasColumnName("res_partner_id");
                    });
            });
        }
    }
}