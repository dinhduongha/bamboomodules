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
        public static void ConfigureMailChannel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailChannel>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mail_channel_pkey");

                entity.ToTable("mail_channel");

                entity.HasIndex(e => e.Uuid, "mail_channel_uuid_unique").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.ChannelType).HasColumnName("channel_type");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DefaultDisplayMode).HasColumnName("default_display_mode");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.GroupPublicId).HasColumnName("group_public_id");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Uuid).HasColumnName("uuid");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_channel_create_uid_fkey");

                entity.HasOne(d => d.GroupPublic).WithMany(p => p.MailChannels)
                    .HasForeignKey(d => d.GroupPublicId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_channel_group_public_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.MailChannels)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_channel_message_main_attachment_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_channel_write_uid_fkey");

                //entity.HasMany(d => d.HrDepartments).WithMany(p => p.MailChannels)
                entity.HasMany<HrDepartment>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "HrDepartmentMailChannelRel",
                        r => r.HasOne<HrDepartment>().WithMany()
                            .HasForeignKey("HrDepartmentId")
                            .HasConstraintName("hr_department_mail_channel_rel_hr_department_id_fkey"),
                        l => l.HasOne<MailChannel>().WithMany()
                            .HasForeignKey("MailChannelId")
                            .HasConstraintName("hr_department_mail_channel_rel_mail_channel_id_fkey"),
                        j =>
                        {
                            j.HasKey("MailChannelId", "HrDepartmentId").HasName("hr_department_mail_channel_rel_pkey");
                            j.ToTable("hr_department_mail_channel_rel");
                            j.HasIndex(new[] { "HrDepartmentId", "MailChannelId" }, "hr_department_mail_channel_re_hr_department_id_mail_channel_idx");
                        });

                //entity.HasMany(d => d.ResGroups).WithMany(p => p.MailChannelsNavigation)
                entity.HasMany<ResGroup>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "MailChannelResGroupsRel",
                        r => r.HasOne<ResGroup>().WithMany()
                            .HasForeignKey("ResGroupsId")
                            .HasConstraintName("mail_channel_res_groups_rel_res_groups_id_fkey"),
                        l => l.HasOne<MailChannel>().WithMany()
                            .HasForeignKey("MailChannelId")
                            .HasConstraintName("mail_channel_res_groups_rel_mail_channel_id_fkey"),
                        j =>
                        {
                            j.HasKey("MailChannelId", "ResGroupsId").HasName("mail_channel_res_groups_rel_pkey");
                            j.ToTable("mail_channel_res_groups_rel");
                            j.HasIndex(new[] { "ResGroupsId", "MailChannelId" }, "mail_channel_res_groups_rel_res_groups_id_mail_channel_id_idx");
                        });
            });
        }
    }
}