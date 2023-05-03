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
public partial class HrLeaveAccrualPlan: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("time_off_type_id")]
    public Guid? TimeOffTypeId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("transition_mode")]
    public string? TransitionMode { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrLeaveAccrualPlanCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("TimeOffTypeId")]
    //[InverseProperty("HrLeaveAccrualPlans")]
    [NotMapped]
    public virtual HrLeaveType? TimeOffType { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrLeaveAccrualPlanWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("AccrualPlan")]
    [NotMapped]
    public virtual ICollection<HrLeaveAccrualLevel> HrLeaveAccrualLevels { get; } = new List<HrLeaveAccrualLevel>();

    //[InverseProperty("AccrualPlan")]
    [NotMapped]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocations { get; } = new List<HrLeaveAllocation>();

}
