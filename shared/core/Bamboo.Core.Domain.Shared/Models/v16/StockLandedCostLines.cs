using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
public partial class StockLandedCostLines : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("cost_id")]
    public Guid? CostId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("account_id")]
    public Guid? AccountId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("split_method")]
    public string? SplitMethod { get; set; }

    [Column("price_unit")]
    public decimal? PriceUnit { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("AccountId")]
    // [InverseProperty("StockLandedCostLines")] // [Many2one]
    public virtual AccountAccount? Account { get; set; }

    // [Many2one]
    [ForeignKey("CostId")]
    // [InverseProperty("StockLandedCostLines")] // [Many2one]
    public virtual StockLandedCost? Cost { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("StockLandedCostLinesCreateU")] // [Many2one]
    public virtual ResUser? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("StockLandedCostLines")] // [Many2one]
    public virtual ProductProduct? Product { get; set; }


    // [Many2many]
    //[NotMapped] // Many2many
    // [InverseProperty("CostLine")] // Many2many
    //public virtual ICollection<StockValuationAdjustmentLines> StockValuationAdjustmentLines { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("StockLandedCostLinesWriteU")] // [Many2one]
    public virtual ResUser? WriteU { get; set; }
}
