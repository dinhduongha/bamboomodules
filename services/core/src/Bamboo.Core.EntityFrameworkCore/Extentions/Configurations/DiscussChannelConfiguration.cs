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
        public static void ConfigureDiscussChannel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiscussChannel>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("discuss_channel_pkey");

                entity.ToTable("discuss_channel");

                entity.HasIndex(e => e.LastInterestDt, "discuss_channel__last_interest_dt_index");

                entity.HasIndex(e => e.LivechatChannelId, "discuss_channel__livechat_channel_id_index").HasFilter("(livechat_channel_id IS NOT NULL)");

                entity.HasIndex(e => e.LivechatOperatorId, "discuss_channel__livechat_operator_id_index").HasFilter("(livechat_operator_id IS NOT NULL)");

                entity.HasIndex(e => e.LivechatVisitorId, "discuss_channel__livechat_visitor_id_index").HasFilter("(livechat_visitor_id IS NOT NULL)");

                entity.HasIndex(e => e.ParentChannelId, "discuss_channel__parent_channel_id_index");

                entity.HasIndex(e => e.FromMessageId, "discuss_channel_from_message_id_unique").IsUnique();

                entity.HasIndex(e => e.Uuid, "discuss_channel_uuid_unique").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.AllowPublicUpload).HasColumnName("allow_public_upload");
                entity.Property(e => e.AnonymousName).HasColumnName("anonymous_name");
                entity.Property(e => e.ChannelType).HasColumnName("channel_type");
                entity.Property(e => e.ChatbotCurrentStepId).HasColumnName("chatbot_current_step_id");
                entity.Property(e => e.CountryId).HasColumnName("country_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DefaultDisplayMode).HasColumnName("default_display_mode");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.FromMessageId).HasColumnName("from_message_id");
                entity.Property(e => e.GroupPublicId).HasColumnName("group_public_id");
                entity.Property(e => e.LastInterestDt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("last_interest_dt");
                entity.Property(e => e.LivechatActive).HasColumnName("livechat_active");
                entity.Property(e => e.LivechatChannelId).HasColumnName("livechat_channel_id");
                entity.Property(e => e.LivechatOperatorId).HasColumnName("livechat_operator_id");
                entity.Property(e => e.LivechatVisitorId).HasColumnName("livechat_visitor_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.ParentChannelId).HasColumnName("parent_channel_id");
                entity.Property(e => e.RatingLastValue).HasColumnName("rating_last_value");
                entity.Property(e => e.SfuChannelUuid).HasColumnName("sfu_channel_uuid");
                entity.Property(e => e.SfuServerUrl).HasColumnName("sfu_server_url");
                entity.Property(e => e.Uuid).HasColumnName("uuid");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.ChatbotCurrentStep).WithMany(p => p.DiscussChannels)
                    .HasForeignKey(d => d.ChatbotCurrentStepId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("discuss_channel_chatbot_current_step_id_fkey");

                entity.HasOne<ResCountry>().WithMany()
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("discuss_channel_country_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("discuss_channel_create_uid_fkey");

                entity.HasOne(d => d.FromMessage).WithOne()
                    .HasForeignKey<DiscussChannel>(d => d.FromMessageId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("discuss_channel_from_message_id_fkey");

                entity.HasOne(d => d.GroupPublic).WithMany()
                    .HasForeignKey(d => d.GroupPublicId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("discuss_channel_group_public_id_fkey");

                entity.HasOne(d => d.LivechatChannel).WithMany(p => p.DiscussChannels)
                    .HasForeignKey(d => d.LivechatChannelId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("discuss_channel_livechat_channel_id_fkey");

                entity.HasOne(d => d.LivechatOperator).WithMany()
                    .HasForeignKey(d => d.LivechatOperatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("discuss_channel_livechat_operator_id_fkey");

                entity.HasOne(d => d.LivechatVisitor).WithMany(p => p.DiscussChannels)
                    .HasForeignKey(d => d.LivechatVisitorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("discuss_channel_livechat_visitor_id_fkey");

                entity.HasOne(d => d.ParentChannel).WithMany(p => p.InverseParentChannel)
                    .HasForeignKey(d => d.ParentChannelId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("discuss_channel_parent_channel_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("discuss_channel_write_uid_fkey");

                entity.HasMany(d => d.HrDepartments).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "DiscussChannelHrDepartmentRel",
                        r => r.HasOne<HrDepartment>().WithMany()
                            .HasForeignKey("HrDepartmentId")
                            .HasConstraintName("discuss_channel_hr_department_rel_hr_department_id_fkey"),
                        l => l.HasOne<DiscussChannel>().WithMany()
                            .HasForeignKey("DiscussChannelId")
                            .HasConstraintName("discuss_channel_hr_department_rel_discuss_channel_id_fkey"),
                        j =>
                        {
                            j.HasKey("DiscussChannelId", "HrDepartmentId").HasName("discuss_channel_hr_department_rel_pkey");
                            j.ToTable("discuss_channel_hr_department_rel");
                            j.HasIndex(new[] { "HrDepartmentId", "DiscussChannelId" }, "discuss_channel_hr_department_hr_department_id_discuss_chan_idx");
                            j.IndexerProperty<Guid>("DiscussChannelId").HasColumnName("discuss_channel_id");
                            j.IndexerProperty<Guid>("HrDepartmentId").HasColumnName("hr_department_id");
                        });

                entity.HasMany(d => d.ResGroups).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "DiscussChannelResGroupsRel",
                        r => r.HasOne<ResGroup>().WithMany()
                            .HasForeignKey("ResGroupsId")
                            .HasConstraintName("discuss_channel_res_groups_rel_res_groups_id_fkey"),
                        l => l.HasOne<DiscussChannel>().WithMany()
                            .HasForeignKey("DiscussChannelId")
                            .HasConstraintName("discuss_channel_res_groups_rel_discuss_channel_id_fkey"),
                        j =>
                        {
                            j.HasKey("DiscussChannelId", "ResGroupsId").HasName("discuss_channel_res_groups_rel_pkey");
                            j.ToTable("discuss_channel_res_groups_rel");
                            j.HasIndex(new[] { "ResGroupsId", "DiscussChannelId" }, "discuss_channel_res_groups_re_res_groups_id_discuss_channel_idx");
                            j.IndexerProperty<Guid>("DiscussChannelId").HasColumnName("discuss_channel_id");
                            j.IndexerProperty<Guid>("ResGroupsId").HasColumnName("res_groups_id");
                        });
            });
        }
    }
}