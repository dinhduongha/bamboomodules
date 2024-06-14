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

[Table("pos_order_line")]
//[Index("OrderId", Name = "pos_order_line_order_id_index")]
public partial class PosOrderLine: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("order_id")]
    public Guid? OrderId { get; set; }

    [Column("refunded_orderline_id")]
    public Guid? RefundedOrderlineId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("notice")]
    public string? Notice { get; set; }

    [Column("full_product_name")]
    public string? FullProductName { get; set; }

    [Column("customer_note")]
    public string? CustomerNote { get; set; }

    [Column("price_unit")]
    public decimal? PriceUnit { get; set; }

    [Column("qty")]
    public decimal? Qty { get; set; }

    [Column("price_subtotal")]
    public decimal? PriceSubtotal { get; set; }

    [Column("price_subtotal_incl")]
    public decimal? PriceSubtotalIncl { get; set; }

    [Column("total_cost")]
    public decimal? TotalCost { get; set; }

    [Column("discount")]
    public decimal? Discount { get; set; }

    [Column("is_total_cost_computed")]
    public bool? IsTotalCostComputed { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("price_extra")]
    public double? PriceExtra { get; set; }

    [Column("sale_order_origin_id")]
    public Guid? SaleOrderOriginId { get; set; }

    [Column("sale_order_line_id")]
    public Guid? SaleOrderLineId { get; set; }

    [Column("down_payment_details")]
    public string? DownPaymentDetails { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("PosOrderLines")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("PosOrderLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("OrderId")]
    //[InverseProperty("PosOrderLines")]
    [NotMapped]
    public virtual PosOrder? Order { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("PosOrderLines")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("RefundedOrderlineId")]
    //[InverseProperty("InverseRefundedOrderline")]
    [NotMapped]
    public virtual PosOrderLine? RefundedOrderline { get; set; }

    [ForeignKey("SaleOrderLineId")]
    //[InverseProperty("PosOrderLines")]
    [NotMapped]
    public virtual SaleOrderLine? SaleOrderLine { get; set; }

    [ForeignKey("SaleOrderOriginId")]
    //[InverseProperty("PosOrderLines")]
    [NotMapped]
    public virtual SaleOrder? SaleOrderOrigin { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("PosOrderLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("RefundedOrderline")]
    [NotMapped]
    public virtual ICollection<PosOrderLine> InverseRefundedOrderline { get; } = new List<PosOrderLine>();

    //[InverseProperty("PosOrderLine")]
    [NotMapped]
    public virtual ICollection<PosPackOperationLot> PosPackOperationLots { get; } = new List<PosPackOperationLot>();

    [ForeignKey("PosOrderLineId")]
    //[InverseProperty("PosOrderLines")]
    [NotMapped]
    public virtual ICollection<AccountTax> AccountTaxes { get; } = new List<AccountTax>();
}
