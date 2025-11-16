using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureForumPost(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ForumPost>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("forum_post_pkey");

                        entity.ToTable("forum_post");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.CreationTime, "forum_post__create_date_index");

                        entity.HasIndex(e => e.CreatorId, "forum_post__create_uid_index");

                        entity.HasIndex(e => e.ForumId, "forum_post__forum_id_index");

                        entity.HasIndex(e => e.ParentId, "forum_post__parent_id_index");

                        entity.HasIndex(e => e.LastModificationTime, "forum_post__write_date_index");

                        entity.HasIndex(e => e.LastModifierId, "forum_post__write_uid_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.ChildCount).HasColumnName("child_count");
                        entity.Property(e => e.ClosedDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("closed_date");
                        entity.Property(e => e.ClosedReasonId).HasColumnName("closed_reason_id");
                        entity.Property(e => e.ClosedUid).HasColumnName("closed_uid");
                        entity.Property(e => e.Content).HasColumnName("content");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.FavouriteCount).HasColumnName("favourite_count");
                        entity.Property(e => e.FlagUserId).HasColumnName("flag_user_id");
                        entity.Property(e => e.ForumId).HasColumnName("forum_id");
                        entity.Property(e => e.HasValidatedAnswer).HasColumnName("has_validated_answer");
                        entity.Property(e => e.IsCorrect).HasColumnName("is_correct");
                        entity.Property(e => e.IsSeoOptimized).HasColumnName("is_seo_optimized");
                        entity.Property(e => e.LastActivityDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("last_activity_date");
                        entity.Property(e => e.ModeratorId).HasColumnName("moderator_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.ParentId).HasColumnName("parent_id");
                        entity.Property(e => e.PlainContent).HasColumnName("plain_content");
                        entity.Property(e => e.Relevancy).HasColumnName("relevancy");
                        entity.Property(e => e.SelfReply).HasColumnName("self_reply");
                        entity.Property(e => e.SeoName)
                            .HasColumnType("jsonb")
                            .HasColumnName("seo_name");
                        entity.Property(e => e.State).HasColumnName("state");
                        entity.Property(e => e.Views).HasColumnName("views");
                        entity.Property(e => e.VoteCount).HasColumnName("vote_count");
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

                        entity.HasOne(d => d.ClosedReason).WithMany(p => p.ForumPost)
                            .HasForeignKey(d => d.ClosedReasonId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("forum_post_closed_reason_id_fkey");

                        // entity.HasOne(d => d.ClosedU).WithMany(p => p.ForumPostClosedU) .HasForeignKey(d => d.ClosedUid) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("forum_post_closed_uid_fkey");
                        entity.HasOne(d => d.ClosedU).WithMany()
                            .HasForeignKey(d => d.ClosedUid)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("forum_post_closed_uid_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ForumPostCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("forum_post_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("forum_post_create_uid_fkey");

                        // entity.HasOne(d => d.FlagUser).WithMany(p => p.ForumPostFlagUser) .HasForeignKey(d => d.FlagUserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("forum_post_flag_user_id_fkey");
                        entity.HasOne(d => d.FlagUser).WithMany()
                            .HasForeignKey(d => d.FlagUserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("forum_post_flag_user_id_fkey");

                        entity.HasOne(d => d.Forum).WithMany(p => p.ForumPost)
                            .HasForeignKey(d => d.ForumId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("forum_post_forum_id_fkey");

                        // entity.HasOne(d => d.Moderator).WithMany(p => p.ForumPostModerator) .HasForeignKey(d => d.ModeratorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("forum_post_moderator_id_fkey");
                        entity.HasOne(d => d.Moderator).WithMany()
                            .HasForeignKey(d => d.ModeratorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("forum_post_moderator_id_fkey");

                        entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                            .HasForeignKey(d => d.ParentId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("forum_post_parent_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ForumPostWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("forum_post_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("forum_post_write_uid_fkey");

                        // entity.HasMany(d => d.ForumTag).WithMany(p => p.ForumPost)
                        entity.HasMany(d => d.ForumTag).WithMany(p => p.ForumPost)
                            .UsingEntity<Dictionary<string, object>>(
                                "ForumTagRel",
                                r => r.HasOne<ForumTag>().WithMany()
                                    .HasForeignKey("ForumTagId")
                                    .HasConstraintName("forum_tag_rel_forum_tag_id_fkey"),
                                l => l.HasOne<ForumPost>().WithMany()
                                    .HasForeignKey("ForumPostId")
                                    .HasConstraintName("forum_tag_rel_forum_post_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ForumPostId", "ForumTagId").HasName("forum_tag_rel_pkey");
                                    j.ToTable("forum_tag_rel");
                                    j.HasIndex(new[] { "ForumTagId", "ForumPostId" }, "forum_tag_rel_forum_tag_id_forum_post_id_idx");
                                    j.IndexerProperty<Guid>("ForumPostId").HasColumnName("forum_post_id");
                                    j.IndexerProperty<Guid>("ForumTagId").HasColumnName("forum_tag_id");
                                });

                        // entity.HasMany(d => d.ResUsers).WithMany(p => p.ForumPost)
                        entity.HasMany(d => d.ResUsers).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "ForumPostResUsersRel",
                                r => r.HasOne<ResUsers>().WithMany()
                                    .HasForeignKey("ResUsersId")
                                    .HasConstraintName("forum_post_res_users_rel_res_users_id_fkey"),
                                l => l.HasOne<ForumPost>().WithMany()
                                    .HasForeignKey("ForumPostId")
                                    .HasConstraintName("forum_post_res_users_rel_forum_post_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ForumPostId", "ResUsersId").HasName("forum_post_res_users_rel_pkey");
                                    j.ToTable("forum_post_res_users_rel");
                                    j.HasIndex(new[] { "ResUsersId", "ForumPostId" }, "forum_post_res_users_rel_res_users_id_forum_post_id_idx");
                                    j.IndexerProperty<Guid>("ForumPostId").HasColumnName("forum_post_id");
                                    j.IndexerProperty<Guid>("ResUsersId").HasColumnName("res_users_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}