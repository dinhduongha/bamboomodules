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
public partial class StockMove : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

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

    [Column("to_refund")]
    public bool? ToRefund { get; set; }

    [Column("sale_line_id")]
    public Guid? SaleLineId { get; set; }

    [Column("purchase_line_id")]
    public Guid? PurchaseLineId { get; set; }

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
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("StockMoveId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("StockMove")] // One2many
    public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("BomLineId")]
    public virtual MrpBomLine? BomLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ByproductId")]
    public virtual MrpBomByproduct? Byproduct { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ConsumeUnbuildId")]
    public virtual MrpUnbuild? ConsumeUnbuild { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatedProductionId")]
    public virtual MrpProduction? CreatedProduction { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("GroupId")]
    public virtual ProcurementGroup? Group { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OriginReturnedMoveId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("OriginReturnedMove")] // One2many
    public virtual ICollection<StockMove> InverseOriginReturnedMove { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LocationId")]
    public virtual StockLocation? Location { get; set; }

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
    [ForeignKey("OperationId")]
    public virtual MrpRoutingWorkcenter? Operation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("OrderFinishedLotId")]
    public virtual StockLot? OrderFinishedLot { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("OrderpointId")]
    public virtual StockWarehouseOrderpoint? Orderpoint { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("OriginReturnedMoveId")]
    public virtual StockMove? OriginReturnedMove { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PackageLevelId")]
    public virtual StockPackageLevel? PackageLevel { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PickingId")]
    public virtual StockPicking? Picking { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PickingTypeId")]
    public virtual StockPickingType? PickingType { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductId")]
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductPackagingId")]
    public virtual ProductPackaging? ProductPackaging { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductUom")]
    public virtual UomUom? ProductUomNavigation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductionId")]
    public virtual MrpProduction? Production { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PurchaseLineId")]
    public virtual PurchaseOrderLine? PurchaseLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MoveDestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MoveDest")] // One2many
    public virtual ICollection<PurchaseRequisitionLine> PurchaseRequisitionLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("RawMaterialProductionId")]
    public virtual MrpProduction? RawMaterialProduction { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("RepairId")]
    public virtual RepairOrder? Repair { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MoveId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Move")] // One2many
    public virtual ICollection<RepairOrder> RepairOrder { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("RestrictPartnerId")]
    public virtual ResPartner? RestrictPartner { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("RuleId")]
    public virtual StockRule? Rule { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SaleLineId")]
    public virtual SaleOrderLine? SaleLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ScrapId")]
    public virtual StockScrap? Scrap { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MoveId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Move")] // One2many
    public virtual ICollection<StockMoveLine> StockMoveLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MoveId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Move")] // One2many
    public virtual ICollection<StockReturnPickingLine> StockReturnPickingLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MoveId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Move")] // One2many
    public virtual ICollection<StockValuationAdjustmentLines> StockValuationAdjustmentLines { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("StockMoveId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("StockMove")] // One2many
    public virtual ICollection<StockValuationLayer> StockValuationLayer { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UnbuildId")]
    public virtual MrpUnbuild? Unbuild { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("WarehouseId")]
    public virtual StockWarehouse? Warehouse { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("WorkorderId")]
    public virtual MrpWorkorder? Workorder { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("StockMoveId")] // Many2many // Normal
    // [InverseProperty("StockMove")] // Many2many // Normal
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MoveId")] //Many2many // Hidden
    // [InverseProperty("Move")] //Many2many // Hidden
    public virtual ICollection<PurchaseOrderLine> CreatedPurchaseLine { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("MoveOrigId")] // Many2many // Normal
    // [InverseProperty("MoveOrig")] // Many2many // Normal
    public virtual ICollection<StockMove> MoveDest { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("MoveDestId")] // Many2many // Normal
    // [InverseProperty("MoveDest")] // Many2many // Normal
    public virtual ICollection<StockMove> MoveOrig { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockMoveId")] //Many2many // Hidden
    // [InverseProperty("StockMove")] //Many2many // Hidden
    public virtual ICollection<ProductLabelLayout> ProductLabelLayout { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("MoveId")] // Many2many // Normal
    // [InverseProperty("Move")] // Many2many // Normal
    public virtual ICollection<StockRoute> Route { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("MoveId")] // Many2many // Normal
    // [InverseProperty("Move")] // Many2many // Normal
    public virtual ICollection<ProductTemplateAttributeValue> TemplateAttributeValue { get; set; }
}
