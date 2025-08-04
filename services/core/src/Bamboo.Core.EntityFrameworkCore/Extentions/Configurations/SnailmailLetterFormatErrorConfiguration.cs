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
        public static void ConfigureSnailmailLetterFormatError(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SnailmailLetterFormatError>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("snailmail_letter_format_error_pkey");

                entity.ToTable("snailmail_letter_format_error");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.MessageId).HasColumnName("message_id");
                entity.Property(e => e.SnailmailCover).HasColumnName("snailmail_cover");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("snailmail_letter_format_error_create_uid_fkey");

                entity.HasOne(d => d.Message).WithMany(p => p.SnailmailLetterFormatErrors)
                    .HasForeignKey(d => d.MessageId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("snailmail_letter_format_error_message_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("snailmail_letter_format_error_write_uid_fkey");
            });
        }
    }
}