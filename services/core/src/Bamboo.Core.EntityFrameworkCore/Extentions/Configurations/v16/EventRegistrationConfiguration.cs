using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.ToTable("event_registration");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.Name, "event_registration__name_index")
                            .HasMethod("gin")
                            .HasOperators(new[] { "gin_trgm_ops" });

                        entity.HasIndex(e => e.UtmCampaignId, "event_registration__utm_campaign_id_index");

                        entity.HasIndex(e => e.UtmMediumId, "event_registration__utm_medium_id_index");

                        entity.HasIndex(e => e.UtmSourceId, "event_registration__utm_source_id_index");

                        entity.HasIndex(e => e.Barcode, "event_registration_barcode_event_uniq").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.Barcode).HasColumnName("barcode");

                        entity.Property(e => e.CompanyName).HasColumnName("company_name");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DateClosed)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_closed");
                        entity.Property(e => e.Email).HasColumnName("email");
                        entity.Property(e => e.EventId).HasColumnName("event_id");
                        entity.Property(e => e.EventTicketId).HasColumnName("event_ticket_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.Phone).HasColumnName("phone");
                        entity.Property(e => e.PosOrderLineId).HasColumnName("pos_order_line_id");
                        entity.Property(e => e.RegistrationProperties)
                            .HasColumnType("jsonb")
                            .HasColumnName("registration_properties");
                        entity.Property(e => e.SaleOrderId).HasColumnName("sale_order_id");
                        entity.Property(e => e.SaleOrderLineId).HasColumnName("sale_order_line_id");
                        entity.Property(e => e.SaleStatus).HasColumnName("sale_status");
                        entity.Property(e => e.State).HasColumnName("state");
                        entity.Property(e => e.UtmCampaignId).HasColumnName("utm_campaign_id");
                        entity.Property(e => e.UtmMediumId).HasColumnName("utm_medium_id");
                        entity.Property(e => e.UtmSourceId).HasColumnName("utm_source_id");
                        entity.Property(e => e.VisitorId).HasColumnName("visitor_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.EventRegistration) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_registration_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_registration_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.EventRegistrationCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_registration_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_registration_create_uid_fkey");

                        entity.HasOne(d => d.Event).WithMany(p => p.EventRegistration)
                            .HasForeignKey(d => d.EventId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("event_registration_event_id_fkey");

                        entity.HasOne(d => d.EventTicket).WithMany(p => p.EventRegistration)
                            .HasForeignKey(d => d.EventTicketId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("event_registration_event_ticket_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.EventRegistration) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_registration_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_registration_partner_id_fkey");

                        entity.HasOne(d => d.PosOrderLine).WithMany(p => p.EventRegistration)
                            .HasForeignKey(d => d.PosOrderLineId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("event_registration_pos_order_line_id_fkey");

                        entity.HasOne(d => d.SaleOrder).WithMany(p => p.EventRegistration)
                            .HasForeignKey(d => d.SaleOrderId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("event_registration_sale_order_id_fkey");

                        entity.HasOne(d => d.SaleOrderLine).WithMany(p => p.EventRegistration)
                            .HasForeignKey(d => d.SaleOrderLineId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("event_registration_sale_order_line_id_fkey");

                        entity.HasOne(d => d.UtmCampaign).WithMany(p => p.EventRegistration)
                            .HasForeignKey(d => d.UtmCampaignId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_registration_utm_campaign_id_fkey");

                        entity.HasOne(d => d.UtmMedium).WithMany(p => p.EventRegistration)
                            .HasForeignKey(d => d.UtmMediumId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_registration_utm_medium_id_fkey");

                        entity.HasOne(d => d.UtmSource).WithMany(p => p.EventRegistration)
                            .HasForeignKey(d => d.UtmSourceId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_registration_utm_source_id_fkey");

                        entity.HasOne(d => d.Visitor).WithMany(p => p.EventRegistration)
                            .HasForeignKey(d => d.VisitorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_registration_visitor_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.EventRegistrationWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_registration_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_registration_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}