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

    [Column("geofence_radius_meters")]
    public int? GeofenceRadiusMeters { get; set; }

    [Column("geofence_polygon_json")]
    public string? GeofencePolygonJson { get; set; }

    [Column("last_inventory_check_date")]
    public DateTimeOffset? LastInventoryCheckDate { get; set; }

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