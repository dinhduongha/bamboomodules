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

[Table("dms_ai_insight")]
public partial class DmsAIInsight : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("outlet_visit_id")]
    public Guid? OutletVisitId { get; set; }

    [Column("achievement_log_id")]
    public Guid? AchievementLogId { get; set; }

    [Column("demand_forecast_id")]
    public Guid? DemandForecastId { get; set; }

    [Column("insight_type")]
    public string InsightType { get; set; } = null!;

    [Column("insight_text")]
    public string InsightText { get; set; } = null!;

    [Column("confidence_score")]
    public decimal ConfidenceScore { get; set; }

    [Column("generated_at")]
    public DateTimeOffset? GeneratedAt { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }
}