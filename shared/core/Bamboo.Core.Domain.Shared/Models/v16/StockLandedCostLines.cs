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

[Table("stock_landed_cost_lines")]
public partial class StockLandedCostLines: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("account_id")]
    public Guid? AccountId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("split_method")]
    public string? SplitMethod { get; set; }

    [Column("price_unit")]
    public decimal? PriceUnit { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("AccountId")]
    // [InverseProperty("StockLandedCostLines")] //Many2one
    public virtual AccountAccount? Account { get; set; }

    // [Many2one]
    [ForeignKey("CostId")]
    // [InverseProperty("StockLandedCostLines")] //Many2one
    public virtual StockLandedCost? Cost { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("StockLandedCostLinesCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("StockLandedCostLines")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [One2many]
    [ForeignKey("CostLineId")]
    [InverseProperty("CostLine")]
    public virtual ICollection<StockValuationAdjustmentLines> StockValuationAdjustmentLines { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("StockLandedCostLinesWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
