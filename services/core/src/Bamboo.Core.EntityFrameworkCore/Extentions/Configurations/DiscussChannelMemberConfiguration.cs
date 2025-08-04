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
        public static void ConfigureDiscussChannelMember(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiscussChannelMember>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("discuss_channel_member_pkey");

                entity.ToTable("discuss_channel_member");

                entity.HasIndex(e => e.FetchedMessageId, "discuss_channel_member__fetched_message_id_index").HasFilter("(fetched_message_id IS NOT NULL)");

                entity.HasIndex(e => e.GuestId, "discuss_channel_member__guest_id_index");

                entity.HasIndex(e => e.LastInterestDt, "discuss_channel_member__last_interest_dt_index");

                entity.HasIndex(e => e.PartnerId, "discuss_channel_member__partner_id_index");

                entity.HasIndex(e => e.SeenMessageId, "discuss_channel_member__seen_message_id_index").HasFilter("(seen_message_id IS NOT NULL)");

                entity.HasIndex(e => e.UnpinDt, "discuss_channel_member__unpin_dt_index");

                entity.HasIndex(e => new { e.ChannelId, e.GuestId }, "discuss_channel_member_guest_unique")
                    .IsUnique()
                    .HasFilter("(guest_id IS NOT NULL)");

                entity.HasIndex(e => new { e.ChannelId, e.PartnerId }, "discuss_channel_member_partner_unique")
                    .IsUnique()
                    .HasFilter("(partner_id IS NOT NULL)");

                entity.HasIndex(e => new { e.ChannelId, e.PartnerId, e.SeenMessageId }, "discuss_channel_member_seen_message_id_idx");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.ChannelId).HasColumnName("channel_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.CustomChannelName).HasColumnName("custom_channel_name");
                entity.Property(e => e.CustomNotifications).HasColumnName("custom_notifications");
                entity.Property(e => e.FetchedMessageId).HasColumnName("fetched_message_id");
                entity.Property(e => e.FoldState).HasColumnName("fold_state");
                entity.Property(e => e.GuestId).HasColumnName("guest_id");
                entity.Property(e => e.LastInterestDt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("last_interest_dt");
                entity.Property(e => e.LastSeenDt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("last_seen_dt");
                entity.Property(e => e.MuteUntilDt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("mute_until_dt");
                entity.Property(e => e.NewMessageSeparator).HasColumnName("new_message_separator");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.RtcInvitingSessionId).HasColumnName("rtc_inviting_session_id");
                entity.Property(e => e.SeenMessageId).HasColumnName("seen_message_id");
                entity.Property(e => e.UnpinDt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("unpin_dt");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Channel).WithMany(p => p.DiscussChannelMembers)
                    .HasForeignKey(d => d.ChannelId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("discuss_channel_member_channel_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("discuss_channel_member_create_uid_fkey");

                entity.HasOne(d => d.FetchedMessage).WithMany()
                    .HasForeignKey(d => d.FetchedMessageId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("discuss_channel_member_fetched_message_id_fkey");

                entity.HasOne(d => d.Guest).WithMany()
                    .HasForeignKey(d => d.GuestId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("discuss_channel_member_guest_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("discuss_channel_member_partner_id_fkey");

                entity.HasOne(d => d.RtcInvitingSession).WithMany(p => p.DiscussChannelMembers)
                    .HasForeignKey(d => d.RtcInvitingSessionId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("discuss_channel_member_rtc_inviting_session_id_fkey");

                entity.HasOne(d => d.SeenMessage).WithMany()
                    .HasForeignKey(d => d.SeenMessageId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("discuss_channel_member_seen_message_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("discuss_channel_member_write_uid_fkey");
            });
        }
    }
}