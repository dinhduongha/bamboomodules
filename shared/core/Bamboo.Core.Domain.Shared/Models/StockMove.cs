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
//[Index("TenantId", Name = "stock_move_company_id_index")]
//[Index("Date", Name = "stock_move_date_index")]
//[Index("LocationDestId", Name = "stock_move_location_dest_id_index")]
//[Index("LocationId", Name = "stock_move_location_id_index")]
//[Index("OrderpointId", Name = "stock_move_orderpoint_id_index")]
//[Index("OriginReturnedMoveId", Name = "stock_move_origin_returned_move_id_index")]
//[Index("PickingId", Name = "stock_move_picking_id_index")]
//[Index("ProductId", Name = "stock_move_product_id_index")]
//[Index("ProductId", "LocationId", "LocationDestId", "TenantId", "State", Name = "stock_move_product_location_index")]
//[Index("State", Name = "stock_move_state_index")]
public partial class StockMove: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_uom")]
    public Guid? ProductUom { get; set; }

    [Column("location_id")]
    public Guid? LocationId { get; set; }

    [Column("location_dest_id")]
    public Guid? LocationDestId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("picking_id")]
    public Guid? PickingId { get; set; }

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
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

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

    [ForeignKey("AnalyticAccountLineId")]
    //[InverseProperty("StockMoves")]
    [NotMapped]
    public virtual AccountAnalyticLine? AnalyticAccountLine { get; set; }

    [ForeignKey("BomLineId")]
    //[InverseProperty("StockMoves")]
    [NotMapped]
    public virtual MrpBomLine? BomLine { get; set; }

    [ForeignKey("ByproductId")]
    //[InverseProperty("StockMoves")]
    [NotMapped]
    public virtual MrpBomByproduct? Byproduct { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("StockMoves")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("ConsumeUnbuildId")]
    //[InverseProperty("StockMoveConsumeUnbuilds")]
    [NotMapped]
    public virtual MrpUnbuild? ConsumeUnbuild { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockMoveCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CreatedProductionId")]
    //[InverseProperty("StockMoveCreatedProductions")]
    [NotMapped]
    public virtual MrpProduction? CreatedProduction { get; set; }

    [ForeignKey("CreatedPurchaseLineId")]
    //[InverseProperty("StockMoveCreatedPurchaseLines")]
    [NotMapped]
    public virtual PurchaseOrderLine? CreatedPurchaseLine { get; set; }

    [ForeignKey("GroupId")]
    //[InverseProperty("StockMoves")]
    [NotMapped]
    public virtual ProcurementGroup? Group { get; set; }

    [ForeignKey("LocationId")]
    //[InverseProperty("StockMoveLocations")]
    [NotMapped]
    public virtual StockLocation? Location { get; set; }

    [ForeignKey("LocationDestId")]
    //[InverseProperty("StockMoveLocationDests")]
    [NotMapped]
    public virtual StockLocation? LocationDest { get; set; }

    [ForeignKey("OperationId")]
    //[InverseProperty("StockMoves")]
    [NotMapped]
    public virtual MrpRoutingWorkcenter? Operation { get; set; }

    [ForeignKey("OrderFinishedLotId")]
    //[InverseProperty("StockMoves")]
    [NotMapped]
    public virtual StockLot? OrderFinishedLot { get; set; }

    [ForeignKey("OrderpointId")]
    //[InverseProperty("StockMoves")]
    [NotMapped]
    public virtual StockWarehouseOrderpoint? Orderpoint { get; set; }

    [ForeignKey("OriginReturnedMoveId")]
    //[InverseProperty("InverseOriginReturnedMove")]
    [NotMapped]
    public virtual StockMove? OriginReturnedMove { get; set; }

    [ForeignKey("PackageLevelId")]
    //[InverseProperty("StockMoves")]
    [NotMapped]
    public virtual StockPackageLevel? PackageLevel { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("StockMovePartners")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("PickingId")]
    //[InverseProperty("StockMoves")]
    [NotMapped]
    public virtual StockPicking? Picking { get; set; }

    [ForeignKey("PickingTypeId")]
    //[InverseProperty("StockMoves")]
    [NotMapped]
    public virtual StockPickingType? PickingType { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("StockMoves")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("ProductPackagingId")]
    //[InverseProperty("StockMoves")]
    [NotMapped]
    public virtual ProductPackaging? ProductPackaging { get; set; }

    [ForeignKey("ProductUom")]
    //[InverseProperty("StockMoves")]
    [NotMapped]
    public virtual UomUom? ProductUomNavigation { get; set; }

    [ForeignKey("ProductionId")]
    //[InverseProperty("StockMoveProductions")]
    [NotMapped]
    public virtual MrpProduction? Production { get; set; }

    [ForeignKey("PurchaseLineId")]
    //[InverseProperty("StockMovePurchaseLines")]
    [NotMapped]
    public virtual PurchaseOrderLine? PurchaseLine { get; set; }

    [ForeignKey("RawMaterialProductionId")]
    //[InverseProperty("StockMoveRawMaterialProductions")]
    [NotMapped]
    public virtual MrpProduction? RawMaterialProduction { get; set; }

    [ForeignKey("RepairId")]
    //[InverseProperty("StockMoves")]
    [NotMapped]
    public virtual RepairOrder? Repair { get; set; }

    [ForeignKey("RestrictPartnerId")]
    //[InverseProperty("StockMoveRestrictPartners")]
    [NotMapped]
    public virtual ResPartner? RestrictPartner { get; set; }

    [ForeignKey("RuleId")]
    //[InverseProperty("StockMoves")]
    [NotMapped]
    public virtual StockRule? Rule { get; set; }

    [ForeignKey("SaleLineId")]
    //[InverseProperty("StockMoves")]
    [NotMapped]
    public virtual SaleOrderLine? SaleLine { get; set; }

    [ForeignKey("UnbuildId")]
    //[InverseProperty("StockMoveUnbuilds")]
    [NotMapped]
    public virtual MrpUnbuild? Unbuild { get; set; }

    [ForeignKey("WarehouseId")]
    //[InverseProperty("StockMoves")]
    [NotMapped]
    public virtual StockWarehouse? Warehouse { get; set; }

    [ForeignKey("WorkorderId")]
    //[InverseProperty("StockMoves")]
    [NotMapped]
    public virtual MrpWorkorder? Workorder { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockMoveWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("StockMove")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoves { get; } = new List<AccountMove>();

    //[InverseProperty("OriginReturnedMove")]
    [NotMapped]
    public virtual ICollection<StockMove> InverseOriginReturnedMove { get; } = new List<StockMove>();

    //[InverseProperty("Move")]
    [NotMapped]
    public virtual ICollection<RepairLine> RepairLines { get; } = new List<RepairLine>();

    //[InverseProperty("Move")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrders { get; } = new List<RepairOrder>();

    //[InverseProperty("Move")]
    [NotMapped]
    public virtual ICollection<StockAssignSerial> StockAssignSerials { get; } = new List<StockAssignSerial>();

    //[InverseProperty("Move")]
    [NotMapped]
    public virtual ICollection<StockMoveLine> StockMoveLines { get; } = new List<StockMoveLine>();

    //[InverseProperty("Move")]
    [NotMapped]
    public virtual ICollection<StockReturnPickingLine> StockReturnPickingLines { get; } = new List<StockReturnPickingLine>();

    //[InverseProperty("Move")]
    [NotMapped]
    public virtual ICollection<StockScrap> StockScraps { get; } = new List<StockScrap>();

    //[InverseProperty("StockMove")]
    [NotMapped]
    public virtual ICollection<StockValuationLayer> StockValuationLayers { get; } = new List<StockValuationLayer>();

    [ForeignKey("MoveOrigId")]
    //[InverseProperty("MoveOrigs")]
    [NotMapped]
    public virtual ICollection<StockMove> MoveDests { get; } = new List<StockMove>();

    [ForeignKey("MoveDestId")]
    //[InverseProperty("MoveDests")]
    [NotMapped]
    public virtual ICollection<StockMove> MoveOrigs { get; } = new List<StockMove>();

    [ForeignKey("MoveId")]
    //[InverseProperty("Moves")]
    [NotMapped]
    public virtual ICollection<StockRoute> Routes { get; } = new List<StockRoute>();
}
