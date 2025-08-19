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

[Table("stock_valuation_layer")]
//[Index("LotId", Name = "stock_valuation_layer__lot_id_index")]
//[Index("StockMoveId", Name = "stock_valuation_layer__stock_move_id_index")]
//[Index("StockValuationLayerId", Name = "stock_valuation_layer__stock_valuation_layer_id_index")]
//[Index("ProductId", "RemainingQty", "StockMoveId", "CompanyId", "CreateDate", Name = "stock_valuation_layer_index")]
public partial class StockValuationLayer: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("categ_id")]
    public Guid? CategId { get; set; }

    [Column("stock_valuation_layer_id")]
    public Guid? StockValuationLayerId { get; set; }

    [Column("stock_move_id")]
    public Guid? StockMoveId { get; set; }

    [Column("account_move_id")]
    public Guid? AccountMoveId { get; set; }

    [Column("account_move_line_id")]
    public Guid? AccountMoveLineId { get; set; }

    [Column("lot_id")]
    public Guid? LotId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("quantity")]
    public decimal? Quantity { get; set; }

    [Column("unit_cost")]
    public decimal? UnitCost { get; set; }

    [Column("value")]
    public decimal? Value { get; set; }

    [Column("remaining_qty")]
    public decimal? RemainingQty { get; set; }

    [Column("remaining_value")]
    public decimal? RemainingValue { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("price_diff_value")]
    public double? PriceDiffValue { get; set; }

    [Column("stock_landed_cost_id")]
    public Guid? StockLandedCostId { get; set; }

    // [Many2one]
    [ForeignKey("AccountMoveId")]
    // [InverseProperty("StockValuationLayer")] //Many2one
    public virtual AccountMove? AccountMove { get; set; }

    // [Many2one]
    [ForeignKey("AccountMoveLineId")]
    // [InverseProperty("StockValuationLayer")] //Many2one
    public virtual AccountMoveLine? AccountMoveLine { get; set; }

    // [Many2one]
    [ForeignKey("CategId")]
    // [InverseProperty("StockValuationLayer")] //Many2one
    public virtual ProductCategory? Categ { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("StockValuationLayer")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("StockValuationLayerCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("StockValuationLayerId")]
    [InverseProperty("StockValuationLayerNavigation")]
    public virtual ICollection<StockValuationLayer> InverseStockValuationLayerNavigation { get; set; }

    // [Many2one]
    [ForeignKey("LotId")]
    // [InverseProperty("StockValuationLayer")] //Many2one
    public virtual StockLot? Lot { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("StockValuationLayer")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [ForeignKey("StockLandedCostId")]
    // [InverseProperty("StockValuationLayer")] //Many2one
    public virtual StockLandedCost? StockLandedCost { get; set; }

    // [Many2one]
    [ForeignKey("StockMoveId")]
    // [InverseProperty("StockValuationLayer")] //Many2one
    public virtual StockMove? StockMove { get; set; }

    // [Many2one]
    [ForeignKey("StockValuationLayerId")]
    // [InverseProperty("InverseStockValuationLayerNavigation")] //Many2one
    public virtual StockValuationLayer? StockValuationLayerNavigation { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("StockValuationLayerWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockValuationLayerId")]
    // [InverseProperty("StockValuationLayer")]
    public virtual ICollection<StockValuationLayerRevaluation> StockValuationLayerRevaluation { get; set; }
}
