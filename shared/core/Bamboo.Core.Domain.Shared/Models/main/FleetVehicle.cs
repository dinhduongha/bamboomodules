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

[Table("fleet_vehicle")]
public partial class FleetVehicle : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("manager_id")]
    public Guid? ManagerId { get; set; }

    [Column("driver_id")]
    public Guid? DriverId { get; set; }

    [Column("future_driver_id")]
    public Guid? FutureDriverId { get; set; }

    [Column("model_id")]
    public Guid? ModelId { get; set; }

    [Column("brand_id")]
    public Guid? BrandId { get; set; }

    [Column("state_id")]
    public Guid? StateId { get; set; }

    [Column("seats")]
    public long? Seats { get; set; }

    [Column("doors")]
    public long? Doors { get; set; }

    [Column("horsepower")]
    public long? Horsepower { get; set; }

    [Column("power")]
    public long? Power { get; set; }

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    [Column("vehicle_range")]
    public long? VehicleRange { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("license_plate")]
    public string? LicensePlate { get; set; }

    [Column("vin_sn")]
    public string? VinSn { get; set; }

    [Column("color")]
    public string? Color { get; set; }

    [Column("location")]
    public string? Location { get; set; }

    [Column("model_year")]
    public string? ModelYear { get; set; }

    [Column("odometer_unit")]
    public string? OdometerUnit { get; set; }

    [Column("transmission")]
    public string? Transmission { get; set; }

    [Column("fuel_type")]
    public string? FuelType { get; set; }

    [Column("power_unit")]
    public string? PowerUnit { get; set; }

    [Column("co2_standard")]
    public string? Co2Standard { get; set; }

    [Column("frame_type")]
    public string? FrameType { get; set; }

    [Column("next_assignation_date")]
    public DateTime? NextAssignationDate { get; set; }

    [Column("order_date")]
    public DateTime? OrderDate { get; set; }

    [Column("acquisition_date")]
    public DateTime? AcquisitionDate { get; set; }

    [Column("write_off_date")]
    public DateTime? WriteOffDate { get; set; }

    [Column("first_contract_date")]
    public DateTime? FirstContractDate { get; set; }

    [JsonField] // VehicleProperties
    [Column("vehicle_properties", TypeName = "jsonb")]
    public JsonElement? VehicleProperties { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("trailer_hook")]
    public bool? TrailerHook { get; set; }

    [Column("plan_to_change_car")]
    public bool? PlanToChangeCar { get; set; }

    [Column("plan_to_change_bike")]
    public bool? PlanToChangeBike { get; set; }

    [Column("electric_assistance")]
    public bool? ElectricAssistance { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("horsepower_tax")]
    public double? HorsepowerTax { get; set; }

    [Column("co2")]
    public double? Co2 { get; set; }

    [Column("car_value")]
    public double? CarValue { get; set; }

    [Column("net_car_value")]
    public double? NetCarValue { get; set; }

    [Column("residual_value")]
    public double? ResidualValue { get; set; }

    [Column("frame_size")]
    public double? FrameSize { get; set; }

    [Column("driver_employee_id")]
    public Guid? DriverEmployeeId { get; set; }

    [Column("future_driver_employee_id")]
    public Guid? FutureDriverEmployeeId { get; set; }

    [Column("mobility_card")]
    public string? MobilityCard { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("VehicleId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Vehicle")] // One2many
    public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("BrandId")]
    public virtual FleetVehicleModelBrand? Brand { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CategoryId")]
    public virtual FleetVehicleModelCategory? Category { get; set; }

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
    [ForeignKey("DriverId")]
    public virtual ResPartner? Driver { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DriverEmployeeId")]
    public virtual HrEmployee? DriverEmployee { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("VehicleId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Vehicle")] // One2many
    public virtual ICollection<FleetVehicleAssignationLog> FleetVehicleAssignationLog { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("VehicleId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Vehicle")] // One2many
    public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContract { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("VehicleId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Vehicle")] // One2many
    public virtual ICollection<FleetVehicleLogServices> FleetVehicleLogServices { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("VehicleId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Vehicle")] // One2many
    public virtual ICollection<FleetVehicleOdometer> FleetVehicleOdometer { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("FutureDriverId")]
    public virtual ResPartner? FutureDriver { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("FutureDriverEmployeeId")]
    public virtual HrEmployee? FutureDriverEmployee { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ManagerId")]
    public virtual ResUsers? Manager { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ModelId")]
    public virtual FleetVehicleModel? Model { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("StateId")]
    public virtual FleetVehicleState? State { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("VehicleId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Vehicle")] // One2many
    public virtual ICollection<StockPickingBatch> StockPickingBatch { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("FleetVehicleId")] //Many2many // Hidden
    // [InverseProperty("FleetVehicle")] //Many2many // Hidden
    public virtual ICollection<FleetVehicleSendMail> FleetVehicleSendMail { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("VehicleTagId")] // Many2many // Normal
    // [InverseProperty("VehicleTag")] // Many2many // Normal
    public virtual ICollection<FleetVehicleTag> Tag { get; set; }
}
