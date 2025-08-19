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
        public static void ConfigureAccountAutomaticEntryWizard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountAutomaticEntryWizard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_automatic_entry_wizard_pkey");

            entity.ToTable("account_automatic_entry_wizard");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AccountType).HasColumnName("account_type");
            entity.Property(e => e.Action).HasColumnName("action");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DestinationAccountId).HasColumnName("destination_account_id");
            entity.Property(e => e.Percentage).HasColumnName("percentage");
            entity.Property(e => e.TotalAmount).HasColumnName("total_amount");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.Company).WithMany(p => p.AccountAutomaticEntryWizard)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("account_automatic_entry_wizard_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountAutomaticEntryWizardCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_automatic_entry_wizard_create_uid_fkey");

            entity.HasOne(d => d.DestinationAccount).WithMany()
                .HasForeignKey(d => d.DestinationAccountId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_automatic_entry_wizard_destination_account_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountAutomaticEntryWizardWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_automatic_entry_wizard_write_uid_fkey");

            // entity.HasMany(d => d.AccountMoveLine).WithMany(p => p.AccountAutomaticEntryWizard)
            entity.HasMany(d => d.AccountMoveLine).WithMany(p => p.AccountAutomaticEntryWizard)
                .UsingEntity<Dictionary<string, object>>(
                    "AccountAutomaticEntryWizardAccountMoveLineRel",
                    r => r.HasOne<AccountMoveLine>().WithMany()
                        .HasForeignKey("AccountMoveLineId")
                        .HasConstraintName("account_automatic_entry_wizard_accoun_account_move_line_id_fkey"),
                    l => l.HasOne<AccountAutomaticEntryWizard>().WithMany()
                        .HasForeignKey("AccountAutomaticEntryWizardId")
                        .HasConstraintName("account_automatic_entry_wizar_account_automatic_entry_wiza_fkey"),
                    j =>
                    {
                        j.HasKey("AccountAutomaticEntryWizardId", "AccountMoveLineId").HasName("account_automatic_entry_wizard_account_move_line_rel_pkey");
                        j.ToTable("account_automatic_entry_wizard_account_move_line_rel");
                        j.HasIndex(new[] { "AccountMoveLineId", "AccountAutomaticEntryWizardId" }, "account_automatic_entry_wizar_account_move_line_id_account__idx");
                        j.IndexerProperty<Guid>("AccountAutomaticEntryWizardId").HasColumnName("account_automatic_entry_wizard_id");
                        j.IndexerProperty<Guid>("AccountMoveLineId").HasColumnName("account_move_line_id");
                    });
            });
        }
    }
}