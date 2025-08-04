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
        public static void ConfigureEventMail(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventMail>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("event_mail_pkey");

                entity.ToTable("event_mail", tb => tb.HasComment("Event Automated Mailing"));

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
                entity.Property(e => e.EventId)
                    .HasComment("Event")
                    .HasColumnName("event_id");
                entity.Property(e => e.IntervalNbr)
                    .HasComment("Interval")
                    .HasColumnName("interval_nbr");
                entity.Property(e => e.IntervalType)
                    .HasComment("Trigger ")
                    .HasColumnType("character varying")
                    .HasColumnName("interval_type");
                entity.Property(e => e.IntervalUnit)
                    .HasComment("Unit")
                    .HasColumnType("character varying")
                    .HasColumnName("interval_unit");
                entity.Property(e => e.MailCountDone)
                    .HasComment("# Sent")
                    .HasColumnName("mail_count_done");
                entity.Property(e => e.MailDone)
                    .HasComment("Sent")
                    .HasColumnName("mail_done");
                entity.Property(e => e.NotificationType)
                    .HasComment("Send")
                    .HasColumnType("character varying")
                    .HasColumnName("notification_type");
                entity.Property(e => e.ScheduledDate)
                    .HasComment("Schedule Date")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("scheduled_date");
                entity.Property(e => e.Sequence)
                    .HasComment("Display order")
                    .HasColumnName("sequence");
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
                    .HasConstraintName("event_mail_create_uid_fkey");

                entity.HasOne(d => d.Event).WithMany(p => p.EventMails)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("event_mail_event_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_mail_write_uid_fkey");
            });
        }
    }
}