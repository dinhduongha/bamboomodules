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
        public static void ConfigureEventEventConfigurator(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventEventConfigurator>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("event_event_configurator_pkey");

                entity.ToTable("event_event_configurator", tb => tb.HasComment("Event Configurator"));

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
                entity.Property(e => e.EventId)
                    .HasComment("Event")
                    .HasColumnName("event_id");
                entity.Property(e => e.EventTicketId)
                    .HasComment("Event Ticket")
                    .HasColumnName("event_ticket_id");
                entity.Property(e => e.ProductId)
                    .HasComment("Product")
                    .HasColumnName("product_id");
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
                    .HasConstraintName("event_event_configurator_create_uid_fkey");

                entity.HasOne(d => d.Event).WithMany(p => p.EventEventConfigurators)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_event_configurator_event_id_fkey");

                entity.HasOne(d => d.EventTicket).WithMany(p => p.EventEventConfigurators)
                    .HasForeignKey(d => d.EventTicketId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_event_configurator_event_ticket_id_fkey");

                entity.HasOne(d => d.Product).WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_event_configurator_product_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_event_configurator_write_uid_fkey");
            });
        }
    }
}