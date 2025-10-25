using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureEventType(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<EventType>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("event_type_pkey");

                        entity.ToTable("event_type");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.BoothMenu).HasColumnName("booth_menu");
                        entity.Property(e => e.CommunityMenu).HasColumnName("community_menu");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DefaultTimezone).HasColumnName("default_timezone");
                        entity.Property(e => e.ExhibitorMenu).HasColumnName("exhibitor_menu");
                        entity.Property(e => e.HasSeatsLimitation).HasColumnName("has_seats_limitation");
                        entity.Property(e => e.MeetingRoomAllowCreation).HasColumnName("meeting_room_allow_creation");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.Note).HasColumnName("note");
                        entity.Property(e => e.SeatsMax).HasColumnName("seats_max");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.TicketInstructions)
                            .HasColumnType("jsonb")
                            .HasColumnName("ticket_instructions");
                        entity.Property(e => e.WebsiteMenu).HasColumnName("website_menu");
                        entity.Property(e => e.WebsiteTrack).HasColumnName("website_track");
                        entity.Property(e => e.WebsiteTrackProposal).HasColumnName("website_track_proposal");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.EventTypeCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_type_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_type_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.EventTypeWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_type_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_type_write_uid_fkey");

                        // entity.HasMany(d => d.EventTag).WithMany(p => p.EventType)
                        entity.HasMany(d => d.EventTag).WithMany(p => p.EventType)
                            .UsingEntity<Dictionary<string, object>>(
                                "EventTagEventTypeRel",
                                r => r.HasOne<EventTag>().WithMany()
                                    .HasForeignKey("EventTagId")
                                    .HasConstraintName("event_tag_event_type_rel_event_tag_id_fkey"),
                                l => l.HasOne<EventType>().WithMany()
                                    .HasForeignKey("EventTypeId")
                                    .HasConstraintName("event_tag_event_type_rel_event_type_id_fkey"),
                                j =>
                                {
                                    j.HasKey("EventTypeId", "EventTagId").HasName("event_tag_event_type_rel_pkey");
                                    j.ToTable("event_tag_event_type_rel");
                                    j.HasIndex(new[] { "EventTagId", "EventTypeId" }, "event_tag_event_type_rel_event_tag_id_event_type_id_idx");
                                    j.IndexerProperty<Guid>("EventTypeId").HasColumnName("event_type_id");
                                    j.IndexerProperty<Guid>("EventTagId").HasColumnName("event_tag_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}