using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigurePosPreset(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<PosPreset>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("pos_preset_pkey");

                        entity.ToTable("pos_preset");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AvailableInSelf).HasColumnName("available_in_self");
                        entity.Property(e => e.Color).HasColumnName("color");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.FiscalPositionId).HasColumnName("fiscal_position_id");
                        entity.Property(e => e.Identification).HasColumnName("identification");
                        entity.Property(e => e.IntervalTime).HasColumnName("interval_time");
                        entity.Property(e => e.IsReturn).HasColumnName("is_return");
                        entity.Property(e => e.MailTemplateId).HasColumnName("mail_template_id");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.PricelistId).HasColumnName("pricelist_id");
                        entity.Property(e => e.ResourceCalendarId).HasColumnName("resource_calendar_id");
                        entity.Property(e => e.ServiceAt).HasColumnName("service_at");
                        entity.Property(e => e.SlotsPerInterval).HasColumnName("slots_per_interval");
                        entity.Property(e => e.UseGuest).HasColumnName("use_guest");
                        entity.Property(e => e.UseTiming).HasColumnName("use_timing");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.PosPresetCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("pos_preset_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_preset_create_uid_fkey");

                        entity.HasOne(d => d.FiscalPosition).WithMany(p => p.PosPreset)
                            .HasForeignKey(d => d.FiscalPositionId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_preset_fiscal_position_id_fkey");

                        entity.HasOne(d => d.MailTemplate).WithMany(p => p.PosPreset)
                            .HasForeignKey(d => d.MailTemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_preset_mail_template_id_fkey");

                        entity.HasOne(d => d.Pricelist).WithMany(p => p.PosPreset)
                            .HasForeignKey(d => d.PricelistId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_preset_pricelist_id_fkey");

                        entity.HasOne(d => d.ResourceCalendar).WithMany(p => p.PosPreset)
                            .HasForeignKey(d => d.ResourceCalendarId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_preset_resource_calendar_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.PosPresetWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("pos_preset_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_preset_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}