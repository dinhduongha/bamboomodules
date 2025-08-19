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

[Table("stock_rule")]
//[Index("Action", Name = "stock_rule__action_index")]
//[Index("LocationDestId", Name = "stock_rule__location_dest_id_index")]
//[Index("LocationSrcId", Name = "stock_rule__location_src_id_index")]
//[Index("RouteId", Name = "stock_rule__route_id_index")]
//[Index("WarehouseId", Name = "stock_rule__warehouse_id_index")]
public partial class StockRule: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("group_id")]
    public Guid? GroupId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("location_dest_id")]
    public Guid? LocationDestId { get; set; }

    [Column("location_src_id")]
    public Guid? LocationSrcId { get; set; }

    [Column("route_id")]
    public Guid? RouteId { get; set; }

    [Column("route_sequence")]
    public long? RouteSequence { get; set; }

    [Column("picking_type_id")]
    public Guid? PickingTypeId { get; set; }

    [Column("delay")]
    public long? Delay { get; set; }

    [Column("partner_address_id")]
    public Guid? PartnerAddressId { get; set; }

    [Column("warehouse_id")]
    public Guid? WarehouseId { get; set; }

    [Column("propagate_warehouse_id")]
    public Guid? PropagateWarehouseId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("group_propagation_option")]
    public string? GroupPropagationOption { get; set; }

    [Column("action")]
    public string? Action { get; set; }

    [Column("procure_method")]
    public string? ProcureMethod { get; set; }

    [Column("auto")]
    public string? Auto { get; set; }

    [Column("push_domain")]
    public string? PushDomain { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("location_dest_from_rule")]
    public bool? LocationDestFromRule { get; set; }

    [Column("propagate_cancel")]
    public bool? PropagateCancel { get; set; }

    [Column("propagate_carrier")]
    public bool? PropagateCarrier { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("StockRule")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("StockRuleCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("GroupId")]
    // [InverseProperty("StockRule")] //Many2one
    public virtual ProcurementGroup? Group { get; set; }

    // [Many2one]
    [ForeignKey("LocationDestId")]
    // [InverseProperty("StockRuleLocationDest")] //Many2one
    public virtual StockLocation? LocationDest { get; set; }

    // [Many2one]
    [ForeignKey("LocationSrcId")]
    // [InverseProperty("StockRuleLocationSrc")] //Many2one
    public virtual StockLocation? LocationSrc { get; set; }

    // [Many2one]
    [ForeignKey("PartnerAddressId")]
    // [InverseProperty("StockRule")] //Many2one
    public virtual ResPartner? PartnerAddress { get; set; }

    // [Many2one]
    [ForeignKey("PickingTypeId")]
    // [InverseProperty("StockRule")] //Many2one
    public virtual StockPickingType? PickingType { get; set; }

    // [Many2one]
    [ForeignKey("PropagateWarehouseId")]
    // [InverseProperty("StockRulePropagateWarehouse")] //Many2one
    public virtual StockWarehouse? PropagateWarehouse { get; set; }

    // [Many2one]
    [ForeignKey("RouteId")]
    // [InverseProperty("StockRule")] //Many2one
    public virtual StockRoute? Route { get; set; }

    // [One2many]
    [ForeignKey("RuleId")]
    [InverseProperty("Rule")]
    public virtual ICollection<StockMove> StockMove { get; set; }

    // [One2many]
    [ForeignKey("BuyPullId")]
    [InverseProperty("BuyPull")]
    public virtual ICollection<StockWarehouse> StockWarehouseBuyPull { get; set; }

    // [One2many]
    [ForeignKey("ManufactureMtoPullId")]
    [InverseProperty("ManufactureMtoPull")]
    public virtual ICollection<StockWarehouse> StockWarehouseManufactureMtoPull { get; set; }

    // [One2many]
    [ForeignKey("ManufacturePullId")]
    [InverseProperty("ManufacturePull")]
    public virtual ICollection<StockWarehouse> StockWarehouseManufacturePull { get; set; }

    // [One2many]
    [ForeignKey("MtoPullId")]
    [InverseProperty("MtoPull")]
    public virtual ICollection<StockWarehouse> StockWarehouseMtoPull { get; set; }

    // [One2many]
    [ForeignKey("PbmMtoPullId")]
    [InverseProperty("PbmMtoPull")]
    public virtual ICollection<StockWarehouse> StockWarehousePbmMtoPull { get; set; }

    // [One2many]
    [ForeignKey("RepairMtoPullId")]
    [InverseProperty("RepairMtoPull")]
    public virtual ICollection<StockWarehouse> StockWarehouseRepairMtoPull { get; set; }

    // [One2many]
    [ForeignKey("SamRuleId")]
    [InverseProperty("SamRule")]
    public virtual ICollection<StockWarehouse> StockWarehouseSamRule { get; set; }

    // [One2many]
    [ForeignKey("SubcontractingDropshippingPullId")]
    [InverseProperty("SubcontractingDropshippingPull")]
    public virtual ICollection<StockWarehouse> StockWarehouseSubcontractingDropshippingPull { get; set; }

    // [One2many]
    [ForeignKey("SubcontractingMtoPullId")]
    [InverseProperty("SubcontractingMtoPull")]
    public virtual ICollection<StockWarehouse> StockWarehouseSubcontractingMtoPull { get; set; }

    // [One2many]
    [ForeignKey("SubcontractingPullId")]
    [InverseProperty("SubcontractingPull")]
    public virtual ICollection<StockWarehouse> StockWarehouseSubcontractingPull { get; set; }

    // [Many2one]
    [ForeignKey("WarehouseId")]
    // [InverseProperty("StockRuleWarehouse")] //Many2one
    public virtual StockWarehouse? Warehouse { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("StockRuleWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
