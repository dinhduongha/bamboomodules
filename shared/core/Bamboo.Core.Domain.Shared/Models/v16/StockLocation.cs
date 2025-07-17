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
//[Index("Barcode", "TenantId", Name = "stock_location_barcode_company_uniq", IsUnique = true)]
//[Index("TenantId", Name = "stock_location_company_id_index")]
//[Index("LocationId", Name = "stock_location_location_id_index")]
//[Index("ParentPath", Name = "stock_location_parent_path_index")]
//[Index("Usage", Name = "stock_location_usage_index")]
public partial class StockLocation: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

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
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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

    // v16-Compat
    [Column("return_location")]
    public bool? ReturnLocation { get; set; }

    [Column("replenish_location")]
    public bool? ReplenishLocation { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("valuation_in_account_id")]
    public Guid? ValuationInAccountId { get; set; }

    [Column("valuation_out_account_id")]
    public Guid? ValuationOutAccountId { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("StockLocations")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockLocationCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LocationId")]
    //[InverseProperty("InverseLocation")]
    [NotMapped]
    public virtual StockLocation? Location { get; set; }

    [ForeignKey("RemovalStrategyId")]
    //[InverseProperty("StockLocations")]
    [NotMapped]
    public virtual ProductRemoval? RemovalStrategy { get; set; }

    [ForeignKey("StorageCategoryId")]
    //[InverseProperty("StockLocations")]
    [NotMapped]
    public virtual StockStorageCategory? StorageCategory { get; set; }

    [ForeignKey("ValuationInAccountId")]
    //[InverseProperty("StockLocationValuationInAccounts")]
    [NotMapped]
    public virtual AccountAccount? ValuationInAccount { get; set; }

    [ForeignKey("ValuationOutAccountId")]
    //[InverseProperty("StockLocationValuationOutAccounts")]
    [NotMapped]
    public virtual AccountAccount? ValuationOutAccount { get; set; }

    [ForeignKey("WarehouseId")]
    //[InverseProperty("StockLocations")]
    [NotMapped]
    public virtual StockWarehouse? Warehouse { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockLocationWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Location")]
    [NotMapped]
    public virtual ICollection<StockLocation> InverseLocation { get; set; } = new List<StockLocation>();

    //[InverseProperty("LocationDest")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductionLocationDests { get; set; } = new List<MrpProduction>();

    //[InverseProperty("LocationSrc")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductionLocationSrcs { get; set; } = new List<MrpProduction>();

    //[InverseProperty("ProductionLocation")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductionProductionLocations { get; set; } = new List<MrpProduction>();

    //[InverseProperty("LocationDest")]
    [NotMapped]
    public virtual ICollection<MrpUnbuild> MrpUnbuildLocationDests { get; set; } = new List<MrpUnbuild>();

    //[InverseProperty("Location")]
    [NotMapped]
    public virtual ICollection<MrpUnbuild> MrpUnbuildLocations { get; set; } = new List<MrpUnbuild>();

    //[InverseProperty("LocationDest")]
    [NotMapped]
    public virtual ICollection<RepairLine> RepairLineLocationDests { get; set; } = new List<RepairLine>();

    //[InverseProperty("Location")]
    [NotMapped]
    public virtual ICollection<RepairLine> RepairLineLocations { get; set; } = new List<RepairLine>();

    //[InverseProperty("Location")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrders { get; set; } = new List<RepairOrder>();

    //[InverseProperty("InternalTransitLocation")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanies { get; set; } = new List<ResCompany>();

    //[InverseProperty("LocationDest")]
    [NotMapped]
    public virtual ICollection<StockMoveLine> StockMoveLineLocationDests { get; set; } = new List<StockMoveLine>();

    //[InverseProperty("Location")]
    [NotMapped]
    public virtual ICollection<StockMoveLine> StockMoveLineLocations { get; set; } = new List<StockMoveLine>();

    //[InverseProperty("LocationDest")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoveLocationDests { get; set; } = new List<StockMove>();

    //[InverseProperty("Location")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoveLocations { get; set; } = new List<StockMove>();

    //[InverseProperty("LocationDest")]
    [NotMapped]
    public virtual ICollection<StockPackageDestination> StockPackageDestinations { get; set; } = new List<StockPackageDestination>();

    //[InverseProperty("LocationDest")]
    [NotMapped]
    public virtual ICollection<StockPackageLevel> StockPackageLevels { get; set; } = new List<StockPackageLevel>();

    //[InverseProperty("LocationDest")]
    [NotMapped]
    public virtual ICollection<StockPicking> StockPickingLocationDests { get; set; } = new List<StockPicking>();

    //[InverseProperty("Location")]
    [NotMapped]
    public virtual ICollection<StockPicking> StockPickingLocations { get; set; } = new List<StockPicking>();

    //[InverseProperty("DefaultLocationDest")]
    [NotMapped]
    public virtual ICollection<StockPickingType> StockPickingTypeDefaultLocationDests { get; set; } = new List<StockPickingType>();

    //[InverseProperty("DefaultLocationSrc")]
    [NotMapped]
    public virtual ICollection<StockPickingType> StockPickingTypeDefaultLocationSrcs { get; set; } = new List<StockPickingType>();

    //[InverseProperty("LocationIn")]
    [NotMapped]
    public virtual ICollection<StockPutawayRule> StockPutawayRuleLocationIns { get; set; } = new List<StockPutawayRule>();

    //[InverseProperty("LocationOut")]
    [NotMapped]
    public virtual ICollection<StockPutawayRule> StockPutawayRuleLocationOuts { get; set; } = new List<StockPutawayRule>();

    //[InverseProperty("Location")]
    [NotMapped]
    public virtual ICollection<StockQuantPackage> StockQuantPackages { get; set; } = new List<StockQuantPackage>();

    //[InverseProperty("Location")]
    [NotMapped]
    public virtual ICollection<StockQuant> StockQuants { get; set; } = new List<StockQuant>();

    //[InverseProperty("Location")]
    [NotMapped]
    public virtual ICollection<StockReturnPicking> StockReturnPickingLocations { get; set; } = new List<StockReturnPicking>();

    //[InverseProperty("OriginalLocation")]
    [NotMapped]
    public virtual ICollection<StockReturnPicking> StockReturnPickingOriginalLocations { get; set; } = new List<StockReturnPicking>();

    //[InverseProperty("ParentLocation")]
    [NotMapped]
    public virtual ICollection<StockReturnPicking> StockReturnPickingParentLocations { get; set; } = new List<StockReturnPicking>();

    //[InverseProperty("LocationDest")]
    [NotMapped]
    public virtual ICollection<StockRule> StockRuleLocationDests { get; set; } = new List<StockRule>();

    //[InverseProperty("LocationSrc")]
    [NotMapped]
    public virtual ICollection<StockRule> StockRuleLocationSrcs { get; set; } = new List<StockRule>();

    //[InverseProperty("Location")]
    [NotMapped]
    public virtual ICollection<StockScrap> StockScrapLocations { get; set; } = new List<StockScrap>();

    //[InverseProperty("ScrapLocation")]
    [NotMapped]
    public virtual ICollection<StockScrap> StockScrapScrapLocations { get; set; } = new List<StockScrap>();

    //[InverseProperty("LotStock")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseLotStocks { get; set; } = new List<StockWarehouse>();

    //[InverseProperty("Location")]
    [NotMapped]
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoints { get; set; } = new List<StockWarehouseOrderpoint>();

    //[InverseProperty("PbmLoc")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehousePbmLocs { get; set; } = new List<StockWarehouse>();

    //[InverseProperty("SamLoc")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseSamLocs { get; set; } = new List<StockWarehouse>();

    //[InverseProperty("ViewLocation")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseViewLocations { get; set; } = new List<StockWarehouse>();

    //[InverseProperty("WhInputStockLoc")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseWhInputStockLocs { get; set; } = new List<StockWarehouse>();

    //[InverseProperty("WhOutputStockLoc")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseWhOutputStockLocs { get; set; } = new List<StockWarehouse>();

    //[InverseProperty("WhPackStockLoc")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseWhPackStockLocs { get; set; } = new List<StockWarehouse>();

    //[InverseProperty("WhQcStockLoc")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseWhQcStockLocs { get; set; } = new List<StockWarehouse>();

    //[InverseProperty("Location")]
    [NotMapped]
    public virtual ICollection<StockWarnInsufficientQtyRepair> StockWarnInsufficientQtyRepairs { get; set; } = new List<StockWarnInsufficientQtyRepair>();

    //[InverseProperty("Location")]
    [NotMapped]
    public virtual ICollection<StockWarnInsufficientQtyScrap> StockWarnInsufficientQtyScraps { get; set; } = new List<StockWarnInsufficientQtyScrap>();

    //[InverseProperty("Location")]
    [NotMapped]
    public virtual ICollection<StockWarnInsufficientQtyUnbuild> StockWarnInsufficientQtyUnbuilds { get; set; } = new List<StockWarnInsufficientQtyUnbuild>();

}
