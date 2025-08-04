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
        public static void ConfigureSlideChannel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SlideChannel>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("slide_channel_pkey");

                entity.ToTable("slide_channel", tb => tb.HasComment("Course"));

                entity.HasIndex(e => e.IsPublished, "slide_channel_is_published_index");

                entity.HasIndex(e => e.WebsiteId, "slide_channel_website_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AccessToken)
                    .HasComment("Security Token")
                    .HasColumnType("character varying")
                    .HasColumnName("access_token");
                entity.Property(e => e.Active)
                    .HasComment("Active")
                    .HasColumnName("active");
                entity.Property(e => e.AllowComment)
                    .HasComment("Allow rating on Course")
                    .HasColumnName("allow_comment");
                entity.Property(e => e.ChannelType)
                    .HasComment("Course type")
                    .HasColumnType("character varying")
                    .HasColumnName("channel_type");
                entity.Property(e => e.Color)
                    .HasComment("Color Index")
                    .HasColumnName("color");
                entity.Property(e => e.CompletedTemplateId)
                    .HasComment("Completion Notification")
                    .HasColumnName("completed_template_id");
                entity.Property(e => e.CoverProperties)
                    .HasComment("Cover Properties")
                    .HasColumnName("cover_properties");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.Description)
                    .HasComment("Description")
                    .HasColumnType("jsonb")
                    .HasColumnName("description");
                entity.Property(e => e.DescriptionHtml)
                    .HasComment("Detailed Description")
                    .HasColumnType("jsonb")
                    .HasColumnName("description_html");
                entity.Property(e => e.DescriptionShort)
                    .HasComment("Short Description")
                    .HasColumnType("jsonb")
                    .HasColumnName("description_short");
                entity.Property(e => e.Enroll)
                    .HasComment("Enroll Policy")
                    .HasColumnType("character varying")
                    .HasColumnName("enroll");
                entity.Property(e => e.EnrollMsg)
                    .HasComment("Enroll Message")
                    .HasColumnType("jsonb")
                    .HasColumnName("enroll_msg");
                entity.Property(e => e.IsPublished)
                    .HasComment("Is Published")
                    .HasColumnName("is_published");
                entity.Property(e => e.KarmaGenChannelFinish)
                    .HasComment("Course finished")
                    .HasColumnName("karma_gen_channel_finish");
                entity.Property(e => e.KarmaGenChannelRank)
                    .HasComment("Course ranked")
                    .HasColumnName("karma_gen_channel_rank");
                entity.Property(e => e.KarmaGenSlideVote)
                    .HasComment("Lesson voted")
                    .HasColumnName("karma_gen_slide_vote");
                entity.Property(e => e.KarmaReview)
                    .HasComment("Add Review")
                    .HasColumnName("karma_review");
                entity.Property(e => e.KarmaSlideComment)
                    .HasComment("Add Comment")
                    .HasColumnName("karma_slide_comment");
                entity.Property(e => e.KarmaSlideVote)
                    .HasComment("Vote")
                    .HasColumnName("karma_slide_vote");
                entity.Property(e => e.MessageMainAttachmentId)
                    .HasComment("Main Attachment")
                    .HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Name)
                    .HasComment("Name")
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.NbrArticle)
                    .HasComment("Articles")
                    .HasColumnName("nbr_article");
                entity.Property(e => e.NbrCertification)
                    .HasComment("Number of Certifications")
                    .HasColumnName("nbr_certification");
                entity.Property(e => e.NbrDocument)
                    .HasComment("Documents")
                    .HasColumnName("nbr_document");
                entity.Property(e => e.NbrInfographic)
                    .HasComment("Infographics")
                    .HasColumnName("nbr_infographic");
                entity.Property(e => e.NbrQuiz)
                    .HasComment("Number of Quizs")
                    .HasColumnName("nbr_quiz");
                entity.Property(e => e.NbrVideo)
                    .HasComment("Videos")
                    .HasColumnName("nbr_video");
                entity.Property(e => e.PromoteStrategy)
                    .HasComment("Featured Content")
                    .HasColumnType("character varying")
                    .HasColumnName("promote_strategy");
                entity.Property(e => e.PromotedSlideId)
                    .HasComment("Promoted Slide")
                    .HasColumnName("promoted_slide_id");
                entity.Property(e => e.PublishTemplateId)
                    .HasComment("New Content Notification")
                    .HasColumnName("publish_template_id");
                entity.Property(e => e.RatingLastValue)
                    .HasComment("Rating Last Value")
                    .HasColumnName("rating_last_value");
                entity.Property(e => e.SeoName)
                    .HasComment("Seo name")
                    .HasColumnType("jsonb")
                    .HasColumnName("seo_name");
                entity.Property(e => e.Sequence)
                    .HasComment("Sequence")
                    .HasColumnName("sequence");
                entity.Property(e => e.ShareChannelTemplateId)
                    .HasComment("Channel Share Template")
                    .HasColumnName("share_channel_template_id");
                entity.Property(e => e.ShareSlideTemplateId)
                    .HasComment("Share Template")
                    .HasColumnName("share_slide_template_id");
                entity.Property(e => e.SlideLastUpdate)
                    .HasComment("Last Update")
                    .HasColumnName("slide_last_update");
                entity.Property(e => e.TotalSlides)
                    .HasComment("Number of Contents")
                    .HasColumnName("total_slides");
                entity.Property(e => e.TotalTime)
                    .HasComment("Duration")
                    .HasColumnName("total_time");
                entity.Property(e => e.TotalViews)
                    .HasComment("Visits")
                    .HasColumnName("total_views");
                entity.Property(e => e.TotalVotes)
                    .HasComment("Votes")
                    .HasColumnName("total_votes");
                entity.Property(e => e.UserId)
                    .HasComment("Responsible")
                    .HasColumnName("user_id");
                entity.Property(e => e.Visibility)
                    .HasComment("Visibility")
                    .HasColumnType("character varying")
                    .HasColumnName("visibility");
                entity.Property(e => e.WebsiteId)
                    .HasComment("Website")
                    .HasColumnName("website_id");
                entity.Property(e => e.WebsiteMetaDescription)
                    .HasComment("Website meta description")
                    .HasColumnType("jsonb")
                    .HasColumnName("website_meta_description");
                entity.Property(e => e.WebsiteMetaKeywords)
                    .HasComment("Website meta keywords")
                    .HasColumnType("jsonb")
                    .HasColumnName("website_meta_keywords");
                entity.Property(e => e.WebsiteMetaOgImg)
                    .HasComment("Website opengraph image")
                    .HasColumnType("character varying")
                    .HasColumnName("website_meta_og_img");
                entity.Property(e => e.WebsiteMetaTitle)
                    .HasComment("Website meta title")
                    .HasColumnType("jsonb")
                    .HasColumnName("website_meta_title");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne(d => d.CompletedTemplate).WithMany()
                    .HasForeignKey(d => d.CompletedTemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_channel_completed_template_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_channel_create_uid_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_channel_message_main_attachment_id_fkey");

                entity.HasOne(d => d.PromotedSlide).WithMany(p => p.SlideChannels)
                    .HasForeignKey(d => d.PromotedSlideId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_channel_promoted_slide_id_fkey");

                entity.HasOne(d => d.PublishTemplate).WithMany()
                    .HasForeignKey(d => d.PublishTemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_channel_publish_template_id_fkey");

                entity.HasOne(d => d.ShareChannelTemplate).WithMany()
                    .HasForeignKey(d => d.ShareChannelTemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_channel_share_channel_template_id_fkey");

                entity.HasOne(d => d.ShareSlideTemplate).WithMany()
                    .HasForeignKey(d => d.ShareSlideTemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_channel_share_slide_template_id_fkey");

                entity.HasOne(d => d.User).WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_channel_user_id_fkey");

                entity.HasOne(d => d.Website).WithMany()
                    .HasForeignKey(d => d.WebsiteId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("slide_channel_website_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_channel_write_uid_fkey");

                //entity.HasMany(d => d.Channels).WithMany(p => p.PrerequisiteChannels)
                entity.HasMany<SlideChannel>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "SlideChannelPrerequisiteSlideChannelRel",
                        r => r.HasOne<SlideChannel>().WithMany()
                            .HasForeignKey("ChannelId")
                            .HasConstraintName("slide_channel_prerequisite_slide_channel_rel_channel_id_fkey"),
                        l => l.HasOne<SlideChannel>().WithMany()
                            .HasForeignKey("PrerequisiteChannelId")
                            .HasConstraintName("slide_channel_prerequisite_slide_c_prerequisite_channel_id_fkey"),
                        j =>
                        {
                            j.HasKey("ChannelId", "PrerequisiteChannelId").HasName("slide_channel_prerequisite_slide_channel_rel_pkey");
                            j.ToTable("slide_channel_prerequisite_slide_channel_rel");
                            j.HasIndex(new[] { "PrerequisiteChannelId", "ChannelId" }, "slide_channel_prerequisite_sl_prerequisite_channel_id_chann_idx");
                            j.IndexerProperty<Guid>("ChannelId").HasColumnName("channel_id");
                            j.IndexerProperty<Guid>("PrerequisiteChannelId").HasColumnName("prerequisite_channel_id");
                        });

                entity.HasMany(d => d.Groups).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "RelUploadGroup",
                        r => r.HasOne<ResGroup>().WithMany()
                            .HasForeignKey("GroupId")
                            .HasConstraintName("rel_upload_groups_group_id_fkey"),
                        l => l.HasOne<SlideChannel>().WithMany()
                            .HasForeignKey("ChannelId")
                            .HasConstraintName("rel_upload_groups_channel_id_fkey"),
                        j =>
                        {
                            j.HasKey("ChannelId", "GroupId").HasName("rel_upload_groups_pkey");
                            j.ToTable("rel_upload_groups", tb => tb.HasComment("RELATION BETWEEN slide_channel AND res_groups"));
                            j.HasIndex(new[] { "GroupId", "ChannelId" }, "rel_upload_groups_group_id_channel_id_idx");
                            j.IndexerProperty<Guid>("ChannelId").HasColumnName("channel_id");
                            j.IndexerProperty<Guid>("GroupId").HasColumnName("group_id");
                        });

                entity.HasMany(d => d.ResGroups).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ResGroupsSlideChannelRel",
                        r => r.HasOne<ResGroup>().WithMany()
                            .HasForeignKey("ResGroupsId")
                            .HasConstraintName("res_groups_slide_channel_rel_res_groups_id_fkey"),
                        l => l.HasOne<SlideChannel>().WithMany()
                            .HasForeignKey("SlideChannelId")
                            .HasConstraintName("res_groups_slide_channel_rel_slide_channel_id_fkey"),
                        j =>
                        {
                            j.HasKey("SlideChannelId", "ResGroupsId").HasName("res_groups_slide_channel_rel_pkey");
                            j.ToTable("res_groups_slide_channel_rel", tb => tb.HasComment("RELATION BETWEEN slide_channel AND res_groups"));
                            j.HasIndex(new[] { "ResGroupsId", "SlideChannelId" }, "res_groups_slide_channel_rel_res_groups_id_slide_channel_id_idx");
                            j.IndexerProperty<Guid>("SlideChannelId").HasColumnName("slide_channel_id");
                            j.IndexerProperty<Guid>("ResGroupsId").HasColumnName("res_groups_id");
                        });

                entity.HasMany(d => d.Tags).WithMany(p => p.Channels)
                    .UsingEntity<Dictionary<string, object>>(
                        "SlideChannelTagRel",
                        r => r.HasOne<SlideChannelTag>().WithMany()
                            .HasForeignKey("TagId")
                            .HasConstraintName("slide_channel_tag_rel_tag_id_fkey"),
                        l => l.HasOne<SlideChannel>().WithMany()
                            .HasForeignKey("ChannelId")
                            .HasConstraintName("slide_channel_tag_rel_channel_id_fkey"),
                        j =>
                        {
                            j.HasKey("ChannelId", "TagId").HasName("slide_channel_tag_rel_pkey");
                            j.ToTable("slide_channel_tag_rel", tb => tb.HasComment("RELATION BETWEEN slide_channel AND slide_channel_tag"));
                            j.HasIndex(new[] { "TagId", "ChannelId" }, "slide_channel_tag_rel_tag_id_channel_id_idx");
                            j.IndexerProperty<Guid>("ChannelId").HasColumnName("channel_id");
                            j.IndexerProperty<Guid>("TagId").HasColumnName("tag_id");
                        });
            });
        }
    }
}