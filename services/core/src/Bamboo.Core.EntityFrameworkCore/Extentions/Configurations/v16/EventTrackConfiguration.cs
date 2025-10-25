using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureEventTrack(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<EventTrack>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("event_track_pkey");

                        entity.ToTable("event_track");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.IsPublished, "event_track__is_published_index");

                        entity.HasIndex(e => e.StageId, "event_track__stage_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.Color).HasColumnName("color");
                        entity.Property(e => e.ContactEmail).HasColumnName("contact_email");
                        entity.Property(e => e.ContactPhone).HasColumnName("contact_phone");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Date)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date");
                        entity.Property(e => e.DateEnd)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_end");
                        entity.Property(e => e.Description)
                            .HasColumnType("jsonb")
                            .HasColumnName("description");
                        entity.Property(e => e.Duration).HasColumnName("duration");
                        entity.Property(e => e.EventId).HasColumnName("event_id");
                        entity.Property(e => e.IsPublished).HasColumnName("is_published");
                        entity.Property(e => e.IsYoutubeReplay).HasColumnName("is_youtube_replay");
                        entity.Property(e => e.KanbanState).HasColumnName("kanban_state");
                        entity.Property(e => e.KanbanStateLabel).HasColumnName("kanban_state_label");
                        entity.Property(e => e.LocationId).HasColumnName("location_id");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.PartnerBiography).HasColumnName("partner_biography");
                        entity.Property(e => e.PartnerCompanyName).HasColumnName("partner_company_name");
                        entity.Property(e => e.PartnerEmail).HasColumnName("partner_email");
                        entity.Property(e => e.PartnerFunction).HasColumnName("partner_function");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.PartnerName).HasColumnName("partner_name");
                        entity.Property(e => e.PartnerPhone).HasColumnName("partner_phone");
                        entity.Property(e => e.Priority).HasColumnName("priority");
                        entity.Property(e => e.QuizId).HasColumnName("quiz_id");
                        entity.Property(e => e.SeoName)
                            .HasColumnType("jsonb")
                            .HasColumnName("seo_name");
                        entity.Property(e => e.StageId).HasColumnName("stage_id");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.WebsiteCta).HasColumnName("website_cta");
                        entity.Property(e => e.WebsiteCtaDelay).HasColumnName("website_cta_delay");
                        entity.Property(e => e.WebsiteCtaTitle).HasColumnName("website_cta_title");
                        entity.Property(e => e.WebsiteCtaUrl).HasColumnName("website_cta_url");
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
                        entity.Property(e => e.WishlistedByDefault).HasColumnName("wishlisted_by_default");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");
                        entity.Property(e => e.YoutubeVideoUrl).HasColumnName("youtube_video_url");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.EventTrackCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_track_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_track_create_uid_fkey");

                        entity.HasOne(d => d.Event).WithMany(p => p.EventTrack)
                            .HasForeignKey(d => d.EventId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("event_track_event_id_fkey");

                        entity.HasOne(d => d.Location).WithMany(p => p.EventTrack)
                            .HasForeignKey(d => d.LocationId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_track_location_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.EventTrack) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_track_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_track_partner_id_fkey");

                        entity.HasOne(d => d.Quiz).WithMany(p => p.EventTrackNavigation)
                            .HasForeignKey(d => d.QuizId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_track_quiz_id_fkey");

                        entity.HasOne(d => d.Stage).WithMany(p => p.EventTrack)
                            .HasForeignKey(d => d.StageId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("event_track_stage_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.EventTrackUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_track_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_track_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.EventTrackWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_track_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_track_write_uid_fkey");

                        // entity.HasMany(d => d.EventTrackTag).WithMany(p => p.EventTrack)
                        entity.HasMany(d => d.EventTrackTag).WithMany(p => p.EventTrack)
                            .UsingEntity<Dictionary<string, object>>(
                                "EventTrackEventTrackTagRel",
                                r => r.HasOne<EventTrackTag>().WithMany()
                                    .HasForeignKey("EventTrackTagId")
                                    .HasConstraintName("event_track_event_track_tag_rel_event_track_tag_id_fkey"),
                                l => l.HasOne<EventTrack>().WithMany()
                                    .HasForeignKey("EventTrackId")
                                    .HasConstraintName("event_track_event_track_tag_rel_event_track_id_fkey"),
                                j =>
                                {
                                    j.HasKey("EventTrackId", "EventTrackTagId").HasName("event_track_event_track_tag_rel_pkey");
                                    j.ToTable("event_track_event_track_tag_rel");
                                    j.HasIndex(new[] { "EventTrackTagId", "EventTrackId" }, "event_track_event_track_tag_r_event_track_tag_id_event_trac_idx");
                                    j.IndexerProperty<Guid>("EventTrackId").HasColumnName("event_track_id");
                                    j.IndexerProperty<Guid>("EventTrackTagId").HasColumnName("event_track_tag_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}