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

[Table("stock_warehouse_orderpoint")]
//[Index("TenantId", Name = "stock_warehouse_orderpoint_company_id_index")]
//[Index("LocationId", Name = "stock_warehouse_orderpoint_location_id_index")]
//[Index("ProductId", "LocationId", "TenantId", Name = "stock_warehouse_orderpoint_product_location_check", IsUnique = true)]
public partial class StockWarehouseOrderpoint: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("warehouse_id")]
    public Guid? WarehouseId { get; set; }

    [Column("location_id")]
    public Guid? LocationId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_category_id")]
    public long? ProductCategoryId { get; set; }

    [Column("group_id")]
    public Guid? GroupId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("route_id")]
    public Guid? RouteId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("trigger")]
    public string? Trigger { get; set; }

    [Column("snoozed_until")]
    public DateTime? SnoozedUntil { get; set; }

    [Column("product_min_qty")]
    public decimal? ProductMinQty { get; set; }

    [Column("product_max_qty")]
    public decimal? ProductMaxQty { get; set; }

    [Column("qty_multiple")]
    public decimal? QtyMultiple { get; set; }

    [Column("qty_to_order")]
    public decimal? QtyToOrder { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("supplier_id")]
    public Guid? SupplierId { get; set; }

    [Column("vendor_id")]
    public Guid? VendorId { get; set; }

    [Column("purchase_visibility_days")]
    public double? PurchaseVisibilityDays { get; set; }

    [Column("bom_id")]
    public Guid? BomId { get; set; }

    [Column("manufacturing_visibility_days")]
    public double? ManufacturingVisibilityDays { get; set; }

    [ForeignKey("BomId")]
    //[InverseProperty("StockWarehouseOrderpoints")]
    [NotMapped]
    public virtual MrpBom? Bom { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("StockWarehouseOrderpoints")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockWarehouseOrderpointCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("GroupId")]
    //[InverseProperty("StockWarehouseOrderpoints")]
    [NotMapped]
    public virtual ProcurementGroup? Group { get; set; }

    [ForeignKey("LocationId")]
    //[InverseProperty("StockWarehouseOrderpoints")]
    [NotMapped]
    public virtual StockLocation? Location { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("StockWarehouseOrderpoints")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("ProductCategoryId")]
    //[InverseProperty("StockWarehouseOrderpoints")]
    [NotMapped]
    public virtual ProductCategory? ProductCategory { get; set; }

    [ForeignKey("RouteId")]
    //[InverseProperty("StockWarehouseOrderpoints")]
    [NotMapped]
    public virtual StockRoute? Route { get; set; }

    [ForeignKey("SupplierId")]
    //[InverseProperty("StockWarehouseOrderpoints")]
    [NotMapped]
    public virtual ProductSupplierinfo? Supplier { get; set; }

    [ForeignKey("VendorId")]
    //[InverseProperty("StockWarehouseOrderpoints")]
    [NotMapped]
    public virtual ResPartner? Vendor { get; set; }

    [ForeignKey("WarehouseId")]
    //[InverseProperty("StockWarehouseOrderpoints")]
    [NotMapped]
    public virtual StockWarehouse? Warehouse { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockWarehouseOrderpointWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Orderpoint")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductions { get; } = new List<MrpProduction>();

    //[InverseProperty("Orderpoint")]
    [NotMapped]
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; } = new List<PurchaseOrderLine>();

    //[InverseProperty("Orderpoint")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoves { get; } = new List<StockMove>();

    //[InverseProperty("Orderpoint")]
    [NotMapped]
    public virtual ICollection<StockReplenishmentInfo> StockReplenishmentInfos { get; } = new List<StockReplenishmentInfo>();

    [ForeignKey("StockWarehouseOrderpointId")]
    //[InverseProperty("StockWarehouseOrderpoints")]
    [NotMapped]
    public virtual ICollection<StockOrderpointSnooze> StockOrderpointSnoozes { get; } = new List<StockOrderpointSnooze>();
}
