using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("hr_leave_accrual_level")]
public partial class HrLeaveAccrualLevel
{
    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("is_based_on_worked_time")]
    public bool? IsBasedOnWorkedTime { get; set; }

    // [Column("maximum_leave")]
    // public double? MaximumLeave { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ParentId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Parent")] // One2many
    public virtual ICollection<HrLeaveAccrualLevel> InverseParent { get; set; }

    // [Many2one]
    [ForeignKey("ParentId")]
    public virtual HrLeaveAccrualLevel? Parent { get; set; }
}
