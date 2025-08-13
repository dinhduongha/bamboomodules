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
        public static void ConfigureResUsersSettings(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResUsersSettings>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("res_users_settings_pkey");

                entity.ToTable("res_users_settings");


                entity.HasIndex(e => e.TenantId, "res_users_settings_company_id_index");

                entity.HasIndex(e => new { e.TenantId, e.UserId }, "res_users_settings_unique_user_id").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.IsDiscussSidebarCategoryChannelOpen).HasColumnName("is_discuss_sidebar_category_channel_open");
                entity.Property(e => e.IsDiscussSidebarCategoryChatOpen).HasColumnName("is_discuss_sidebar_category_chat_open");
                entity.Property(e => e.PushToTalkKey).HasColumnName("push_to_talk_key");
                entity.Property(e => e.UsePushToTalk).HasColumnName("use_push_to_talk");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.VoiceActiveDuration).HasColumnName("voice_active_duration");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_users_settings_create_uid_fkey");

                entity.HasOne(d => d.User).WithOne(p => p.ResUsersSettingUser)
                    .HasForeignKey<ResUsersSettings>(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("res_users_settings_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_users_settings_write_uid_fkey");

                //entity.HasMany(d => d.ResLangs).WithMany(p => p.ResUsersSettings)
                entity.HasMany<ResLang>().WithMany()
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
            });
        }
    }
}