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
//[Index("TenantId", Name = "mrp_production_company_id_index")]
//[Index("DatePlannedStart", Name = "mrp_production_date_planned_start_index")]
//[Index("Name", "TenantId", Name = "mrp_production_name_uniq", IsUnique = true)]
//[Index("PickingTypeId", Name = "mrp_production_picking_type_id_index")]
//[Index("ReservationState", Name = "mrp_production_reservation_state_index")]
//[Index("State", Name = "mrp_production_state_index")]
public partial class MrpProduction: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    // v16-Compat
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("backorder_sequence")]
    public long BackorderSequence { get; set; }

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
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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

    // v16-Compat
    [Column("date_planned_start", TypeName = "timestamp without time zone")]
    public DateTime? DatePlannedStart { get; set; }

    // v16-Compat
    [Column("date_planned_finished", TypeName = "timestamp without time zone")]
    public DateTime? DatePlannedFinished { get; set; }

    [Column("date_deadline", TypeName = "timestamp without time zone")]
    public DateTime? DateDeadline { get; set; }

    [Column("date_start", TypeName = "timestamp without time zone")]
    public DateTime? DateStart { get; set; }

    [Column("date_finished", TypeName = "timestamp without time zone")]
    public DateTime? DateFinished { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("product_uom_qty")]
    public double? ProductUomQty { get; set; }

    // v16-Compat
    [Column("analytic_account_id")]
    public Guid? AnalyticAccountId { get; set; }

    [Column("extra_cost")]
    public double? ExtraCost { get; set; }

    [Column("project_id")]
    public Guid? ProjectId { get; set; }

    [Column("sale_line_id")]
    public Guid? SaleLineId { get; set; }

    // v16-Compat
    [ForeignKey("AnalyticAccountId")]
    //[InverseProperty("MrpProductions")]
    [NotMapped]
    public virtual AccountAnalyticAccount? AnalyticAccount { get; set; }

    [ForeignKey("BomId")]
    //[InverseProperty("MrpProductions")]
    [NotMapped]
    public virtual MrpBom? Bom { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("MrpProductions")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MrpProductionCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LocationDestId")]
    //[InverseProperty("MrpProductionLocationDests")]
    [NotMapped]
    public virtual StockLocation? LocationDest { get; set; }

    [ForeignKey("LocationSrcId")]
    //[InverseProperty("MrpProductionLocationSrcs")]
    [NotMapped]
    public virtual StockLocation? LocationSrc { get; set; }

    [ForeignKey("LotProducingId")]
    //[InverseProperty("MrpProductions")]
    [NotMapped]
    public virtual StockLot? LotProducing { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("MrpProductions")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("OrderpointId")]
    //[InverseProperty("MrpProductions")]
    [NotMapped]
    public virtual StockWarehouseOrderpoint? Orderpoint { get; set; }

    [ForeignKey("PickingTypeId")]
    //[InverseProperty("MrpProductions")]
    [NotMapped]
    public virtual StockPickingType? PickingType { get; set; }

    [ForeignKey("ProcurementGroupId")]
    //[InverseProperty("MrpProductions")]
    [NotMapped]
    public virtual ProcurementGroup? ProcurementGroup { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("MrpProductions")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("ProductUomId")]
    //[InverseProperty("MrpProductions")]
    [NotMapped]
    public virtual UomUom? ProductUom { get; set; }

    [ForeignKey("ProductionLocationId")]
    //[InverseProperty("MrpProductionProductionLocations")]
    [NotMapped]
    public virtual StockLocation? ProductionLocation { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("MrpProductionUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MrpProductionWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Mo")]
    [NotMapped]
    public virtual ICollection<ChangeProductionQty> ChangeProductionQties { get; set; } = new List<ChangeProductionQty>();

    //[InverseProperty("Mo")]
    //[NotMapped]
    //public virtual ICollection<ChangeProductionQty> ChangeProductionQties { get; set; } = new List<ChangeProductionQty>();

    //[InverseProperty("Production")]
    [NotMapped]
    public virtual ICollection<MrpBatchProduce> MrpBatchProduces { get; set; } = new List<MrpBatchProduce>();

    //[InverseProperty("MrpProduction")]
    [NotMapped]
    public virtual ICollection<MrpConsumptionWarningLine> MrpConsumptionWarningLines { get; set; } = new List<MrpConsumptionWarningLine>();

    //[InverseProperty("Production")]
    [NotMapped]
    public virtual ICollection<MrpImmediateProductionLine> MrpImmediateProductionLines { get; set; } = new List<MrpImmediateProductionLine>();

    //[InverseProperty("MrpProduction")]
    [NotMapped]
    public virtual ICollection<MrpProductionBackorderLine> MrpProductionBackorderLines { get; set; } = new List<MrpProductionBackorderLine>();

    //[InverseProperty("Production")]
    [NotMapped]
    public virtual ICollection<MrpProductionSplit> MrpProductionSplits { get; set; } = new List<MrpProductionSplit>();

    //[InverseProperty("Mo")]
    [NotMapped]
    public virtual ICollection<MrpUnbuild> MrpUnbuilds { get; set; } = new List<MrpUnbuild>();

    //[InverseProperty("Production")]
    [NotMapped]
    public virtual ICollection<MrpWorkorder> MrpWorkorders { get; set; } = new List<MrpWorkorder>();

    //[InverseProperty("Production")]
    [NotMapped]
    public virtual ICollection<StockAssignSerial> StockAssignSerials { get; set; } = new List<StockAssignSerial>();

    //[InverseProperty("CreatedProduction")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoveCreatedProductions { get; set; } = new List<StockMove>();

    //[InverseProperty("Production")]
    [NotMapped]
    public virtual ICollection<StockMoveLine> StockMoveLines { get; set; } = new List<StockMoveLine>();

    //[InverseProperty("Production")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoveProductions { get; set; } = new List<StockMove>();

    //[InverseProperty("RawMaterialProduction")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoveRawMaterialProductions { get; set; } = new List<StockMove>();

    //[InverseProperty("Production")]
    [NotMapped]
    public virtual ICollection<StockScrap> StockScraps { get; set; } = new List<StockScrap>();

    [ForeignKey("MrpProductionId")]
    //[InverseProperty("MrpProductions")]
    [NotMapped]
    public virtual ICollection<MrpConsumptionWarning> MrpConsumptionWarnings { get; set; } = new List<MrpConsumptionWarning>();

    [ForeignKey("MrpProductionId")]
    //[InverseProperty("MrpProductions")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoves { get; set; } = new List<AccountMove>();

    [ForeignKey("MrpProductionId")]
    //[InverseProperty("MrpProductions")]
    [NotMapped]
    public virtual ICollection<MrpAccountWipAccounting> MrpAccountWipAccountings { get; set; } = new List<MrpAccountWipAccounting>();


    // RELATIONS BEGIN - MUST HAVE
    //[ForeignKey("MrpProductionId")]
    //[InverseProperty("MrpProductions")]
    //[NotMapped]
    //public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccounts { get; set; } = new List<AccountAnalyticAccount>();
    // RELATIONS END

    [ForeignKey("MrpProductionId")]
    //[InverseProperty("MrpProductions")]
    [NotMapped]
    public virtual ICollection<MrpImmediateProduction> MrpImmediateProductions { get; set; } = new List<MrpImmediateProduction>();

    [ForeignKey("MrpProductionId")]
    //[InverseProperty("MrpProductions")]
    [NotMapped]
    public virtual ICollection<MrpProductionBackorder> MrpProductionBackorders { get; set; } = new List<MrpProductionBackorder>();

    [ForeignKey("MrpProductionId")]
    //[InverseProperty("MrpProductions")]
    [NotMapped]
    public virtual ICollection<PickingLabelType> PickingLabelTypes { get; set; } = new List<PickingLabelType>();

    [ForeignKey("ProductionId")]
    //[InverseProperty("Productions")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeValue> TemplateAttributeValues { get; set; } = new List<ProductTemplateAttributeValue>();
}
