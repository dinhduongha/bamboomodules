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

[Table("fleet_vehicle_model")]
public partial class FleetVehicleModel: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("brand_id")]
    public Guid? BrandId { get; set; }

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    [Column("model_year")]
    public long? ModelYear { get; set; }

    [Column("seats")]
    public long? Seats { get; set; }

    [Column("doors")]
    public long? Doors { get; set; }

    [Column("power")]
    public long? Power { get; set; }

    [Column("horsepower")]
    public long? Horsepower { get; set; }

    [Column("vehicle_range")]
    public long? VehicleRange { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("vehicle_type")]
    public string? VehicleType { get; set; }

    [Column("transmission")]
    public string? Transmission { get; set; }

    [Column("color")]
    public string? Color { get; set; }

    [Column("co2_standard")]
    public string? Co2Standard { get; set; }

    [Column("default_fuel_type")]
    public string? DefaultFuelType { get; set; }

    [Column("power_unit")]
    public string? PowerUnit { get; set; }

    [JsonField]
    [Column("vehicle_properties_definition", TypeName = "jsonb")]
    public string? VehiclePropertiesDefinition { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("trailer_hook")]
    public bool? TrailerHook { get; set; }

    [Column("electric_assistance")]
    public bool? ElectricAssistance { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("default_co2")]
    public double? DefaultCo2 { get; set; }

    [Column("horsepower_tax")]
    public double? HorsepowerTax { get; set; }

    // [Many2one]
    [ForeignKey("BrandId")]
    public virtual FleetVehicleModelBrand? Brand { get; set; }

    // [Many2one]
    [ForeignKey("CategoryId")]
    public virtual FleetVehicleModelCategory? Category { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Model")] // One2many
    public virtual ICollection<FleetVehicle> FleetVehicle { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [NotMapped] // Many2many // Peer relationship (ResPartner) is commented out
    // [ForeignKey("ModelId")] // Many2many // Normal
    // [InverseProperty("Model")] // Many2many // Normal
    public virtual ICollection<ResPartner> Partner { get; set; }
}
