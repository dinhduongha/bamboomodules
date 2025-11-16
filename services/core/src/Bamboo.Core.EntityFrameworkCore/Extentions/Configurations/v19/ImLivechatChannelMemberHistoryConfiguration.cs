using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureImLivechatChannelMemberHistory(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ImLivechatChannelMemberHistory>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("im_livechat_channel_member_history_pkey");

                        entity.ToTable("im_livechat_channel_member_history");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.ChannelId, "im_livechat_channel_member_history__channel_id_index");

                        entity.HasIndex(e => e.ChatbotScriptId, "im_livechat_channel_member_history__chatbot_script_id_index").HasFilter("(chatbot_script_id IS NOT NULL)");

                        entity.HasIndex(e => e.GuestId, "im_livechat_channel_member_history__guest_id_index").HasFilter("(guest_id IS NOT NULL)");

                        entity.HasIndex(e => e.MemberId, "im_livechat_channel_member_history__member_id_index").HasFilter("(member_id IS NOT NULL)");

                        entity.HasIndex(e => e.PartnerId, "im_livechat_channel_member_history__partner_id_index").HasFilter("(partner_id IS NOT NULL)");

                        entity.HasIndex(e => new { e.ChannelId, e.GuestId }, "im_livechat_channel_member_history_channel_id_guest_id_unique")
                            .IsUnique()
                            .HasFilter("(guest_id IS NOT NULL)");

                        entity.HasIndex(e => new { e.ChannelId, e.PartnerId }, "im_livechat_channel_member_history_channel_id_partner_id_unique")
                            .IsUnique()
                            .HasFilter("(partner_id IS NOT NULL)");

                        entity.HasIndex(e => e.MemberId, "im_livechat_channel_member_history_member_id_unique").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CallDurationHour).HasColumnName("call_duration_hour");
                        entity.Property(e => e.ChannelId).HasColumnName("channel_id");
                        entity.Property(e => e.ChatbotScriptId).HasColumnName("chatbot_script_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.GuestId).HasColumnName("guest_id");
                        entity.Property(e => e.HasCall).HasColumnName("has_call");
                        entity.Property(e => e.HelpStatus).HasColumnName("help_status");
                        entity.Property(e => e.LivechatMemberType).HasColumnName("livechat_member_type");
                        entity.Property(e => e.MemberId).HasColumnName("member_id");
                        entity.Property(e => e.MessageCount).HasColumnName("message_count");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.RatingId).HasColumnName("rating_id");
                        entity.Property(e => e.ResponseTimeHour).HasColumnName("response_time_hour");
                        entity.Property(e => e.SessionDurationHour).HasColumnName("session_duration_hour");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Channel).WithMany(p => p.ImLivechatChannelMemberHistory)
                            .HasForeignKey(d => d.ChannelId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("im_livechat_channel_member_history_channel_id_fkey");

                        entity.HasOne(d => d.ChatbotScript).WithMany(p => p.ImLivechatChannelMemberHistory)
                            .HasForeignKey(d => d.ChatbotScriptId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("im_livechat_channel_member_history_chatbot_script_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ImLivechatChannelMemberHistoryCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("im_livechat_channel_member_history_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("im_livechat_channel_member_history_create_uid_fkey");

                        entity.HasOne(d => d.Guest).WithMany(p => p.ImLivechatChannelMemberHistory)
                            .HasForeignKey(d => d.GuestId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("im_livechat_channel_member_history_guest_id_fkey");

                        entity.HasOne(d => d.Member).WithOne(p => p.ImLivechatChannelMemberHistory)
                            .HasForeignKey<ImLivechatChannelMemberHistory>(d => d.MemberId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("im_livechat_channel_member_history_member_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.ImLivechatChannelMemberHistory) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("im_livechat_channel_member_history_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("im_livechat_channel_member_history_partner_id_fkey");

                        entity.HasOne(d => d.Rating).WithMany(p => p.ImLivechatChannelMemberHistory)
                            .HasForeignKey(d => d.RatingId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("im_livechat_channel_member_history_rating_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ImLivechatChannelMemberHistoryWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("im_livechat_channel_member_history_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("im_livechat_channel_member_history_write_uid_fkey");

                        // entity.HasMany(d => d.ImLivechatExpertise).WithMany(p => p.ImLivechatChannelMemberHistory)
                        entity.HasMany(d => d.ImLivechatExpertise).WithMany(p => p.ImLivechatChannelMemberHistory)
                            .UsingEntity<Dictionary<string, object>>(
                                "ImLivechatChannelMemberHistoryImLivechatExpertiseRel",
                                r => r.HasOne<ImLivechatExpertise>().WithMany()
                                    .HasForeignKey("ImLivechatExpertiseId")
                                    .HasConstraintName("im_livechat_channel_member_histor_im_livechat_expertise_id_fkey"),
                                l => l.HasOne<ImLivechatChannelMemberHistory>().WithMany()
                                    .HasForeignKey("ImLivechatChannelMemberHistoryId")
                                    .HasConstraintName("im_livechat_channel_member_hi_im_livechat_channel_member_h_fkey"),
                                j =>
                                {
                                    j.HasKey("ImLivechatChannelMemberHistoryId", "ImLivechatExpertiseId").HasName("im_livechat_channel_member_history_im_livechat_expertise_r_pkey");
                                    j.ToTable("im_livechat_channel_member_history_im_livechat_expertise_rel");
                                    j.HasIndex(new[] { "ImLivechatExpertiseId", "ImLivechatChannelMemberHistoryId" }, "im_livechat_channel_member_hi_im_livechat_expertise_id_im_l_idx");
                                    j.IndexerProperty<Guid>("ImLivechatChannelMemberHistoryId").HasColumnName("im_livechat_channel_member_history_id");
                                    j.IndexerProperty<Guid>("ImLivechatExpertiseId").HasColumnName("im_livechat_expertise_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}