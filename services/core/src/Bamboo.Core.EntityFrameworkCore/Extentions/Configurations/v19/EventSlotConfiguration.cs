using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureEventSlot(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<EventSlot>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("event_slot_pkey");

                        entity.ToTable("event_slot");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.EventId, "event_slot__event_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Color).HasColumnName("color");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Date).HasColumnName("date");
                        entity.Property(e => e.EndDatetime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("end_datetime");
                        entity.Property(e => e.EndHour).HasColumnName("end_hour");
                        entity.Property(e => e.EventId).HasColumnName("event_id");
                        entity.Property(e => e.StartDatetime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("start_datetime");
                        entity.Property(e => e.StartHour).HasColumnName("start_hour");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.EventSlotCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_slot_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_slot_create_uid_fkey");

                        entity.HasOne(d => d.Event).WithMany(p => p.EventSlot)
                            .HasForeignKey(d => d.EventId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("event_slot_event_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.EventSlotWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_slot_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_slot_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}