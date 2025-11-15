using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

[Table("hr_leave_accrual_level")]
public partial class HrLeaveAccrualLevel : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("accrual_plan_id")]
    public Guid? AccrualPlanId { get; set; }

    [Column("start_count")]
    public long? StartCount { get; set; }

    [Column("first_day")]
    public long? FirstDay { get; set; }

    [Column("second_day")]
    public long? SecondDay { get; set; }

    [Column("first_month_day")]
    public long? FirstMonthDay { get; set; }

    [Column("second_month_day")]
    public long? SecondMonthDay { get; set; }

    [Column("yearly_day")]
    public long? YearlyDay { get; set; }

    [Column("postpone_max_days")]
    public long? PostponeMaxDays { get; set; }

    [Column("accrual_validity_count")]
    public long? AccrualValidityCount { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("start_type")]
    public string? StartType { get; set; }

    [Column("added_value_type")]
    public string? AddedValueType { get; set; }

    [Column("frequency")]
    public string? Frequency { get; set; }

    [Column("week_day")]
    public string? WeekDay { get; set; }

    [Column("first_month")]
    public string? FirstMonth { get; set; }

    [Column("second_month")]
    public string? SecondMonth { get; set; }

    [Column("yearly_month")]
    public string? YearlyMonth { get; set; }

    [Column("action_with_unused_accruals")]
    public string? ActionWithUnusedAccruals { get; set; }

    [Column("accrual_validity_type")]
    public string? AccrualValidityType { get; set; }

    [Column("added_value")]
    public decimal? AddedValue { get; set; }

    [Column("maximum_leave")]
    public decimal? MaximumLeave { get; set; }

    [Column("maximum_leave_yearly")]
    public decimal? MaximumLeaveYearly { get; set; }

    [Column("cap_accrued_time")]
    public bool? CapAccruedTime { get; set; }

    [Column("cap_accrued_time_yearly")]
    public bool? CapAccruedTimeYearly { get; set; }

    [Column("accrual_validity")]
    public bool? AccrualValidity { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("frequency_hourly_source")]
    public string? FrequencyHourlySource { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccrualPlanId")]
    public virtual HrLeaveAccrualPlan? AccrualPlan { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
