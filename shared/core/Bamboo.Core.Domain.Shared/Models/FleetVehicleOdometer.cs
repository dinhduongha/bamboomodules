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

[Table("fleet_vehicle_odometer")]
public partial class FleetVehicleOdometer: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("vehicle_id")]
    public Guid? VehicleId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("value")]
    public double? Value { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("FleetVehicleOdometerCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("VehicleId")]
    //[InverseProperty("FleetVehicleOdometers")]
    [NotMapped]
    public virtual FleetVehicle? Vehicle { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("FleetVehicleOdometerWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Odometer")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogService> FleetVehicleLogServices { get; } = new List<FleetVehicleLogService>();

}
