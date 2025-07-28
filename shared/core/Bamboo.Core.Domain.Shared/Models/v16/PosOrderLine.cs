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
public partial class PosOrderLine: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("combo_parent_id")]
    public Guid? ComboParentId { get; set; }

    [Column("combo_item_id")]
    public Guid? ComboItemId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("notice")]
    public string? Notice { get; set; }

    [Column("price_type")]
    public string? PriceType { get; set; }

    [Column("full_product_name")]
    public string? FullProductName { get; set; }

    [Column("customer_note")]
    public string? CustomerNote { get; set; }

    [Column("uuid")]
    public string? Uuid { get; set; }

    [Column("note")]
    public string? Note { get; set; }

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

    [Column("skip_change")]
    public bool? SkipChange { get; set; }

    [Column("is_total_cost_computed")]
    public bool? IsTotalCostComputed { get; set; }

    [Column("is_edited")]
    public bool? IsEdited { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("price_extra")]
    public double? PriceExtra { get; set; }

    [Column("sale_order_origin_id")]
    public Guid? SaleOrderOriginId { get; set; }

    [Column("sale_order_line_id")]
    public Guid? SaleOrderLineId { get; set; }

    [Column("down_payment_details")]
    public string? DownPaymentDetails { get; set; }

    [Column("qty_delivered")]
    public double? QtyDelivered { get; set; }

    [Column("combo_id")]
    public Guid? ComboId { get; set; }

    [Column("event_ticket_id")]
    public Guid? EventTicketId { get; set; }

    [ForeignKey("ComboId")]
    //[InverseProperty("PosOrderLines")]
    [NotMapped]
    public virtual ProductCombo? Combo { get; set; }

    [ForeignKey("ComboItemId")]
    //[InverseProperty("PosOrderLines")]
    [NotMapped]
    public virtual ProductComboItem? ComboItem { get; set; }

    [ForeignKey("ComboParentId")]
    //[InverseProperty("InverseComboParent")]
    [NotMapped]
    public virtual PosOrderLine? ComboParent { get; set; }

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
    public virtual ICollection<PosOrderLine> InverseRefundedOrderline { get; set; } 

    //[InverseProperty("PosOrderLine")]
    [NotMapped]
    public virtual ICollection<PosPackOperationLot> PosPackOperationLots { get; set; } 

    [ForeignKey("PosOrderLineId")]
    //[InverseProperty("PosOrderLines")]
    [NotMapped]
    public virtual ICollection<AccountTax> AccountTaxes { get; set; } 
}
