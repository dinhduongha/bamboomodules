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

[Table("stock_warehouse_orderpoint")]
//[Index("CompanyId", Name = "stock_warehouse_orderpoint__company_id_index")]
//[Index("LocationId", Name = "stock_warehouse_orderpoint__location_id_index")]
//[Index("ProductId", "LocationId", "CompanyId", Name = "stock_warehouse_orderpoint_product_location_check", IsUnique = true)]
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
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("BomId")]
    public virtual MrpBom? Bom { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("GroupId")]
    public virtual ProcurementGroup? Group { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LocationId")]
    public virtual StockLocation? Location { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OrderpointId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Orderpoint")] // One2many
    public virtual ICollection<MrpProduction> MrpProduction { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductId")]
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductCategoryId")]
    public virtual ProductCategory? ProductCategory { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductSupplierId")]
    public virtual ResPartner? ProductSupplier { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OrderpointId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Orderpoint")] // One2many
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("RouteId")]
    public virtual StockRoute? Route { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OrderpointId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Orderpoint")] // One2many
    public virtual ICollection<StockMove> StockMove { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OrderpointId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Orderpoint")] // One2many
    public virtual ICollection<StockReplenishmentInfo> StockReplenishmentInfo { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SupplierId")]
    public virtual ProductSupplierinfo? Supplier { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("VendorId")]
    public virtual ResPartner? Vendor { get; set; }

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
    // [ForeignKey("StockWarehouseOrderpointId")] //Many2many // Hidden
    // [InverseProperty("StockWarehouseOrderpoint")] //Many2many // Hidden
    public virtual ICollection<StockOrderpointSnooze> StockOrderpointSnooze { get; set; }
}
