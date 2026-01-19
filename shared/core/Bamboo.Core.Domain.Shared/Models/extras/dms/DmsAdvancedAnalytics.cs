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

[Table("dms_advanced_analytics")]
public partial class DmsAdvancedAnalytics : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("bi_report_config_id")]
    public Guid? BIReportConfigId { get; set; }

    [Column("sales_kpi_id")]
    public Guid? SalesKPIId { get; set; }

    [Column("metric_type")]
    public string MetricType { get; set; } = "predictive_sales";

    [Column("predicted_value")]
    public decimal PredictedValue { get; set; }

    [Column("insight_text")]
    public string InsightText { get; set; } = null!;

    [Column("model_version")]
    public string ModelVersion { get; set; } = null!;

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("BIReportConfigId")]
    public virtual DmsBIReportConfig? BIReportConfig { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SalesKPIId")]
    public virtual DmsSalesKPI? SalesKPI { get; set; }
}