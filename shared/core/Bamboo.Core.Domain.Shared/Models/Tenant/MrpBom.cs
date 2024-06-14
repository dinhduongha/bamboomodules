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

[Table("mrp_bom")]
//[Index("TenantId", Name = "mrp_bom_company_id_index")]
//[Index("ProductId", Name = "mrp_bom_product_id_index")]
//[Index("ProductTmplId", Name = "mrp_bom_product_tmpl_id_index")]
public partial class MrpBom: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("product_tmpl_id")]
    public Guid? ProductTmplId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_uom_id")]
    public Guid? ProductUomId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("picking_type_id")]
    public Guid? PickingTypeId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [Column("ready_to_produce")]
    public string? ReadyToProduce { get; set; }

    [Column("consumption")]
    public string? Consumption { get; set; }

    [Column("product_qty")]
    public decimal? ProductQty { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("allow_operation_dependencies")]
    public bool? AllowOperationDependencies { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("MrpBoms")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MrpBomCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("MrpBoms")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("PickingTypeId")]
    //[InverseProperty("MrpBoms")]
    [NotMapped]
    public virtual StockPickingType? PickingType { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("MrpBoms")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("ProductTmplId")]
    //[InverseProperty("MrpBoms")]
    [NotMapped]
    public virtual ProductTemplate? ProductTmpl { get; set; }

    [ForeignKey("ProductUomId")]
    //[InverseProperty("MrpBoms")]
    [NotMapped]
    public virtual UomUom? ProductUom { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MrpBomWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Bom")]
    [NotMapped]
    public virtual ICollection<MrpBomByproduct> MrpBomByproducts { get; } = new List<MrpBomByproduct>();

    //[InverseProperty("Bom")]
    [NotMapped]
    public virtual ICollection<MrpBomLine> MrpBomLines { get; } = new List<MrpBomLine>();

    //[InverseProperty("Bom")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductions { get; } = new List<MrpProduction>();

    //[InverseProperty("Bom")]
    [NotMapped]
    public virtual ICollection<MrpRoutingWorkcenter> MrpRoutingWorkcenters { get; } = new List<MrpRoutingWorkcenter>();

    //[InverseProperty("Bom")]
    [NotMapped]
    public virtual ICollection<MrpUnbuild> MrpUnbuilds { get; } = new List<MrpUnbuild>();

    //[InverseProperty("Bom")]
    [NotMapped]
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoints { get; } = new List<StockWarehouseOrderpoint>();

}
