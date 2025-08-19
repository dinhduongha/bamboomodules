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

[Table("stock_route")]
//[Index("CompanyId", Name = "stock_route__company_id_index")]
public partial class StockRoute: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("supplied_wh_id")]
    public Guid? SuppliedWhId { get; set; }

    [Column("supplier_wh_id")]
    public Guid? SupplierWhId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("product_selectable")]
    public bool? ProductSelectable { get; set; }

    [Column("product_categ_selectable")]
    public bool? ProductCategSelectable { get; set; }

    [Column("warehouse_selectable")]
    public bool? WarehouseSelectable { get; set; }

    [Column("packaging_selectable")]
    public bool? PackagingSelectable { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("sale_selectable")]
    public bool? SaleSelectable { get; set; }

    [Column("shipping_selectable")]
    public bool? ShippingSelectable { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("StockRoute")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("StockRouteCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("RouteId")]
    [InverseProperty("Route")]
    public virtual ICollection<PosConfig> PosConfig { get; set; }

    // [One2many]
    [ForeignKey("RouteId")]
    [InverseProperty("Route")]
    public virtual ICollection<ProductReplenish> ProductReplenish { get; set; }

    // [One2many]
    [ForeignKey("RouteId")]
    [InverseProperty("Route")]
    public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }

    // [One2many]
    [ForeignKey("RouteId")]
    [InverseProperty("Route")]
    public virtual ICollection<StockReplenishmentOption> StockReplenishmentOption { get; set; }

    // [One2many]
    [ForeignKey("RouteId")]
    [InverseProperty("Route")]
    public virtual ICollection<StockRule> StockRule { get; set; }

    // [One2many]
    [ForeignKey("CrossdockRouteId")]
    [InverseProperty("CrossdockRoute")]
    public virtual ICollection<StockWarehouse> StockWarehouseCrossdockRoute { get; set; }

    // [One2many]
    [ForeignKey("DeliveryRouteId")]
    [InverseProperty("DeliveryRoute")]
    public virtual ICollection<StockWarehouse> StockWarehouseDeliveryRoute { get; set; }

    // [One2many]
    [ForeignKey("RouteId")]
    [InverseProperty("Route")]
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoint { get; set; }

    // [One2many]
    [ForeignKey("PbmRouteId")]
    [InverseProperty("PbmRoute")]
    public virtual ICollection<StockWarehouse> StockWarehousePbmRoute { get; set; }

    // [One2many]
    [ForeignKey("ReceptionRouteId")]
    [InverseProperty("ReceptionRoute")]
    public virtual ICollection<StockWarehouse> StockWarehouseReceptionRoute { get; set; }

    // [One2many]
    [ForeignKey("SubcontractingRouteId")]
    [InverseProperty("SubcontractingRoute")]
    public virtual ICollection<StockWarehouse> StockWarehouseSubcontractingRoute { get; set; }

    // [Many2one]
    [ForeignKey("SuppliedWhId")]
    // [InverseProperty("StockRouteSuppliedWh")] //Many2one
    public virtual StockWarehouse? SuppliedWh { get; set; }

    // [Many2one]
    [ForeignKey("SupplierWhId")]
    // [InverseProperty("StockRouteSupplierWh")] //Many2one
    public virtual StockWarehouse? SupplierWh { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("StockRouteWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("RouteId")] //Many2many
    // [InverseProperty("Route")] //Many2many
    public virtual ICollection<ProductCategory> Categ { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("RouteId")]
    // [InverseProperty("Route")]
    public virtual ICollection<StockMove> Move { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("RouteId")] //Many2many
    // [InverseProperty("Route")] //Many2many
    public virtual ICollection<ProductPackaging> Packaging { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("RouteId")] //Many2many
    // [InverseProperty("Route")] //Many2many
    public virtual ICollection<ProductTemplate> Product { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("RouteId")]
    // [InverseProperty("Route")]
    public virtual ICollection<DeliveryCarrier> Shipping { get; set; }

    // [Many2many] // ManyToMany Hidden
    //[NotMapped] //Many2many // Hidden
    // [ForeignKey("StockRouteId")]
    // [InverseProperty("StockRoute")]
    //public virtual ICollection<ProductReplenish> ProductReplenish { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockRouteId")]
    // [InverseProperty("StockRoute")]
    public virtual ICollection<StockRulesReport> StockRulesReport { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("RouteId")] //Many2many
    // [InverseProperty("Route")] //Many2many
    public virtual ICollection<StockWarehouse> Warehouse { get; set; }
}
