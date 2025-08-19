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
        public static void ConfigureMailGroupMessageReject(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailGroupMessageReject>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mail_group_message_reject_pkey");

            entity.ToTable("mail_group_message_reject");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Action).HasColumnName("action");
            entity.Property(e => e.Body).HasColumnName("body");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.MailGroupMessageId).HasColumnName("mail_group_message_id");
            entity.Property(e => e.Subject).HasColumnName("subject");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.MailGroupMessageRejectCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_group_message_reject_create_uid_fkey");

            entity.HasOne(d => d.MailGroupMessage).WithMany(p => p.MailGroupMessageReject)
                .HasForeignKey(d => d.MailGroupMessageId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mail_group_message_reject_mail_group_message_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.MailGroupMessageRejectWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_group_message_reject_write_uid_fkey");
            });
        }
    }
}