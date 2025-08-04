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
        public static void ConfigureEventMailRegistration(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventMailRegistration>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("event_mail_registration_pkey");

                entity.ToTable("event_mail_registration", tb => tb.HasComment("Registration Mail Scheduler"));

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
                entity.Property(e => e.MailSent)
                    .HasComment("Mail Sent")
                    .HasColumnName("mail_sent");
                entity.Property(e => e.RegistrationId)
                    .HasComment("Attendee")
                    .HasColumnName("registration_id");
                entity.Property(e => e.ScheduledDate)
                    .HasComment("Scheduled Time")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("scheduled_date");
                entity.Property(e => e.SchedulerId)
                    .HasComment("Mail Scheduler")
                    .HasColumnName("scheduler_id");
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
                    .HasConstraintName("event_mail_registration_create_uid_fkey");

                entity.HasOne(d => d.Registration).WithMany(p => p.EventMailRegistrations)
                    .HasForeignKey(d => d.RegistrationId)
                    .HasConstraintName("event_mail_registration_registration_id_fkey");

                entity.HasOne(d => d.Scheduler).WithMany(p => p.EventMailRegistrations)
                    .HasForeignKey(d => d.SchedulerId)
                    .HasConstraintName("event_mail_registration_scheduler_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_mail_registration_write_uid_fkey");
            });
        }
    }
}