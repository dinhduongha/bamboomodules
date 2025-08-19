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

[Table("stock_move")]
//[Index("CompanyId", Name = "stock_move__company_id_index")]
//[Index("CreatedProductionId", Name = "stock_move__created_production_id_index")]
//[Index("Date", Name = "stock_move__date_index")]
//[Index("GroupId", Name = "stock_move__group_id_index")]
//[Index("LocationDestId", Name = "stock_move__location_dest_id_index")]
//[Index("LocationFinalId", Name = "stock_move__location_final_id_index")]
//[Index("LocationId", Name = "stock_move__location_id_index")]
//[Index("OrderpointId", Name = "stock_move__orderpoint_id_index")]
//[Index("OriginReturnedMoveId", Name = "stock_move__origin_returned_move_id_index")]
//[Index("PickingId", Name = "stock_move__picking_id_index")]
//[Index("ProductId", Name = "stock_move__product_id_index")]
//[Index("RepairLineType", Name = "stock_move__repair_line_type_index")]
//[Index("State", Name = "stock_move__state_index")]
//[Index("ProductId", "LocationId", "LocationDestId", "CompanyId", "State", Name = "stock_move_product_location_index")]
public partial class StockMove: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_uom")]
    public Guid? ProductUom { get; set; }

    [Column("location_id")]
    public Guid? LocationId { get; set; }

    [Column("location_dest_id")]
    public Guid? LocationDestId { get; set; }

    [Column("location_final_id")]
    public Guid? LocationFinalId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("picking_id")]
    public Guid? PickingId { get; set; }

    [Column("scrap_id")]
    public Guid? ScrapId { get; set; }

    [Column("group_id")]
    public Guid? GroupId { get; set; }

    [Column("rule_id")]
    public Guid? RuleId { get; set; }

    [Column("picking_type_id")]
    public Guid? PickingTypeId { get; set; }

    [Column("origin_returned_move_id")]
    public Guid? OriginReturnedMoveId { get; set; }

    [Column("restrict_partner_id")]
    public Guid? RestrictPartnerId { get; set; }

    [Column("warehouse_id")]
    public Guid? WarehouseId { get; set; }

    [Column("package_level_id")]
    public Guid? PackageLevelId { get; set; }

    [Column("next_serial_count")]
    public long? NextSerialCount { get; set; }

    [Column("orderpoint_id")]
    public Guid? OrderpointId { get; set; }

    [Column("product_packaging_id")]
    public Guid? ProductPackagingId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("priority")]
    public string? Priority { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("origin")]
    public string? Origin { get; set; }

    [Column("procure_method")]
    public string? ProcureMethod { get; set; }

    [Column("reference")]
    public string? Reference { get; set; }

    [Column("next_serial")]
    public string? NextSerial { get; set; }

    [Column("reservation_date")]
    public DateTime? ReservationDate { get; set; }

    [Column("description_picking")]
    public string? DescriptionPicking { get; set; }

    [Column("product_qty")]
    public decimal? ProductQty { get; set; }

    [Column("product_uom_qty")]
    public decimal? ProductUomQty { get; set; }

    [Column("quantity")]
    public decimal? Quantity { get; set; }

    [Column("picked")]
    public bool? Picked { get; set; }

    [Column("quantity_done")]
    public decimal? QuantityDone { get; set; }

    [Column("scrapped")]
    public bool? Scrapped { get; set; }

    [Column("propagate_cancel")]
    public bool? PropagateCancel { get; set; }

    [Column("is_inventory")]
    public bool? IsInventory { get; set; }

    [Column("additional")]
    public bool? Additional { get; set; }

    [Column("date", TypeName = "timestamp without time zone")]
    public DateTime? Date { get; set; }

    [Column("date_deadline", TypeName = "timestamp without time zone")]
    public DateTime? DateDeadline { get; set; }

    [Column("delay_alert_date", TypeName = "timestamp without time zone")]
    public DateTime? DelayAlertDate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("price_unit")]
    public double? PriceUnit { get; set; }

    [Column("analytic_account_line_id")]
    public Guid? AnalyticAccountLineId { get; set; }

    [Column("to_refund")]
    public bool? ToRefund { get; set; }

    [Column("sale_line_id")]
    public Guid? SaleLineId { get; set; }

    [Column("purchase_line_id")]
    public Guid? PurchaseLineId { get; set; }

    [Column("created_purchase_line_id")]
    public Guid? CreatedPurchaseLineId { get; set; }

    [Column("repair_id")]
    public Guid? RepairId { get; set; }

    [Column("repair_line_type")]
    public string? RepairLineType { get; set; }

    [Column("is_done")]
    public bool? IsDone { get; set; }

    [Column("unit_factor")]
    public double? UnitFactor { get; set; }

    [Column("created_production_id")]
    public Guid? CreatedProductionId { get; set; }

    [Column("production_id")]
    public Guid? ProductionId { get; set; }

    [Column("raw_material_production_id")]
    public Guid? RawMaterialProductionId { get; set; }

    [Column("unbuild_id")]
    public Guid? UnbuildId { get; set; }

    [Column("consume_unbuild_id")]
    public Guid? ConsumeUnbuildId { get; set; }

    [Column("operation_id")]
    public Guid? OperationId { get; set; }

    [Column("workorder_id")]
    public Guid? WorkorderId { get; set; }

    [Column("bom_line_id")]
    public Guid? BomLineId { get; set; }

    [Column("byproduct_id")]
    public Guid? ByproductId { get; set; }

    [Column("order_finished_lot_id")]
    public Guid? OrderFinishedLotId { get; set; }

    [Column("cost_share")]
    public decimal? CostShare { get; set; }

    [Column("manual_consumption")]
    public bool? ManualConsumption { get; set; }

    [Column("weight")]
    public decimal? Weight { get; set; }

    [Column("is_subcontract")]
    public bool? IsSubcontract { get; set; }

    // [One2many]
    [ForeignKey("StockMoveId")]
    [InverseProperty("StockMove")]
    public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [Many2one]
    [ForeignKey("AnalyticAccountLineId")]
    // [InverseProperty("StockMove")] //Many2one
    public virtual AccountAnalyticLine? AnalyticAccountLine { get; set; }

    // [Many2one]
    [ForeignKey("BomLineId")]
    // [InverseProperty("StockMove")] //Many2one
    public virtual MrpBomLine? BomLine { get; set; }

    // [Many2one]
    [ForeignKey("ByproductId")]
    // [InverseProperty("StockMove")] //Many2one
    public virtual MrpBomByproduct? Byproduct { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("StockMove")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("ConsumeUnbuildId")]
    // [InverseProperty("StockMoveConsumeUnbuild")] //Many2one
    public virtual MrpUnbuild? ConsumeUnbuild { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("StockMoveCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CreatedProductionId")]
    // [InverseProperty("StockMoveCreatedProduction")] //Many2one
    public virtual MrpProduction? CreatedProduction { get; set; }

    // v16-Compat
    // [Many2one]
    [ForeignKey("CreatedPurchaseLineId")]
    // [InverseProperty("StockMoveCreatedPurchaseLine")] //Many2one
    public virtual PurchaseOrderLine? CreatedPurchaseLine { get; set; }

    // [Many2one]
    [ForeignKey("GroupId")]
    // [InverseProperty("StockMove")] //Many2one
    public virtual ProcurementGroup? Group { get; set; }

    // [One2many]
    [ForeignKey("OriginReturnedMoveId")]
    [InverseProperty("OriginReturnedMove")]
    public virtual ICollection<StockMove> InverseOriginReturnedMove { get; set; }

    // [Many2one]
    [ForeignKey("LocationId")]
    // [InverseProperty("StockMoveLocation")] //Many2one
    public virtual StockLocation? Location { get; set; }

    // [Many2one]
    [ForeignKey("LocationDestId")]
    // [InverseProperty("StockMoveLocationDest")] //Many2one
    public virtual StockLocation? LocationDest { get; set; }

    // [Many2one]
    [ForeignKey("LocationFinalId")]
    // [InverseProperty("StockMoveLocationFinal")] //Many2one
    public virtual StockLocation? LocationFinal { get; set; }

    // [Many2one]
    [ForeignKey("OperationId")]
    // [InverseProperty("StockMove")] //Many2one
    public virtual MrpRoutingWorkcenter? Operation { get; set; }

    // [Many2one]
    [ForeignKey("OrderFinishedLotId")]
    // [InverseProperty("StockMove")] //Many2one
    public virtual StockLot? OrderFinishedLot { get; set; }

    // [Many2one]
    [ForeignKey("OrderpointId")]
    // [InverseProperty("StockMove")] //Many2one
    public virtual StockWarehouseOrderpoint? Orderpoint { get; set; }

    // [Many2one]
    [ForeignKey("OriginReturnedMoveId")]
    // [InverseProperty("InverseOriginReturnedMove")] //Many2one
    public virtual StockMove? OriginReturnedMove { get; set; }

    // [Many2one]
    [ForeignKey("PackageLevelId")]
    // [InverseProperty("StockMove")] //Many2one
    public virtual StockPackageLevel? PackageLevel { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("StockMovePartner")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("PickingId")]
    // [InverseProperty("StockMove")] //Many2one
    public virtual StockPicking? Picking { get; set; }

    // [Many2one]
    [ForeignKey("PickingTypeId")]
    // [InverseProperty("StockMove")] //Many2one
    public virtual StockPickingType? PickingType { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("StockMove")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [ForeignKey("ProductPackagingId")]
    // [InverseProperty("StockMove")] //Many2one
    public virtual ProductPackaging? ProductPackaging { get; set; }

    // [Many2one]
    [ForeignKey("ProductUom")]
    // [InverseProperty("StockMove")] //Many2one
    public virtual UomUom? ProductUomNavigation { get; set; }

    // [Many2one]
    [ForeignKey("ProductionId")]
    // [InverseProperty("StockMoveProduction")] //Many2one
    public virtual MrpProduction? Production { get; set; }

    // [Many2one]
    [ForeignKey("PurchaseLineId")]
    // [InverseProperty("StockMovePurchaseLine")] //Many2one
    // [InverseProperty("StockMove")] //Many2one
    public virtual PurchaseOrderLine? PurchaseLine { get; set; }

    // [One2many]
    [ForeignKey("MoveDestId")]
    [InverseProperty("MoveDest")]
    public virtual ICollection<PurchaseRequisitionLine> PurchaseRequisitionLine { get; set; }

    // [Many2one]
    [ForeignKey("RawMaterialProductionId")]
    // [InverseProperty("StockMoveRawMaterialProduction")] //Many2one
    public virtual MrpProduction? RawMaterialProduction { get; set; }

    // [Many2one]
    [ForeignKey("RepairId")]
    // [InverseProperty("StockMove")] //Many2one
    public virtual RepairOrder? Repair { get; set; }

    // [One2many]
    [ForeignKey("MoveId")]
    [InverseProperty("Move")]
    public virtual ICollection<RepairLine> RepairLine { get; set; }

    // [One2many]
    [ForeignKey("MoveId")]
    [InverseProperty("Move")]
    public virtual ICollection<RepairOrder> RepairOrder { get; set; }

    // [Many2one]
    [ForeignKey("RestrictPartnerId")]
    // [InverseProperty("StockMoveRestrictPartner")] //Many2one
    public virtual ResPartner? RestrictPartner { get; set; }

    // [Many2one]
    [ForeignKey("RuleId")]
    // [InverseProperty("StockMove")] //Many2one
    public virtual StockRule? Rule { get; set; }

    // [Many2one]
    [ForeignKey("SaleLineId")]
    // [InverseProperty("StockMove")] //Many2one
    public virtual SaleOrderLine? SaleLine { get; set; }

    // [Many2one]
    [ForeignKey("ScrapId")]
    // [InverseProperty("StockMove")] //Many2one
    public virtual StockScrap? Scrap { get; set; }

    // [One2many]
    [ForeignKey("MoveId")]
    [InverseProperty("Move")]
    public virtual ICollection<StockAssignSerial> StockAssignSerial { get; set; }

    // [One2many]
    [ForeignKey("MoveId")]
    [InverseProperty("Move")]
    public virtual ICollection<StockMoveLine> StockMoveLine { get; set; }

    // [One2many]
    [ForeignKey("MoveId")]
    [InverseProperty("Move")]
    public virtual ICollection<StockReturnPickingLine> StockReturnPickingLine { get; set; }

    // [One2many]
    [ForeignKey("MoveId")]
    [InverseProperty("Move")]
    public virtual ICollection<StockScrap> StockScrap { get; set; }

    // [One2many]
    [ForeignKey("MoveId")]
    [InverseProperty("Move")]
    public virtual ICollection<StockValuationAdjustmentLines> StockValuationAdjustmentLines { get; set; }

    // [One2many]
    [ForeignKey("StockMoveId")]
    [InverseProperty("StockMove")]
    public virtual ICollection<StockValuationLayer> StockValuationLayer { get; set; }

    // [Many2one]
    [ForeignKey("UnbuildId")]
    // [InverseProperty("StockMoveUnbuild")] //Many2one
    public virtual MrpUnbuild? Unbuild { get; set; }

    // [Many2one]
    [ForeignKey("WarehouseId")]
    // [InverseProperty("StockMove")] //Many2one
    public virtual StockWarehouse? Warehouse { get; set; }

    // [Many2one]
    [ForeignKey("WorkorderId")]
    // [InverseProperty("StockMove")] //Many2one
    public virtual MrpWorkorder? Workorder { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("StockMoveWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("StockMoveId")] //Many2many
    // [InverseProperty("StockMove")] //Many2many
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    [ForeignKey("MoveId")]
    [InverseProperty("Move")]
    public virtual ICollection<PurchaseOrderLine> CreatedPurchaseOrderLine { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("MoveOrigId")] //Many2many
    // [InverseProperty("MoveOrig")] //Many2many
    public virtual ICollection<StockMove> MoveDest { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("MoveDestId")] //Many2many
    // [InverseProperty("MoveDest")] //Many2many
    public virtual ICollection<StockMove> MoveOrig { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockMoveId")]
    // [InverseProperty("StockMove")]
    public virtual ICollection<ProductLabelLayout> ProductLabelLayout { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("MoveId")] //Many2many
    // [InverseProperty("Move")] //Many2many
    public virtual ICollection<StockRoute> Route { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("MoveId")] //Many2many
    // [InverseProperty("Move")] //Many2many
    public virtual ICollection<ProductTemplateAttributeValue> TemplateAttributeValue { get; set; }
}
