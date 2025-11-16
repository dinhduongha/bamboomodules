using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureEventTypeTicket(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<EventTypeTicket>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("event_type_ticket_pkey");

                        entity.ToTable("event_type_ticket");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.ProductId, "event_type_ticket__product_id_index");

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
                        entity.Property(e => e.Description)
                            .HasColumnType("jsonb")
                            .HasColumnName("description");
                        entity.Property(e => e.EventTypeId).HasColumnName("event_type_id");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.Price).HasColumnName("price");
                        entity.Property(e => e.ProductId).HasColumnName("product_id");
                        entity.Property(e => e.SeatsLimited).HasColumnName("seats_limited");
                        entity.Property(e => e.SeatsMax).HasColumnName("seats_max");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.EventTypeTicketCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_type_ticket_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_type_ticket_create_uid_fkey");

                        entity.HasOne(d => d.EventType).WithMany(p => p.EventTypeTicket)
                            .HasForeignKey(d => d.EventTypeId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("event_type_ticket_event_type_id_fkey");

                        // entity.HasOne(d => d.Product).WithMany(p => p.EventTypeTicket) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("event_type_ticket_product_id_fkey");
                        entity.HasOne(d => d.Product).WithMany()
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("event_type_ticket_product_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.EventTypeTicketWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_type_ticket_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_type_ticket_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}