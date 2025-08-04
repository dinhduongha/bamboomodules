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
        public static void ConfigureMailMessageReaction(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailMessageReaction>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mail_message_reaction_pkey");

                entity.ToTable("mail_message_reaction");

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
                entity.Property(e => e.Content).HasColumnName("content");
                entity.Property(e => e.GuestId).HasColumnName("guest_id");
                entity.Property(e => e.MessageId).HasColumnName("message_id");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");

                entity.HasOne(d => d.Guest).WithMany(p => p.MailMessageReactions)
                    .HasForeignKey(d => d.GuestId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("mail_message_reaction_guest_id_fkey");

                entity.HasOne(d => d.Message).WithMany(p => p.MailMessageReactions)
                    .HasForeignKey(d => d.MessageId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("mail_message_reaction_message_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("mail_message_reaction_partner_id_fkey");
            });
        }
    }
}