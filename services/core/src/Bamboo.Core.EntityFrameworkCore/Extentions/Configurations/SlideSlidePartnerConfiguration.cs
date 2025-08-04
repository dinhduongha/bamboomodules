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
        public static void ConfigureSlideSlidePartner(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SlideSlidePartner>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("slide_slide_partner_pkey");

                entity.ToTable("slide_slide_partner", tb => tb.HasComment("Slide / Partner decorated m2m"));

                entity.HasIndex(e => e.ChannelId, "slide_slide_partner_channel_id_index");

                entity.HasIndex(e => e.PartnerId, "slide_slide_partner_partner_id_index");

                entity.HasIndex(e => e.SlideId, "slide_slide_partner_slide_id_index");

                entity.HasIndex(e => new { e.SlideId, e.PartnerId }, "slide_slide_partner_slide_partner_uniq").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.ChannelId)
                    .HasComment("Channel")
                    .HasColumnName("channel_id");
                entity.Property(e => e.Completed)
                    .HasComment("Completed")
                    .HasColumnName("completed");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.PartnerId)
                    .HasComment("Partner")
                    .HasColumnName("partner_id");
                entity.Property(e => e.QuizAttemptsCount)
                    .HasComment("Quiz attempts count")
                    .HasColumnName("quiz_attempts_count");
                entity.Property(e => e.SlideId)
                    .HasComment("Content")
                    .HasColumnName("slide_id");
                entity.Property(e => e.SurveyScoringSuccess)
                    .HasComment("Certification Succeeded")
                    .HasColumnName("survey_scoring_success");
                entity.Property(e => e.Vote)
                    .HasComment("Vote")
                    .HasColumnName("vote");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne(d => d.Channel).WithMany(p => p.SlideSlidePartners)
                    .HasForeignKey(d => d.ChannelId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("slide_slide_partner_channel_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_slide_partner_create_uid_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("slide_slide_partner_partner_id_fkey");

                entity.HasOne(d => d.Slide).WithMany(p => p.SlideSlidePartners)
                    .HasForeignKey(d => d.SlideId)
                    .HasConstraintName("slide_slide_partner_slide_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_slide_partner_write_uid_fkey");
            });
        }
    }
}