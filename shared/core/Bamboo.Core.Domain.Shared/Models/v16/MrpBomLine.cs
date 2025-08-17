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

[Table("mrp_bom_line")]
//[Index("BomId", Name = "mrp_bom_line_bom_id_index")]
//[Index("CompanyId", Name = "mrp_bom_line_company_id_index")]
//[Index("ProductTmplId", Name = "mrp_bom_line_product_tmpl_id_index")]
public partial class MrpBomLine: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("product_tmpl_id")]
    public Guid? ProductTmplId { get; set; }

    [Column("product_uom_id")]
    public Guid? ProductUomId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("bom_id")]
    public Guid? BomId { get; set; }

    [Column("operation_id")]
    public Guid? OperationId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("product_qty")]
    public decimal? ProductQty { get; set; }

    [Column("manual_consumption")]
    public bool? ManualConsumption { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("cost_share")]
    public decimal? CostShare { get; set; }

    // [Many2one]
    [ForeignKey("BomId")]
    // [InverseProperty("MrpBomLine")] //Many2one
    public virtual MrpBom? Bom { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("MrpBomLine")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("MrpBomLineCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("OperationId")]
    // [InverseProperty("MrpBomLine")] //Many2one
    public virtual MrpRoutingWorkcenter? Operation { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("MrpBomLine")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [ForeignKey("ProductTmplId")]
    // [InverseProperty("MrpBomLine")] //Many2one
    public virtual ProductTemplate? ProductTmpl { get; set; }

    // [Many2one]
    [ForeignKey("ProductUomId")]
    // [InverseProperty("MrpBomLine")] //Many2one
    public virtual UomUom? ProductUom { get; set; }

    // [One2many]
    [ForeignKey("BomLineId")]
    [InverseProperty("BomLine")]
    public virtual ICollection<StockMove> StockMove { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("MrpBomLineWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("MrpBomLineId")] //Many2many
    // [InverseProperty("MrpBomLine")] //Many2many
    public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValue { get; set; }
}
