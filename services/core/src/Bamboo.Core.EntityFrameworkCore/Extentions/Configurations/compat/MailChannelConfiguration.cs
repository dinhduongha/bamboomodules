using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.LivechatChannelId, "mail_channel_livechat_channel_id_index").HasFilter("(livechat_channel_id IS NOT NULL)");

                        entity.HasIndex(e => e.LivechatVisitorId, "mail_channel_livechat_visitor_id_index").HasFilter("(livechat_visitor_id IS NOT NULL)");

                        entity.HasIndex(e => e.Uuid, "mail_channel_uuid_unique").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.AnonymousName).HasColumnName("anonymous_name");
                        entity.Property(e => e.ChannelType).HasColumnName("channel_type");
                        entity.Property(e => e.ChatbotCurrentStepId).HasColumnName("chatbot_current_step_id");
                        entity.Property(e => e.CountryId).HasColumnName("country_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DefaultDisplayMode).HasColumnName("default_display_mode");
                        entity.Property(e => e.Description).HasColumnName("description");
                        entity.Property(e => e.GroupPublicId).HasColumnName("group_public_id");
                        entity.Property(e => e.LivechatActive).HasColumnName("livechat_active");
                        entity.Property(e => e.LivechatChannelId).HasColumnName("livechat_channel_id");
                        entity.Property(e => e.LivechatOperatorId).HasColumnName("livechat_operator_id");
                        entity.Property(e => e.LivechatVisitorId).HasColumnName("livechat_visitor_id");
                        entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.RatingLastValue).HasColumnName("rating_last_value");
                        entity.Property(e => e.Uuid).HasColumnName("uuid");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.ChatbotCurrentStep).WithMany()
                            .HasForeignKey(d => d.ChatbotCurrentStepId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_channel_chatbot_current_step_id_fkey");

                        // entity.HasOne(d => d.Country).WithMany(p => p.MailChannel) .HasForeignKey(d => d.CountryId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_channel_country_id_fkey");
                        entity.HasOne(d => d.Country).WithMany()
                            .HasForeignKey(d => d.CountryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_channel_country_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MailChannelCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_channel_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_channel_create_uid_fkey");

                        entity.HasOne(d => d.GroupPublic).WithMany(p => p.MailChannel)
                            .HasForeignKey(d => d.GroupPublicId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_channel_group_public_id_fkey");

                        entity.HasOne(d => d.LivechatChannel).WithMany()
                            .HasForeignKey(d => d.LivechatChannelId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_channel_livechat_channel_id_fkey");

                        // entity.HasOne(d => d.LivechatOperator).WithMany(p => p.MailChannel) .HasForeignKey(d => d.LivechatOperatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_channel_livechat_operator_id_fkey");
                        entity.HasOne(d => d.LivechatOperator).WithMany()
                            .HasForeignKey(d => d.LivechatOperatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_channel_livechat_operator_id_fkey");

                        entity.HasOne(d => d.LivechatVisitor).WithMany()
                            .HasForeignKey(d => d.LivechatVisitorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_channel_livechat_visitor_id_fkey");

                        // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.MailChannel) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_channel_message_main_attachment_id_fkey");
                        entity.HasOne(d => d.MessageMainAttachment).WithMany()
                            .HasForeignKey(d => d.MessageMainAttachmentId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_channel_message_main_attachment_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MailChannelWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_channel_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_channel_write_uid_fkey");

                        // entity.HasMany(d => d.HrDepartment).WithMany(p => p.MailChannel)
                        entity.HasMany(d => d.HrDepartment).WithMany(p => p.MailChannel)
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
                                    j.IndexerProperty<Guid>("MailChannelId").HasColumnName("mail_channel_id");
                                    j.IndexerProperty<Guid>("HrDepartmentId").HasColumnName("hr_department_id");
                                });

                        // entity.HasMany(d => d.ResGroups).WithMany(p => p.MailChannelNavigation)
                        entity.HasMany(d => d.ResGroups).WithMany(p => p.MailChannelNavigation)
                            .UsingEntity<Dictionary<string, object>>(
                                "MailChannelResGroupsRel",
                                r => r.HasOne<ResGroups>().WithMany()
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
                                    j.IndexerProperty<Guid>("MailChannelId").HasColumnName("mail_channel_id");
                                    j.IndexerProperty<Guid>("ResGroupsId").HasColumnName("res_groups_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}