using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

//[Keyless]
public partial class FleetVehicleCostReport: Entity<Guid>, IMultiTenant
{
    [Column("id")]
    public Guid? Id { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("vehicle_id")]
    public Guid? VehicleId { get; set; }

    [Column("name", TypeName = "character varying")]
    public string? Name { get; set; }

    [Column("driver_id")]
    public Guid? DriverId { get; set; }

    [Column("fuel_type", TypeName = "character varying")]
    public string? FuelType { get; set; }

    [Column("date_start")]
    public DateTime? DateStart { get; set; }

    [Column("vehicle_type", TypeName = "character varying")]
    public string? VehicleType { get; set; }

    [Column("cost")]
    public decimal? Cost { get; set; }

    [Column("cost_type")]
    public string? CostType { get; set; }
}
