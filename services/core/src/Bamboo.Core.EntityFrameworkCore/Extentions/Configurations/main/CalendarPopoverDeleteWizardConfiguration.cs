using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureCalendarPopoverDeleteWizard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<CalendarPopoverDeleteWizard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("calendar_popover_delete_wizard_pkey");

                        entity.ToTable("calendar_popover_delete_wizard");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Body).HasColumnName("body");
                        entity.Property(e => e.CalendarEventId).HasColumnName("calendar_event_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Delete).HasColumnName("delete");
                        entity.Property(e => e.Lang).HasColumnName("lang");
                        entity.Property(e => e.Subject).HasColumnName("subject");
                        entity.Property(e => e.TemplateId).HasColumnName("template_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.CalendarEvent).WithMany(p => p.CalendarPopoverDeleteWizard)
                            .HasForeignKey(d => d.CalendarEventId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("calendar_popover_delete_wizard_calendar_event_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.CalendarPopoverDeleteWizardCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("calendar_popover_delete_wizard_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("calendar_popover_delete_wizard_create_uid_fkey");

                        entity.HasOne(d => d.Template).WithMany(p => p.CalendarPopoverDeleteWizard)
                            .HasForeignKey(d => d.TemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("calendar_popover_delete_wizard_template_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.CalendarPopoverDeleteWizardWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("calendar_popover_delete_wizard_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("calendar_popover_delete_wizard_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}