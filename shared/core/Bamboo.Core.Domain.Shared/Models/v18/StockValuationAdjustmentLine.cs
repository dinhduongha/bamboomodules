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

[Table("stock_valuation_adjustment_lines")]
public partial class StockValuationAdjustmentLine: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("cost_id")]
    public Guid? CostId { get; set; }

    [Column("cost_line_id")]
    public Guid? CostLineId { get; set; }

    [Column("move_id")]
    public Guid? MoveId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("quantity")]
    public decimal? Quantity { get; set; }

    [Column("weight")]
    public decimal? Weight { get; set; }

    [Column("volume")]
    public decimal? Volume { get; set; }

    [Column("former_cost")]
    public decimal? FormerCost { get; set; }

    [Column("additional_landed_cost")]
    public decimal? AdditionalLandedCost { get; set; }

    [Column("final_cost")]
    public decimal? FinalCost { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CostId")]
    //[InverseProperty("StockValuationAdjustmentLines")] //Many2One
    public virtual StockLandedCost? Cost { get; set; }

    [ForeignKey("CostLineId")]
    //[InverseProperty("StockValuationAdjustmentLines")] //Many2One
    public virtual StockLandedCostLine? CostLine { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockValuationAdjustmentLineCreateUs")] //Many2One
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MoveId")]
    //[InverseProperty("StockValuationAdjustmentLines")] //Many2One
    public virtual StockMove? Move { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("StockValuationAdjustmentLines")] //Many2One
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockValuationAdjustmentLineWriteUs")] //Many2One
    public virtual ResUser? WriteU { get; set; }
}
