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

[Table("fleet_vehicle")]
public partial class FleetVehicle: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

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

    [JsonField]
    [Column("vehicle_properties", TypeName = "jsonb")]
    public string? VehicleProperties { get; set; }

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
    [ForeignKey("VehicleId")]
    [InverseProperty("Vehicle")]
    public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [Many2one]
    [ForeignKey("BrandId")]
    // [InverseProperty("FleetVehicle")] //Many2one
    public virtual FleetVehicleModelBrand? Brand { get; set; }

    // [Many2one]
    [ForeignKey("CategoryId")]
    // [InverseProperty("FleetVehicle")] //Many2one
    public virtual FleetVehicleModelCategory? Category { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("FleetVehicle")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("FleetVehicleCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("DriverId")]
    // [InverseProperty("FleetVehicleDriver")] //Many2one
    public virtual ResPartner? Driver { get; set; }

    // [Many2one]
    [ForeignKey("DriverEmployeeId")]
    // [InverseProperty("FleetVehicleDriverEmployee")] //Many2one
    public virtual HrEmployee? DriverEmployee { get; set; }

    // [One2many]
    [ForeignKey("VehicleId")]
    [InverseProperty("Vehicle")]
    public virtual ICollection<FleetVehicleAssignationLog> FleetVehicleAssignationLog { get; set; }

    // [One2many]
    [ForeignKey("VehicleId")]
    [InverseProperty("Vehicle")]
    public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContract { get; set; }

    // [One2many]
    [ForeignKey("VehicleId")]
    [InverseProperty("Vehicle")]
    public virtual ICollection<FleetVehicleLogServices> FleetVehicleLogServices { get; set; }

    // [One2many]
    [ForeignKey("VehicleId")]
    [InverseProperty("Vehicle")]
    public virtual ICollection<FleetVehicleOdometer> FleetVehicleOdometer { get; set; }

    // [Many2one]
    [ForeignKey("FutureDriverId")]
    // [InverseProperty("FleetVehicleFutureDriver")] //Many2one
    public virtual ResPartner? FutureDriver { get; set; }

    // [Many2one]
    [ForeignKey("FutureDriverEmployeeId")]
    // [InverseProperty("FleetVehicleFutureDriverEmployee")] //Many2one
    public virtual HrEmployee? FutureDriverEmployee { get; set; }

    // [Many2one]
    [ForeignKey("ManagerId")]
    // [InverseProperty("FleetVehicleManager")] //Many2one
    public virtual ResUsers? Manager { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("FleetVehicle")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("ModelId")]
    // [InverseProperty("FleetVehicle")] //Many2one
    public virtual FleetVehicleModel? Model { get; set; }

    // [Many2one]
    [ForeignKey("StateId")]
    // [InverseProperty("FleetVehicle")] //Many2one
    public virtual FleetVehicleState? State { get; set; }

    // [One2many]
    [ForeignKey("VehicleId")]
    [InverseProperty("Vehicle")]
    public virtual ICollection<StockPickingBatch> StockPickingBatch { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("FleetVehicleWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("FleetVehicleId")]
    // [InverseProperty("FleetVehicle")]
    public virtual ICollection<FleetVehicleSendMail> FleetVehicleSendMail { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("VehicleTagId")] //Many2many
    // [InverseProperty("VehicleTag")] //Many2many
    public virtual ICollection<FleetVehicleTag> Tag { get; set; }
}
