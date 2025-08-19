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
        public static void ConfigureAccountMergeWizard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountMergeWizard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_merge_wizard_pkey");

            entity.ToTable("account_merge_wizard");

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
            entity.Property(e => e.IsGroupByName).HasColumnName("is_group_by_name");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountMergeWizardCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_merge_wizard_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountMergeWizardWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_merge_wizard_write_uid_fkey");

            // entity.HasMany(d => d.AccountAccount).WithMany(p => p.AccountMergeWizard)
            entity.HasMany(d => d.AccountAccount).WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "AccountAccountAccountMergeWizardRel",
                    r => r.HasOne<AccountAccount>().WithMany()
                        .HasForeignKey("AccountAccountId")
                        .HasConstraintName("account_account_account_merge_wizard_re_account_account_id_fkey"),
                    l => l.HasOne<AccountMergeWizard>().WithMany()
                        .HasForeignKey("AccountMergeWizardId")
                        .HasConstraintName("account_account_account_merge_wiza_account_merge_wizard_id_fkey"),
                    j =>
                    {
                        j.HasKey("AccountMergeWizardId", "AccountAccountId").HasName("account_account_account_merge_wizard_rel_pkey");
                        j.ToTable("account_account_account_merge_wizard_rel");
                        j.HasIndex(new[] { "AccountAccountId", "AccountMergeWizardId" }, "account_account_account_merge_account_account_id_account_me_idx");
                        j.IndexerProperty<Guid>("AccountMergeWizardId").HasColumnName("account_merge_wizard_id");
                        j.IndexerProperty<Guid>("AccountAccountId").HasColumnName("account_account_id");
                    });
            });
        }
    }
}