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
        public static void ConfigureSlideSlide(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SlideSlide>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("slide_slide_pkey");

                entity.ToTable("slide_slide", tb => tb.HasComment("Slides"));

                entity.HasIndex(e => e.IsPublished, "slide_slide_is_published_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active)
                    .HasComment("Active")
                    .HasColumnName("active");
                entity.Property(e => e.CategoryId)
                    .HasComment("Section")
                    .HasColumnName("category_id");
                entity.Property(e => e.ChannelId)
                    .HasComment("Course")
                    .HasColumnName("channel_id");
                entity.Property(e => e.CompletionTime)
                    .HasComment("Duration")
                    .HasColumnName("completion_time");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.DatePublished)
                    .HasComment("Publish Date")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_published");
                entity.Property(e => e.Description)
                    .HasComment("Description")
                    .HasColumnType("jsonb")
                    .HasColumnName("description");
                entity.Property(e => e.Dislikes)
                    .HasComment("Dislikes")
                    .HasColumnName("dislikes");
                entity.Property(e => e.HtmlContent)
                    .HasComment("HTML Content")
                    .HasColumnType("jsonb")
                    .HasColumnName("html_content");
                entity.Property(e => e.IsCategory)
                    .HasComment("Is a category")
                    .HasColumnName("is_category");
                entity.Property(e => e.IsPreview)
                    .HasComment("Allow Preview")
                    .HasColumnName("is_preview");
                entity.Property(e => e.IsPublished)
                    .HasComment("Is Published")
                    .HasColumnName("is_published");
                entity.Property(e => e.Likes)
                    .HasComment("Likes")
                    .HasColumnName("likes");
                entity.Property(e => e.MessageMainAttachmentId)
                    .HasComment("Main Attachment")
                    .HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Name)
                    .HasComment("Title")
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.NbrArticle)
                    .HasComment("Number of Articles")
                    .HasColumnName("nbr_article");
                entity.Property(e => e.NbrCertification)
                    .HasComment("Number of Certifications")
                    .HasColumnName("nbr_certification");
                entity.Property(e => e.NbrDocument)
                    .HasComment("Number of Documents")
                    .HasColumnName("nbr_document");
                entity.Property(e => e.NbrInfographic)
                    .HasComment("Number of Images")
                    .HasColumnName("nbr_infographic");
                entity.Property(e => e.NbrQuiz)
                    .HasComment("Number of Quizs")
                    .HasColumnName("nbr_quiz");
                entity.Property(e => e.NbrVideo)
                    .HasComment("Number of Videos")
                    .HasColumnName("nbr_video");
                entity.Property(e => e.PublicViews)
                    .HasComment("# of Public Views")
                    .HasColumnName("public_views");
                entity.Property(e => e.QuizFirstAttemptReward)
                    .HasComment("Reward: first attempt")
                    .HasColumnName("quiz_first_attempt_reward");
                entity.Property(e => e.QuizFourthAttemptReward)
                    .HasComment("Reward: every attempt after the third try")
                    .HasColumnName("quiz_fourth_attempt_reward");
                entity.Property(e => e.QuizSecondAttemptReward)
                    .HasComment("Reward: second attempt")
                    .HasColumnName("quiz_second_attempt_reward");
                entity.Property(e => e.QuizThirdAttemptReward)
                    .HasComment("Reward: third attempt")
                    .HasColumnName("quiz_third_attempt_reward");
                entity.Property(e => e.SeoName)
                    .HasComment("Seo name")
                    .HasColumnType("jsonb")
                    .HasColumnName("seo_name");
                entity.Property(e => e.Sequence)
                    .HasComment("Sequence")
                    .HasColumnName("sequence");
                entity.Property(e => e.SlideCategory)
                    .HasComment("Category")
                    .HasColumnType("character varying")
                    .HasColumnName("slide_category");
                entity.Property(e => e.SlideResourceDownloadable)
                    .HasComment("Allow Download")
                    .HasColumnName("slide_resource_downloadable");
                entity.Property(e => e.SlideType)
                    .HasComment("Slide Type")
                    .HasColumnType("character varying")
                    .HasColumnName("slide_type");
                entity.Property(e => e.SlideViews)
                    .HasComment("# of Website Views")
                    .HasColumnName("slide_views");
                entity.Property(e => e.SourceType)
                    .HasComment("Source Type")
                    .HasColumnType("character varying")
                    .HasColumnName("source_type");
                entity.Property(e => e.SurveyId)
                    .HasComment("Certification")
                    .HasColumnName("survey_id");
                entity.Property(e => e.TotalSlides)
                    .HasComment("Total Slides")
                    .HasColumnName("total_slides");
                entity.Property(e => e.TotalViews)
                    .HasComment("# Total Views")
                    .HasColumnName("total_views");
                entity.Property(e => e.Url)
                    .HasComment("External URL")
                    .HasColumnType("character varying")
                    .HasColumnName("url");
                entity.Property(e => e.UserId)
                    .HasComment("Uploaded by")
                    .HasColumnName("user_id");
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

                entity.HasOne(d => d.Category).WithMany(p => p.InverseCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_slide_category_id_fkey");

                entity.HasOne(d => d.Channel).WithMany(p => p.SlideSlides)
                    .HasForeignKey(d => d.ChannelId)
                    .HasConstraintName("slide_slide_channel_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_slide_create_uid_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_slide_message_main_attachment_id_fkey");

                entity.HasOne(d => d.Survey).WithMany(p => p.SlideSlides)
                    .HasForeignKey(d => d.SurveyId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_slide_survey_id_fkey");

                entity.HasOne(d => d.User).WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_slide_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_slide_write_uid_fkey");

                entity.HasMany(d => d.Tags).WithMany(p => p.Slides)
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
                            j.ToTable("rel_slide_tag", tb => tb.HasComment("RELATION BETWEEN slide_slide AND slide_tag"));
                            j.HasIndex(new[] { "TagId", "SlideId" }, "rel_slide_tag_tag_id_slide_id_idx");
                            j.IndexerProperty<Guid>("SlideId").HasColumnName("slide_id");
                            j.IndexerProperty<Guid>("TagId").HasColumnName("tag_id");
                        });
            });
        }
    }
}