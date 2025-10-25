using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.ToTable("slide_slide_partner");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.ChannelId, "slide_slide_partner__channel_id_index");

                        entity.HasIndex(e => e.PartnerId, "slide_slide_partner__partner_id_index");

                        entity.HasIndex(e => e.SlideId, "slide_slide_partner__slide_id_index");

                        entity.HasIndex(e => new { e.SlideId, e.PartnerId }, "slide_slide_partner_slide_partner_uniq").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.ChannelId).HasColumnName("channel_id");
                        entity.Property(e => e.Completed).HasColumnName("completed");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.QuizAttemptsCount).HasColumnName("quiz_attempts_count");
                        entity.Property(e => e.SlideId).HasColumnName("slide_id");
                        entity.Property(e => e.SurveyScoringSuccess).HasColumnName("survey_scoring_success");
                        entity.Property(e => e.Vote).HasColumnName("vote");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Channel).WithMany(p => p.SlideSlidePartner)
                            .HasForeignKey(d => d.ChannelId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("slide_slide_partner_channel_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.SlideSlidePartnerCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("slide_slide_partner_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("slide_slide_partner_create_uid_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.SlideSlidePartner) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("slide_slide_partner_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("slide_slide_partner_partner_id_fkey");

                        entity.HasOne(d => d.Slide).WithMany(p => p.SlideSlidePartner)
                            .HasForeignKey(d => d.SlideId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("slide_slide_partner_slide_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.SlideSlidePartnerWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("slide_slide_partner_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("slide_slide_partner_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}