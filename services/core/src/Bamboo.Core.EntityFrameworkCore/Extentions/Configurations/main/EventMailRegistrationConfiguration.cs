using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.ToTable("event_mail_registration");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

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
                        entity.Property(e => e.MailSent).HasColumnName("mail_sent");
                        entity.Property(e => e.RegistrationId).HasColumnName("registration_id");
                        entity.Property(e => e.ScheduledDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("scheduled_date");
                        entity.Property(e => e.SchedulerId).HasColumnName("scheduler_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.EventMailRegistrationCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_mail_registration_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_mail_registration_create_uid_fkey");

                        entity.HasOne(d => d.Registration).WithMany(p => p.EventMailRegistration)
                            .HasForeignKey(d => d.RegistrationId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("event_mail_registration_registration_id_fkey");

                        entity.HasOne(d => d.Scheduler).WithMany(p => p.EventMailRegistration)
                            .HasForeignKey(d => d.SchedulerId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("event_mail_registration_scheduler_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.EventMailRegistrationWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_mail_registration_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_mail_registration_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}