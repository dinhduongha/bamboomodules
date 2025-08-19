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
        public static void ConfigureEventEventConfigurator(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<EventEventConfigurator>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("event_event_configurator_pkey");

            entity.ToTable("event_event_configurator");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.EventTicketId).HasColumnName("event_ticket_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.EventEventConfiguratorCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("event_event_configurator_create_uid_fkey");

            entity.HasOne(d => d.Event).WithMany(p => p.EventEventConfigurator)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("event_event_configurator_event_id_fkey");

            entity.HasOne(d => d.EventTicket).WithMany(p => p.EventEventConfigurator)
                .HasForeignKey(d => d.EventTicketId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("event_event_configurator_event_ticket_id_fkey");

            // entity.HasOne(d => d.Product).WithMany(p => p.EventEventConfigurator)
            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("event_event_configurator_product_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.EventEventConfiguratorWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("event_event_configurator_write_uid_fkey");
            });
        }
    }
}