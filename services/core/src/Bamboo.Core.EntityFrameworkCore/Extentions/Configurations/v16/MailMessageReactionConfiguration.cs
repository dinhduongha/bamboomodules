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
        public static void ConfigureMailMessageReaction(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailMessageReaction>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mail_message_reaction_pkey");

            entity.ToTable("mail_message_reaction");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => new { e.MessageId, e.Content, e.GuestId }, "mail_message_reaction_guest_unique")
                .IsUnique()
                .HasFilter("(guest_id IS NOT NULL)");

            entity.HasIndex(e => new { e.MessageId, e.Content, e.PartnerId }, "mail_message_reaction_partner_unique")
                .IsUnique()
                .HasFilter("(partner_id IS NOT NULL)");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.GuestId).HasColumnName("guest_id");
            entity.Property(e => e.MessageId).HasColumnName("message_id");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");

            entity.HasOne(d => d.Guest).WithMany(p => p.MailMessageReaction)
                .HasForeignKey(d => d.GuestId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mail_message_reaction_guest_id_fkey");

            entity.HasOne(d => d.Message).WithMany(p => p.MailMessageReaction)
                .HasForeignKey(d => d.MessageId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mail_message_reaction_message_id_fkey");

            // entity.HasOne(d => d.Partner).WithMany(p => p.MailMessageReaction)
            entity.HasOne(d => d.Partner).WithMany()
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mail_message_reaction_partner_id_fkey");
            });
        }
    }
}