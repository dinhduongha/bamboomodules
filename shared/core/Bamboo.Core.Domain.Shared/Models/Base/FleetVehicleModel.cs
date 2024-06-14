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
public partial class FleetVehicleModel: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("brand_id")]
    public long BrandId { get; set; }

    [Column("category_id")]
    public long? CategoryId { get; set; }

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

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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

    [Column("active")]
    public bool? Active { get; set; }

    [Column("trailer_hook")]
    public bool? TrailerHook { get; set; }

    [Column("electric_assistance")]
    public bool? ElectricAssistance { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("default_co2")]
    public double? DefaultCo2 { get; set; }

    [Column("horsepower_tax")]
    public double? HorsepowerTax { get; set; }

    [ForeignKey("BrandId")]
    //[InverseProperty("FleetVehicleModels")]
    [NotMapped]
    public virtual FleetVehicleModelBrand Brand { get; set; } = null!;

    [ForeignKey("CategoryId")]
    //[InverseProperty("FleetVehicleModels")]
    [NotMapped]
    public virtual FleetVehicleModelCategory? Category { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("FleetVehicleModelCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("FleetVehicleModelWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Model")]
    [NotMapped]
    public virtual ICollection<FleetVehicle> FleetVehicles { get; } = new List<FleetVehicle>();

    [ForeignKey("ModelId")]
    //[InverseProperty("Models")]
    [NotMapped]
    public virtual ICollection<ResPartner> Partners { get; } = new List<ResPartner>();
}
