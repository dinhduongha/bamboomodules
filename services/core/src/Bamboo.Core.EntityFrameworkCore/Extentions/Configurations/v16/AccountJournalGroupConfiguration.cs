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
        public static void ConfigureAccountJournalGroup(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountJournalGroup>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_journal_group_pkey");

            entity.ToTable("account_journal_group");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => new { e.TenantId, e.Name }, "account_journal_group_uniq_name").IsUnique();

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
            entity.Property(e => e.Name)
                .HasColumnType("jsonb")
                .HasColumnName("name");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.Company).WithMany(p => p.AccountJournalGroup)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_journal_group_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountJournalGroupCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_journal_group_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountJournalGroupWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_journal_group_write_uid_fkey");

            // entity.HasMany(d => d.AccountJournal).WithMany(p => p.AccountJournalGroup)
            entity.HasMany(d => d.AccountJournal).WithMany(p => p.AccountJournalGroup)
                .UsingEntity<Dictionary<string, object>>(
                    "AccountJournalAccountJournalGroupRel",
                    r => r.HasOne<AccountJournal>().WithMany()
                        .HasForeignKey("AccountJournalId")
                        .HasConstraintName("account_journal_account_journal_group_r_account_journal_id_fkey"),
                    l => l.HasOne<AccountJournalGroup>().WithMany()
                        .HasForeignKey("AccountJournalGroupId")
                        .HasConstraintName("account_journal_account_journal_g_account_journal_group_id_fkey"),
                    j =>
                    {
                        j.HasKey("AccountJournalGroupId", "AccountJournalId").HasName("account_journal_account_journal_group_rel_pkey");
                        j.ToTable("account_journal_account_journal_group_rel");
                        j.HasIndex(new[] { "AccountJournalId", "AccountJournalGroupId" }, "account_journal_account_journ_account_journal_id_account_jo_idx");
                        j.IndexerProperty<Guid>("AccountJournalGroupId").HasColumnName("account_journal_group_id");
                        j.IndexerProperty<Guid>("AccountJournalId").HasColumnName("account_journal_id");
                    });
            });
        }
    }
}
