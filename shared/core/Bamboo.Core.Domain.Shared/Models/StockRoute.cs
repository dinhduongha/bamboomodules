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
//[Index("TenantId", Name = "stock_route_company_id_index")]
public partial class StockRoute: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("supplied_wh_id")]
    public Guid? SuppliedWhId { get; set; }

    [Column("supplier_wh_id")]
    public Guid? SupplierWhId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("sale_selectable")]
    public bool? SaleSelectable { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("StockRoutes")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockRouteCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("SuppliedWhId")]
    //[InverseProperty("StockRouteSuppliedWhs")]
    [NotMapped]
    public virtual StockWarehouse? SuppliedWh { get; set; }

    [ForeignKey("SupplierWhId")]
    //[InverseProperty("StockRouteSupplierWhs")]
    [NotMapped]
    public virtual StockWarehouse? SupplierWh { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockRouteWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Route")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigs { get; } = new List<PosConfig>();

    //[InverseProperty("Route")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLines { get; } = new List<SaleOrderLine>();

    //[InverseProperty("Route")]
    [NotMapped]
    public virtual ICollection<StockReplenishmentOption> StockReplenishmentOptions { get; } = new List<StockReplenishmentOption>();

    //[InverseProperty("Route")]
    [NotMapped]
    public virtual ICollection<StockRule> StockRules { get; } = new List<StockRule>();

    //[InverseProperty("CrossdockRoute")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseCrossdockRoutes { get; } = new List<StockWarehouse>();

    //[InverseProperty("DeliveryRoute")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseDeliveryRoutes { get; } = new List<StockWarehouse>();

    //[InverseProperty("Route")]
    [NotMapped]
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoints { get; } = new List<StockWarehouseOrderpoint>();

    //[InverseProperty("PbmRoute")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehousePbmRoutes { get; } = new List<StockWarehouse>();

    //[InverseProperty("ReceptionRoute")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseReceptionRoutes { get; } = new List<StockWarehouse>();

    [ForeignKey("RouteId")]
    //[InverseProperty("Routes")]
    [NotMapped]
    public virtual ICollection<ProductCategory> Categs { get; } = new List<ProductCategory>();

    [ForeignKey("RouteId")]
    //[InverseProperty("Routes")]
    [NotMapped]
    public virtual ICollection<StockMove> Moves { get; } = new List<StockMove>();

    [ForeignKey("RouteId")]
    //[InverseProperty("Routes")]
    [NotMapped]
    public virtual ICollection<ProductPackaging> Packagings { get; } = new List<ProductPackaging>();

    [ForeignKey("StockRouteId")]
    //[InverseProperty("StockRoutes")]
    [NotMapped]
    public virtual ICollection<ProductReplenish> ProductReplenishes { get; } = new List<ProductReplenish>();

    [ForeignKey("RouteId")]
    //[InverseProperty("Routes")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> Products { get; } = new List<ProductTemplate>();

    [ForeignKey("StockRouteId")]
    //[InverseProperty("StockRoutes")]
    [NotMapped]
    public virtual ICollection<StockRulesReport> StockRulesReports { get; } = new List<StockRulesReport>();

    [ForeignKey("RouteId")]
    //[InverseProperty("Routes")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> Warehouses { get; } = new List<StockWarehouse>();
}
