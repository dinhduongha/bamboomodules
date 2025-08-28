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

[Table("hr_leave_accrual_plan")]
public partial class HrLeaveAccrualPlan: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("time_off_type_id")]
    public Guid? TimeOffTypeId { get; set; }

    [Column("carryover_day")]
    public long? CarryoverDay { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("transition_mode")]
    public string? TransitionMode { get; set; }

    [Column("accrued_gain_time")]
    public string? AccruedGainTime { get; set; }

    [Column("carryover_date")]
    public string? CarryoverDate { get; set; }

    [Column("carryover_month")]
    public string? CarryoverMonth { get; set; }

    [Column("added_value_type")]
    public string? AddedValueType { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("is_based_on_worked_time")]
    public bool? IsBasedOnWorkedTime { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("AccrualPlanId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AccrualPlan")] // One2many
    public virtual ICollection<HrLeaveAccrualLevel> HrLeaveAccrualLevel { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("AccrualPlanId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AccrualPlan")] // One2many
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocation { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("AccrualPlanId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AccrualPlan")] // One2many
    public virtual ICollection<HrLeaveAllocationGenerateMultiWizard> HrLeaveAllocationGenerateMultiWizard { get; set; }

    // [Many2one]
    [ForeignKey("TimeOffTypeId")]
    public virtual HrLeaveType? TimeOffType { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
