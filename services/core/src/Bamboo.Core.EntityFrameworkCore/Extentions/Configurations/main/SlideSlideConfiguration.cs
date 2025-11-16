using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureSlideSlide(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<SlideSlide>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("slide_slide_pkey");

                        entity.ToTable("slide_slide");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.IsPublished, "slide_slide__is_published_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.CategoryId).HasColumnName("category_id");
                        entity.Property(e => e.ChannelId).HasColumnName("channel_id");
                        entity.Property(e => e.CompletionTime).HasColumnName("completion_time");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DatePublished)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_published");
                        entity.Property(e => e.Description)
                            .HasColumnType("jsonb")
                            .HasColumnName("description");
                        entity.Property(e => e.Dislikes).HasColumnName("dislikes");
                        entity.Property(e => e.HtmlContent)
                            .HasColumnType("jsonb")
                            .HasColumnName("html_content");
                        entity.Property(e => e.IsCategory).HasColumnName("is_category");
                        entity.Property(e => e.IsPreview).HasColumnName("is_preview");
                        entity.Property(e => e.IsPublished).HasColumnName("is_published");
                        entity.Property(e => e.Likes).HasColumnName("likes");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.NbrArticle).HasColumnName("nbr_article");
                        entity.Property(e => e.NbrCertification).HasColumnName("nbr_certification");
                        entity.Property(e => e.NbrDocument).HasColumnName("nbr_document");
                        entity.Property(e => e.NbrInfographic).HasColumnName("nbr_infographic");
                        entity.Property(e => e.NbrQuiz).HasColumnName("nbr_quiz");
                        entity.Property(e => e.NbrVideo).HasColumnName("nbr_video");
                        entity.Property(e => e.PublicViews).HasColumnName("public_views");
                        entity.Property(e => e.QuizFirstAttemptReward).HasColumnName("quiz_first_attempt_reward");
                        entity.Property(e => e.QuizFourthAttemptReward).HasColumnName("quiz_fourth_attempt_reward");
                        entity.Property(e => e.QuizSecondAttemptReward).HasColumnName("quiz_second_attempt_reward");
                        entity.Property(e => e.QuizThirdAttemptReward).HasColumnName("quiz_third_attempt_reward");
                        entity.Property(e => e.SeoName)
                            .HasColumnType("jsonb")
                            .HasColumnName("seo_name");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.SlideCategory).HasColumnName("slide_category");
                        entity.Property(e => e.SlideResourceDownloadable).HasColumnName("slide_resource_downloadable");
                        entity.Property(e => e.SlideType).HasColumnName("slide_type");
                        entity.Property(e => e.SlideViews).HasColumnName("slide_views");
                        entity.Property(e => e.SourceType).HasColumnName("source_type");
                        entity.Property(e => e.SurveyId).HasColumnName("survey_id");
                        entity.Property(e => e.TotalSlides).HasColumnName("total_slides");
                        entity.Property(e => e.TotalViews).HasColumnName("total_views");
                        entity.Property(e => e.Url).HasColumnName("url");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
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

                        entity.HasOne(d => d.Category).WithMany(p => p.InverseCategory)
                            .HasForeignKey(d => d.CategoryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("slide_slide_category_id_fkey");

                        entity.HasOne(d => d.Channel).WithMany(p => p.SlideSlide)
                            .HasForeignKey(d => d.ChannelId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("slide_slide_channel_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.SlideSlideCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("slide_slide_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("slide_slide_create_uid_fkey");

                        entity.HasOne(d => d.Survey).WithMany(p => p.SlideSlide)
                            .HasForeignKey(d => d.SurveyId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("slide_slide_survey_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.SlideSlideUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("slide_slide_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("slide_slide_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.SlideSlideWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("slide_slide_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("slide_slide_write_uid_fkey");

                        // entity.HasMany(d => d.Tag).WithMany(p => p.Slide)
                        entity.HasMany(d => d.Tag).WithMany(p => p.Slide)
                            .UsingEntity<Dictionary<string, object>>(
                                "RelSlideTag",
                                r => r.HasOne<SlideTag>().WithMany()
                                    .HasForeignKey("TagId")
                                    .HasConstraintName("rel_slide_tag_tag_id_fkey"),
                                l => l.HasOne<SlideSlide>().WithMany()
                                    .HasForeignKey("SlideId")
                                    .HasConstraintName("rel_slide_tag_slide_id_fkey"),
                                j =>
                                {
                                    j.HasKey("SlideId", "TagId").HasName("rel_slide_tag_pkey");
                                    j.ToTable("rel_slide_tag");
                                    j.HasIndex(new[] { "TagId", "SlideId" }, "rel_slide_tag_tag_id_slide_id_idx");
                                    j.IndexerProperty<Guid>("SlideId").HasColumnName("slide_id");
                                    j.IndexerProperty<Guid>("TagId").HasColumnName("tag_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}