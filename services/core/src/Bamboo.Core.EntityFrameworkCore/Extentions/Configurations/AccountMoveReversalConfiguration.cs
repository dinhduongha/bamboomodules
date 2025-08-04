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
        public static void ConfigureAccountMoveReversal(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountMoveReversal>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_move_reversal_pkey");

                entity.ToTable("account_move_reversal");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Date).HasColumnName("date");
                entity.Property(e => e.DateMode).HasColumnName("date_mode");
                entity.Property(e => e.JournalId).HasColumnName("journal_id");
                entity.Property(e => e.Reason).HasColumnName("reason");
                entity.Property(e => e.RefundMethod).HasColumnName("refund_method");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_move_reversal_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_move_reversal_create_uid_fkey");

                entity.HasOne(d => d.Journal).WithMany(p => p.AccountMoveReversals)
                    .HasForeignKey(d => d.JournalId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_move_reversal_journal_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_move_reversal_write_uid_fkey");

                // TODO: CHECK RELATION
                /// TODO: Add SharedTypeEntity
                //entity.HasMany(d => d.Moves).WithMany(p => p.Reversals)
                entity.HasMany<AccountMove>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountMoveReversalMove",
                        r => r.HasOne<AccountMove>().WithMany()
                            .HasForeignKey("MoveId")
                            .HasConstraintName("account_move_reversal_move_move_id_fkey"),
                        l => l.HasOne<AccountMoveReversal>().WithMany()
                            .HasForeignKey("ReversalId")
                            .HasConstraintName("account_move_reversal_move_reversal_id_fkey"),
                        j =>
                        {
                            j.HasKey("ReversalId", "MoveId").HasName("account_move_reversal_move_pkey");
                            j.ToTable("account_move_reversal_move");
                            j.HasIndex(new[] { "MoveId", "ReversalId" }, "account_move_reversal_move_move_id_reversal_id_idx");
                            j.IndexerProperty<Guid>("ReversalId").HasColumnName("reversal_id");
                            j.IndexerProperty<Guid>("MoveId").HasColumnName("move_id");
                        });

                // TODO: CHECK RELATION
                /// TODO: Add SharedTypeEntity
                //entity.HasMany(d => d.NewMoves).WithMany(p => p.ReversalsNavigation)
                entity.HasMany<AccountMove>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountMoveReversalNewMove",
                        r => r.HasOne<AccountMove>().WithMany()
                            .HasForeignKey("NewMoveId")
                            .HasConstraintName("account_move_reversal_new_move_new_move_id_fkey"),
                        l => l.HasOne<AccountMoveReversal>().WithMany()
                            .HasForeignKey("ReversalId")
                            .HasConstraintName("account_move_reversal_new_move_reversal_id_fkey"),
                        j =>
                        {
                            j.HasKey("ReversalId", "NewMoveId").HasName("account_move_reversal_new_move_pkey");
                            j.ToTable("account_move_reversal_new_move");
                            j.HasIndex(new[] { "NewMoveId", "ReversalId" }, "account_move_reversal_new_move_new_move_id_reversal_id_idx");
                            j.IndexerProperty<Guid>("ReversalId").HasColumnName("reversal_id");
                            j.IndexerProperty<Guid>("NewMoveId").HasColumnName("new_move_id");
                        });
            });
        }
    }
}