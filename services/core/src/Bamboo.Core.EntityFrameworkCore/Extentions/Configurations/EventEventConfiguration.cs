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
        public static void ConfigureEventEvent(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventEvent>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("event_event_pkey");

                entity.ToTable("event_event", tb => tb.HasComment("Event"));

                entity.HasIndex(e => e.IsPublished, "event_event_is_published_index");

                entity.HasIndex(e => e.WebsiteId, "event_event_website_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active)
                    .HasComment("Active")
                    .HasColumnName("active");
                entity.Property(e => e.AddressId)
                    .HasComment("Venue")
                    .HasColumnName("address_id");
                entity.Property(e => e.AutoConfirm) 
                    .HasComment("Autoconfirmation")
                    .HasColumnName("auto_confirm");
                entity.Property(e => e.CommunityMenu)
                    .HasComment("Community Menu")
                    .HasColumnName("community_menu");
                entity.Property(e => e.TenantId)
                    .HasComment("Company")
                    .HasColumnName("company_id");
                entity.Property(e => e.CountryId)
                    .HasComment("Country")
                    .HasColumnName("country_id");
                entity.Property(e => e.CoverProperties)
                    .HasComment("Cover Properties")
                    .HasColumnName("cover_properties");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.DateBegin)
                    .HasComment("Start Date")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_begin");
                entity.Property(e => e.DateEnd)
                    .HasComment("End Date")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_end");
                entity.Property(e => e.DateTz)
                    .HasComment("Timezone")
                    .HasColumnType("character varying")
                    .HasColumnName("date_tz");
                entity.Property(e => e.Description)
                    .HasComment("Description")
                    .HasColumnType("jsonb")
                    .HasColumnName("description");
                entity.Property(e => e.EventTypeId)
                    .HasComment("Template")
                    .HasColumnName("event_type_id");
                entity.Property(e => e.IntroductionMenu)
                    .HasComment("Introduction Menu")
                    .HasColumnName("introduction_menu");
                entity.Property(e => e.IsPublished)
                    .HasComment("Is Published")
                    .HasColumnName("is_published");
                entity.Property(e => e.KanbanState)
                    .HasComment("Kanban State")
                    .HasColumnType("character varying")
                    .HasColumnName("kanban_state");
                entity.Property(e => e.KanbanStateLabel)
                    .HasComment("Kanban State Label")
                    .HasColumnType("character varying")
                    .HasColumnName("kanban_state_label");
                entity.Property(e => e.LocationMenu)
                    .HasComment("Location Menu")
                    .HasColumnName("location_menu");
                entity.Property(e => e.MenuId)
                    .HasComment("Event Menu")
                    .HasColumnName("menu_id");
                entity.Property(e => e.MenuRegisterCta)
                    .HasComment("Extra Register Button")
                    .HasColumnName("menu_register_cta");
                entity.Property(e => e.MessageMainAttachmentId)
                    .HasComment("Main Attachment")
                    .HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Name)
                    .HasComment("Event")
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.Note)
                    .HasComment("Note")
                    .HasColumnName("note");
                entity.Property(e => e.OrganizerId)
                    .HasComment("Organizer")
                    .HasColumnName("organizer_id");
                entity.Property(e => e.RegisterMenu)
                    .HasComment("Register Menu")
                    .HasColumnName("register_menu");
                entity.Property(e => e.SeatsLimited)
                    .HasComment("Limit Attendees")
                    .HasColumnName("seats_limited");
                entity.Property(e => e.SeatsMax)
                    .HasComment("Maximum Attendees")
                    .HasColumnName("seats_max");
                entity.Property(e => e.SeoName)
                    .HasComment("Seo name")
                    .HasColumnType("jsonb")
                    .HasColumnName("seo_name");
                entity.Property(e => e.StageId)
                    .HasComment("Stage")
                    .HasColumnName("stage_id");
                entity.Property(e => e.Subtitle)
                    .HasComment("Event Subtitle")
                    .HasColumnType("jsonb")
                    .HasColumnName("subtitle");
                entity.Property(e => e.TicketInstructions)
                    .HasComment("Ticket Instructions")
                    .HasColumnType("jsonb")
                    .HasColumnName("ticket_instructions");
                entity.Property(e => e.UserId)
                    .HasComment("Responsible")
                    .HasColumnName("user_id");
                entity.Property(e => e.WebsiteId)
                    .HasComment("Website")
                    .HasColumnName("website_id");
                entity.Property(e => e.WebsiteMenu)
                    .HasComment("Website Menu")
                    .HasColumnName("website_menu");
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

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_event_address_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_event_company_id_fkey");

                entity.HasOne<ResCountry>().WithMany()
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_event_country_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_event_create_uid_fkey");

                entity.HasOne(d => d.EventType).WithMany(p => p.EventEvents)
                    .HasForeignKey(d => d.EventTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_event_event_type_id_fkey");

                entity.HasOne<WebsiteMenu>().WithMany()
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_event_menu_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_event_message_main_attachment_id_fkey");

                entity.HasOne(d => d.Organizer).WithMany()
                    .HasForeignKey(d => d.OrganizerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_event_organizer_id_fkey");

                entity.HasOne(d => d.Stage).WithMany(p => p.EventEvents)
                    .HasForeignKey(d => d.StageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("event_event_stage_id_fkey");

                entity.HasOne(d => d.User).WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_event_user_id_fkey");

                entity.HasOne(d => d.Website).WithMany()
                    .HasForeignKey(d => d.WebsiteId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("event_event_website_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_event_write_uid_fkey");

                entity.HasMany(d => d.EventTags).WithMany(p => p.EventEvents)
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
                            j.ToTable("event_event_event_tag_rel", tb => tb.HasComment("RELATION BETWEEN event_event AND event_tag"));
                            j.HasIndex(new[] { "EventTagId", "EventEventId" }, "event_event_event_tag_rel_event_tag_id_event_event_id_idx");
                            j.IndexerProperty<Guid>("EventEventId").HasColumnName("event_event_id");
                            j.IndexerProperty<Guid>("EventTagId").HasColumnName("event_tag_id");
                        });
            });
        }
    }
}