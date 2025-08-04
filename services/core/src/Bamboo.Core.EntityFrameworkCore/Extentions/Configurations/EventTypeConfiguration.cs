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
        public static void ConfigureEventType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("event_type_pkey");

                entity.ToTable("event_type", tb => tb.HasComment("Event Template"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AutoConfirm)
                    .HasComment("Automatically Confirm Registrations")
                    .HasColumnName("auto_confirm");
                entity.Property(e => e.CommunityMenu)
                    .HasComment("Community Menu")
                    .HasColumnName("community_menu");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.DefaultTimezone)
                    .HasComment("Timezone")
                    .HasColumnType("character varying")
                    .HasColumnName("default_timezone");
                entity.Property(e => e.HasSeatsLimitation)
                    .HasComment("Limited Seats")
                    .HasColumnName("has_seats_limitation");
                entity.Property(e => e.MenuRegisterCta)
                    .HasComment("Extra Register Button")
                    .HasColumnName("menu_register_cta");
                entity.Property(e => e.Name)
                    .HasComment("Event Template")
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.Note)
                    .HasComment("Note")
                    .HasColumnName("note");
                entity.Property(e => e.SeatsMax)
                    .HasComment("Maximum Registrations")
                    .HasColumnName("seats_max");
                entity.Property(e => e.Sequence)
                    .HasComment("Sequence")
                    .HasColumnName("sequence");
                entity.Property(e => e.TicketInstructions)
                    .HasComment("Ticket Instructions")
                    .HasColumnType("jsonb")
                    .HasColumnName("ticket_instructions");
                entity.Property(e => e.WebsiteMenu)
                    .HasComment("Display a dedicated menu on Website")
                    .HasColumnName("website_menu");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_type_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_type_write_uid_fkey");

                entity.HasMany(d => d.EventTags).WithMany(p => p.EventTypes)
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
                            j.ToTable("event_tag_event_type_rel", tb => tb.HasComment("RELATION BETWEEN event_type AND event_tag"));
                            j.HasIndex(new[] { "EventTagId", "EventTypeId" }, "event_tag_event_type_rel_event_tag_id_event_type_id_idx");
                            j.IndexerProperty<Guid>("EventTypeId").HasColumnName("event_type_id");
                            j.IndexerProperty<Guid>("EventTagId").HasColumnName("event_tag_id");
                        });
            });
        }
    }
}