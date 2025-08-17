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
public partial class StockValuationAdjustmentLines: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("cost_id")]
    public Guid? CostId { get; set; }

    [Column("cost_line_id")]
    public Guid? CostLineId { get; set; }

    [Column("move_id")]
    public Guid? MoveId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CostId")]
    // [InverseProperty("StockValuationAdjustmentLines")] //Many2one
    public virtual StockLandedCost? Cost { get; set; }

    // [Many2one]
    [ForeignKey("CostLineId")]
    // [InverseProperty("StockValuationAdjustmentLines")] //Many2one
    public virtual StockLandedCostLines? CostLine { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("StockValuationAdjustmentLinesCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("MoveId")]
    // [InverseProperty("StockValuationAdjustmentLines")] //Many2one
    public virtual StockMove? Move { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("StockValuationAdjustmentLines")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("StockValuationAdjustmentLinesWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
