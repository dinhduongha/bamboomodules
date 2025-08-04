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
        public static void ConfigureAccountMoveSendBatchWizard(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountMoveSendBatchWizard>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_move_send_batch_wizard_pkey");

                entity.ToTable("account_move_send_batch_wizard");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_move_send_batch_wizard_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_move_send_batch_wizard_write_uid_fkey");

                // TODO: CHECK RELATION
                //entity.HasMany(d => d.AccountMoves).WithMany(p => p.AccountMoveSendBatchWizards)
                entity.HasMany(d => d.AccountMoves).WithMany()
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