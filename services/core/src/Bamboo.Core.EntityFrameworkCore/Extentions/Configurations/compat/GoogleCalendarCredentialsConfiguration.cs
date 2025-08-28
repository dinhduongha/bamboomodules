using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureGoogleCalendarCredentials(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<GoogleCalendarCredentials>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("google_calendar_credentials_pkey");

                        entity.ToTable("google_calendar_credentials");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CalendarCalId).HasColumnName("calendar_cal_id");
                        entity.Property(e => e.CalendarRtoken).HasColumnName("calendar_rtoken");
                        entity.Property(e => e.CalendarSyncToken).HasColumnName("calendar_sync_token");
                        entity.Property(e => e.CalendarToken).HasColumnName("calendar_token");
                        entity.Property(e => e.CalendarTokenValidity)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("calendar_token_validity");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.SynchronizationStopped).HasColumnName("synchronization_stopped");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.GoogleCalendarCredentialsCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("google_calendar_credentials_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("google_calendar_credentials_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.GoogleCalendarCredentialsWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("google_calendar_credentials_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("google_calendar_credentials_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}