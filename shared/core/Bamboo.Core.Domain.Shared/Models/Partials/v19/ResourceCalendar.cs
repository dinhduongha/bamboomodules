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

public partial class ResourceCalendar
{
    [Column("schedule_type")]
    public string? ScheduleType { get; set; }

    [Column("duration_based")]
    public bool? DurationBased { get; set; }

    [Column("hours_per_week")]
    public double? HoursPerWeek { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ResourceCalendarId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ResourceCalendar")] // One2many
    public virtual ICollection<HrAttendanceOvertimeRule> HrAttendanceOvertimeRule { get; set; }

    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("ResourceCalendarId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("ResourceCalendar")] // One2many
    // public virtual ICollection<HrLeave> HrLeave { get; set; }

    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("ResourceCalendarId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("ResourceCalendar")] // One2many
    // public virtual ICollection<HrLeaveMandatoryDay> HrLeaveMandatoryDay { get; set; }

    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("DefaultResourceCalendarId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("DefaultResourceCalendar")] // One2many
    // public virtual ICollection<HrPayrollStructureType> HrPayrollStructureType { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ResourceCalendarId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ResourceCalendar")] // One2many
    public virtual ICollection<HrVersion> HrVersion { get; set; }

    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("ResourceCalendarId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("ResourceCalendar")] // One2many
    // public virtual ICollection<MrpWorkcenter> MrpWorkcenter { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ResourceCalendarId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ResourceCalendar")] // One2many
    public virtual ICollection<PosPreset> PosPreset { get; set; }


}