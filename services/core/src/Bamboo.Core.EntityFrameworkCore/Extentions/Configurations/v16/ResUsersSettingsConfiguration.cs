using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureResUsersSettings(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ResUsersSettings>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("res_users_settings_pkey");

                        entity.ToTable("res_users_settings");

                        entity.HasIndex(e => e.MuteUntilDt, "res_users_settings__mute_until_dt_index");

                        entity.HasIndex(e => e.UserId, "res_users_settings_unique_user_id").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");
                        entity.Property(e => e.CalendarDefaultPrivacy).HasColumnName("calendar_default_privacy");
                        entity.Property(e => e.ChannelNotifications).HasColumnName("channel_notifications");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.GoogleCalendarCalId).HasColumnName("google_calendar_cal_id");
                        entity.Property(e => e.GoogleCalendarRtoken).HasColumnName("google_calendar_rtoken");
                        entity.Property(e => e.GoogleCalendarSyncToken).HasColumnName("google_calendar_sync_token");
                        entity.Property(e => e.GoogleCalendarToken).HasColumnName("google_calendar_token");
                        entity.Property(e => e.GoogleCalendarTokenValidity)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("google_calendar_token_validity");
                        entity.Property(e => e.GoogleSynchronizationStopped).HasColumnName("google_synchronization_stopped");
                        entity.Property(e => e.IsDiscussSidebarCategoryChannelOpen).HasColumnName("is_discuss_sidebar_category_channel_open");
                        entity.Property(e => e.IsDiscussSidebarCategoryChatOpen).HasColumnName("is_discuss_sidebar_category_chat_open");
                        entity.Property(e => e.LivechatUsername).HasColumnName("livechat_username");
                        entity.Property(e => e.MicrosoftCalendarSyncToken).HasColumnName("microsoft_calendar_sync_token");
                        entity.Property(e => e.MicrosoftLastSyncDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("microsoft_last_sync_date");
                        entity.Property(e => e.MicrosoftSynchronizationStopped).HasColumnName("microsoft_synchronization_stopped");
                        entity.Property(e => e.MuteUntilDt)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("mute_until_dt");
                        entity.Property(e => e.PushToTalkKey).HasColumnName("push_to_talk_key");
                        entity.Property(e => e.UsePushToTalk).HasColumnName("use_push_to_talk");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.VoiceActiveDuration).HasColumnName("voice_active_duration");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ResUsersSettingsCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_users_settings_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_users_settings_create_uid_fkey");

                        // entity.HasOne(d => d.User).WithOne(p => p.ResUsersSettingsUser) .HasForeignKey<ResUsersSettings>(d => d.UserId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("res_users_settings_user_id_fkey");
                        entity.HasOne(d => d.User).WithOne(p => p.ResUsersSettingsUser)
                            .HasForeignKey<ResUsersSettings>(d => d.UserId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("res_users_settings_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ResUsersSettingsWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_users_settings_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_users_settings_write_uid_fkey");

                        // entity.HasMany(d => d.ResLang).WithMany(p => p.ResUsersSettings)
                        entity.HasMany(d => d.ResLang).WithMany(p => p.ResUsersSettings)
                            .UsingEntity<Dictionary<string, object>>(
                                "ResLangResUsersSettingsRel",
                                r => r.HasOne<ResLang>().WithMany()
                                    .HasForeignKey("ResLangId")
                                    .HasConstraintName("res_lang_res_users_settings_rel_res_lang_id_fkey"),
                                l => l.HasOne<ResUsersSettings>().WithMany()
                                    .HasForeignKey("ResUsersSettingsId")
                                    .HasConstraintName("res_lang_res_users_settings_rel_res_users_settings_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ResUsersSettingsId", "ResLangId").HasName("res_lang_res_users_settings_rel_pkey");
                                    j.ToTable("res_lang_res_users_settings_rel");
                                    j.HasIndex(new[] { "ResLangId", "ResUsersSettingsId" }, "res_lang_res_users_settings_r_res_lang_id_res_users_setting_idx");
                                    j.IndexerProperty<Guid>("ResUsersSettingsId").HasColumnName("res_users_settings_id");
                                    j.IndexerProperty<Guid>("ResLangId").HasColumnName("res_lang_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}