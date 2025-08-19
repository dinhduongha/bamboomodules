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
//[Index("CompanyId", Name = "mrp_bom__company_id_index")]
//[Index("ProductId", Name = "mrp_bom__product_id_index")]
//[Index("ProductTmplId", Name = "mrp_bom__product_tmpl_id_index")]
public partial class MrpBom: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("product_tmpl_id")]
    public Guid? ProductTmplId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_uom_id")]
    public Guid? ProductUomId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("picking_type_id")]
    public Guid? PickingTypeId { get; set; }

    [Column("produce_delay")]
    public long? ProduceDelay { get; set; }

    [Column("days_to_prepare_mo")]
    public long? DaysToPrepareMo { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("project_id")]
    public Guid? ProjectId { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("MrpBom")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("MrpBomCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MrpBom")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [One2many]
    [ForeignKey("BomId")]
    [InverseProperty("Bom")]
    public virtual ICollection<MrpBomByproduct> MrpBomByproduct { get; set; }

    // [One2many]
    [ForeignKey("BomId")]
    [InverseProperty("Bom")]
    public virtual ICollection<MrpBomLine> MrpBomLine { get; set; }

    // [One2many]
    [ForeignKey("BomId")]
    [InverseProperty("Bom")]
    public virtual ICollection<MrpProduction> MrpProduction { get; set; }

    // [One2many]
    [ForeignKey("BomId")]
    [InverseProperty("Bom")]
    public virtual ICollection<MrpRoutingWorkcenter> MrpRoutingWorkcenter { get; set; }

    // [One2many]
    [ForeignKey("BomId")]
    [InverseProperty("Bom")]
    public virtual ICollection<MrpUnbuild> MrpUnbuild { get; set; }

    // [Many2one]
    [ForeignKey("PickingTypeId")]
    // [InverseProperty("MrpBom")] //Many2one
    public virtual StockPickingType? PickingType { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("MrpBom")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [One2many]
    [ForeignKey("BomId")]
    [InverseProperty("Bom")]
    public virtual ICollection<ProductReplenish> ProductReplenish { get; set; }

    // [Many2one]
    [ForeignKey("ProductTmplId")]
    // [InverseProperty("MrpBom")] //Many2one
    public virtual ProductTemplate? ProductTmpl { get; set; }

    // [Many2one]
    [ForeignKey("ProductUomId")]
    // [InverseProperty("MrpBom")] //Many2one
    public virtual UomUom? ProductUom { get; set; }

    // [Many2one]
    [ForeignKey("ProjectId")]
    // [InverseProperty("MrpBom")] //Many2one
    public virtual ProjectProject? Project { get; set; }

    // [One2many]
    [ForeignKey("BomId")]
    [InverseProperty("Bom")]
    public virtual ICollection<StockScrap> StockScrap { get; set; }

    // [One2many]
    [ForeignKey("BomId")]
    [InverseProperty("Bom")]
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoint { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("MrpBomWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MrpBomId")]
    // [InverseProperty("MrpBom")]
    public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccount { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("MrpBomId")] //Many2many
    // [InverseProperty("MrpBom")] //Many2many
    public virtual ICollection<ResPartner> ResPartner { get; set; }
}
