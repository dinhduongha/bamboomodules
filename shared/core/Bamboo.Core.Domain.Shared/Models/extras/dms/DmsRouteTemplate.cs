using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Table("dms_route_template")]
public partial class DmsRouteTemplate : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("template_code")]
    public string TemplateCode { get; set; } = null!;

    [Column("template_name")]
    public string TemplateName { get; set; } = null!;

    [Column("frequency")]
    public string Frequency { get; set; } = "weekly"; // weekly, biweekly, monthly

    [Column("day_of_week")]
    public int? DayOfWeek { get; set; } // 1-7 (Thứ 2 đến CN)

    [Column("week_of_month")]
    public int? WeekOfMonth { get; set; } // 1-4

    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    [Column("description")]
    public string? Description { get; set; }

    // Navigation
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public virtual ICollection<DmsRouteTemplateLine> TemplateLines { get; set; } = new List<DmsRouteTemplateLine>();
}