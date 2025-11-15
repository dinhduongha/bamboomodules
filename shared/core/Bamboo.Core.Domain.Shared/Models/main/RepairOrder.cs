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

[Table("repair_order")]
//[Index("CompanyId", Name = "repair_order__company_id_index")]
//[Index("LocationDestId", Name = "repair_order__location_dest_id_index")]
//[Index("LocationId", Name = "repair_order__location_id_index")]
//[Index("PartnerId", Name = "repair_order__partner_id_index")]
//[Index("PartsLocationId", Name = "repair_order__parts_location_id_index")]
//[Index("PickingTypeId", Name = "repair_order__picking_type_id_index")]
//[Index("ProductLocationDestId", Name = "repair_order__product_location_dest_id_index")]
//[Index("ProductLocationSrcId", Name = "repair_order__product_location_src_id_index")]
//[Index("RecycleLocationId", Name = "repair_order__recycle_location_id_index")]
//[Index("ScheduleDate", Name = "repair_order__schedule_date_index")]
//[Index("State", Name = "repair_order__state_index")]
public partial class RepairOrder : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("move_id")]
    public Guid? MoveId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_uom")]
    public Guid? ProductUom { get; set; }

    [Column("lot_id")]
    public Guid? LotId { get; set; }

    [Column("picking_type_id")]
    public Guid? PickingTypeId { get; set; }

    [Column("procurement_group_id")]
    public Guid? ProcurementGroupId { get; set; }

    [Column("location_id")]
    public Guid? LocationId { get; set; }

    [Column("product_location_src_id")]
    public Guid? ProductLocationSrcId { get; set; }

    [Column("product_location_dest_id")]
    public Guid? ProductLocationDestId { get; set; }

    [Column("location_dest_id")]
    public Guid? LocationDestId { get; set; }

    [Column("parts_location_id")]
    public Guid? PartsLocationId { get; set; }

    [Column("recycle_location_id")]
    public Guid? RecycleLocationId { get; set; }

    [Column("sale_order_id")]
    public Guid? SaleOrderId { get; set; }

    [Column("sale_order_line_id")]
    public Guid? SaleOrderLineId { get; set; }

    [Column("picking_id")]
    public Guid? PickingId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("priority")]
    public string? Priority { get; set; }

    [JsonField] // RepairProperties
    [Column("repair_properties", TypeName = "jsonb")]
    public JsonElement? RepairProperties { get; set; }

    [Column("internal_notes")]
    public string? InternalNotes { get; set; }

    [Column("product_qty")]
    public decimal? ProductQty { get; set; }

    [Column("under_warranty")]
    public bool? UnderWarranty { get; set; }

    [Column("is_parts_available")]
    public bool? IsPartsAvailable { get; set; }

    [Column("is_parts_late")]
    public bool? IsPartsLate { get; set; }

    [Column("schedule_date", TypeName = "timestamp without time zone")]
    public DateTime? ScheduleDate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

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
    [ForeignKey("LocationId")]
    public virtual StockLocation? Location { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LocationDestId")]
    public virtual StockLocation? LocationDest { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LotId")]
    public virtual StockLot? Lot { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("MoveId")]
    public virtual StockMove? Move { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartsLocationId")]
    public virtual StockLocation? PartsLocation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PickingId")]
    public virtual StockPicking? Picking { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PickingTypeId")]
    public virtual StockPickingType? PickingType { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProcurementGroupId")]
    public virtual ProcurementGroup? ProcurementGroup { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductId")]
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductLocationDestId")]
    public virtual StockLocation? ProductLocationDest { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductLocationSrcId")]
    public virtual StockLocation? ProductLocationSrc { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductUom")]
    public virtual UomUom? ProductUomNavigation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("RecycleLocationId")]
    public virtual StockLocation? RecycleLocation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SaleOrderId")]
    public virtual SaleOrder? SaleOrder { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SaleOrderLineId")]
    public virtual SaleOrderLine? SaleOrderLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("RepairId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Repair")] // One2many
    public virtual ICollection<StockMove> StockMove { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("RepairId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Repair")] // One2many
    public virtual ICollection<StockWarnInsufficientQtyRepair> StockWarnInsufficientQtyRepair { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("RepairOrderId")] // Many2many // Normal
    // [InverseProperty("RepairOrder")] // Many2many // Normal
    public virtual ICollection<RepairTags> RepairTags { get; set; }
}
