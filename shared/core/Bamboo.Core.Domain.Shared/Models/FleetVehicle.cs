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
public partial class FleetVehicle: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("manager_id")]
    public Guid? ManagerId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("driver_id")]
    public Guid? DriverId { get; set; }

    [Column("future_driver_id")]
    public Guid? FutureDriverId { get; set; }

    [Column("model_id")]
    public Guid? ModelId { get; set; }

    [Column("brand_id")]
    public long? BrandId { get; set; }

    [Column("state_id")]
    public long? StateId { get; set; }

    [Column("seats")]
    public long? Seats { get; set; }

    [Column("doors")]
    public long? Doors { get; set; }

    [Column("horsepower")]
    public long? Horsepower { get; set; }

    [Column("power")]
    public long? Power { get; set; }

    [Column("category_id")]
    public long? CategoryId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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

    [Column("co2_standard")]
    public string? Co2Standard { get; set; }

    [Column("frame_type")]
    public string? FrameType { get; set; }

    [Column("next_assignation_date")]
    public DateTime? NextAssignationDate { get; set; }

    [Column("acquisition_date")]
    public DateTime? AcquisitionDate { get; set; }

    [Column("write_off_date")]
    public DateTime? WriteOffDate { get; set; }

    [Column("first_contract_date")]
    public DateTime? FirstContractDate { get; set; }

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
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

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

    [ForeignKey("BrandId")]
    //[InverseProperty("FleetVehicles")]
    [NotMapped]
    public virtual FleetVehicleModelBrand? Brand { get; set; }

    [ForeignKey("CategoryId")]
    //[InverseProperty("FleetVehicles")]
    [NotMapped]
    public virtual FleetVehicleModelCategory? Category { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("FleetVehicles")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("FleetVehicleCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("DriverId")]
    //[InverseProperty("FleetVehicleDrivers")]
    [NotMapped]
    public virtual ResPartner? Driver { get; set; }

    [ForeignKey("DriverEmployeeId")]
    //[InverseProperty("FleetVehicleDriverEmployees")]
    [NotMapped]
    public virtual HrEmployee? DriverEmployee { get; set; }

    [ForeignKey("FutureDriverId")]
    //[InverseProperty("FleetVehicleFutureDrivers")]
    [NotMapped]
    public virtual ResPartner? FutureDriver { get; set; }

    [ForeignKey("FutureDriverEmployeeId")]
    //[InverseProperty("FleetVehicleFutureDriverEmployees")]
    [NotMapped]
    public virtual HrEmployee? FutureDriverEmployee { get; set; }

    [ForeignKey("ManagerId")]
    //[InverseProperty("FleetVehicleManagers")]
    [NotMapped]
    public virtual ResUser? Manager { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("FleetVehicles")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("ModelId")]
    //[InverseProperty("FleetVehicles")]
    [NotMapped]
    public virtual FleetVehicleModel? Model { get; set; }

    [ForeignKey("StateId")]
    //[InverseProperty("FleetVehicles")]
    [NotMapped]
    public virtual FleetVehicleState? State { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("FleetVehicleWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Vehicle")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLines { get; } = new List<AccountMoveLine>();

    //[InverseProperty("Vehicle")]
    [NotMapped]
    public virtual ICollection<FleetVehicleAssignationLog> FleetVehicleAssignationLogs { get; } = new List<FleetVehicleAssignationLog>();

    //[InverseProperty("Vehicle")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContracts { get; } = new List<FleetVehicleLogContract>();

    //[InverseProperty("Vehicle")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogService> FleetVehicleLogServices { get; } = new List<FleetVehicleLogService>();

    //[InverseProperty("Vehicle")]
    [NotMapped]
    public virtual ICollection<FleetVehicleOdometer> FleetVehicleOdometers { get; } = new List<FleetVehicleOdometer>();

    [ForeignKey("VehicleTagId")]
    //[InverseProperty("VehicleTags")]
    [NotMapped]
    public virtual ICollection<FleetVehicleTag> Tags { get; } = new List<FleetVehicleTag>();
}
