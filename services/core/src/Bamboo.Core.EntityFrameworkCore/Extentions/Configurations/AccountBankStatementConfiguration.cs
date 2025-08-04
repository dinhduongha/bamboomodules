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
        public static void ConfigureAccountBankStatement(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountBankStatement>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_bank_statement_pkey");

                entity.ToTable("account_bank_statement");

                entity.HasIndex(e => e.Date, "account_bank_statement__date_index");

                entity.HasIndex(e => new { e.JournalId, e.FirstLineIndex }, "account_bank_statement_first_line_index_idx");

                entity.HasIndex(e => new { e.JournalId, e.Date, e.Id }, "account_bank_statement_journal_id_date_desc_id_desc_idx").IsDescending(false, true, true);

                entity.HasIndex(e => e.FirstLineIndex, "account_bank_statement_first_line_index_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.BalanceEnd).HasColumnName("balance_end");
                entity.Property(e => e.BalanceEndReal).HasColumnName("balance_end_real");
                entity.Property(e => e.BalanceStart).HasColumnName("balance_start");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Date).HasColumnName("date");
                entity.Property(e => e.FirstLineIndex).HasColumnName("first_line_index");
                entity.Property(e => e.IsComplete).HasColumnName("is_complete");
                entity.Property(e => e.JournalId).HasColumnName("journal_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Reference).HasColumnName("reference");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_bank_statement_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_bank_statement_create_uid_fkey");

                entity.HasOne(d => d.Journal).WithMany(p => p.AccountBankStatements)
                    .HasForeignKey(d => d.JournalId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_bank_statement_journal_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_bank_statement_write_uid_fkey");

                // TODO: CHECK RELATION
                //entity.HasMany(d => d.IrAttachments).WithMany(p => p.AccountBankStatements)
                entity.HasMany<IrAttachment>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountBankStatementIrAttachmentRel",
                        r => r.HasOne<IrAttachment>().WithMany()
                            .HasForeignKey("IrAttachmentId")
                            .HasConstraintName("account_bank_statement_ir_attachment_rel_ir_attachment_id_fkey"),
                        l => l.HasOne<AccountBankStatement>().WithMany()
                            .HasForeignKey("AccountBankStatementId")
                            .HasConstraintName("account_bank_statement_ir_attach_account_bank_statement_id_fkey"),
                        j =>
                        {
                            j.HasKey("AccountBankStatementId", "IrAttachmentId").HasName("account_bank_statement_ir_attachment_rel_pkey");
                            j.ToTable("account_bank_statement_ir_attachment_rel");
                            j.HasIndex(new[] { "IrAttachmentId", "AccountBankStatementId" }, "account_bank_statement_ir_att_ir_attachment_id_account_bank_idx");
                            j.IndexerProperty<Guid>("AccountBankStatementId").HasColumnName("account_bank_statement_id");
                            j.IndexerProperty<Guid>("IrAttachmentId").HasColumnName("ir_attachment_id");
                        });
            });
        }
    }
}