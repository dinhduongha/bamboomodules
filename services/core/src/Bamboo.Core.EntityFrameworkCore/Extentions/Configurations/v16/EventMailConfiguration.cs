using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.ToTable("event_mail");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.EventId).HasColumnName("event_id");
                        entity.Property(e => e.IntervalNbr).HasColumnName("interval_nbr");
                        entity.Property(e => e.IntervalType).HasColumnName("interval_type");
                        entity.Property(e => e.IntervalUnit).HasColumnName("interval_unit");
                        entity.Property(e => e.LastRegistrationId).HasColumnName("last_registration_id");
                        entity.Property(e => e.MailCountDone).HasColumnName("mail_count_done");
                        entity.Property(e => e.MailDone).HasColumnName("mail_done");
                        entity.Property(e => e.ScheduledDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("scheduled_date");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.TemplateRef).HasColumnName("template_ref");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.EventMailCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_mail_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_mail_create_uid_fkey");

                        entity.HasOne(d => d.Event).WithMany(p => p.EventMail)
                            .HasForeignKey(d => d.EventId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("event_mail_event_id_fkey");

                        entity.HasOne(d => d.LastRegistration).WithMany(p => p.EventMail)
                            .HasForeignKey(d => d.LastRegistrationId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_mail_last_registration_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.EventMailWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_mail_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_mail_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}