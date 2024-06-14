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
public partial class StockRule: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("group_id")]
    public Guid? GroupId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

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
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("group_propagation_option")]
    public string? GroupPropagationOption { get; set; }

    [Column("action")]
    public string? Action { get; set; }

    [Column("procure_method")]
    public string? ProcureMethod { get; set; }

    [Column("auto")]
    public string? Auto { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("propagate_cancel")]
    public bool? PropagateCancel { get; set; }

    [Column("propagate_carrier")]
    public bool? PropagateCarrier { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("StockRules")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockRuleCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("GroupId")]
    //[InverseProperty("StockRules")]
    [NotMapped]
    public virtual ProcurementGroup? Group { get; set; }

    [ForeignKey("LocationDestId")]
    //[InverseProperty("StockRuleLocationDests")]
    [NotMapped]
    public virtual StockLocation? LocationDest { get; set; }

    [ForeignKey("LocationSrcId")]
    //[InverseProperty("StockRuleLocationSrcs")]
    [NotMapped]
    public virtual StockLocation? LocationSrc { get; set; }

    [ForeignKey("PartnerAddressId")]
    //[InverseProperty("StockRules")]
    [NotMapped]
    public virtual ResPartner? PartnerAddress { get; set; }

    [ForeignKey("PickingTypeId")]
    //[InverseProperty("StockRules")]
    [NotMapped]
    public virtual StockPickingType? PickingType { get; set; }

    [ForeignKey("PropagateWarehouseId")]
    //[InverseProperty("StockRulePropagateWarehouses")]
    [NotMapped]
    public virtual StockWarehouse? PropagateWarehouse { get; set; }

    [ForeignKey("RouteId")]
    //[InverseProperty("StockRules")]
    [NotMapped]
    public virtual StockRoute? Route { get; set; }

    [ForeignKey("WarehouseId")]
    //[InverseProperty("StockRuleWarehouses")]
    [NotMapped]
    public virtual StockWarehouse? Warehouse { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockRuleWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Rule")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoves { get; } = new List<StockMove>();

    //[InverseProperty("BuyPull")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseBuyPulls { get; } = new List<StockWarehouse>();

    //[InverseProperty("ManufactureMtoPull")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseManufactureMtoPulls { get; } = new List<StockWarehouse>();

    //[InverseProperty("ManufacturePull")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseManufacturePulls { get; } = new List<StockWarehouse>();

    //[InverseProperty("MtoPull")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseMtoPulls { get; } = new List<StockWarehouse>();

    //[InverseProperty("PbmMtoPull")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehousePbmMtoPulls { get; } = new List<StockWarehouse>();

    //[InverseProperty("SamRule")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseSamRules { get; } = new List<StockWarehouse>();

}
