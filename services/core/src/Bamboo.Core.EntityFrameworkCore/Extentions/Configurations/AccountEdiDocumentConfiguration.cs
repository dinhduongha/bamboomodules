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
        public static void ConfigureAccountEdiDocument(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountEdiDocument>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_edi_document_pkey");

                entity.ToTable("account_edi_document");

                entity.HasIndex(e => e.TenantId, "account_edi_document_company_id_index");

                entity.HasIndex(e => new { e.TenantId, e.EdiFormatId, e.MoveId }, "account_edi_document_unique_edi_document_by_move_by_format").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AttachmentId).HasColumnName("attachment_id");
                entity.Property(e => e.BlockingLevel).HasColumnName("blocking_level");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.EdiFormatId).HasColumnName("edi_format_id");
                entity.Property(e => e.Error).HasColumnName("error");
                entity.Property(e => e.MoveId).HasColumnName("move_id");
                entity.Property(e => e.State).HasColumnName("state");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Attachment).WithMany(p => p.AccountEdiDocuments)
                    .HasForeignKey(d => d.AttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_edi_document_attachment_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_edi_document_create_uid_fkey");

                entity.HasOne(d => d.EdiFormat).WithMany(p => p.AccountEdiDocuments)
                    .HasForeignKey(d => d.EdiFormatId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_edi_document_edi_format_id_fkey");

                entity.HasOne(d => d.Move).WithMany(p => p.AccountEdiDocuments)
                    .HasForeignKey(d => d.MoveId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_edi_document_move_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_edi_document_write_uid_fkey");
            });
        }
    }
}