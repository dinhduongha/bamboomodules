using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureResourceCalendarLeaves(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ResourceCalendarLeaves>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("resource_calendar_leaves_pkey");

                        entity.ToTable("resource_calendar_leaves");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.CalendarId, "resource_calendar_leaves__calendar_id_index");

                        entity.HasIndex(e => e.ResourceId, "resource_calendar_leaves__resource_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CalendarId).HasColumnName("calendar_id");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DateFrom)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_from");
                        entity.Property(e => e.DateTo)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_to");
                        entity.Property(e => e.HolidayId).HasColumnName("holiday_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.ResourceId).HasColumnName("resource_id");
                        entity.Property(e => e.TimeType).HasColumnName("time_type");
                        entity.Property(e => e.WorkEntryTypeId).HasColumnName("work_entry_type_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Calendar).WithMany(p => p.ResourceCalendarLeaves)
                            .HasForeignKey(d => d.CalendarId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("resource_calendar_leaves_calendar_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.ResourceCalendarLeaves) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("resource_calendar_leaves_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("resource_calendar_leaves_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ResourceCalendarLeavesCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("resource_calendar_leaves_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("resource_calendar_leaves_create_uid_fkey");

                        entity.HasOne(d => d.Holiday).WithMany(p => p.ResourceCalendarLeaves)
                            .HasForeignKey(d => d.HolidayId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("resource_calendar_leaves_holiday_id_fkey");

                        entity.HasOne(d => d.Resource).WithMany(p => p.ResourceCalendarLeaves)
                            .HasForeignKey(d => d.ResourceId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("resource_calendar_leaves_resource_id_fkey");

                        entity.HasOne(d => d.WorkEntryType).WithMany(p => p.ResourceCalendarLeaves)
                            .HasForeignKey(d => d.WorkEntryTypeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("resource_calendar_leaves_work_entry_type_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ResourceCalendarLeavesWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("resource_calendar_leaves_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("resource_calendar_leaves_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}