using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMailChannelMember(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailChannelMember>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mail_channel_member_pkey");

                        entity.ToTable("mail_channel_member");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.FetchedMessageId, "mail_channel_member_fetched_message_id_index").HasFilter("(fetched_message_id IS NOT NULL)");

                        entity.HasIndex(e => e.GuestId, "mail_channel_member_guest_id_index");

                        entity.HasIndex(e => new { e.ChannelId, e.GuestId }, "mail_channel_member_guest_unique")
                            .IsUnique()
                            .HasFilter("(guest_id IS NOT NULL)");

                        entity.HasIndex(e => e.PartnerId, "mail_channel_member_partner_id_index");

                        entity.HasIndex(e => new { e.ChannelId, e.PartnerId }, "mail_channel_member_partner_unique")
                            .IsUnique()
                            .HasFilter("(partner_id IS NOT NULL)");

                        entity.HasIndex(e => new { e.ChannelId, e.PartnerId, e.SeenMessageId }, "mail_channel_member_seen_message_id_idx");

                        entity.HasIndex(e => e.SeenMessageId, "mail_channel_member_seen_message_id_index").HasFilter("(seen_message_id IS NOT NULL)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.ChannelId).HasColumnName("channel_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CustomChannelName).HasColumnName("custom_channel_name");
                        entity.Property(e => e.FetchedMessageId).HasColumnName("fetched_message_id");
                        entity.Property(e => e.FoldState).HasColumnName("fold_state");
                        entity.Property(e => e.GuestId).HasColumnName("guest_id");
                        entity.Property(e => e.IsMinimized).HasColumnName("is_minimized");
                        entity.Property(e => e.IsPinned).HasColumnName("is_pinned");
                        entity.Property(e => e.LastInterestDt)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("last_interest_dt");
                        entity.Property(e => e.LastSeenDt)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("last_seen_dt");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.RtcInvitingSessionId).HasColumnName("rtc_inviting_session_id");
                        entity.Property(e => e.SeenMessageId).HasColumnName("seen_message_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Channel).WithMany(p => p.MailChannelMember)
                            .HasForeignKey(d => d.ChannelId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("mail_channel_member_channel_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MailChannelMemberCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_channel_member_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_channel_member_create_uid_fkey");

                        entity.HasOne(d => d.FetchedMessage).WithMany(p => p.MailChannelMemberFetchedMessage)
                            .HasForeignKey(d => d.FetchedMessageId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_channel_member_fetched_message_id_fkey");

                        entity.HasOne(d => d.Guest).WithMany()
                            .HasForeignKey(d => d.GuestId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("mail_channel_member_guest_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.MailChannelMember) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("mail_channel_member_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("mail_channel_member_partner_id_fkey");

                        entity.HasOne(d => d.RtcInvitingSession).WithMany(p => p.MailChannelMember)
                            .HasForeignKey(d => d.RtcInvitingSessionId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_channel_member_rtc_inviting_session_id_fkey");

                        entity.HasOne(d => d.SeenMessage).WithMany(p => p.MailChannelMemberSeenMessage)
                            .HasForeignKey(d => d.SeenMessageId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_channel_member_seen_message_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MailChannelMemberWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_channel_member_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_channel_member_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}