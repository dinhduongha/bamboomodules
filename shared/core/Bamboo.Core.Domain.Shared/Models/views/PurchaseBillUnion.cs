using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

//[Keyless]
public partial class PurchaseBillUnion: Entity<Guid>, IMultiTenant
{
    [Column("id")]
    public Guid? Id { get; set; }

    [Column("name", TypeName = "character varying")]
    public string? Name { get; set; }

    [Column("reference", TypeName = "character varying")]
    public string? Reference { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("amount")]
    public decimal? Amount { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("vendor_bill_id")]
    public Guid? VendorBillId { get; set; }

    [Column("purchase_order_id")]
    public Guid? PurchaseOrderId { get; set; }
}
