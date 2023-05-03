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
public partial class HrLeaveAccrualLevel: Entity<long>, IEntityDto<long>
{
    [Key]
    [Column("id")]
    public long Id { get => base.Id; set => base.Id = value; }

    [Column("sequence", TypeName = "bigserial")]
    public long Sequence { get; set; }

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
    public long? ParentId { get; set; }

    [Column("postpone_max_days")]
    public long? PostponeMaxDays { get; set; }

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

    [Column("is_based_on_worked_time")]
    public bool? IsBasedOnWorkedTime { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("added_value")]
    public double? AddedValue { get; set; }

    [Column("maximum_leave")]
    public double? MaximumLeave { get; set; }

    [ForeignKey("AccrualPlanId")]
    //[InverseProperty("HrLeaveAccrualLevels")]
    [NotMapped]
    public virtual HrLeaveAccrualPlan? AccrualPlan { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrLeaveAccrualLevelCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ParentId")]
    //[InverseProperty("InverseParent")]
    [NotMapped]
    public virtual HrLeaveAccrualLevel? Parent { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrLeaveAccrualLevelWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<HrLeaveAccrualLevel> InverseParent { get; } = new List<HrLeaveAccrualLevel>();

}
