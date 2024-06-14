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
//[Index("AccountMoveLineId", Name = "stock_valuation_layer_account_move_line_id_index")]
//[Index("ProductId", "RemainingQty", "StockMoveId", "TenantId", "CreationTime", Name = "stock_valuation_layer_index")]
//[Index("StockMoveId", Name = "stock_valuation_layer_stock_move_id_index")]
public partial class StockValuationLayer: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("stock_valuation_layer_id")]
    public Guid? StockValuationLayerId { get; set; }

    [Column("stock_move_id")]
    public Guid? StockMoveId { get; set; }

    [Column("account_move_id")]
    public Guid? AccountMoveId { get; set; }

    [Column("account_move_line_id")]
    public Guid? AccountMoveLineId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("price_diff_value")]
    public double? PriceDiffValue { get; set; }

    [ForeignKey("AccountMoveId")]
    //[InverseProperty("StockValuationLayers")]
    [NotMapped]
    public virtual AccountMove? AccountMove { get; set; }

    [ForeignKey("AccountMoveLineId")]
    //[InverseProperty("StockValuationLayers")]
    [NotMapped]
    public virtual AccountMoveLine? AccountMoveLine { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("StockValuationLayers")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockValuationLayerCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("StockValuationLayers")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("StockMoveId")]
    //[InverseProperty("StockValuationLayers")]
    [NotMapped]
    public virtual StockMove? StockMove { get; set; }

    [ForeignKey("StockValuationLayerId")]
    //[InverseProperty("InverseStockValuationLayerNavigation")]
    [NotMapped]
    public virtual StockValuationLayer? StockValuationLayerNavigation { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockValuationLayerWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("StockValuationLayerNavigation")]
    [NotMapped]
    public virtual ICollection<StockValuationLayer> InverseStockValuationLayerNavigation { get; } = new List<StockValuationLayer>();

}
