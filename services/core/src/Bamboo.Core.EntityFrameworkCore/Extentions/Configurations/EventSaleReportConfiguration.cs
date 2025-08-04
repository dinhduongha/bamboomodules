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
        public static void ConfigureEventSaleReport(this ModelBuilder modelBuilder)
        {
            // TODO HasNoKey
            /*
            modelBuilder.Entity<EventSaleReport>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("event_sale_report");

                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.EventDateBegin)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("event_date_begin");
                entity.Property(e => e.EventDateEnd)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("event_date_end");
                entity.Property(e => e.EventId).HasColumnName("event_id");
                entity.Property(e => e.EventRegistrationCreateDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("event_registration_create_date");
                entity.Property(e => e.EventRegistrationId).HasColumnName("event_registration_id");
                entity.Property(e => e.EventRegistrationName)
                    .HasColumnType("character varying")
                    .HasColumnName("event_registration_name");
                entity.Property(e => e.EventRegistrationState)
                    .HasColumnType("character varying")
                    .HasColumnName("event_registration_state");
                entity.Property(e => e.EventTicketId).HasColumnName("event_ticket_id");
                entity.Property(e => e.EventTicketPrice).HasColumnName("event_ticket_price");
                entity.Property(e => e.EventTypeId).HasColumnName("event_type_id");
                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.InvoicePartnerId).HasColumnName("invoice_partner_id");
                entity.Property(e => e.IsPaid).HasColumnName("is_paid");
                entity.Property(e => e.IsPublished).HasColumnName("is_published");
                entity.Property(e => e.PaymentStatus).HasColumnName("payment_status");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.SaleOrderDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("sale_order_date");
                entity.Property(e => e.SaleOrderId).HasColumnName("sale_order_id");
                entity.Property(e => e.SaleOrderLineId).HasColumnName("sale_order_line_id");
                entity.Property(e => e.SaleOrderPartnerId).HasColumnName("sale_order_partner_id");
                entity.Property(e => e.SaleOrderState)
                    .HasColumnType("character varying")
                    .HasColumnName("sale_order_state");
                entity.Property(e => e.SaleOrderUserId).HasColumnName("sale_order_user_id");
                entity.Property(e => e.SalePrice).HasColumnName("sale_price");
                entity.Property(e => e.SalePriceUntaxed).HasColumnName("sale_price_untaxed");
            });
            */
        }
    }
}