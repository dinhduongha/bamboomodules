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
        public static void ConfigureAccountMoveSendBatchWizard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountMoveSendBatchWizard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_move_send_batch_wizard_pkey");

            entity.ToTable("account_move_send_batch_wizard");

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
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountMoveSendBatchWizardCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_move_send_batch_wizard_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountMoveSendBatchWizardWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_move_send_batch_wizard_write_uid_fkey");

            // entity.HasMany(d => d.AccountMove).WithMany(p => p.AccountMoveSendBatchWizard)
            entity.HasMany(d => d.AccountMove).WithMany(p => p.AccountMoveSendBatchWizard)
                .UsingEntity<Dictionary<string, object>>(
                    "AccountMoveAccountMoveSendBatchWizardRel",
                    r => r.HasOne<AccountMove>().WithMany()
                        .HasForeignKey("AccountMoveId")
                        .HasConstraintName("account_move_account_move_send_batch_wizar_account_move_id_fkey"),
                    l => l.HasOne<AccountMoveSendBatchWizard>().WithMany()
                        .HasForeignKey("AccountMoveSendBatchWizardId")
                        .HasConstraintName("account_move_account_move_sen_account_move_send_batch_wiza_fkey"),
                    j =>
                    {
                        j.HasKey("AccountMoveSendBatchWizardId", "AccountMoveId").HasName("account_move_account_move_send_batch_wizard_rel_pkey");
                        j.ToTable("account_move_account_move_send_batch_wizard_rel");
                        j.HasIndex(new[] { "AccountMoveId", "AccountMoveSendBatchWizardId" }, "account_move_account_move_sen_account_move_id_account_move__idx");
                        j.IndexerProperty<Guid>("AccountMoveSendBatchWizardId").HasColumnName("account_move_send_batch_wizard_id");
                        j.IndexerProperty<Guid>("AccountMoveId").HasColumnName("account_move_id");
                    });
            });
        }
    }
}