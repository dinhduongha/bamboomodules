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

[Table("mrp_production")]
//[Index("CompanyId", Name = "mrp_production_company_id_index")]
//[Index("DatePlannedStart", Name = "mrp_production_date_planned_start_index")]
//[Index("Name", "CompanyId", Name = "mrp_production_name_uniq", IsUnique = true)]
//[Index("PickingTypeId", Name = "mrp_production_picking_type_id_index")]
//[Index("ReservationState", Name = "mrp_production_reservation_state_index")]
//[Index("State", Name = "mrp_production_state_index")]
public partial class MrpProduction: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("date_planned_start", TypeName = "timestamp without time zone")]
    public DateTime? DatePlannedStart { get; set; }

    [Column("date_planned_finished", TypeName = "timestamp without time zone")]
    public DateTime? DatePlannedFinished { get; set; }

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

    [Column("analytic_account_id")]
    public Guid? AnalyticAccountId { get; set; }

    [Column("extra_cost")]
    public double? ExtraCost { get; set; }

    [Column("subcontractor_id")]
    public Guid? SubcontractorId { get; set; }

    [Column("subcontracting_has_been_recorded")]
    public bool? SubcontractingHasBeenRecorded { get; set; }

    // [Many2one]
    [ForeignKey("AnalyticAccountId")]
    // [InverseProperty("MrpProduction")] //Many2one
    public virtual AccountAnalyticAccount? AnalyticAccount { get; set; }

    // [Many2one]
    [ForeignKey("BomId")]
    // [InverseProperty("MrpProduction")] //Many2one
    public virtual MrpBom? Bom { get; set; }

    // [One2many]
    [ForeignKey("MoId")]
    [InverseProperty("Mo")]
    public virtual ICollection<ChangeProductionQty> ChangeProductionQty { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("MrpProduction")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("MrpProductionCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("LocationDestId")]
    // [InverseProperty("MrpProductionLocationDest")] //Many2one
    public virtual StockLocation? LocationDest { get; set; }

    // [Many2one]
    [ForeignKey("LocationSrcId")]
    // [InverseProperty("MrpProductionLocationSrc")] //Many2one
    public virtual StockLocation? LocationSrc { get; set; }

    // [Many2one]
    [ForeignKey("LotProducingId")]
    // [InverseProperty("MrpProduction")] //Many2one
    public virtual StockLot? LotProducing { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MrpProduction")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [One2many]
    [ForeignKey("MrpProductionId")]
    [InverseProperty("MrpProduction")]
    public virtual ICollection<MrpConsumptionWarningLine> MrpConsumptionWarningLine { get; set; }

    // [One2many]
    [ForeignKey("ProductionId")]
    [InverseProperty("Production")]
    public virtual ICollection<MrpImmediateProductionLine> MrpImmediateProductionLine { get; set; }

    // [One2many]
    [ForeignKey("MrpProductionId")]
    [InverseProperty("MrpProduction")]
    public virtual ICollection<MrpProductionBackorderLine> MrpProductionBackorderLine { get; set; }

    // [One2many]
    [ForeignKey("ProductionId")]
    [InverseProperty("Production")]
    public virtual ICollection<MrpProductionSplit> MrpProductionSplit { get; set; }

    // [One2many]
    [ForeignKey("MoId")]
    [InverseProperty("Mo")]
    public virtual ICollection<MrpUnbuild> MrpUnbuild { get; set; }

    // [One2many]
    [ForeignKey("ProductionId")]
    [InverseProperty("Production")]
    public virtual ICollection<MrpWorkorder> MrpWorkorder { get; set; }

    // [Many2one]
    [ForeignKey("OrderpointId")]
    // [InverseProperty("MrpProduction")] //Many2one
    public virtual StockWarehouseOrderpoint? Orderpoint { get; set; }

    // [Many2one]
    [ForeignKey("PickingTypeId")]
    // [InverseProperty("MrpProduction")] //Many2one
    public virtual StockPickingType? PickingType { get; set; }

    // [Many2one]
    [ForeignKey("ProcurementGroupId")]
    // [InverseProperty("MrpProduction")] //Many2one
    public virtual ProcurementGroup? ProcurementGroup { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("MrpProduction")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [ForeignKey("ProductUomId")]
    // [InverseProperty("MrpProduction")] //Many2one
    public virtual UomUom? ProductUom { get; set; }

    // [Many2one]
    [ForeignKey("ProductionLocationId")]
    // [InverseProperty("MrpProductionProductionLocation")] //Many2one
    public virtual StockLocation? ProductionLocation { get; set; }

    // [One2many]
    [ForeignKey("ProductionId")]
    [InverseProperty("Production")]
    public virtual ICollection<StockAssignSerial> StockAssignSerial { get; set; }

    // [One2many]
    [ForeignKey("CreatedProductionId")]
    [InverseProperty("CreatedProduction")]
    public virtual ICollection<StockMove> StockMoveCreatedProduction { get; set; }

    // [One2many]
    [ForeignKey("ProductionId")]
    [InverseProperty("Production")]
    public virtual ICollection<StockMoveLine> StockMoveLine { get; set; }

    // [One2many]
    [ForeignKey("ProductionId")]
    [InverseProperty("Production")]
    public virtual ICollection<StockMove> StockMoveProduction { get; set; }

    // [One2many]
    [ForeignKey("RawMaterialProductionId")]
    [InverseProperty("RawMaterialProduction")]
    public virtual ICollection<StockMove> StockMoveRawMaterialProduction { get; set; }

    // [One2many]
    [ForeignKey("ProductionId")]
    [InverseProperty("Production")]
    public virtual ICollection<StockScrap> StockScrap { get; set; }

    // [Many2one]
    [ForeignKey("SubcontractorId")]
    // [InverseProperty("MrpProduction")] //Many2one
    public virtual ResPartner? Subcontractor { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("MrpProductionUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("MrpProductionWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("MrpProductionId")]
    // [InverseProperty("MrpProduction")]
    // public virtual ICollection<ExpiryPickingConfirmation> ExpiryPickingConfirmation { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("MrpProductionId")]
    // [InverseProperty("MrpProduction")]
    // public virtual ICollection<MrpConsumptionWarning> MrpConsumptionWarning { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("MrpProductionId")]
    // [InverseProperty("MrpProduction")]
    // public virtual ICollection<MrpImmediateProduction> MrpImmediateProduction { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("MrpProductionId")]
    // [InverseProperty("MrpProduction")]
    // public virtual ICollection<MrpProductionBackorder> MrpProductionBackorder { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("MrpProductionId")]
    // [InverseProperty("MrpProduction")]
    // public virtual ICollection<StockLandedCost> StockLandedCost { get; set; }
}
