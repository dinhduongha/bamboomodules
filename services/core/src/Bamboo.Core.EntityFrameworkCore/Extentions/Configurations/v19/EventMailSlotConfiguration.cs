using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureEventMailSlot(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<EventMailSlot>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("event_mail_slot_pkey");

                        entity.ToTable("event_mail_slot");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.SchedulerId, "event_mail_slot__scheduler_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.EventSlotId).HasColumnName("event_slot_id");
                        entity.Property(e => e.LastRegistrationId).HasColumnName("last_registration_id");
                        entity.Property(e => e.MailCountDone).HasColumnName("mail_count_done");
                        entity.Property(e => e.MailDone).HasColumnName("mail_done");
                        entity.Property(e => e.ScheduledDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("scheduled_date");
                        entity.Property(e => e.SchedulerId).HasColumnName("scheduler_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.EventMailSlotCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_mail_slot_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_mail_slot_create_uid_fkey");

                        entity.HasOne(d => d.EventSlot).WithMany(p => p.EventMailSlot)
                            .HasForeignKey(d => d.EventSlotId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("event_mail_slot_event_slot_id_fkey");

                        entity.HasOne(d => d.LastRegistration).WithMany(p => p.EventMailSlot)
                            .HasForeignKey(d => d.LastRegistrationId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_mail_slot_last_registration_id_fkey");

                        entity.HasOne(d => d.Scheduler).WithMany(p => p.EventMailSlot)
                            .HasForeignKey(d => d.SchedulerId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("event_mail_slot_scheduler_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.EventMailSlotWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_mail_slot_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_mail_slot_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}