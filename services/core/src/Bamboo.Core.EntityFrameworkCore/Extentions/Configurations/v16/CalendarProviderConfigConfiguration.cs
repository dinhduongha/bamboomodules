using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureCalendarProviderConfig(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<CalendarProviderConfig>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("calendar_provider_config_pkey");

            entity.ToTable("calendar_provider_config");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.CalClientId).HasColumnName("cal_client_id");
            entity.Property(e => e.CalClientSecret).HasColumnName("cal_client_secret");
            entity.Property(e => e.CalSyncPaused).HasColumnName("cal_sync_paused");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.ExternalCalendarProvider).HasColumnName("external_calendar_provider");
            entity.Property(e => e.MicrosoftOutlookClientIdentifier).HasColumnName("microsoft_outlook_client_identifier");
            entity.Property(e => e.MicrosoftOutlookClientSecret).HasColumnName("microsoft_outlook_client_secret");
            entity.Property(e => e.MicrosoftOutlookSyncPaused).HasColumnName("microsoft_outlook_sync_paused");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.CalendarProviderConfigCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("calendar_provider_config_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.CalendarProviderConfigWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("calendar_provider_config_write_uid_fkey");
            });
        }
    }
}
