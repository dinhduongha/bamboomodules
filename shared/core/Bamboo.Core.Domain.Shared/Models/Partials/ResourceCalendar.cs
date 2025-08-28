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

//[Table("resource_calendar")]
public partial class ResourceCalendar
{
    //[Column("hours_per_day")]
    //public double? HoursPerDay { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ResourceCalendarId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("ResourceCalendar")] // One2many
    public virtual ICollection<HrLeaveStressDay> HrLeaveStressDay { get; set; }
}
