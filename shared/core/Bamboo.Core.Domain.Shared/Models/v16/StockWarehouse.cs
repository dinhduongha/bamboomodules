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

[Table("stock_warehouse")]
//[Index("Code", "CompanyId", Name = "stock_warehouse_warehouse_code_uniq", IsUnique = true)]
//[Index("Name", "CompanyId", Name = "stock_warehouse_warehouse_name_uniq", IsUnique = true)]
public partial class StockWarehouse: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("view_location_id")]
    public Guid? ViewLocationId { get; set; }

    [Column("lot_stock_id")]
    public Guid? LotStockId { get; set; }

    [Column("wh_input_stock_loc_id")]
    public Guid? WhInputStockLocId { get; set; }

    [Column("wh_qc_stock_loc_id")]
    public Guid? WhQcStockLocId { get; set; }

    [Column("wh_output_stock_loc_id")]
    public Guid? WhOutputStockLocId { get; set; }

    [Column("wh_pack_stock_loc_id")]
    public Guid? WhPackStockLocId { get; set; }

    [Column("mto_pull_id")]
    public Guid? MtoPullId { get; set; }

    [Column("pick_type_id")]
    public Guid? PickTypeId { get; set; }

    [Column("pack_type_id")]
    public Guid? PackTypeId { get; set; }

    [Column("out_type_id")]
    public Guid? OutTypeId { get; set; }

    [Column("in_type_id")]
    public Guid? InTypeId { get; set; }

    [Column("int_type_id")]
    public Guid? IntTypeId { get; set; }

    [Column("qc_type_id")]
    public Guid? QcTypeId { get; set; }

    [Column("store_type_id")]
    public Guid? StoreTypeId { get; set; }

    [Column("xdock_type_id")]
    public Guid? XdockTypeId { get; set; }

    [Column("crossdock_route_id")]
    public Guid? CrossdockRouteId { get; set; }

    [Column("reception_route_id")]
    public Guid? ReceptionRouteId { get; set; }

    [Column("delivery_route_id")]
    public Guid? DeliveryRouteId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("reception_steps")]
    public string? ReceptionSteps { get; set; }

    [Column("delivery_steps")]
    public string? DeliverySteps { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("pos_type_id")]
    public Guid? PosTypeId { get; set; }

    [Column("buy_pull_id")]
    public Guid? BuyPullId { get; set; }

    [Column("buy_to_resupply")]
    public bool? BuyToResupply { get; set; }

    [Column("repair_type_id")]
    public Guid? RepairTypeId { get; set; }

    [Column("repair_mto_pull_id")]
    public Guid? RepairMtoPullId { get; set; }

    [Column("manufacture_pull_id")]
    public Guid? ManufacturePullId { get; set; }

    [Column("manufacture_mto_pull_id")]
    public Guid? ManufactureMtoPullId { get; set; }

    [Column("pbm_mto_pull_id")]
    public Guid? PbmMtoPullId { get; set; }

    [Column("sam_rule_id")]
    public Guid? SamRuleId { get; set; }

    [Column("manu_type_id")]
    public Guid? ManuTypeId { get; set; }

    [Column("pbm_type_id")]
    public Guid? PbmTypeId { get; set; }

    [Column("sam_type_id")]
    public Guid? SamTypeId { get; set; }

    [Column("pbm_route_id")]
    public Guid? PbmRouteId { get; set; }

    [Column("pbm_loc_id")]
    public Guid? PbmLocId { get; set; }

    [Column("sam_loc_id")]
    public Guid? SamLocId { get; set; }

    [Column("manufacture_steps")]
    public string? ManufactureSteps { get; set; }

    [Column("manufacture_to_resupply")]
    public bool? ManufactureToResupply { get; set; }

    [Column("subcontracting_mto_pull_id")]
    public Guid? SubcontractingMtoPullId { get; set; }

    [Column("subcontracting_pull_id")]
    public Guid? SubcontractingPullId { get; set; }

    [Column("subcontracting_route_id")]
    public Guid? SubcontractingRouteId { get; set; }

    [Column("subcontracting_type_id")]
    public Guid? SubcontractingTypeId { get; set; }

    [Column("subcontracting_resupply_type_id")]
    public Guid? SubcontractingResupplyTypeId { get; set; }

    [Column("subcontracting_to_resupply")]
    public bool? SubcontractingToResupply { get; set; }

    [Column("opening_hours")]
    public Guid? OpeningHours { get; set; }

    [Column("subcontracting_dropshipping_pull_id")]
    public Guid? SubcontractingDropshippingPullId { get; set; }

    [Column("subcontracting_dropshipping_to_resupply")]
    public bool? SubcontractingDropshippingToResupply { get; set; }

    // [Many2one]
    [ForeignKey("BuyPullId")]
    public virtual StockRule? BuyPull { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CrossdockRouteId")]
    public virtual StockRoute? CrossdockRoute { get; set; }

    // [Many2one]
    [ForeignKey("DeliveryRouteId")]
    public virtual StockRoute? DeliveryRoute { get; set; }

    // [Many2one]
    [ForeignKey("InTypeId")]
    public virtual StockPickingType? InType { get; set; }

    // [Many2one]
    [ForeignKey("IntTypeId")]
    public virtual StockPickingType? IntType { get; set; }

    // [Many2one]
    [ForeignKey("LotStockId")]
    public virtual StockLocation? LotStock { get; set; }

    // [Many2one]
    [ForeignKey("ManuTypeId")]
    public virtual StockPickingType? ManuType { get; set; }

    // [Many2one]
    [ForeignKey("ManufactureMtoPullId")]
    public virtual StockRule? ManufactureMtoPull { get; set; }

    // [Many2one]
    [ForeignKey("ManufacturePullId")]
    public virtual StockRule? ManufacturePull { get; set; }

    // [Many2one]
    [ForeignKey("MtoPullId")]
    public virtual StockRule? MtoPull { get; set; }

    // [Many2one]
    [ForeignKey("OpeningHours")]
    public virtual ResourceCalendar? OpeningHoursNavigation { get; set; }

    // [Many2one]
    [ForeignKey("OutTypeId")]
    public virtual StockPickingType? OutType { get; set; }

    // [Many2one]
    [ForeignKey("PackTypeId")]
    public virtual StockPickingType? PackType { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("PbmLocId")]
    public virtual StockLocation? PbmLoc { get; set; }

    // [Many2one]
    [ForeignKey("PbmMtoPullId")]
    public virtual StockRule? PbmMtoPull { get; set; }

    // [Many2one]
    [ForeignKey("PbmRouteId")]
    public virtual StockRoute? PbmRoute { get; set; }

    // [Many2one]
    [ForeignKey("PbmTypeId")]
    public virtual StockPickingType? PbmType { get; set; }

    // [Many2one]
    [ForeignKey("PickTypeId")]
    public virtual StockPickingType? PickType { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("WarehouseId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Warehouse")] // One2many
    public virtual ICollection<PosConfig> PosConfig { get; set; }

    // [Many2one]
    [ForeignKey("PosTypeId")]
    public virtual StockPickingType? PosType { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("WarehouseId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Warehouse")] // One2many
    public virtual ICollection<ProductReplenish> ProductReplenish { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("WarehouseId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Warehouse")] // One2many
    public virtual ICollection<PurchaseRequisition> PurchaseRequisition { get; set; }

    // [Many2one]
    [ForeignKey("QcTypeId")]
    public virtual StockPickingType? QcType { get; set; }

    // [Many2one]
    [ForeignKey("ReceptionRouteId")]
    public virtual StockRoute? ReceptionRoute { get; set; }

    // [Many2one]
    [ForeignKey("RepairMtoPullId")]
    public virtual StockRule? RepairMtoPull { get; set; }

    // [Many2one]
    [ForeignKey("RepairTypeId")]
    public virtual StockPickingType? RepairType { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("WarehouseId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Warehouse")] // One2many
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("WarehouseId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Warehouse")] // One2many
    public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }

    // [Many2one]
    [ForeignKey("SamLocId")]
    public virtual StockLocation? SamLoc { get; set; }

    // [Many2one]
    [ForeignKey("SamRuleId")]
    public virtual StockRule? SamRule { get; set; }

    // [Many2one]
    [ForeignKey("SamTypeId")]
    public virtual StockPickingType? SamType { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("WarehouseId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Warehouse")] // One2many
    public virtual ICollection<StockLocation> StockLocation { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("WarehouseId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Warehouse")] // One2many
    public virtual ICollection<StockMove> StockMove { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("WarehouseId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Warehouse")] // One2many
    public virtual ICollection<StockPickingType> StockPickingType { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("SuppliedWhId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SuppliedWh")] // One2many
    public virtual ICollection<StockRoute> StockRouteSuppliedWh { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("SupplierWhId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SupplierWh")] // One2many
    public virtual ICollection<StockRoute> StockRouteSupplierWh { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("PropagateWarehouseId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PropagateWarehouse")] // One2many
    public virtual ICollection<StockRule> StockRulePropagateWarehouse { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("WarehouseId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Warehouse")] // One2many
    public virtual ICollection<StockRule> StockRuleWarehouse { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("WarehouseId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Warehouse")] // One2many
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoint { get; set; }

    // [Many2one]
    [ForeignKey("StoreTypeId")]
    public virtual StockPickingType? StoreType { get; set; }

    // [Many2one]
    [ForeignKey("SubcontractingDropshippingPullId")]
    public virtual StockRule? SubcontractingDropshippingPull { get; set; }

    // [Many2one]
    [ForeignKey("SubcontractingMtoPullId")]
    public virtual StockRule? SubcontractingMtoPull { get; set; }

    // [Many2one]
    [ForeignKey("SubcontractingPullId")]
    public virtual StockRule? SubcontractingPull { get; set; }

    // [Many2one]
    [ForeignKey("SubcontractingResupplyTypeId")]
    public virtual StockPickingType? SubcontractingResupplyType { get; set; }

    // [Many2one]
    [ForeignKey("SubcontractingRouteId")]
    public virtual StockRoute? SubcontractingRoute { get; set; }

    // [Many2one]
    [ForeignKey("SubcontractingTypeId")]
    public virtual StockPickingType? SubcontractingType { get; set; }

    // [Many2one]
    [ForeignKey("ViewLocationId")]
    public virtual StockLocation? ViewLocation { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("WarehouseId")]
    [NotMapped] // One2many // Peer relationship (Website) is commented out
    // [InverseProperty("Warehouse")] // One2many
    public virtual ICollection<Website> Website { get; set; }

    // [Many2one]
    [ForeignKey("WhInputStockLocId")]
    public virtual StockLocation? WhInputStockLoc { get; set; }

    // [Many2one]
    [ForeignKey("WhOutputStockLocId")]
    public virtual StockLocation? WhOutputStockLoc { get; set; }

    // [Many2one]
    [ForeignKey("WhPackStockLocId")]
    public virtual StockLocation? WhPackStockLoc { get; set; }

    // [Many2one]
    [ForeignKey("WhQcStockLocId")]
    public virtual StockLocation? WhQcStockLoc { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2one]
    [ForeignKey("XdockTypeId")]
    public virtual StockPickingType? XdockType { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockWarehouseId")] //Many2many // Hidden
    // [InverseProperty("StockWarehouse")] //Many2many // Hidden
    public virtual ICollection<DeliveryCarrier> DeliveryCarrier { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("WarehouseId")] //Many2many // Hidden
    // [InverseProperty("Warehouse")] //Many2many // Hidden
    public virtual ICollection<StockRoute> Route { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockWarehouseId")] //Many2many // Hidden
    // [InverseProperty("StockWarehouse")] //Many2many // Hidden
    public virtual ICollection<StockRulesReport> StockRulesReport { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("SupplierWhId")] // Many2many // Normal
    // [InverseProperty("SupplierWh")] // Many2many // Normal
    public virtual ICollection<StockWarehouse> SuppliedWh { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("SuppliedWhId")] // Many2many // Normal
    // [InverseProperty("SuppliedWh")] // Many2many // Normal
    public virtual ICollection<StockWarehouse> SupplierWh { get; set; }
}
