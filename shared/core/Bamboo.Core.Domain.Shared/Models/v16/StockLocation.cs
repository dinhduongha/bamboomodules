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

[Table("stock_location")]
//[Index("Barcode", "CompanyId", Name = "stock_location_barcode_company_uniq", IsUnique = true)]
//[Index("CompanyId", Name = "stock_location_company_id_index")]
//[Index("LocationId", Name = "stock_location_location_id_index")]
//[Index("ParentPath", Name = "stock_location_parent_path_index")]
//[Index("Usage", Name = "stock_location_usage_index")]
public partial class StockLocation: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

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

    [Column("return_location")]
    public bool? ReturnLocation { get; set; }

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

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("StockLocation")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("StockLocationCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("LocationId")]
    [InverseProperty("Location")]
    public virtual ICollection<StockLocation> InverseLocation { get; set; }

    // [Many2one]
    [ForeignKey("LocationId")]
    // [InverseProperty("InverseLocation")] //Many2one
    public virtual StockLocation? Location { get; set; }

    // [One2many]
    [ForeignKey("LocationDestId")]
    [InverseProperty("LocationDest")]
    public virtual ICollection<MrpProduction> MrpProductionLocationDest { get; set; }

    // [One2many]
    [ForeignKey("LocationSrcId")]
    [InverseProperty("LocationSrc")]
    public virtual ICollection<MrpProduction> MrpProductionLocationSrc { get; set; }

    // [One2many]
    [ForeignKey("ProductionLocationId")]
    [InverseProperty("ProductionLocation")]
    public virtual ICollection<MrpProduction> MrpProductionProductionLocation { get; set; }

    // [One2many]
    [ForeignKey("LocationId")]
    [InverseProperty("Location")]
    public virtual ICollection<MrpUnbuild> MrpUnbuildLocation { get; set; }

    // [One2many]
    [ForeignKey("LocationDestId")]
    [InverseProperty("LocationDest")]
    public virtual ICollection<MrpUnbuild> MrpUnbuildLocationDest { get; set; }

    // [Many2one]
    [ForeignKey("RemovalStrategyId")]
    // [InverseProperty("StockLocation")] //Many2one
    public virtual ProductRemoval? RemovalStrategy { get; set; }

    // [One2many]
    [ForeignKey("LocationId")]
    [InverseProperty("Location")]
    public virtual ICollection<RepairLine> RepairLineLocation { get; set; }

    // [One2many]
    [ForeignKey("LocationDestId")]
    [InverseProperty("LocationDest")]
    public virtual ICollection<RepairLine> RepairLineLocationDest { get; set; }

    // [One2many]
    [ForeignKey("LocationId")]
    [InverseProperty("Location")]
    public virtual ICollection<RepairOrder> RepairOrder { get; set; }

    // [One2many]
    [ForeignKey("InternalTransitLocationId")]
    [InverseProperty("InternalTransitLocation")]
    public virtual ICollection<ResCompany> ResCompanyInternalTransitLocation { get; set; }

    // [One2many]
    [ForeignKey("SubcontractingLocationId")]
    [InverseProperty("SubcontractingLocation")]
    public virtual ICollection<ResCompany> ResCompanySubcontractingLocation { get; set; }

    // [One2many]
    [ForeignKey("LocationId")]
    [InverseProperty("Location")]
    public virtual ICollection<StockMoveLine> StockMoveLineLocation { get; set; }

    // [One2many]
    [ForeignKey("LocationDestId")]
    [InverseProperty("LocationDest")]
    public virtual ICollection<StockMoveLine> StockMoveLineLocationDest { get; set; }

    // [One2many]
    [ForeignKey("LocationId")]
    [InverseProperty("Location")]
    public virtual ICollection<StockMove> StockMoveLocation { get; set; }

    // [One2many]
    [ForeignKey("LocationDestId")]
    [InverseProperty("LocationDest")]
    public virtual ICollection<StockMove> StockMoveLocationDest { get; set; }

    // [One2many]
    [ForeignKey("LocationDestId")]
    [InverseProperty("LocationDest")]
    public virtual ICollection<StockPackageDestination> StockPackageDestination { get; set; }

    // [One2many]
    [ForeignKey("LocationDestId")]
    [InverseProperty("LocationDest")]
    public virtual ICollection<StockPackageLevel> StockPackageLevel { get; set; }

    // [One2many]
    [ForeignKey("LocationId")]
    [InverseProperty("Location")]
    public virtual ICollection<StockPicking> StockPickingLocation { get; set; }

    // [One2many]
    [ForeignKey("LocationDestId")]
    [InverseProperty("LocationDest")]
    public virtual ICollection<StockPicking> StockPickingLocationDest { get; set; }

    // [One2many]
    [ForeignKey("DefaultLocationDestId")]
    [InverseProperty("DefaultLocationDest")]
    public virtual ICollection<StockPickingType> StockPickingTypeDefaultLocationDest { get; set; }

    // [One2many]
    [ForeignKey("DefaultLocationSrcId")]
    [InverseProperty("DefaultLocationSrc")]
    public virtual ICollection<StockPickingType> StockPickingTypeDefaultLocationSrc { get; set; }

    // [One2many]
    [ForeignKey("LocationInId")]
    [InverseProperty("LocationIn")]
    public virtual ICollection<StockPutawayRule> StockPutawayRuleLocationIn { get; set; }

    // [One2many]
    [ForeignKey("LocationOutId")]
    [InverseProperty("LocationOut")]
    public virtual ICollection<StockPutawayRule> StockPutawayRuleLocationOut { get; set; }

    // [One2many]
    [ForeignKey("LocationId")]
    [InverseProperty("Location")]
    public virtual ICollection<StockQuant> StockQuant { get; set; }

    // [One2many]
    [ForeignKey("LocationId")]
    [InverseProperty("Location")]
    public virtual ICollection<StockQuantPackage> StockQuantPackage { get; set; }

    // [One2many]
    [ForeignKey("LocationId")]
    [InverseProperty("Location")]
    public virtual ICollection<StockReturnPicking> StockReturnPickingLocation { get; set; }

    // [One2many]
    [ForeignKey("OriginalLocationId")]
    [InverseProperty("OriginalLocation")]
    public virtual ICollection<StockReturnPicking> StockReturnPickingOriginalLocation { get; set; }

    // [One2many]
    [ForeignKey("ParentLocationId")]
    [InverseProperty("ParentLocation")]
    public virtual ICollection<StockReturnPicking> StockReturnPickingParentLocation { get; set; }

    // [One2many]
    [ForeignKey("LocationDestId")]
    [InverseProperty("LocationDest")]
    public virtual ICollection<StockRule> StockRuleLocationDest { get; set; }

    // [One2many]
    [ForeignKey("LocationSrcId")]
    [InverseProperty("LocationSrc")]
    public virtual ICollection<StockRule> StockRuleLocationSrc { get; set; }

    // [One2many]
    [ForeignKey("LocationId")]
    [InverseProperty("Location")]
    public virtual ICollection<StockScrap> StockScrapLocation { get; set; }

    // [One2many]
    [ForeignKey("ScrapLocationId")]
    [InverseProperty("ScrapLocation")]
    public virtual ICollection<StockScrap> StockScrapScrapLocation { get; set; }

    // [One2many]
    [ForeignKey("LotStockId")]
    [InverseProperty("LotStock")]
    public virtual ICollection<StockWarehouse> StockWarehouseLotStock { get; set; }

    // [One2many]
    [ForeignKey("LocationId")]
    [InverseProperty("Location")]
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoint { get; set; }

    // [One2many]
    [ForeignKey("PbmLocId")]
    [InverseProperty("PbmLoc")]
    public virtual ICollection<StockWarehouse> StockWarehousePbmLoc { get; set; }

    // [One2many]
    [ForeignKey("SamLocId")]
    [InverseProperty("SamLoc")]
    public virtual ICollection<StockWarehouse> StockWarehouseSamLoc { get; set; }

    // [One2many]
    [ForeignKey("ViewLocationId")]
    [InverseProperty("ViewLocation")]
    public virtual ICollection<StockWarehouse> StockWarehouseViewLocation { get; set; }

    // [One2many]
    [ForeignKey("WhInputStockLocId")]
    [InverseProperty("WhInputStockLoc")]
    public virtual ICollection<StockWarehouse> StockWarehouseWhInputStockLoc { get; set; }

    // [One2many]
    [ForeignKey("WhOutputStockLocId")]
    [InverseProperty("WhOutputStockLoc")]
    public virtual ICollection<StockWarehouse> StockWarehouseWhOutputStockLoc { get; set; }

    // [One2many]
    [ForeignKey("WhPackStockLocId")]
    [InverseProperty("WhPackStockLoc")]
    public virtual ICollection<StockWarehouse> StockWarehouseWhPackStockLoc { get; set; }

    // [One2many]
    [ForeignKey("WhQcStockLocId")]
    [InverseProperty("WhQcStockLoc")]
    public virtual ICollection<StockWarehouse> StockWarehouseWhQcStockLoc { get; set; }

    // [One2many]
    [ForeignKey("LocationId")]
    [InverseProperty("Location")]
    public virtual ICollection<StockWarnInsufficientQtyRepair> StockWarnInsufficientQtyRepair { get; set; }

    // [One2many]
    [ForeignKey("LocationId")]
    [InverseProperty("Location")]
    public virtual ICollection<StockWarnInsufficientQtyScrap> StockWarnInsufficientQtyScrap { get; set; }

    // [One2many]
    [ForeignKey("LocationId")]
    [InverseProperty("Location")]
    public virtual ICollection<StockWarnInsufficientQtyUnbuild> StockWarnInsufficientQtyUnbuild { get; set; }

    // [Many2one]
    [ForeignKey("StorageCategoryId")]
    // [InverseProperty("StockLocation")] //Many2one
    public virtual StockStorageCategory? StorageCategory { get; set; }

    // [Many2one]
    [ForeignKey("ValuationInAccountId")]
    // [InverseProperty("StockLocationValuationInAccount")] //Many2one
    public virtual AccountAccount? ValuationInAccount { get; set; }

    // [Many2one]
    [ForeignKey("ValuationOutAccountId")]
    // [InverseProperty("StockLocationValuationOutAccount")] //Many2one
    public virtual AccountAccount? ValuationOutAccount { get; set; }

    // [Many2one]
    [ForeignKey("WarehouseId")]
    // [InverseProperty("StockLocation")] //Many2one
    public virtual StockWarehouse? Warehouse { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("StockLocationWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
