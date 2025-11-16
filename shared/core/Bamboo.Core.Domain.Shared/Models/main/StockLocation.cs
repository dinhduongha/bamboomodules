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

[Table("stock_location")]
//[Index("CompanyId", Name = "stock_location__company_id_index")]
//[Index("LocationId", Name = "stock_location__location_id_index")]
//[Index("ParentPath", Name = "stock_location__parent_path_index")]
//[Index("Usage", Name = "stock_location__usage_index")]
//[Index("Barcode", "CompanyId", Name = "stock_location_barcode_company_uniq", IsUnique = true)]
public partial class StockLocation : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("location_id")]
    public Guid? LocationId { get; set; }

    [Column("posx")]
    public long? Posx { get; set; }

    [Column("posy")]
    public long? Posy { get; set; }

    [Column("posz")]
    public long? Posz { get; set; }

    [Column("removal_strategy_id")]
    public Guid? RemovalStrategyId { get; set; }

    [Column("cyclic_inventory_frequency")]
    public long? CyclicInventoryFrequency { get; set; }

    [Column("warehouse_id")]
    public Guid? WarehouseId { get; set; }

    [Column("storage_category_id")]
    public Guid? StorageCategoryId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("complete_name")]
    public string? CompleteName { get; set; }

    [Column("usage")]
    public string? Usage { get; set; }

    [Column("parent_path")]
    public string? ParentPath { get; set; }

    [Column("barcode")]
    public string? Barcode { get; set; }

    [Column("last_inventory_date")]
    public DateTime? LastInventoryDate { get; set; }

    [Column("next_inventory_date")]
    public DateTime? NextInventoryDate { get; set; }

    [Column("comment")]
    public string? Comment { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("scrap_location")]
    public bool? ScrapLocation { get; set; }

    [Column("replenish_location")]
    public bool? ReplenishLocation { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("valuation_in_account_id")]
    public Guid? ValuationInAccountId { get; set; }

    [Column("valuation_out_account_id")]
    public Guid? ValuationOutAccountId { get; set; }

    [Column("is_subcontracting_location")]
    public bool? IsSubcontractingLocation { get; set; }

    [Column("is_a_dock")]
    public bool? IsADock { get; set; }

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
    // [One2many] [ForeignKey("LocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Location")] // One2many
    public virtual ICollection<StockLocation> InverseLocation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LocationId")]
    public virtual StockLocation? Location { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationDestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LocationDest")] // One2many
    public virtual ICollection<MrpProduction> MrpProductionLocationDest { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationFinalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LocationFinal")] // One2many
    public virtual ICollection<MrpProduction> MrpProductionLocationFinal { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationSrcId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LocationSrc")] // One2many
    public virtual ICollection<MrpProduction> MrpProductionLocationSrc { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductionLocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ProductionLocation")] // One2many
    public virtual ICollection<MrpProduction> MrpProductionProductionLocation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Location")] // One2many
    public virtual ICollection<MrpUnbuild> MrpUnbuildLocation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationDestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LocationDest")] // One2many
    public virtual ICollection<MrpUnbuild> MrpUnbuildLocationDest { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationFinalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LocationFinal")] // One2many
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("RemovalStrategyId")]
    public virtual ProductRemoval? RemovalStrategy { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Location")] // One2many
    public virtual ICollection<RepairOrder> RepairOrderLocation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationDestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LocationDest")] // One2many
    public virtual ICollection<RepairOrder> RepairOrderLocationDest { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PartsLocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PartsLocation")] // One2many
    public virtual ICollection<RepairOrder> RepairOrderPartsLocation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductLocationDestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ProductLocationDest")] // One2many
    public virtual ICollection<RepairOrder> RepairOrderProductLocationDest { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductLocationSrcId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ProductLocationSrc")] // One2many
    public virtual ICollection<RepairOrder> RepairOrderProductLocationSrc { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("RecycleLocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("RecycleLocation")] // One2many
    public virtual ICollection<RepairOrder> RepairOrderRecycleLocation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("InternalTransitLocationId")]
    [NotMapped] // One2many // Peer relationship (ResCompany) is commented out
    // [InverseProperty("InternalTransitLocation")] // One2many
    public virtual ICollection<ResCompany> ResCompanyInternalTransitLocation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SubcontractingLocationId")]
    [NotMapped] // One2many // Peer relationship (ResCompany) is commented out
    // [InverseProperty("SubcontractingLocation")] // One2many
    public virtual ICollection<ResCompany> ResCompanySubcontractingLocation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Location")] // One2many
    public virtual ICollection<StockLot> StockLot { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Location")] // One2many
    public virtual ICollection<StockMoveLine> StockMoveLineLocation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationDestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LocationDest")] // One2many
    public virtual ICollection<StockMoveLine> StockMoveLineLocationDest { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Location")] // One2many
    public virtual ICollection<StockMove> StockMoveLocation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationDestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LocationDest")] // One2many
    public virtual ICollection<StockMove> StockMoveLocationDest { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationFinalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LocationFinal")] // One2many
    public virtual ICollection<StockMove> StockMoveLocationFinal { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationDestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LocationDest")] // One2many
    public virtual ICollection<StockPackageDestination> StockPackageDestination { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationDestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LocationDest")] // One2many
    public virtual ICollection<StockPackageLevel> StockPackageLevel { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DockId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Dock")] // One2many
    public virtual ICollection<StockPickingBatch> StockPickingBatch { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Location")] // One2many
    public virtual ICollection<StockPicking> StockPickingLocation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationDestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LocationDest")] // One2many
    public virtual ICollection<StockPicking> StockPickingLocationDest { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DefaultLocationDestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("DefaultLocationDest")] // One2many
    public virtual ICollection<StockPickingType> StockPickingTypeDefaultLocationDest { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DefaultLocationSrcId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("DefaultLocationSrc")] // One2many
    public virtual ICollection<StockPickingType> StockPickingTypeDefaultLocationSrc { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DefaultProductLocationDestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("DefaultProductLocationDest")] // One2many
    public virtual ICollection<StockPickingType> StockPickingTypeDefaultProductLocationDest { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DefaultProductLocationSrcId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("DefaultProductLocationSrc")] // One2many
    public virtual ICollection<StockPickingType> StockPickingTypeDefaultProductLocationSrc { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DefaultRecycleLocationDestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("DefaultRecycleLocationDest")] // One2many
    public virtual ICollection<StockPickingType> StockPickingTypeDefaultRecycleLocationDest { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DefaultRemoveLocationDestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("DefaultRemoveLocationDest")] // One2many
    public virtual ICollection<StockPickingType> StockPickingTypeDefaultRemoveLocationDest { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationInId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LocationIn")] // One2many
    public virtual ICollection<StockPutawayRule> StockPutawayRuleLocationIn { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationOutId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LocationOut")] // One2many
    public virtual ICollection<StockPutawayRule> StockPutawayRuleLocationOut { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Location")] // One2many
    public virtual ICollection<StockQuant> StockQuant { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Location")] // One2many
    public virtual ICollection<StockQuantPackage> StockQuantPackage { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DestLocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("DestLocation")] // One2many
    public virtual ICollection<StockQuantRelocate> StockQuantRelocate { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationDestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LocationDest")] // One2many
    public virtual ICollection<StockRule> StockRuleLocationDest { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationSrcId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LocationSrc")] // One2many
    public virtual ICollection<StockRule> StockRuleLocationSrc { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Location")] // One2many
    public virtual ICollection<StockScrap> StockScrapLocation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ScrapLocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ScrapLocation")] // One2many
    public virtual ICollection<StockScrap> StockScrapScrapLocation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LotStockId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LotStock")] // One2many
    public virtual ICollection<StockWarehouse> StockWarehouseLotStock { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Location")] // One2many
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoint { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PbmLocId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PbmLoc")] // One2many
    public virtual ICollection<StockWarehouse> StockWarehousePbmLoc { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SamLocId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SamLoc")] // One2many
    public virtual ICollection<StockWarehouse> StockWarehouseSamLoc { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ViewLocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ViewLocation")] // One2many
    public virtual ICollection<StockWarehouse> StockWarehouseViewLocation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("WhInputStockLocId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("WhInputStockLoc")] // One2many
    public virtual ICollection<StockWarehouse> StockWarehouseWhInputStockLoc { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("WhOutputStockLocId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("WhOutputStockLoc")] // One2many
    public virtual ICollection<StockWarehouse> StockWarehouseWhOutputStockLoc { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("WhPackStockLocId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("WhPackStockLoc")] // One2many
    public virtual ICollection<StockWarehouse> StockWarehouseWhPackStockLoc { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("WhQcStockLocId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("WhQcStockLoc")] // One2many
    public virtual ICollection<StockWarehouse> StockWarehouseWhQcStockLoc { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Location")] // One2many
    public virtual ICollection<StockWarnInsufficientQtyRepair> StockWarnInsufficientQtyRepair { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Location")] // One2many
    public virtual ICollection<StockWarnInsufficientQtyScrap> StockWarnInsufficientQtyScrap { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Location")] // One2many
    public virtual ICollection<StockWarnInsufficientQtyUnbuild> StockWarnInsufficientQtyUnbuild { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("StorageCategoryId")]
    public virtual StockStorageCategory? StorageCategory { get; set; }

    // CONFLICK-v19
    // // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ValuationInAccountId")]
    public virtual AccountAccount? ValuationInAccount { get; set; }

    // CONFLICK-v19
    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ValuationOutAccountId")]
    public virtual AccountAccount? ValuationOutAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("WarehouseId")]
    public virtual StockWarehouse? Warehouse { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockLocationId")] //Many2many // Hidden
    // [InverseProperty("StockLocation")] //Many2many // Hidden
    public virtual ICollection<StockPickingType> StockPickingType { get; set; }
}
