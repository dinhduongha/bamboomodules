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
        public static void ConfigureRegistrationEditorLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<RegistrationEditorLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("registration_editor_line_pkey");

            entity.ToTable("registration_editor_line");

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
            entity.Property(e => e.EditorId).HasColumnName("editor_id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.EventTicketId).HasColumnName("event_ticket_id");
            entity.Property(e => e.Mobile).HasColumnName("mobile");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.RegistrationId).HasColumnName("registration_id");
            entity.Property(e => e.SaleOrderLineId).HasColumnName("sale_order_line_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.RegistrationEditorLineCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("registration_editor_line_create_uid_fkey");

            entity.HasOne(d => d.Editor).WithMany(p => p.RegistrationEditorLine)
                .HasForeignKey(d => d.EditorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("registration_editor_line_editor_id_fkey");

            entity.HasOne(d => d.Event).WithMany(p => p.RegistrationEditorLine)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("registration_editor_line_event_id_fkey");

            entity.HasOne(d => d.EventTicket).WithMany(p => p.RegistrationEditorLine)
                .HasForeignKey(d => d.EventTicketId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("registration_editor_line_event_ticket_id_fkey");

            entity.HasOne(d => d.Registration).WithMany(p => p.RegistrationEditorLine)
                .HasForeignKey(d => d.RegistrationId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("registration_editor_line_registration_id_fkey");

            entity.HasOne(d => d.SaleOrderLine).WithMany(p => p.RegistrationEditorLine)
                .HasForeignKey(d => d.SaleOrderLineId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("registration_editor_line_sale_order_line_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.RegistrationEditorLineWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("registration_editor_line_write_uid_fkey");
            });
        }
    }
}