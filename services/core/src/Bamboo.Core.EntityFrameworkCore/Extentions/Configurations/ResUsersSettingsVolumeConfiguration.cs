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
        public static void ConfigureResUsersSettingsVolume(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResUsersSettingsVolume>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("res_users_settings_volumes_pkey");

                entity.ToTable("res_users_settings_volumes");

                entity.HasIndex(e => e.TenantId, "res_users_settings_volumes_company_id_index");

                entity.HasIndex(e => e.GuestId, "res_users_settings_volumes_guest_id_index");

                entity.HasIndex(e => new { e.TenantId, e.UserSettingId, e.GuestId }, "res_users_settings_volumes_guest_unique")
                    .IsUnique()
                    .HasFilter("(guest_id IS NOT NULL)");

                entity.HasIndex(e => e.PartnerId, "res_users_settings_volumes_partner_id_index");

                entity.HasIndex(e => new { e.TenantId, e.UserSettingId, e.PartnerId }, "res_users_settings_volumes_partner_unique")
                    .IsUnique()
                    .HasFilter("(partner_id IS NOT NULL)");

                entity.HasIndex(e => e.UserSettingId, "res_users_settings_volumes_user_setting_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.GuestId).HasColumnName("guest_id");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.UserSettingId).HasColumnName("user_setting_id");
                entity.Property(e => e.Volume).HasColumnName("volume");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_users_settings_volumes_create_uid_fkey");

                entity.HasOne(d => d.Guest).WithMany(p => p.ResUsersSettingsVolumeGuests)
                    .HasForeignKey(d => d.GuestId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("res_users_settings_volumes_guest_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("res_users_settings_volumes_partner_id_fkey");

                entity.HasOne(d => d.UserSetting).WithMany(p => p.ResUsersSettingsVolumes)
                    .HasForeignKey(d => d.UserSettingId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("res_users_settings_volumes_user_setting_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_users_settings_volumes_write_uid_fkey");
            });
        }
    }
}