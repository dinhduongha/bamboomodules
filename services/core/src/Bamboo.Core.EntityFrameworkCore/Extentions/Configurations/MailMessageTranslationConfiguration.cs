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
        public static void ConfigureMailMessageTranslation(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailMessageTranslation>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mail_message_translation_pkey");

                entity.ToTable("mail_message_translation");

                entity.HasIndex(e => e.CreationTime, "mail_message_translation__create_date_index");

                entity.HasIndex(e => new { e.MessageId, e.TargetLang }, "mail_message_translation_unique").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Body).HasColumnName("body");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.MessageId).HasColumnName("message_id");
                entity.Property(e => e.SourceLang).HasColumnName("source_lang");
                entity.Property(e => e.TargetLang).HasColumnName("target_lang");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_message_translation_create_uid_fkey");

                entity.HasOne(d => d.Message).WithMany()
                    .HasForeignKey(d => d.MessageId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("mail_message_translation_message_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_message_translation_write_uid_fkey");
            });
        }
    }
}