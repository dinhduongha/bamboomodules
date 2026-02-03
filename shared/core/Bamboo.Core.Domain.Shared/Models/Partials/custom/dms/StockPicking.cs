using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace Bamboo.Core.Models;

public partial class StockPicking
{
    [Column("dms_route_id")]
    public Guid? DmsRouteId { get; set; }

    [Column("vehicle_id")]
    public Guid? VehicleId { get; set; }

    [Column("planned_start_time")]
    public DateTimeOffset? PlannedStartTime { get; set; }

    [Column("actual_delivery_time")]
    public DateTimeOffset? ActualDeliveryTime { get; set; }

    [Column("delivery_status")]
    public string? DeliveryStatus { get; set; } = "pending"; // enum string: "pending", "in_transit", "delivered", ...

    [Column("vmi_order_flag")]
    public bool? VMIOrderFlag { get; set; } = false;

    [Column("promotion_applied_json", TypeName = "jsonb")]
    public Dictionary<string, object>? PromotionApplied { get; set; }

    // Navigation properties mới
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DmsRouteId")]
    public virtual DmsRoute? DmsRoute { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("VehicleId")]
    public virtual FleetVehicle? Vehicle { get; set; }
}