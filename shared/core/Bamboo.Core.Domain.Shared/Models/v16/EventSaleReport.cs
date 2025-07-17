using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;
//[Keyless]
public partial class EventSaleReport: IMultiTenant
{
    [Column("id")]
    public Guid? Id { get; set; }

    [Column("event_registration_id")]
    public Guid? EventRegistrationId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("event_id")]
    public Guid? EventId { get; set; }

    [Column("event_ticket_id")]
    public Guid? EventTicketId { get; set; }

    [Column("event_registration_create_date", TypeName = "timestamp without time zone")]
    public DateTime? EventRegistrationCreateDate { get; set; }

    [Column("event_registration_name", TypeName = "character varying")]
    public string? EventRegistrationName { get; set; }

    [Column("event_registration_state", TypeName = "character varying")]
    public string? EventRegistrationState { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("sale_order_id")]
    public Guid? SaleOrderId { get; set; }

    [Column("sale_order_line_id")]
    public Guid? SaleOrderLineId { get; set; }

    [Column("is_paid")]
    public bool? IsPaid { get; set; }

    [Column("event_type_id")]
    public Guid? EventTypeId { get; set; }

    [Column("event_date_begin", TypeName = "timestamp without time zone")]
    public DateTime? EventDateBegin { get; set; }

    [Column("event_date_end", TypeName = "timestamp without time zone")]
    public DateTime? EventDateEnd { get; set; }

    [Column("event_ticket_price")]
    public decimal? EventTicketPrice { get; set; }

    [Column("sale_order_date", TypeName = "timestamp without time zone")]
    public DateTime? SaleOrderDate { get; set; }

    [Column("invoice_partner_id")]
    public Guid? InvoicePartnerId { get; set; }

    [Column("sale_order_partner_id")]
    public Guid? SaleOrderPartnerId { get; set; }

    [Column("sale_order_state", TypeName = "character varying")]
    public string? SaleOrderState { get; set; }

    [Column("sale_order_user_id")]
    public Guid? SaleOrderUserId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("sale_price")]
    public decimal? SalePrice { get; set; }

    [Column("sale_price_untaxed")]
    public decimal? SalePriceUntaxed { get; set; }

    [Column("payment_status")]
    public string? PaymentStatus { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }
}
