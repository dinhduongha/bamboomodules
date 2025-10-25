using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.MoveId, "account_edi_document__move_id_index");

                        entity.HasIndex(e => new { e.EdiFormatId, e.MoveId }, "account_edi_document_unique_edi_document_by_move_by_format").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AttachmentId).HasColumnName("attachment_id");
                        entity.Property(e => e.BlockingLevel).HasColumnName("blocking_level");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
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

                        // entity.HasOne(d => d.Attachment).WithMany(p => p.AccountEdiDocument) .HasForeignKey(d => d.AttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_edi_document_attachment_id_fkey");
                        entity.HasOne(d => d.Attachment).WithMany()
                            .HasForeignKey(d => d.AttachmentId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_edi_document_attachment_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountEdiDocumentCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_edi_document_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_edi_document_create_uid_fkey");

                        entity.HasOne(d => d.EdiFormat).WithMany(p => p.AccountEdiDocument)
                            .HasForeignKey(d => d.EdiFormatId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_edi_document_edi_format_id_fkey");

                        entity.HasOne(d => d.Move).WithMany(p => p.AccountEdiDocument)
                            .HasForeignKey(d => d.MoveId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("account_edi_document_move_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountEdiDocumentWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_edi_document_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_edi_document_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}