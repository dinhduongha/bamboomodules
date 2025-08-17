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

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

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

    [Column("note")]
    public string? Note { get; set; }

    [Column("uuid")]
    public string? Uuid { get; set; }

    [Column("mp_skip")]
    public bool? MpSkip { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("PosOrderLine")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CouponId")]
    // [InverseProperty("PosOrderLine")] //Many2one
    public virtual LoyaltyCard? Coupon { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("PosOrderLineCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("RefundedOrderlineId")]
    [InverseProperty("RefundedOrderline")]
    public virtual ICollection<PosOrderLine> InverseRefundedOrderline { get; set; }

    // [Many2one]
    [ForeignKey("OrderId")]
    // [InverseProperty("PosOrderLine")] //Many2one
    public virtual PosOrder? Order { get; set; }

    // [One2many]
    [ForeignKey("PosOrderLineId")]
    [InverseProperty("PosOrderLine")]
    public virtual ICollection<PosPackOperationLot> PosPackOperationLot { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("PosOrderLine")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [ForeignKey("RefundedOrderlineId")]
    // [InverseProperty("InverseRefundedOrderline")] //Many2one
    public virtual PosOrderLine? RefundedOrderline { get; set; }

    // [Many2one]
    [ForeignKey("RewardId")]
    // [InverseProperty("PosOrderLine")] //Many2one
    public virtual LoyaltyReward? Reward { get; set; }

    // [Many2one]
    [ForeignKey("SaleOrderLineId")]
    // [InverseProperty("PosOrderLine")] //Many2one
    public virtual SaleOrderLine? SaleOrderLine { get; set; }

    // [Many2one]
    [ForeignKey("SaleOrderOriginId")]
    // [InverseProperty("PosOrderLine")] //Many2one
    public virtual SaleOrder? SaleOrderOrigin { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("PosOrderLineWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("PosOrderLineId")] //Many2many
    // [InverseProperty("PosOrderLine")] //Many2many
    public virtual ICollection<AccountTax> AccountTax { get; set; }
}
