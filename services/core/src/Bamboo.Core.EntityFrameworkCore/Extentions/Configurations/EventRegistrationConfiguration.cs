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
        public static void ConfigureEventRegistration(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventRegistration>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("event_registration_pkey");

                entity.ToTable("event_registration", tb => tb.HasComment("Event Registration"));

                entity.HasIndex(e => e.Name, "event_registration_name_index")
                    .HasMethod("gin")
                    .HasOperators(new[] { "gin_trgm_ops" });

                entity.HasIndex(e => e.UtmCampaignId, "event_registration_utm_campaign_id_index");

                entity.HasIndex(e => e.UtmMediumId, "event_registration_utm_medium_id_index");

                entity.HasIndex(e => e.UtmSourceId, "event_registration_utm_source_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active)
                    .HasComment("Active")
                    .HasColumnName("active");
                entity.Property(e => e.TenantId)
                    .HasComment("Company")
                    .HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.DateClosed)
                    .HasComment("Attended Date")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_closed");
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
                entity.Property(e => e.IsPaid)
                    .HasComment("Is Paid")
                    .HasColumnName("is_paid");
                entity.Property(e => e.MessageMainAttachmentId)
                    .HasComment("Main Attachment")
                    .HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Mobile)
                    .HasComment("Mobile")
                    .HasColumnType("character varying")
                    .HasColumnName("mobile");
                entity.Property(e => e.Name)
                    .HasComment("Attendee Name")
                    .HasColumnType("character varying")
                    .HasColumnName("name");
                entity.Property(e => e.PartnerId)
                    .HasComment("Booked by")
                    .HasColumnName("partner_id");
                entity.Property(e => e.Phone)
                    .HasComment("Phone")
                    .HasColumnType("character varying")
                    .HasColumnName("phone");
                entity.Property(e => e.SaleOrderId)
                    .HasComment("Sales Order")
                    .HasColumnName("sale_order_id");
                entity.Property(e => e.SaleOrderLineId)
                    .HasComment("Sales Order Line")
                    .HasColumnName("sale_order_line_id");
                entity.Property(e => e.State)
                    .HasComment("Status")
                    .HasColumnType("character varying")
                    .HasColumnName("state");
                entity.Property(e => e.UtmCampaignId)
                    .HasComment("Campaign")
                    .HasColumnName("utm_campaign_id");
                entity.Property(e => e.UtmMediumId)
                    .HasComment("Medium")
                    .HasColumnName("utm_medium_id");
                entity.Property(e => e.UtmSourceId)
                    .HasComment("Source")
                    .HasColumnName("utm_source_id");
                entity.Property(e => e.VisitorId)
                    .HasComment("Visitor")
                    .HasColumnName("visitor_id");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_registration_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_registration_create_uid_fkey");

                entity.HasOne(d => d.Event).WithMany(p => p.EventRegistrations)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("event_registration_event_id_fkey");

                entity.HasOne(d => d.EventTicket).WithMany(p => p.EventRegistrations)
                    .HasForeignKey(d => d.EventTicketId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("event_registration_event_ticket_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_registration_message_main_attachment_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_registration_partner_id_fkey");

                entity.HasOne(d => d.SaleOrder).WithMany()
                    .HasForeignKey(d => d.SaleOrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("event_registration_sale_order_id_fkey");

                entity.HasOne(d => d.SaleOrderLine).WithMany()
                    .HasForeignKey(d => d.SaleOrderLineId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("event_registration_sale_order_line_id_fkey");

                entity.HasOne(d => d.UtmCampaign).WithMany(p => p.EventRegistrations)
                    .HasForeignKey(d => d.UtmCampaignId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_registration_utm_campaign_id_fkey");

                entity.HasOne(d => d.UtmMedium).WithMany(p => p.EventRegistrations)
                    .HasForeignKey(d => d.UtmMediumId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_registration_utm_medium_id_fkey");

                entity.HasOne(d => d.UtmSource).WithMany()
                    .HasForeignKey(d => d.UtmSourceId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_registration_utm_source_id_fkey");

                entity.HasOne(d => d.Visitor).WithMany(p => p.EventRegistrations)
                    .HasForeignKey(d => d.VisitorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_registration_visitor_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_registration_write_uid_fkey");

                entity.HasMany(d => d.CrmLeads).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "CrmLeadEventRegistrationRel",
                        r => r.HasOne<CrmLead>().WithMany()
                            .HasForeignKey("CrmLeadId")
                            .HasConstraintName("crm_lead_event_registration_rel_crm_lead_id_fkey"),
                        l => l.HasOne<EventRegistration>().WithMany()
                            .HasForeignKey("EventRegistrationId")
                            .HasConstraintName("crm_lead_event_registration_rel_event_registration_id_fkey"),
                        j =>
                        {
                            j.HasKey("EventRegistrationId", "CrmLeadId").HasName("crm_lead_event_registration_rel_pkey");
                            j.ToTable("crm_lead_event_registration_rel", tb => tb.HasComment("RELATION BETWEEN event_registration AND crm_lead"));
                            j.HasIndex(new[] { "CrmLeadId", "EventRegistrationId" }, "crm_lead_event_registration_r_crm_lead_id_event_registratio_idx");
                            j.IndexerProperty<Guid>("EventRegistrationId").HasColumnName("event_registration_id");
                            j.IndexerProperty<Guid>("CrmLeadId").HasColumnName("crm_lead_id");
                        });
            });
        }
    }
}