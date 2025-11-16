using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureEventMeetingRoom(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<EventMeetingRoom>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("event_meeting_room_pkey");

                        entity.ToTable("event_meeting_room");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.IsPublished, "event_meeting_room__is_published_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
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
                        entity.Property(e => e.EventId).HasColumnName("event_id");
                        entity.Property(e => e.IsPinned).HasColumnName("is_pinned");
                        entity.Property(e => e.IsPublished).HasColumnName("is_published");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.Summary)
                            .HasColumnType("jsonb")
                            .HasColumnName("summary");
                        entity.Property(e => e.TargetAudience)
                            .HasColumnType("jsonb")
                            .HasColumnName("target_audience");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.ChatRoom).WithMany(p => p.EventMeetingRoom)
                            .HasForeignKey(d => d.ChatRoomId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("event_meeting_room_chat_room_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.EventMeetingRoomCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_meeting_room_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_meeting_room_create_uid_fkey");

                        entity.HasOne(d => d.Event).WithMany(p => p.EventMeetingRoom)
                            .HasForeignKey(d => d.EventId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("event_meeting_room_event_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.EventMeetingRoomWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_meeting_room_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_meeting_room_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}