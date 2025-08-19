using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMailGroupMessage(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailGroupMessage>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mail_group_message_pkey");

            entity.ToTable("mail_group_message");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.MailMessageId, "mail_group_message__mail_message_id_index");

            entity.HasIndex(e => e.ModerationStatus, "mail_group_message__moderation_status_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.EmailFromNormalized).HasColumnName("email_from_normalized");
            entity.Property(e => e.GroupMessageParentId).HasColumnName("group_message_parent_id");
            entity.Property(e => e.MailGroupId).HasColumnName("mail_group_id");
            entity.Property(e => e.MailMessageId).HasColumnName("mail_message_id");
            entity.Property(e => e.ModerationStatus).HasColumnName("moderation_status");
            entity.Property(e => e.ModeratorId).HasColumnName("moderator_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.MailGroupMessageCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_group_message_create_uid_fkey");

            entity.HasOne(d => d.GroupMessageParent).WithMany(p => p.InverseGroupMessageParent)
                .HasForeignKey(d => d.GroupMessageParentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_group_message_group_message_parent_id_fkey");

            entity.HasOne(d => d.MailGroup).WithMany(p => p.MailGroupMessage)
                .HasForeignKey(d => d.MailGroupId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mail_group_message_mail_group_id_fkey");

            entity.HasOne(d => d.MailMessage).WithMany(p => p.MailGroupMessage)
                .HasForeignKey(d => d.MailMessageId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mail_group_message_mail_message_id_fkey");

            entity.HasOne(d => d.Moderator).WithMany()
                .HasForeignKey(d => d.ModeratorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_group_message_moderator_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.MailGroupMessageWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_group_message_write_uid_fkey");
            });
        }
    }
}
