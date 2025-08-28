using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureEventEvent(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<EventEvent>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("event_event_pkey");

                        entity.ToTable("event_event");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.IsPublished, "event_event__is_published_index");

                        entity.HasIndex(e => e.WebsiteId, "event_event__website_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.AddressId).HasColumnName("address_id");
                        entity.Property(e => e.BadgeFormat).HasColumnName("badge_format");
                        entity.Property(e => e.BoothMenu).HasColumnName("booth_menu");
                        entity.Property(e => e.CommunityMenu).HasColumnName("community_menu");

                        entity.Property(e => e.CountryId).HasColumnName("country_id");
                        entity.Property(e => e.CoverProperties).HasColumnName("cover_properties");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DateBegin)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_begin");
                        entity.Property(e => e.DateEnd)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_end");
                        entity.Property(e => e.DateTz).HasColumnName("date_tz");
                        entity.Property(e => e.Description)
                            .HasColumnType("jsonb")
                            .HasColumnName("description");
                        entity.Property(e => e.EventTypeId).HasColumnName("event_type_id");
                        entity.Property(e => e.ExhibitorMenu).HasColumnName("exhibitor_menu");
                        entity.Property(e => e.IntroductionMenu).HasColumnName("introduction_menu");
                        entity.Property(e => e.IsPublished).HasColumnName("is_published");
                        entity.Property(e => e.KanbanState).HasColumnName("kanban_state");
                        entity.Property(e => e.KanbanStateLabel).HasColumnName("kanban_state_label");
                        entity.Property(e => e.Lang).HasColumnName("lang");
                        entity.Property(e => e.LocationMenu).HasColumnName("location_menu");
                        entity.Property(e => e.MeetingRoomAllowCreation).HasColumnName("meeting_room_allow_creation");
                        entity.Property(e => e.MenuId).HasColumnName("menu_id");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.Note).HasColumnName("note");
                        entity.Property(e => e.OrganizerId).HasColumnName("organizer_id");
                        entity.Property(e => e.RegisterMenu).HasColumnName("register_menu");
                        entity.Property(e => e.RegistrationPropertiesDefinition)
                            .HasColumnType("jsonb")
                            .HasColumnName("registration_properties_definition");
                        entity.Property(e => e.SeatsLimited).HasColumnName("seats_limited");
                        entity.Property(e => e.SeatsMax).HasColumnName("seats_max");
                        entity.Property(e => e.SeoName)
                            .HasColumnType("jsonb")
                            .HasColumnName("seo_name");
                        entity.Property(e => e.StageId).HasColumnName("stage_id");
                        entity.Property(e => e.Subtitle)
                            .HasColumnType("jsonb")
                            .HasColumnName("subtitle");
                        entity.Property(e => e.TicketInstructions)
                            .HasColumnType("jsonb")
                            .HasColumnName("ticket_instructions");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                        entity.Property(e => e.WebsiteMenu).HasColumnName("website_menu");
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
                        entity.Property(e => e.WebsiteTrack).HasColumnName("website_track");
                        entity.Property(e => e.WebsiteTrackProposal).HasColumnName("website_track_proposal");
                        entity.Property(e => e.WebsiteVisibility).HasColumnName("website_visibility");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Address).WithMany(p => p.EventEventAddress) .HasForeignKey(d => d.AddressId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_event_address_id_fkey");
                        entity.HasOne(d => d.Address).WithMany()
                            .HasForeignKey(d => d.AddressId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_event_address_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.EventEvent) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_event_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_event_company_id_fkey");

                        // entity.HasOne(d => d.Country).WithMany(p => p.EventEvent) .HasForeignKey(d => d.CountryId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_event_country_id_fkey");
                        entity.HasOne(d => d.Country).WithMany()
                            .HasForeignKey(d => d.CountryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_event_country_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.EventEventCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_event_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_event_create_uid_fkey");

                        entity.HasOne(d => d.EventType).WithMany(p => p.EventEvent)
                            .HasForeignKey(d => d.EventTypeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_event_event_type_id_fkey");

                        entity.HasOne(d => d.Menu).WithMany(p => p.EventEvent)
                            .HasForeignKey(d => d.MenuId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_event_menu_id_fkey");

                        // entity.HasOne(d => d.Organizer).WithMany(p => p.EventEventOrganizer) .HasForeignKey(d => d.OrganizerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_event_organizer_id_fkey");
                        entity.HasOne(d => d.Organizer).WithMany()
                            .HasForeignKey(d => d.OrganizerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_event_organizer_id_fkey");

                        entity.HasOne(d => d.Stage).WithMany(p => p.EventEvent)
                            .HasForeignKey(d => d.StageId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("event_event_stage_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.EventEventUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_event_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_event_user_id_fkey");

                        // entity.HasOne(d => d.Website).WithMany(p => p.EventEvent) .HasForeignKey(d => d.WebsiteId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("event_event_website_id_fkey");
                        entity.HasOne(d => d.Website).WithMany()
                            .HasForeignKey(d => d.WebsiteId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("event_event_website_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.EventEventWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_event_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_event_write_uid_fkey");

                        // entity.HasMany(d => d.EventTag).WithMany(p => p.EventEvent)
                        entity.HasMany(d => d.EventTag).WithMany(p => p.EventEvent)
                            .UsingEntity<Dictionary<string, object>>(
                                "EventEventEventTagRel",
                                r => r.HasOne<EventTag>().WithMany()
                                    .HasForeignKey("EventTagId")
                                    .HasConstraintName("event_event_event_tag_rel_event_tag_id_fkey"),
                                l => l.HasOne<EventEvent>().WithMany()
                                    .HasForeignKey("EventEventId")
                                    .HasConstraintName("event_event_event_tag_rel_event_event_id_fkey"),
                                j =>
                                {
                                    j.HasKey("EventEventId", "EventTagId").HasName("event_event_event_tag_rel_pkey");
                                    j.ToTable("event_event_event_tag_rel");
                                    j.HasIndex(new[] { "EventTagId", "EventEventId" }, "event_event_event_tag_rel_event_tag_id_event_event_id_idx");
                                    j.IndexerProperty<Guid>("EventEventId").HasColumnName("event_event_id");
                                    j.IndexerProperty<Guid>("EventTagId").HasColumnName("event_tag_id");
                                });

                        // entity.HasMany(d => d.EventTrackTag).WithMany(p => p.EventEvent)
                        entity.HasMany(d => d.EventTrackTag).WithMany(p => p.EventEvent)
                            .UsingEntity<Dictionary<string, object>>(
                                "EventAllowedTrackTagsRel",
                                r => r.HasOne<EventTrackTag>().WithMany()
                                    .HasForeignKey("EventTrackTagId")
                                    .HasConstraintName("event_allowed_track_tags_rel_event_track_tag_id_fkey"),
                                l => l.HasOne<EventEvent>().WithMany()
                                    .HasForeignKey("EventEventId")
                                    .HasConstraintName("event_allowed_track_tags_rel_event_event_id_fkey"),
                                j =>
                                {
                                    j.HasKey("EventEventId", "EventTrackTagId").HasName("event_allowed_track_tags_rel_pkey");
                                    j.ToTable("event_allowed_track_tags_rel");
                                    j.HasIndex(new[] { "EventTrackTagId", "EventEventId" }, "event_allowed_track_tags_rel_event_track_tag_id_event_event_idx");
                                    j.IndexerProperty<Guid>("EventEventId").HasColumnName("event_event_id");
                                    j.IndexerProperty<Guid>("EventTrackTagId").HasColumnName("event_track_tag_id");
                                });

                        // entity.HasMany(d => d.EventTrackTagNavigation).WithMany(p => p.EventEventNavigation)
                        entity.HasMany(d => d.EventTrackTagNavigation).WithMany(p => p.EventEventNavigation)
                            .UsingEntity<Dictionary<string, object>>(
                                "EventTrackTagsRel",
                                r => r.HasOne<EventTrackTag>().WithMany()
                                    .HasForeignKey("EventTrackTagId")
                                    .HasConstraintName("event_track_tags_rel_event_track_tag_id_fkey"),
                                l => l.HasOne<EventEvent>().WithMany()
                                    .HasForeignKey("EventEventId")
                                    .HasConstraintName("event_track_tags_rel_event_event_id_fkey"),
                                j =>
                                {
                                    j.HasKey("EventEventId", "EventTrackTagId").HasName("event_track_tags_rel_pkey");
                                    j.ToTable("event_track_tags_rel");
                                    j.HasIndex(new[] { "EventTrackTagId", "EventEventId" }, "event_track_tags_rel_event_track_tag_id_event_event_id_idx");
                                    j.IndexerProperty<Guid>("EventEventId").HasColumnName("event_event_id");
                                    j.IndexerProperty<Guid>("EventTrackTagId").HasColumnName("event_track_tag_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}