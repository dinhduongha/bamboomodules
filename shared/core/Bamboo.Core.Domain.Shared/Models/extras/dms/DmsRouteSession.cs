using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Table("dms_route_session")]
public partial class DmsRouteSession : FullAuditedAggregateRoot<Guid>, IMultiTenant
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

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("route_id")]
    public Guid? RouteId { get; set; }

    [Column("session_date")]
    public DateTimeOffset? SessionDate { get; set; }

    [Column("start_time")]
    public DateTimeOffset? StartTime { get; set; }

    [Column("end_time")]
    public DateTimeOffset? EndTime { get; set; }

    [Column("actual_distance_km")]
    public decimal? ActualDistanceKm { get; set; }

    [Column("missed_visits_count")]
    public long MissedVisitsCount { get; set; }

    [Column("status")]
    public string? Status { get; set; } = "planned";

    [Column("notes")]
    public string? Notes { get; set; }

    // Thêm trường mới để hỗ trợ nhiều session/ngày
    [Column("session_number")]
    public int SessionNumber { get; set; } // 1 = sáng, 2 = chiều, 3 = tối (tùy ý)

    [Column("is_overnight")]
    public bool IsOvernight { get; set; } = false; // true nếu session kéo dài qua đêm (đi xa)

    // Navigation
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("RouteId")]
    public virtual DmsRoute Route { get; set; } = null!;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UserId")]
    public virtual ResUsers User { get; set; } = null!;

}