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

public partial class CalendarEvent
{
    [Column("notes")]
    public string? Notes { get; set; }

    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("CalendarEventId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("CalendarEvent")] // One2many
    // public virtual ICollection<CalendarPopoverDeleteWizard> CalendarPopoverDeleteWizard { get; set; }

}