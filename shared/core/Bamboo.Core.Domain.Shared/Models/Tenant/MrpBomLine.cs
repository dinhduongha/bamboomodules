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
//[Index("TenantId", Name = "mrp_bom_line_company_id_index")]
//[Index("ProductTmplId", Name = "mrp_bom_line_product_tmpl_id_index")]
public partial class MrpBomLine: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_tmpl_id")]
    public Guid? ProductTmplId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("product_uom_id")]
    public Guid? ProductUomId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("bom_id")]
    public Guid? BomId { get; set; }

    [Column("operation_id")]
    public Guid? OperationId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("product_qty")]
    public decimal? ProductQty { get; set; }

    [Column("manual_consumption")]
    public bool? ManualConsumption { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("cost_share")]
    public decimal? CostShare { get; set; }

    [ForeignKey("BomId")]
    //[InverseProperty("MrpBomLines")]
    [NotMapped]
    public virtual MrpBom? Bom { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("MrpBomLines")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MrpBomLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("OperationId")]
    //[InverseProperty("MrpBomLines")]
    [NotMapped]
    public virtual MrpRoutingWorkcenter? Operation { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("MrpBomLines")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("ProductTmplId")]
    //[InverseProperty("MrpBomLines")]
    [NotMapped]
    public virtual ProductTemplate? ProductTmpl { get; set; }

    [ForeignKey("ProductUomId")]
    //[InverseProperty("MrpBomLines")]
    [NotMapped]
    public virtual UomUom? ProductUom { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MrpBomLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("BomLine")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoves { get; } = new List<StockMove>();

    [ForeignKey("MrpBomLineId")]
    //[InverseProperty("MrpBomLines")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValues { get; } = new List<ProductTemplateAttributeValue>();
}
