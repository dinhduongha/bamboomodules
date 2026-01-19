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

[Table("dms_image_analysis")]
public partial class DmsImageAnalysis : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("planogram_check_id")]
    public Guid? PlanogramCheckId { get; set; }

    [Column("analyzed_image_url")]
    public string AnalyzedImageUrl { get; set; } = null!;

    [Column("detected_products_json")]
    public string? DetectedProductsJson { get; set; }

    [Column("compliance_score")]
    public decimal ComplianceScore { get; set; }

    [Column("issues_json")]
    public string? IssuesJson { get; set; }

    [Column("ai_provider")]
    public string AIProvider { get; set; } = "google_vision";

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("OutletVisitId")]
    public virtual DmsOutletVisit? OutletVisit { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PlanogramCheckId")]
    public virtual DmsPlanogramCheck? PlanogramCheck { get; set; }
}