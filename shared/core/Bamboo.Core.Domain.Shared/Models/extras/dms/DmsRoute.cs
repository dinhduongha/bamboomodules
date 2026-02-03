using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

// 1. DmsRoute
[Table("dms_route")]
public partial class DmsRoute : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("team_id")]
    public Guid? TeamId { get; set; }

    [Column("route_code")]
    public string RouteCode { get; set; } = null!;

    [Column("planned_date")]
    public DateTimeOffset? PlannedDate { get; set; }

    [Column("status")]
    public string Status { get; set; } = "draft";

    [Column("total_distance_km")]
    public decimal? TotalDistanceKm { get; set; }

    [Column("estimated_time_hours")]
    public decimal? EstimatedTimeHours { get; set; }

    [Column("vehicle_id")]
    public Guid? VehicleId { get; set; }

    [Column("planned_by_user_id")]
    public Guid? PlannedByUserId { get; set; }

    [Column("start_checkpoint_id")]
    public Guid? StartCheckpointId { get; set; }

    [Column("route_template_id")]
    public Guid? RouteTemplateId { get; set; }

    [Column("is_dynamic")]
    public bool IsDynamic { get; set; } = true; // true: động, false: copy nguyên từ template

    [Column("date")]
    public DateTimeOffset? Date { get; set; } // Ngày áp dụng route này

    [Column("h3_center")]
    public string? H3Center { get; set; }  // hex trung tâm của route

    [Column("geom_start")]
    public NetTopologySuite.Geometries.Point? GeomStartPoint { get; set; }

    [Column("geojson_start", TypeName = "jsonb")]
    public string? GeoJsonStartPoint { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("VehicleId")]
    public virtual FleetVehicle? Vehicle { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PlannedByUserId")]
    public virtual ResUsers? PlannedByUser { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public virtual ICollection<DmsRouteLine>? RouteLines { get; set; } = new List<DmsRouteLine>();

    // Navigation mới
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("RouteTemplateId")]
    public virtual DmsRouteTemplate? RouteTemplate { get; set; }
}
