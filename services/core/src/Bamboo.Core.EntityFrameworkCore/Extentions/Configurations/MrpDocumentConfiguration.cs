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
        public static void ConfigureMrpDocument(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MrpDocument>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mrp_document_pkey");

                entity.ToTable("mrp_document");

                entity.HasIndex(e => e.TenantId, "mrp_document_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.IrAttachmentId).HasColumnName("ir_attachment_id");
                entity.Property(e => e.Priority).HasColumnName("priority");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_document_create_uid_fkey");

                entity.HasOne(d => d.IrAttachment).WithMany(p => p.MrpDocuments)
                    .HasForeignKey(d => d.IrAttachmentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("mrp_document_ir_attachment_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_document_write_uid_fkey");
            });
        }
    }
}