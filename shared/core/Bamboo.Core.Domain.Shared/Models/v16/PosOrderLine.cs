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
//[Index("OrderId", Name = "pos_order_line__order_id_index")]
public partial class PosOrderLine: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

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
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

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

    [Column("reward_id")]
    public Guid? RewardId { get; set; }

    [Column("coupon_id")]
    public Guid? CouponId { get; set; }

    [Column("reward_identifier_code")]
    public string? RewardIdentifierCode { get; set; }

    [Column("is_reward_line")]
    public bool? IsRewardLine { get; set; }

    [Column("points_cost")]
    public double? PointsCost { get; set; }

    // [Many2one]
    [ForeignKey("ComboId")]
    public virtual ProductCombo? Combo { get; set; }

    // [Many2one]
    [ForeignKey("ComboItemId")]
    public virtual ProductComboItem? ComboItem { get; set; }

    // [Many2one]
    [ForeignKey("ComboParentId")]
    public virtual PosOrderLine? ComboParent { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CouponId")]
    public virtual LoyaltyCard? Coupon { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("PosOrderLineId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PosOrderLine")] // One2many
    public virtual ICollection<EventRegistration> EventRegistration { get; set; }

    // [Many2one]
    [ForeignKey("EventTicketId")]
    public virtual EventEventTicket? EventTicket { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ComboParentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ComboParent")] // One2many
    public virtual ICollection<PosOrderLine> InverseComboParent { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("RefundedOrderlineId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("RefundedOrderline")] // One2many
    public virtual ICollection<PosOrderLine> InverseRefundedOrderline { get; set; }

    // [Many2one]
    [ForeignKey("OrderId")]
    public virtual PosOrder? Order { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("PosOrderLineId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PosOrderLine")] // One2many
    public virtual ICollection<PosPackOperationLot> PosPackOperationLot { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    public virtual ProductProduct? Product { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("PosOrderLineId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PosOrderLine")] // One2many
    public virtual ICollection<ProductAttributeCustomValue> ProductAttributeCustomValue { get; set; }

    // [Many2one]
    [ForeignKey("RefundedOrderlineId")]
    public virtual PosOrderLine? RefundedOrderline { get; set; }

    // [Many2one]
    [ForeignKey("RewardId")]
    public virtual LoyaltyReward? Reward { get; set; }

    // [Many2one]
    [ForeignKey("SaleOrderLineId")]
    public virtual SaleOrderLine? SaleOrderLine { get; set; }

    // [Many2one]
    [ForeignKey("SaleOrderOriginId")]
    public virtual SaleOrder? SaleOrderOrigin { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("PosOrderLineId")] // Many2many // Normal
    // [InverseProperty("PosOrderLine")] // Many2many // Normal
    public virtual ICollection<AccountTax> AccountTax { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("PosOrderLineId")] // Many2many // Normal
    // [InverseProperty("PosOrderLine")] // Many2many // Normal
    public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValue { get; set; }
}
