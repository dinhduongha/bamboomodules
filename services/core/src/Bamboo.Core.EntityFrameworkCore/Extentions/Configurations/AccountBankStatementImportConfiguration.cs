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
        public static void ConfigureAccountBankStatementImport(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountBankStatementImport>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_bank_statement_import_pkey");

                entity.ToTable("account_bank_statement_import");
                entity.HasIndex(e => e.TenantId, "account_bank_statement_import_company_id_index");

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
                    .HasConstraintName("account_bank_statement_import_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_bank_statement_import_write_uid_fkey");

                //entity.HasMany(d => d.IrAttachments).WithMany(p => p.AccountBankStatementImports)
                entity.HasMany<IrAttachment>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountBankStatementImportIrAttachmentRel",
                        r => r.HasOne<IrAttachment>().WithMany()
                            .HasForeignKey("IrAttachmentId")
                            .HasConstraintName("account_bank_statement_import_ir_attachme_ir_attachment_id_fkey"),
                        l => l.HasOne<AccountBankStatementImport>().WithMany()
                            .HasForeignKey("AccountBankStatementImportId")
                            .HasConstraintName("account_bank_statement_import_account_bank_statement_impor_fkey"),
                        j =>
                        {
                            j.HasKey("AccountBankStatementImportId", "IrAttachmentId").HasName("account_bank_statement_import_ir_attachment_rel_pkey");
                            j.ToTable("account_bank_statement_import_ir_attachment_rel");
                            j.HasIndex(new[] { "IrAttachmentId", "AccountBankStatementImportId" }, "account_bank_statement_import_ir_attachment_id_account_bank_idx");
                        });
            });
        }
    }
}