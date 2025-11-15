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

[Table("mrp_production")]
//[Index("CompanyId", Name = "mrp_production__company_id_index")]
//[Index("DateStart", Name = "mrp_production__date_start_index")]
//[Index("PickingTypeId", Name = "mrp_production__picking_type_id_index")]
//[Index("ReservationState", Name = "mrp_production__reservation_state_index")]
//[Index("State", Name = "mrp_production__state_index")]
//[Index("Name", "CompanyId", Name = "mrp_production_name_uniq", IsUnique = true)]
public partial class MrpProduction : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("backorder_sequence")]
    public long? BackorderSequence { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_uom_id")]
    public Guid? ProductUomId { get; set; }

    [Column("lot_producing_id")]
    public Guid? LotProducingId { get; set; }

    [Column("picking_type_id")]
    public Guid? PickingTypeId { get; set; }

    [Column("location_src_id")]
    public Guid? LocationSrcId { get; set; }

    [Column("location_dest_id")]
    public Guid? LocationDestId { get; set; }

    [Column("location_final_id")]
    public Guid? LocationFinalId { get; set; }

    [Column("bom_id")]
    public Guid? BomId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("procurement_group_id")]
    public Guid? ProcurementGroupId { get; set; }

    [Column("orderpoint_id")]
    public Guid? OrderpointId { get; set; }

    [Column("production_location_id")]
    public Guid? ProductionLocationId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("priority")]
    public string? Priority { get; set; }

    [Column("origin")]
    public string? Origin { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("reservation_state")]
    public string? ReservationState { get; set; }

    [Column("product_description_variants")]
    public string? ProductDescriptionVariants { get; set; }

    [Column("consumption")]
    public string? Consumption { get; set; }

    [Column("product_qty")]
    public decimal? ProductQty { get; set; }

    [Column("qty_producing")]
    public decimal? QtyProducing { get; set; }

    [Column("propagate_cancel")]
    public bool? PropagateCancel { get; set; }

    [Column("is_locked")]
    public bool? IsLocked { get; set; }

    [Column("is_planned")]
    public bool? IsPlanned { get; set; }

    [Column("allow_workorder_dependencies")]
    public bool? AllowWorkorderDependencies { get; set; }

    [Column("is_outdated_bom")]
    public bool? IsOutdatedBom { get; set; }

    [Column("date_deadline", TypeName = "timestamp without time zone")]
    public DateTime? DateDeadline { get; set; }

    [Column("date_start", TypeName = "timestamp without time zone")]
    public DateTime? DateStart { get; set; }

    [Column("date_finished", TypeName = "timestamp without time zone")]
    public DateTime? DateFinished { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("product_uom_qty")]
    public double? ProductUomQty { get; set; }

    [Column("extra_cost")]
    public double? ExtraCost { get; set; }

    [Column("project_id")]
    public Guid? ProjectId { get; set; }

    [Column("sale_line_id")]
    public Guid? SaleLineId { get; set; }

    [Column("subcontractor_id")]
    public Guid? SubcontractorId { get; set; }

    [Column("subcontracting_has_been_recorded")]
    public bool? SubcontractingHasBeenRecorded { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("BomId")]
    public virtual MrpBom? Bom { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MoId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Mo")] // One2many
    public virtual ICollection<ChangeProductionQty> ChangeProductionQty { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LocationDestId")]
    public virtual StockLocation? LocationDest { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LocationFinalId")]
    public virtual StockLocation? LocationFinal { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LocationSrcId")]
    public virtual StockLocation? LocationSrc { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LotProducingId")]
    public virtual StockLot? LotProducing { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Production")] // One2many
    public virtual ICollection<MrpBatchProduce> MrpBatchProduce { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MrpProductionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MrpProduction")] // One2many
    public virtual ICollection<MrpConsumptionWarningLine> MrpConsumptionWarningLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MrpProductionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MrpProduction")] // One2many
    public virtual ICollection<MrpProductionBackorderLine> MrpProductionBackorderLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Production")] // One2many
    public virtual ICollection<MrpProductionSplit> MrpProductionSplit { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MoId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Mo")] // One2many
    public virtual ICollection<MrpUnbuild> MrpUnbuild { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Production")] // One2many
    public virtual ICollection<MrpWorkorder> MrpWorkorder { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("OrderpointId")]
    public virtual StockWarehouseOrderpoint? Orderpoint { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PickingTypeId")]
    public virtual StockPickingType? PickingType { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProcurementGroupId")]
    public virtual ProcurementGroup? ProcurementGroup { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductId")]
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductUomId")]
    public virtual UomUom? ProductUom { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductionLocationId")]
    public virtual StockLocation? ProductionLocation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProjectId")]
    public virtual ProjectProject? Project { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SaleLineId")]
    public virtual SaleOrderLine? SaleLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CreatedProductionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("CreatedProduction")] // One2many
    public virtual ICollection<StockMove> StockMoveCreatedProduction { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Production")] // One2many
    public virtual ICollection<StockMoveLine> StockMoveLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Production")] // One2many
    public virtual ICollection<StockMove> StockMoveProduction { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("RawMaterialProductionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("RawMaterialProduction")] // One2many
    public virtual ICollection<StockMove> StockMoveRawMaterialProduction { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Production")] // One2many
    public virtual ICollection<StockScrap> StockScrap { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SubcontractorId")]
    public virtual ResPartner? Subcontractor { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MrpProductionId")] //Many2many // Hidden
    // [InverseProperty("MrpProduction")] //Many2many // Hidden
    public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccount { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MrpProductionId")] //Many2many // Hidden
    // [InverseProperty("MrpProduction")] //Many2many // Hidden
    public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MrpProductionId")] //Many2many // Hidden
    // [InverseProperty("MrpProduction")] //Many2many // Hidden
    public virtual ICollection<ExpiryPickingConfirmation> ExpiryPickingConfirmation { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MrpProductionId")] //Many2many // Hidden
    // [InverseProperty("MrpProduction")] //Many2many // Hidden
    public virtual ICollection<MrpAccountWipAccounting> MrpAccountWipAccounting { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MrpProductionId")] //Many2many // Hidden
    // [InverseProperty("MrpProduction")] //Many2many // Hidden
    public virtual ICollection<MrpConsumptionWarning> MrpConsumptionWarning { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MrpProductionId")] //Many2many // Hidden
    // [InverseProperty("MrpProduction")] //Many2many // Hidden
    public virtual ICollection<MrpProductionBackorder> MrpProductionBackorder { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MrpProductionId")] //Many2many // Hidden
    // [InverseProperty("MrpProduction")] //Many2many // Hidden
    public virtual ICollection<PickingLabelType> PickingLabelType { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MrpProductionId")] //Many2many // Hidden
    // [InverseProperty("MrpProduction")] //Many2many // Hidden
    public virtual ICollection<StockLandedCost> StockLandedCost { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ProductionId")] // Many2many // Normal
    // [InverseProperty("Production")] // Many2many // Normal
    public virtual ICollection<ProductTemplateAttributeValue> TemplateAttributeValue { get; set; }
}
