using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace Bamboo.Core.Models;

// public enum LocationTypeEnum
// {

// }

public partial class StockLocation
{
    [Column("location_type")]
    public string? LocationType { get; set; } = "internal"; // enum string: "internal", "view", "transit", "customer", "vehicle", "salesman_personal", ...

    [Column("vehicle_id")]
    public Guid? VehicleId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("owner_id")]
    public Guid? OwnerId { get; set; }

    [Column("is_mobility")]
    public bool? IsMobility { get; set; } = false;

    [Column("is_shared")]
    public bool? IsShared { get; set; } = false;

    [Column("shared_partner_id")]
    public Guid? SharedPartnerId { get; set; }

    [Column("last_inventory_check_date")]
    public DateTimeOffset? LastInventoryCheckDate { get; set; }

    [Column("h3_index")]
    public string? H3Index { get; set; }  // level 10

    [Column("h3_indexes")]
    public string[]? H3Indexes { get; set; }  // mảng h3index bao phủ polygon (level 7-9)

    [Column("geofence_radius_meters")]
    public long? GeofenceRadiusMeters { get; set; }

    [Column("geofence_id")]
    public Guid? GeofenceId { get; set; }

    [Column("gps_latitude")]
    public decimal? GpsLatitude { get; set; }

    [Column("gps_longitude")]
    public decimal? GpsLongitude { get; set; }

    [Column("geom_point")]
    public NetTopologySuite.Geometries.Point? GeomPoint { get; set; }  // thay cho lat/lng

    [Column("geom_polygon")]
    public NetTopologySuite.Geometries.Polygon? GeomPolygon { get; set; }  // geography(POLYGON, 4326)

    [Column("geom_geofence_polygon")]
    public NetTopologySuite.Geometries.Polygon? GeomGeofencePolygon { get; set; }

    [Column("geojson_point", TypeName = "jsonb")]
    public string? GeoJsonPoint { get; set; }  // thay cho lat/lng

    [Column("geojson_polygon", TypeName = "jsonb")]
    public string? GeoJsonPolygon { get; set; }

    [Column("geojson_geofence_polygon", TypeName = "jsonb")]
    public string? GeoJsonGeofencePolygon { get; set; }

    // Navigation properties mới
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("VehicleId")]
    public virtual FleetVehicle? Vehicle { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }
}