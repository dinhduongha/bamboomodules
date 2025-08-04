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
        public static void ConfigureAccountBankStatementImportJournalCreation(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountBankStatementImportJournalCreation>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_bank_statement_import_journal_creation_pkey");

                entity.ToTable("account_bank_statement_import_journal_creation");

                entity.HasIndex(e => e.TenantId, "account_bank_statement_import_journal_creation_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.JournalId).HasColumnName("journal_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_bank_statement_import_journal_creation_create_uid_fkey");

                entity.HasOne(d => d.Journal).WithMany(p => p.AccountBankStatementImportJournalCreations)
                    .HasForeignKey(d => d.JournalId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_bank_statement_import_journal_creation_journal_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_bank_statement_import_journal_creation_write_uid_fkey");
            });
        }
    }
}