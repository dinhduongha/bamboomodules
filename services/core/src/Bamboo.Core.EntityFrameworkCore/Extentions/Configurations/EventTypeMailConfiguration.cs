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
        public static void ConfigureEventTypeMail(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventTypeMail>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("event_type_mail_pkey");

                entity.ToTable("event_type_mail", tb => tb.HasComment("Mail Scheduling on Event Category"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.EventTypeId)
                    .HasComment("Event Type")
                    .HasColumnName("event_type_id");
                entity.Property(e => e.IntervalNbr)
                    .HasComment("Interval")
                    .HasColumnName("interval_nbr");
                entity.Property(e => e.IntervalType)
                    .HasComment("Trigger")
                    .HasColumnType("character varying")
                    .HasColumnName("interval_type");
                entity.Property(e => e.IntervalUnit)
                    .HasComment("Unit")
                    .HasColumnType("character varying")
                    .HasColumnName("interval_unit");
                entity.Property(e => e.NotificationType)
                    .HasComment("Send")
                    .HasColumnType("character varying")
                    .HasColumnName("notification_type");
                entity.Property(e => e.TemplateRef)
                    .HasComment("Template")
                    .HasColumnType("character varying")
                    .HasColumnName("template_ref");
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
                    .HasConstraintName("event_type_mail_create_uid_fkey");

                entity.HasOne(d => d.EventType).WithMany(p => p.EventTypeMails)
                    .HasForeignKey(d => d.EventTypeId)
                    .HasConstraintName("event_type_mail_event_type_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_type_mail_write_uid_fkey");
            });
        }
    }
}