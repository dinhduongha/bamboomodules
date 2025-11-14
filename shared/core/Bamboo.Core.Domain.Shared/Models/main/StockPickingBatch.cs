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

[Table("stock_picking_batch")]
//[Index("CompanyId", Name = "stock_picking_batch__company_id_index")]
//[Index("PickingTypeId", Name = "stock_picking_batch__picking_type_id_index")]
//[Index("State", Name = "stock_picking_batch__state_index")]
public partial class StockPickingBatch: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("picking_type_id")]
    public Guid? PickingTypeId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [JsonField] // Properties
    [Column("properties", TypeName = "jsonb")]
    public JsonElement? Properties { get; set; }

    [Column("is_wave")]
    public bool? IsWave { get; set; }

    [Column("scheduled_date", TypeName = "timestamp without time zone")]
    public DateTime? ScheduledDate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("vehicle_id")]
    public Guid? VehicleId { get; set; }

    [Column("vehicle_category_id")]
    public Guid? VehicleCategoryId { get; set; }

    [Column("dock_id")]
    public Guid? DockId { get; set; }

    [Column("driver_id")]
    public Guid? DriverId { get; set; }

    [Column("end_date", TypeName = "timestamp without time zone")]
    public DateTime? EndDate { get; set; }

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
    [ForeignKey("DockId")]
    public virtual StockLocation? Dock { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DriverId")]
    public virtual ResPartner? Driver { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PickingTypeId")]
    public virtual StockPickingType? PickingType { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("WaveId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Wave")] // One2many
    public virtual ICollection<StockAddToWave> StockAddToWave { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("BatchId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Batch")] // One2many
    public virtual ICollection<StockMoveLine> StockMoveLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("BatchId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Batch")] // One2many
    public virtual ICollection<StockPicking> StockPicking { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("BatchId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Batch")] // One2many
    public virtual ICollection<StockPickingToBatch> StockPickingToBatch { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("VehicleId")]
    public virtual FleetVehicle? Vehicle { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("VehicleCategoryId")]
    public virtual FleetVehicleModelCategory? VehicleCategory { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
