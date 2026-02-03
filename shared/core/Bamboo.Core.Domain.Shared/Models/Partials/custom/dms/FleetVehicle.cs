using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace Bamboo.Core.Models;

public partial class FleetVehicle
{
    [Column("max_weight_kg")]
    public decimal? MaxWeightKg { get; set; }

    [Column("max_volume_m3")]
    public decimal? MaxVolumeM3 { get; set; }

    [Column("current_location_id")]
    public Guid? CurrentLocationId { get; set; }

    [Column("current_driver_id")]
    public Guid? CurrentDriverId { get; set; }

    [Column("is_active_for_delivery")]
    public bool? IsActiveForDelivery { get; set; } = true;

    [Column("vehicle_type")]
    public string? VehicleType { get; set; } = "truck"; // "truck", "van", "motorbike", ...

    [Column("track_device_id")]
    public string? TrackDeviceId { get; set; }

    [Column("posm_capacity")]
    public long? POSMCapacity { get; set; } = 0;

    [Column("odometer_auto_update")]
    public bool? OdometerAutoUpdate { get; set; } = false;

    [Column("route_optimization_score")]
    public decimal? RouteOptimizationScore { get; set; } = 0;

    [Column("last_h3_index")]
    public string? LastH3Index { get; set; }  // level 10

    [Column("last_h3_index_11")]
    public string? LastH3Index11 { get; set; }  // level 11

    [Column("last_gps_latitude")]
    public decimal? LastGpsLatitude { get; set; }

    [Column("last_gps_longitude")]
    public decimal? LastGpsLongitude { get; set; }

    [Column("last_gps_time")]
    public DateTimeOffset? LastGpsTime { get; set; }

    [Column("last_gps_geom")]
    public NetTopologySuite.Geometries.Point? LastGpsGeom { get; set; }  // thay cho lat/lng

    // Navigation properties mới
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CurrentStockLocationId")]
    public virtual StockLocation? CurrentStockLocation { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CurrentDriverId")]
    public virtual ResUsers? CurrentDriver { get; set; }

    // DmsRouteIds
    // FuelTypeEnum
    // LastMaintenanceDate
    // InsuranceExpiryDate
}