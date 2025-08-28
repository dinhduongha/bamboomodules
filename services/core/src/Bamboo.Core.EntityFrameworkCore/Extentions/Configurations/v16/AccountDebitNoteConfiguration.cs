using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountDebitNote(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountDebitNote>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_debit_note_pkey");

                        entity.ToTable("account_debit_note");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CopyLines).HasColumnName("copy_lines");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Date).HasColumnName("date");
                        entity.Property(e => e.JournalId).HasColumnName("journal_id");
                        entity.Property(e => e.Reason).HasColumnName("reason");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountDebitNoteCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_debit_note_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_debit_note_create_uid_fkey");

                        // entity.HasOne(d => d.Journal).WithMany(p => p.AccountDebitNote) .HasForeignKey(d => d.JournalId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_debit_note_journal_id_fkey");
                        entity.HasOne(d => d.Journal).WithMany()
                            .HasForeignKey(d => d.JournalId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_debit_note_journal_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountDebitNoteWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_debit_note_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_debit_note_write_uid_fkey");

                        // entity.HasMany(d => d.Move).WithMany(p => p.Debit)
                        entity.HasMany(d => d.Move).WithMany(p => p.Debit)
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountMoveDebitMove",
                                r => r.HasOne<AccountMove>().WithMany()
                                    .HasForeignKey("MoveId")
                                    .HasConstraintName("account_move_debit_move_move_id_fkey"),
                                l => l.HasOne<AccountDebitNote>().WithMany()
                                    .HasForeignKey("DebitId")
                                    .HasConstraintName("account_move_debit_move_debit_id_fkey"),
                                j =>
                                {
                                    j.HasKey("DebitId", "MoveId").HasName("account_move_debit_move_pkey");
                                    j.ToTable("account_move_debit_move");
                                    j.HasIndex(new[] { "MoveId", "DebitId" }, "account_move_debit_move_move_id_debit_id_idx");
                                    j.IndexerProperty<Guid>("DebitId").HasColumnName("debit_id");
                                    j.IndexerProperty<Guid>("MoveId").HasColumnName("move_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}