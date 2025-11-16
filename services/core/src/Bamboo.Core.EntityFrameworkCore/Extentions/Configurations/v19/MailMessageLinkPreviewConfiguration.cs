using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMailMessageLinkPreview(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailMessageLinkPreview>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mail_message_link_preview_pkey");

                        entity.ToTable("mail_message_link_preview");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.LinkPreviewId, "mail_message_link_preview__link_preview_id_index");

                        entity.HasIndex(e => e.MessageId, "mail_message_link_preview__message_id_index");

                        entity.HasIndex(e => new { e.MessageId, e.LinkPreviewId }, "mail_message_link_preview_unique_message_link_preview").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.IsHidden).HasColumnName("is_hidden");
                        entity.Property(e => e.LinkPreviewId).HasColumnName("link_preview_id");
                        entity.Property(e => e.MessageId).HasColumnName("message_id");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MailMessageLinkPreviewCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_message_link_preview_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_message_link_preview_create_uid_fkey");

                        entity.HasOne(d => d.LinkPreview).WithMany(p => p.MailMessageLinkPreview)
                            .HasForeignKey(d => d.LinkPreviewId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("mail_message_link_preview_link_preview_id_fkey");

                        entity.HasOne(d => d.Message).WithMany(p => p.MailMessageLinkPreview)
                            .HasForeignKey(d => d.MessageId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("mail_message_link_preview_message_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MailMessageLinkPreviewWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_message_link_preview_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_message_link_preview_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}