using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace Bamboo.Core.Models;

public partial class ResUsers
{
    [Column("default_salesman_location_id")]
    public Guid? DefaultSalesmanLocationId { get; set; }

    [Column("is_salesman")]
    public bool? IsSalesman { get; set; } = false;

    [Column("is_driver")]
    public bool? IsDriver { get; set; } = false;

    [Column("current_vehicle_id")]
    public Guid? CurrentVehicleId { get; set; }

    [Column("provision_location_id")]
    public Guid? ProvisionLocationId { get; set; }

    [Column("target_daily_sales")]
    public decimal? TargetDailySales { get; set; }

    [Column("target_monthly_visit")]
    public long? TargetMonthlyVisit { get; set; }

    [Column("achievement_today")]
    public decimal? AchievementToday { get; set; } // computed, nhưng vẫn lưu để dễ query

    [Column("last_provision_date")]
    public DateTimeOffset? LastProvisionDate { get; set; }

    [Column("voice_note_enabled")]
    public bool? VoiceNoteEnabled { get; set; } = false;

    [Column("posm_deployment_status")]
    public string? POSMDeploymentStatus { get; set; } // enum string: "Deployed", "Pending", "Rejected"

    [Column("vmi_enabled")]
    public bool? VMIEnabled { get; set; } = false;

    // Navigation properties mới
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DefaultSalesmanLocationId")]
    public virtual StockLocation? DefaultSalesmanLocation { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CurrentVehicleId")]
    public virtual FleetVehicle? CurrentVehicle { get; set; }
}