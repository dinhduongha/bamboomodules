using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

[Table("mrp_bom")]
//[Index("CompanyId", Name = "mrp_bom__company_id_index")]
//[Index("ProductId", Name = "mrp_bom__product_id_index")]
//[Index("ProductTmplId", Name = "mrp_bom__product_tmpl_id_index")]
public partial class MrpBom : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

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
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("BomId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Bom")] // One2many
    public virtual ICollection<MrpBomByproduct> MrpBomByproduct { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("BomId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Bom")] // One2many
    public virtual ICollection<MrpBomLine> MrpBomLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("BomId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Bom")] // One2many
    public virtual ICollection<MrpProduction> MrpProduction { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("BomId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Bom")] // One2many
    public virtual ICollection<MrpRoutingWorkcenter> MrpRoutingWorkcenter { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("BomId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Bom")] // One2many
    public virtual ICollection<MrpUnbuild> MrpUnbuild { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PickingTypeId")]
    public virtual StockPickingType? PickingType { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductId")]
    public virtual ProductProduct? Product { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("BomId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Bom")] // One2many
    public virtual ICollection<ProductReplenish> ProductReplenish { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductTmplId")]
    public virtual ProductTemplate? ProductTmpl { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductUomId")]
    public virtual UomUom? ProductUom { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProjectId")]
    public virtual ProjectProject? Project { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("BomId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Bom")] // One2many
    public virtual ICollection<StockScrap> StockScrap { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("BomId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Bom")] // One2many
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoint { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MrpBomId")] //Many2many // Hidden
    // [InverseProperty("MrpBom")] //Many2many // Hidden
    public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccount { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResPartner) is commented out
    // [ForeignKey("MrpBomId")] // Many2many // Normal
    // [InverseProperty("MrpBom")] // Many2many // Normal
    public virtual ICollection<ResPartner> ResPartner { get; set; }
}
