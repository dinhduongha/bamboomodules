using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureResUsersSettingsEmbeddedAction(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ResUsersSettingsEmbeddedAction>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("res_users_settings_embedded_action_pkey");

                        entity.ToTable("res_users_settings_embedded_action");

                        entity.HasIndex(e => e.UserSettingId, "res_users_settings_embedded_action__user_setting_id_index").HasFilter("(user_setting_id IS NOT NULL)");

                        entity.HasIndex(e => new { e.UserSettingId, e.ActionId, e.ResId }, "res_users_settings_embedded_action_res_user_settings_e_91890fa3").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");
                        entity.Property(e => e.ActionId).HasColumnName("action_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.EmbeddedActionsOrder).HasColumnName("embedded_actions_order");
                        entity.Property(e => e.EmbeddedActionsVisibility).HasColumnName("embedded_actions_visibility");
                        entity.Property(e => e.EmbeddedVisibility).HasColumnName("embedded_visibility");
                        entity.Property(e => e.ResId).HasColumnName("res_id");
                        entity.Property(e => e.ResModel).HasColumnName("res_model");
                        entity.Property(e => e.UserSettingId).HasColumnName("user_setting_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Action).WithMany(p => p.ResUsersSettingsEmbeddedAction)
                            .HasForeignKey(d => d.ActionId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("res_users_settings_embedded_action_action_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ResUsersSettingsEmbeddedActionCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_users_settings_embedded_action_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_users_settings_embedded_action_create_uid_fkey");

                        entity.HasOne(d => d.UserSetting).WithMany(p => p.ResUsersSettingsEmbeddedAction)
                            .HasForeignKey(d => d.UserSettingId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("res_users_settings_embedded_action_user_setting_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ResUsersSettingsEmbeddedActionWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_users_settings_embedded_action_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_users_settings_embedded_action_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}