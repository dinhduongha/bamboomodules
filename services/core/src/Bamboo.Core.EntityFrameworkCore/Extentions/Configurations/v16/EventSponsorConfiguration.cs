using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureEventSponsor(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<EventSponsor>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("event_sponsor_pkey");

                        entity.ToTable("event_sponsor");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.IsPublished, "event_sponsor__is_published_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.ChatRoomId).HasColumnName("chat_room_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Email).HasColumnName("email");
                        entity.Property(e => e.EventId).HasColumnName("event_id");
                        entity.Property(e => e.ExhibitorType).HasColumnName("exhibitor_type");
                        entity.Property(e => e.HourFrom).HasColumnName("hour_from");
                        entity.Property(e => e.HourTo).HasColumnName("hour_to");
                        entity.Property(e => e.IsPublished).HasColumnName("is_published");
                        entity.Property(e => e.Mobile).HasColumnName("mobile");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.Phone).HasColumnName("phone");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.SponsorTypeId).HasColumnName("sponsor_type_id");
                        entity.Property(e => e.Subtitle).HasColumnName("subtitle");
                        entity.Property(e => e.Url).HasColumnName("url");
                        entity.Property(e => e.WebsiteDescription)
                            .HasColumnType("jsonb")
                            .HasColumnName("website_description");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.ChatRoom).WithMany(p => p.EventSponsor)
                            .HasForeignKey(d => d.ChatRoomId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_sponsor_chat_room_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.EventSponsorCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_sponsor_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_sponsor_create_uid_fkey");

                        entity.HasOne(d => d.Event).WithMany(p => p.EventSponsor)
                            .HasForeignKey(d => d.EventId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("event_sponsor_event_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.EventSponsor) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("event_sponsor_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("event_sponsor_partner_id_fkey");

                        entity.HasOne(d => d.SponsorType).WithMany(p => p.EventSponsor)
                            .HasForeignKey(d => d.SponsorTypeId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("event_sponsor_sponsor_type_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.EventSponsorWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_sponsor_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_sponsor_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}