using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.ToTable("slide_channel");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.ForumId, "slide_channel__forum_id_index").HasFilter("(forum_id IS NOT NULL)");

                        entity.HasIndex(e => e.IsPublished, "slide_channel__is_published_index");

                        entity.HasIndex(e => e.ProductId, "slide_channel__product_id_index").HasFilter("(product_id IS NOT NULL)");

                        entity.HasIndex(e => e.WebsiteId, "slide_channel__website_id_index");

                        entity.HasIndex(e => e.ForumId, "slide_channel_forum_uniq").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccessToken).HasColumnName("access_token");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.AllowComment).HasColumnName("allow_comment");
                        entity.Property(e => e.ChannelType).HasColumnName("channel_type");
                        entity.Property(e => e.Color).HasColumnName("color");
                        entity.Property(e => e.CompletedTemplateId).HasColumnName("completed_template_id");
                        entity.Property(e => e.CoverProperties).HasColumnName("cover_properties");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Description)
                            .HasColumnType("jsonb")
                            .HasColumnName("description");
                        entity.Property(e => e.DescriptionHtml)
                            .HasColumnType("jsonb")
                            .HasColumnName("description_html");
                        entity.Property(e => e.DescriptionShort)
                            .HasColumnType("jsonb")
                            .HasColumnName("description_short");
                        entity.Property(e => e.Enroll).HasColumnName("enroll");
                        entity.Property(e => e.EnrollMsg)
                            .HasColumnType("jsonb")
                            .HasColumnName("enroll_msg");
                        entity.Property(e => e.ForumId).HasColumnName("forum_id");
                        entity.Property(e => e.IsPublished).HasColumnName("is_published");
                        entity.Property(e => e.IsSeoOptimized).HasColumnName("is_seo_optimized");
                        entity.Property(e => e.KarmaGenChannelFinish).HasColumnName("karma_gen_channel_finish");
                        entity.Property(e => e.KarmaGenChannelRank).HasColumnName("karma_gen_channel_rank");
                        entity.Property(e => e.KarmaReview).HasColumnName("karma_review");
                        entity.Property(e => e.KarmaSlideComment).HasColumnName("karma_slide_comment");
                        entity.Property(e => e.KarmaSlideVote).HasColumnName("karma_slide_vote");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.NbrArticle).HasColumnName("nbr_article");
                        entity.Property(e => e.NbrCertification).HasColumnName("nbr_certification");
                        entity.Property(e => e.NbrDocument).HasColumnName("nbr_document");
                        entity.Property(e => e.NbrInfographic).HasColumnName("nbr_infographic");
                        entity.Property(e => e.NbrQuiz).HasColumnName("nbr_quiz");
                        entity.Property(e => e.NbrVideo).HasColumnName("nbr_video");
                        entity.Property(e => e.ProductId).HasColumnName("product_id");
                        entity.Property(e => e.PromoteStrategy).HasColumnName("promote_strategy");
                        entity.Property(e => e.PromotedSlideId).HasColumnName("promoted_slide_id");
                        entity.Property(e => e.PublishTemplateId).HasColumnName("publish_template_id");
                        entity.Property(e => e.RatingLastValue).HasColumnName("rating_last_value");
                        entity.Property(e => e.SeoName)
                            .HasColumnType("jsonb")
                            .HasColumnName("seo_name");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.ShareChannelTemplateId).HasColumnName("share_channel_template_id");
                        entity.Property(e => e.ShareSlideTemplateId).HasColumnName("share_slide_template_id");
                        entity.Property(e => e.SlideLastUpdate).HasColumnName("slide_last_update");
                        entity.Property(e => e.TotalSlides).HasColumnName("total_slides");
                        entity.Property(e => e.TotalTime).HasColumnName("total_time");
                        entity.Property(e => e.TotalViews).HasColumnName("total_views");
                        entity.Property(e => e.TotalVotes).HasColumnName("total_votes");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.Visibility).HasColumnName("visibility");
                        entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                        entity.Property(e => e.WebsiteMetaDescription)
                            .HasColumnType("jsonb")
                            .HasColumnName("website_meta_description");
                        entity.Property(e => e.WebsiteMetaKeywords)
                            .HasColumnType("jsonb")
                            .HasColumnName("website_meta_keywords");
                        entity.Property(e => e.WebsiteMetaOgImg).HasColumnName("website_meta_og_img");
                        entity.Property(e => e.WebsiteMetaTitle)
                            .HasColumnType("jsonb")
                            .HasColumnName("website_meta_title");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.CompletedTemplate).WithMany(p => p.SlideChannelCompletedTemplate)
                            .HasForeignKey(d => d.CompletedTemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("slide_channel_completed_template_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.SlideChannelCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("slide_channel_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("slide_channel_create_uid_fkey");

                        entity.HasOne(d => d.Forum).WithOne(p => p.SlideChannelNavigation)
                            .HasForeignKey<SlideChannel>(d => d.ForumId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("slide_channel_forum_id_fkey");

                        // entity.HasOne(d => d.Product).WithMany(p => p.SlideChannel) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("slide_channel_product_id_fkey");
                        entity.HasOne(d => d.Product).WithMany()
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("slide_channel_product_id_fkey");

                        entity.HasOne(d => d.PromotedSlide).WithMany(p => p.SlideChannel)
                            .HasForeignKey(d => d.PromotedSlideId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("slide_channel_promoted_slide_id_fkey");

                        entity.HasOne(d => d.PublishTemplate).WithMany(p => p.SlideChannelPublishTemplate)
                            .HasForeignKey(d => d.PublishTemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("slide_channel_publish_template_id_fkey");

                        entity.HasOne(d => d.ShareChannelTemplate).WithMany(p => p.SlideChannelShareChannelTemplate)
                            .HasForeignKey(d => d.ShareChannelTemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("slide_channel_share_channel_template_id_fkey");

                        entity.HasOne(d => d.ShareSlideTemplate).WithMany(p => p.SlideChannelShareSlideTemplate)
                            .HasForeignKey(d => d.ShareSlideTemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("slide_channel_share_slide_template_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.SlideChannelUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("slide_channel_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("slide_channel_user_id_fkey");

                        // entity.HasOne(d => d.Website).WithMany(p => p.SlideChannel) .HasForeignKey(d => d.WebsiteId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("slide_channel_website_id_fkey");
                        entity.HasOne(d => d.Website).WithMany()
                            .HasForeignKey(d => d.WebsiteId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("slide_channel_website_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.SlideChannelWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("slide_channel_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("slide_channel_write_uid_fkey");

                        // entity.HasMany(d => d.Channel).WithMany(p => p.PrerequisiteChannel)
                        entity.HasMany(d => d.Channel).WithMany(p => p.PrerequisiteChannel)
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

                        // entity.HasMany(d => d.Group).WithMany(p => p.Channel)
                        entity.HasMany(d => d.Group).WithMany(p => p.Channel)
                            .UsingEntity<Dictionary<string, object>>(
                                "RelUploadGroups",
                                r => r.HasOne<ResGroups>().WithMany()
                                    .HasForeignKey("GroupId")
                                    .HasConstraintName("rel_upload_groups_group_id_fkey"),
                                l => l.HasOne<SlideChannel>().WithMany()
                                    .HasForeignKey("ChannelId")
                                    .HasConstraintName("rel_upload_groups_channel_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ChannelId", "GroupId").HasName("rel_upload_groups_pkey");
                                    j.ToTable("rel_upload_groups");
                                    j.HasIndex(new[] { "GroupId", "ChannelId" }, "rel_upload_groups_group_id_channel_id_idx");
                                    j.IndexerProperty<Guid>("ChannelId").HasColumnName("channel_id");
                                    j.IndexerProperty<Guid>("GroupId").HasColumnName("group_id");
                                });

                        // entity.HasMany(d => d.PrerequisiteChannel).WithMany(p => p.Channel)
                        entity.HasMany(d => d.PrerequisiteChannel).WithMany(p => p.Channel)
                            .UsingEntity<Dictionary<string, object>>(
                                "SlideChannelPrerequisiteSlideChannelRel",
                                r => r.HasOne<SlideChannel>().WithMany()
                                    .HasForeignKey("PrerequisiteChannelId")
                                    .HasConstraintName("slide_channel_prerequisite_slide_c_prerequisite_channel_id_fkey"),
                                l => l.HasOne<SlideChannel>().WithMany()
                                    .HasForeignKey("ChannelId")
                                    .HasConstraintName("slide_channel_prerequisite_slide_channel_rel_channel_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ChannelId", "PrerequisiteChannelId").HasName("slide_channel_prerequisite_slide_channel_rel_pkey");
                                    j.ToTable("slide_channel_prerequisite_slide_channel_rel");
                                    j.HasIndex(new[] { "PrerequisiteChannelId", "ChannelId" }, "slide_channel_prerequisite_sl_prerequisite_channel_id_chann_idx");
                                    j.IndexerProperty<Guid>("ChannelId").HasColumnName("channel_id");
                                    j.IndexerProperty<Guid>("PrerequisiteChannelId").HasColumnName("prerequisite_channel_id");
                                });

                        // entity.HasMany(d => d.ResGroups).WithMany(p => p.SlideChannel)
                        entity.HasMany(d => d.ResGroups).WithMany(p => p.SlideChannel)
                            .UsingEntity<Dictionary<string, object>>(
                                "ResGroupsSlideChannelRel",
                                r => r.HasOne<ResGroups>().WithMany()
                                    .HasForeignKey("ResGroupsId")
                                    .HasConstraintName("res_groups_slide_channel_rel_res_groups_id_fkey"),
                                l => l.HasOne<SlideChannel>().WithMany()
                                    .HasForeignKey("SlideChannelId")
                                    .HasConstraintName("res_groups_slide_channel_rel_slide_channel_id_fkey"),
                                j =>
                                {
                                    j.HasKey("SlideChannelId", "ResGroupsId").HasName("res_groups_slide_channel_rel_pkey");
                                    j.ToTable("res_groups_slide_channel_rel");
                                    j.HasIndex(new[] { "ResGroupsId", "SlideChannelId" }, "res_groups_slide_channel_rel_res_groups_id_slide_channel_id_idx");
                                    j.IndexerProperty<Guid>("SlideChannelId").HasColumnName("slide_channel_id");
                                    j.IndexerProperty<Guid>("ResGroupsId").HasColumnName("res_groups_id");
                                });

                        // entity.HasMany(d => d.Tag).WithMany(p => p.Channel)
                        entity.HasMany(d => d.Tag).WithMany(p => p.Channel)
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
                                    j.ToTable("slide_channel_tag_rel");
                                    j.HasIndex(new[] { "TagId", "ChannelId" }, "slide_channel_tag_rel_tag_id_channel_id_idx");
                                    j.IndexerProperty<Guid>("ChannelId").HasColumnName("channel_id");
                                    j.IndexerProperty<Guid>("TagId").HasColumnName("tag_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}