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
//[Index("CompanyId", Name = "stock_warehouse_orderpoint__company_id_index")]
//[Index("LocationId", Name = "stock_warehouse_orderpoint__location_id_index")]
//[Index("ProductId", "LocationId", "CompanyId", Name = "stock_warehouse_orderpoint_product_location_check", IsUnique = true)]
//[Index("WarehouseId", Name = "stock_warehouse_orderpoint_warehouse_id_index")]
public partial class StockWarehouseOrderpoint: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("warehouse_id")]
    public Guid? WarehouseId { get; set; }

    [Column("location_id")]
    public Guid? LocationId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_category_id")]
    public Guid? ProductCategoryId { get; set; }

    [Column("group_id")]
    public Guid? GroupId { get; set; }

    [Column("route_id")]
    public Guid? RouteId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

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

    [Column("qty_to_order_manual")]
    public decimal? QtyToOrderManual { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("supplier_id")]
    public Guid? SupplierId { get; set; }

    [Column("vendor_id")]
    public Guid? VendorId { get; set; }

    [Column("product_supplier_id")]
    public Guid? ProductSupplierId { get; set; }

    [Column("purchase_visibility_days")]
    public double? PurchaseVisibilityDays { get; set; }

    [Column("bom_id")]
    public Guid? BomId { get; set; }

    [Column("manufacturing_visibility_days")]
    public double? ManufacturingVisibilityDays { get; set; }

    // [Many2one]
    [ForeignKey("BomId")]
    // [InverseProperty("StockWarehouseOrderpoint")] //Many2one
    public virtual MrpBom? Bom { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("StockWarehouseOrderpoint")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("StockWarehouseOrderpointCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("GroupId")]
    // [InverseProperty("StockWarehouseOrderpoint")] //Many2one
    public virtual ProcurementGroup? Group { get; set; }

    // [Many2one]
    [ForeignKey("LocationId")]
    // [InverseProperty("StockWarehouseOrderpoint")] //Many2one
    public virtual StockLocation? Location { get; set; }

    // [One2many]
    [ForeignKey("OrderpointId")]
    [InverseProperty("Orderpoint")]
    public virtual ICollection<MrpProduction> MrpProduction { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("StockWarehouseOrderpoint")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [ForeignKey("ProductCategoryId")]
    // [InverseProperty("StockWarehouseOrderpoint")] //Many2one
    public virtual ProductCategory? ProductCategory { get; set; }

    // [Many2one]
    [ForeignKey("ProductSupplierId")]
    // [InverseProperty("StockWarehouseOrderpointProductSupplier")] //Many2one
    public virtual ResPartner? ProductSupplier { get; set; }

    // [One2many]
    [ForeignKey("OrderpointId")]
    [InverseProperty("Orderpoint")]
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLine { get; set; }

    // [Many2one]
    [ForeignKey("RouteId")]
    // [InverseProperty("StockWarehouseOrderpoint")] //Many2one
    public virtual StockRoute? Route { get; set; }

    // [One2many]
    [ForeignKey("OrderpointId")]
    [InverseProperty("Orderpoint")]
    public virtual ICollection<StockMove> StockMove { get; set; }

    // [One2many]
    [ForeignKey("OrderpointId")]
    [InverseProperty("Orderpoint")]
    public virtual ICollection<StockReplenishmentInfo> StockReplenishmentInfo { get; set; }

    // [Many2one]
    [ForeignKey("SupplierId")]
    // [InverseProperty("StockWarehouseOrderpoint")] //Many2one
    public virtual ProductSupplierinfo? Supplier { get; set; }

    // [Many2one]
    [ForeignKey("VendorId")]
    // [InverseProperty("StockWarehouseOrderpoint")] //Many2one
    // [InverseProperty("StockWarehouseOrderpointVendor")] //Many2one
    public virtual ResPartner? Vendor { get; set; }

    // [Many2one]
    [ForeignKey("WarehouseId")]
    // [InverseProperty("StockWarehouseOrderpoint")] //Many2one
    public virtual StockWarehouse? Warehouse { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("StockWarehouseOrderpointWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockWarehouseOrderpointId")]
    // [InverseProperty("StockWarehouseOrderpoint")]
    public virtual ICollection<StockOrderpointSnooze> StockOrderpointSnooze { get; set; }
}
