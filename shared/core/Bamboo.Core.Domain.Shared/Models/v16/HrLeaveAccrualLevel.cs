using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Table("hr_leave_accrual_level")]
public partial class HrLeaveAccrualLevel : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("sequence", TypeName = "bigserial")]
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

    // v16-Compat
    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("postpone_max_days")]
    public long? PostponeMaxDays { get; set; }

    [Column("accrual_validity_count")]
    public long? AccrualValidityCount { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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

    // v16-Compat
    [Column("is_based_on_worked_time")]
    public bool? IsBasedOnWorkedTime { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("frequency_hourly_source")]
    public string? FrequencyHourlySource { get; set; }

    // v16-Compat
    // [Column("added_value")]
    // public double? AddedValue { get; set; }

    // v16-Compat
    // [Column("maximum_leave")]
    // public double? MaximumLeave { get; set; }

    // v16-Compat
    [ForeignKey("TenantId")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("AccrualPlanId")]
    //[InverseProperty("HrLeaveAccrualLevels")]
    [NotMapped]
    public virtual HrLeaveAccrualPlan? AccrualPlan { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrLeaveAccrualLevelCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    // v16-Compat
    [ForeignKey("ParentId")]
    //[InverseProperty("InverseParent")]
    [NotMapped]
    public virtual HrLeaveAccrualLevel? Parent { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrLeaveAccrualLevelWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    // v16-Compat
    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<HrLeaveAccrualLevel> InverseParent { get; set; } = new List<HrLeaveAccrualLevel>();

}
