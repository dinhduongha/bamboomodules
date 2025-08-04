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
        public static void ConfigureRegistrationEditorLine(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegistrationEditorLine>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("registration_editor_line_pkey");

                entity.ToTable("registration_editor_line", tb => tb.HasComment("Edit Attendee Line on Sales Confirmation"));

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
                entity.Property(e => e.EditorId)
                    .HasComment("Editor")
                    .HasColumnName("editor_id");
                entity.Property(e => e.Email)
                    .HasComment("Email")
                    .HasColumnType("character varying")
                    .HasColumnName("email");
                entity.Property(e => e.EventId)
                    .HasComment("Event")
                    .HasColumnName("event_id");
                entity.Property(e => e.EventTicketId)
                    .HasComment("Event Ticket")
                    .HasColumnName("event_ticket_id");
                entity.Property(e => e.Mobile)
                    .HasComment("Mobile")
                    .HasColumnType("character varying")
                    .HasColumnName("mobile");
                entity.Property(e => e.Name)
                    .HasComment("Name")
                    .HasColumnType("character varying")
                    .HasColumnName("name");
                entity.Property(e => e.Phone)
                    .HasComment("Phone")
                    .HasColumnType("character varying")
                    .HasColumnName("phone");
                entity.Property(e => e.RegistrationId)
                    .HasComment("Original Registration")
                    .HasColumnName("registration_id");
                entity.Property(e => e.SaleOrderLineId)
                    .HasComment("Sales Order Line")
                    .HasColumnName("sale_order_line_id");
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
                    .HasConstraintName("registration_editor_line_create_uid_fkey");

                entity.HasOne(d => d.Editor).WithMany(p => p.RegistrationEditorLines)
                    .HasForeignKey(d => d.EditorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("registration_editor_line_editor_id_fkey");

                entity.HasOne(d => d.Event).WithMany(p => p.RegistrationEditorLines)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("registration_editor_line_event_id_fkey");

                entity.HasOne(d => d.EventTicket).WithMany(p => p.RegistrationEditorLines)
                    .HasForeignKey(d => d.EventTicketId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("registration_editor_line_event_ticket_id_fkey");

                entity.HasOne(d => d.Registration).WithMany(p => p.RegistrationEditorLines)
                    .HasForeignKey(d => d.RegistrationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("registration_editor_line_registration_id_fkey");

                entity.HasOne(d => d.SaleOrderLine).WithMany()
                    .HasForeignKey(d => d.SaleOrderLineId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("registration_editor_line_sale_order_line_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("registration_editor_line_write_uid_fkey");
            });
        }
    }
}