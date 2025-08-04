using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
// TODO: Hãy chắc chắn rằng bạn đã thêm using cho namespace chứa Models của mình ở đây
// Ví dụ: using YourProject.Models;
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

                entity.ToTable("event_type_ticket", tb => tb.HasComment("Event Template Ticket"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.Description)
                    .HasComment("Description")
                    .HasColumnType("jsonb")
                    .HasColumnName("description");
                entity.Property(e => e.EventTypeId)
                    .HasComment("Event Category")
                    .HasColumnName("event_type_id");
                entity.Property(e => e.Name)
                    .HasComment("Name")
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.Price)
                    .HasComment("Price")
                    .HasColumnName("price");
                entity.Property(e => e.ProductId)
                    .HasComment("Product")
                    .HasColumnName("product_id");
                entity.Property(e => e.SeatsLimited)
                    .HasComment("Limit Attendees")
                    .HasColumnName("seats_limited");
                entity.Property(e => e.SeatsMax)
                    .HasComment("Maximum Attendees")
                    .HasColumnName("seats_max");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_type_ticket_create_uid_fkey");

                entity.HasOne(d => d.EventType).WithMany(p => p.EventTypeTickets)
                    .HasForeignKey(d => d.EventTypeId)
                    .HasConstraintName("event_type_ticket_event_type_id_fkey");

                entity.HasOne(d => d.Product).WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("event_type_ticket_product_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_type_ticket_write_uid_fkey");
            });
        }
    }
}