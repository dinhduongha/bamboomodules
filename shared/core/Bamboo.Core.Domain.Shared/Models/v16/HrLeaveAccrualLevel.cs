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
public partial class HrLeaveAccrualLevel: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

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

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("postpone_max_days")]
    public long? PostponeMaxDays { get; set; }

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

    [Column("added_value")]
    public decimal? AddedValue { get; set; }

    [Column("is_based_on_worked_time")]
    public bool? IsBasedOnWorkedTime { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("maximum_leave")]
    public double? MaximumLeave { get; set; }

    // [Many2one]
    [ForeignKey("AccrualPlanId")]
    // [InverseProperty("HrLeaveAccrualLevel")] //Many2one
    public virtual HrLeaveAccrualPlan? AccrualPlan { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("HrLeaveAccrualLevelCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("ParentId")]
    [InverseProperty("Parent")]
    public virtual ICollection<HrLeaveAccrualLevel> InverseParent { get; set; }

    // [Many2one]
    [ForeignKey("ParentId")]
    // [InverseProperty("InverseParent")] //Many2one
    public virtual HrLeaveAccrualLevel? Parent { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("HrLeaveAccrualLevelWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
