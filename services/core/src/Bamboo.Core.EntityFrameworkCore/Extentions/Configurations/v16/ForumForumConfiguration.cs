using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureForumForum(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ForumForum>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("forum_forum_pkey");

                        entity.ToTable("forum_forum");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.WebsiteId, "forum_forum__website_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.AllowShare).HasColumnName("allow_share");
                        entity.Property(e => e.AuthorizedGroupId).HasColumnName("authorized_group_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DefaultOrder).HasColumnName("default_order");
                        entity.Property(e => e.Description)
                            .HasColumnType("jsonb")
                            .HasColumnName("description");
                        entity.Property(e => e.Faq)
                            .HasColumnType("jsonb")
                            .HasColumnName("faq");
                        entity.Property(e => e.KarmaAnswer).HasColumnName("karma_answer");
                        entity.Property(e => e.KarmaAnswerAcceptAll).HasColumnName("karma_answer_accept_all");
                        entity.Property(e => e.KarmaAnswerAcceptOwn).HasColumnName("karma_answer_accept_own");
                        entity.Property(e => e.KarmaAsk).HasColumnName("karma_ask");
                        entity.Property(e => e.KarmaCloseAll).HasColumnName("karma_close_all");
                        entity.Property(e => e.KarmaCloseOwn).HasColumnName("karma_close_own");
                        entity.Property(e => e.KarmaCommentAll).HasColumnName("karma_comment_all");
                        entity.Property(e => e.KarmaCommentConvertAll).HasColumnName("karma_comment_convert_all");
                        entity.Property(e => e.KarmaCommentConvertOwn).HasColumnName("karma_comment_convert_own");
                        entity.Property(e => e.KarmaCommentOwn).HasColumnName("karma_comment_own");
                        entity.Property(e => e.KarmaCommentUnlinkAll).HasColumnName("karma_comment_unlink_all");
                        entity.Property(e => e.KarmaCommentUnlinkOwn).HasColumnName("karma_comment_unlink_own");
                        entity.Property(e => e.KarmaDofollow).HasColumnName("karma_dofollow");
                        entity.Property(e => e.KarmaDownvote).HasColumnName("karma_downvote");
                        entity.Property(e => e.KarmaEditAll).HasColumnName("karma_edit_all");
                        entity.Property(e => e.KarmaEditOwn).HasColumnName("karma_edit_own");
                        entity.Property(e => e.KarmaEditRetag).HasColumnName("karma_edit_retag");
                        entity.Property(e => e.KarmaEditor).HasColumnName("karma_editor");
                        entity.Property(e => e.KarmaFlag).HasColumnName("karma_flag");
                        entity.Property(e => e.KarmaGenAnswerAccept).HasColumnName("karma_gen_answer_accept");
                        entity.Property(e => e.KarmaGenAnswerAccepted).HasColumnName("karma_gen_answer_accepted");
                        entity.Property(e => e.KarmaGenAnswerDownvote).HasColumnName("karma_gen_answer_downvote");
                        entity.Property(e => e.KarmaGenAnswerFlagged).HasColumnName("karma_gen_answer_flagged");
                        entity.Property(e => e.KarmaGenAnswerUpvote).HasColumnName("karma_gen_answer_upvote");
                        entity.Property(e => e.KarmaGenQuestionDownvote).HasColumnName("karma_gen_question_downvote");
                        entity.Property(e => e.KarmaGenQuestionNew).HasColumnName("karma_gen_question_new");
                        entity.Property(e => e.KarmaGenQuestionUpvote).HasColumnName("karma_gen_question_upvote");
                        entity.Property(e => e.KarmaModerate).HasColumnName("karma_moderate");
                        entity.Property(e => e.KarmaPost).HasColumnName("karma_post");
                        entity.Property(e => e.KarmaTagCreate).HasColumnName("karma_tag_create");
                        entity.Property(e => e.KarmaUnlinkAll).HasColumnName("karma_unlink_all");
                        entity.Property(e => e.KarmaUnlinkOwn).HasColumnName("karma_unlink_own");
                        entity.Property(e => e.KarmaUpvote).HasColumnName("karma_upvote");
                        entity.Property(e => e.KarmaUserBio).HasColumnName("karma_user_bio");
                        entity.Property(e => e.Mode).HasColumnName("mode");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.Privacy).HasColumnName("privacy");
                        entity.Property(e => e.RelevancyPostVote).HasColumnName("relevancy_post_vote");
                        entity.Property(e => e.RelevancyTimeDecay).HasColumnName("relevancy_time_decay");
                        entity.Property(e => e.SeoName)
                            .HasColumnType("jsonb")
                            .HasColumnName("seo_name");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.SlideChannelId).HasColumnName("slide_channel_id");
                        entity.Property(e => e.Teaser).HasColumnName("teaser");
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
                        entity.Property(e => e.WelcomeMessage)
                            .HasColumnType("jsonb")
                            .HasColumnName("welcome_message");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.AuthorizedGroup).WithMany(p => p.ForumForum)
                            .HasForeignKey(d => d.AuthorizedGroupId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("forum_forum_authorized_group_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ForumForumCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("forum_forum_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("forum_forum_create_uid_fkey");

                        entity.HasOne(d => d.SlideChannel).WithMany(p => p.ForumForum)
                            .HasForeignKey(d => d.SlideChannelId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("forum_forum_slide_channel_id_fkey");

                        // entity.HasOne(d => d.Website).WithMany(p => p.ForumForum) .HasForeignKey(d => d.WebsiteId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("forum_forum_website_id_fkey");
                        entity.HasOne(d => d.Website).WithMany()
                            .HasForeignKey(d => d.WebsiteId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("forum_forum_website_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ForumForumWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("forum_forum_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("forum_forum_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}